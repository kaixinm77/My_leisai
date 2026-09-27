using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

namespace 雷赛基础运动
{
    /// <summary>
    /// 插补运动窗口：XY 两轴插补绘制图形
    /// 优先使用连续插补(dmc_conti_*)，失败时自动降级为单段插补(dmc_line_unit)
    /// </summary>
    public partial class Form2 : Form
    {
        private readonly ushort CardNo;      // 板卡号（由 Form1 传入）
        private readonly double Equiv;       // 脉冲当量（由 Form1 传入，X/Y 两轴统一）
        private const ushort Crd = 0;        // 插补坐标系号
        private ushort xAxis = 0;            // X 轴号
        private ushort yAxis = 1;            // Y 轴号
        private short rtn;

        private List<PointF> shapePoints;   // 当前形状轮廓（相对起点坐标）
        private readonly List<PointF> drawnPoints = new List<PointF>(); // 已走过的轨迹
        private double startX, startY;      // 开始绘制时的机械位置
        private bool isRunning = false;
        private bool isSingleMode = false;  // true=单段插补降级模式
        private volatile bool stopDraw = false; // 单段模式停止标志
        private Thread drawThread;
        private int drawMode = 0; // 0=未探测 1=dmc_line_unit 2=dmc_line_multicoor 3=比例速度软件插补

        public Form2(ushort cardNo, double equiv = 1)
        {
            InitializeComponent();
            CardNo = cardNo;
            Equiv = equiv;

            // 轴号下拉框：0 ~ 7 轴
            for (int i = 0; i <= 7; i++)
            {
                cmbXAxis.Items.Add($"{i}轴");
                cmbYAxis.Items.Add($"{i}轴");
            }
            cmbXAxis.SelectedIndex = 0;
            cmbYAxis.SelectedIndex = 1;

            lstShapes.SelectedIndex = 0; // 默认选中第一个形状并预览

            // 读取固件版本，便于确认卡型与插补功能支持情况
            try
            {
                byte[] ver = new byte[64];
                if (LTDMC.dmc_get_release_version(CardNo, ver) == 0)
                {
                    string s = System.Text.Encoding.Default.GetString(ver).TrimEnd('\0').Trim();
                    if (!string.IsNullOrEmpty(s)) lblHint.Text = $"固件版本：{s}";
                }
            }
            catch { }
        }

        // ==================== 形状生成 ====================

        // 正多边形 / 圆形通用生成：n 边数，r 半径，startDeg 起始角（度）
        private List<PointF> Polygon(int n, double r, double startDeg)
        {
            var pts = new List<PointF>();
            for (int i = 0; i <= n; i++) // 多取一个点闭合
            {
                double a = startDeg * Math.PI / 180 + 2 * Math.PI * i / n;
                pts.Add(new PointF((float)(r * Math.Cos(a)), (float)(r * Math.Sin(a))));
            }
            return pts;
        }

        // 根据名称生成形状点集（以 0,0 为中心，大小为 size）
        private List<PointF> GetShapePoints(string name, double size)
        {
            double r = size / 2;
            var pts = new List<PointF>();

            switch (name)
            {
                case "心形":
                    // 经典心形参数方程
                    for (int i = 0; i <= 120; i++)
                    {
                        double t = 2 * Math.PI * i / 120;
                        double x = 16 * Math.Pow(Math.Sin(t), 3);
                        double y = 13 * Math.Cos(t) - 5 * Math.Cos(2 * t)
                                 - 2 * Math.Cos(3 * t) - Math.Cos(4 * t);
                        pts.Add(new PointF((float)(x * size / 34), (float)(y * size / 34)));
                    }
                    break;

                case "圆形":
                    pts = Polygon(72, r, 90); // 72 段拟合圆
                    break;

                case "正方形":
                    pts = Polygon(4, r, 45);
                    break;

                case "三角形":
                    pts = Polygon(3, r, 90);
                    break;

                case "五角星":
                    {
                        double ri = r * 0.382; // 内接半径
                        for (int i = 0; i < 5; i++)
                        {
                            double aOut = Math.PI / 2 + i * 2 * Math.PI / 5;
                            double aIn = aOut + Math.PI / 5;
                            pts.Add(new PointF((float)(r * Math.Cos(aOut)), (float)(r * Math.Sin(aOut))));
                            pts.Add(new PointF((float)(ri * Math.Cos(aIn)), (float)(ri * Math.Sin(aIn))));
                        }
                        pts.Add(pts[0]); // 闭合
                    }
                    break;

                case "六边形":
                    pts = Polygon(6, r, 0);
                    break;

                case "八边形":
                    pts = Polygon(8, r, 22.5);
                    break;

                case "菱形":
                    pts = Polygon(4, r, 0); // 顶点朝上下左右的四边形
                    break;

                case "无限符号":
                    // 伯努利双纽线（Gerono 形式）
                    for (int i = 0; i <= 120; i++)
                    {
                        double t = 2 * Math.PI * i / 120;
                        double x = r * Math.Sin(t);
                        double y = r * Math.Sin(t) * Math.Cos(t) / 2;
                        pts.Add(new PointF((float)x, (float)y));
                    }
                    break;

                case "螺旋线":
                    // 阿基米德螺线，3 圈
                    for (int i = 0; i <= 200; i++)
                    {
                        double t = 6 * Math.PI * i / 200;
                        double rr = r * i / 200;
                        pts.Add(new PointF((float)(rr * Math.Cos(t)), (float)(rr * Math.Sin(t))));
                    }
                    break;
            }
            return pts;
        }

        // 把形状平移到以第一个点为原点（机器从当前位置起笔）
        private void NormalizeToStart(List<PointF> pts)
        {
            PointF origin = pts[0];
            for (int i = 0; i < pts.Count; i++)
            {
                pts[i] = new PointF(pts[i].X - origin.X, pts[i].Y - origin.Y);
            }
        }

        // ==================== 预览绘制 ====================

        private void lstShapes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstShapes.SelectedItem == null) return;

            double size = ParseDouble(txtSize.Text, "图形大小", 50);
            shapePoints = GetShapePoints(lstShapes.SelectedItem.ToString(), size);
            NormalizeToStart(shapePoints);
            drawnPoints.Clear();
            RedrawPreview();
            lblShapeInfo.Text = $"{lstShapes.SelectedItem}：共 {shapePoints.Count - 1} 段直线插补";
        }

        // 把形状坐标映射到预览框像素（Y 轴翻转）
        private PointF ToPixel(PointF p, float minX, float minY, float scale)
        {
            const int margin = 10;
            float x = margin + (p.X - minX) * scale;
            float y = picPreview.Height - margin - (p.Y - minY) * scale;
            return new PointF(x, y);
        }

        private void RedrawPreview()
        {
            if (picPreview.Width <= 0 || picPreview.Height <= 0) return;

            Bitmap bmp = new Bitmap(picPreview.Width, picPreview.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                g.SmoothingMode = SmoothingMode.AntiAlias;

                if (shapePoints == null || shapePoints.Count < 2)
                {
                    picPreview.Image?.Dispose();
                    picPreview.Image = bmp;
                    return;
                }

                // 计算包围盒（轮廓 + 已走轨迹一起算，保证轨迹不超出画布）
                float minX = float.MaxValue, minY = float.MaxValue, maxX = float.MinValue, maxY = float.MinValue;
                foreach (PointF p in shapePoints)
                {
                    minX = Math.Min(minX, p.X); maxX = Math.Max(maxX, p.X);
                    minY = Math.Min(minY, p.Y); maxY = Math.Max(maxY, p.Y);
                }
                foreach (PointF p in drawnPoints)
                {
                    minX = Math.Min(minX, p.X); maxX = Math.Max(maxX, p.X);
                    minY = Math.Min(minY, p.Y); maxY = Math.Max(maxY, p.Y);
                }
                float rangeX = Math.Max(maxX - minX, 0.001f);
                float rangeY = Math.Max(maxY - minY, 0.001f);
                float scale = Math.Min((picPreview.Width - 30) / rangeX, (picPreview.Height - 30) / rangeY);

                // 灰色轮廓
                var outline = new PointF[shapePoints.Count];
                for (int i = 0; i < shapePoints.Count; i++)
                    outline[i] = ToPixel(shapePoints[i], minX, minY, scale);

                using (Pen gray = new Pen(Color.LightGray, 1f))
                using (Pen red = new Pen(Color.Red, 1.5f))
                using (Pen blue = new Pen(Color.DodgerBlue, 2f))
                {
                    g.DrawLines(gray, outline);

                    // 红色已走轨迹
                    if (drawnPoints.Count > 1)
                    {
                        var path = new PointF[drawnPoints.Count];
                        for (int i = 0; i < drawnPoints.Count; i++)
                            path[i] = ToPixel(drawnPoints[i], minX, minY, scale);
                        g.DrawLines(red, path);
                    }

                    // 蓝色起点标记
                    PointF sp = ToPixel(shapePoints[0], minX, minY, scale);
                    g.DrawEllipse(blue, sp.X - 3, sp.Y - 3, 6, 6);
                }
            }

            Image old = picPreview.Image;
            picPreview.Image = bmp;
            old?.Dispose();
        }

        // ==================== 诊断与使能 ====================

        // 读取雷赛错误码的中文说明
        private string GetErrDesc(short code)
        {
            try
            {
                byte[] buf = new byte[256];
                if (LTDMC.dmc_get_error_description(code, buf) == 0)
                {
                    string s = System.Text.Encoding.Default.GetString(buf).TrimEnd('\0').Trim();
                    if (!string.IsNullOrEmpty(s)) return s;
                }
            }
            catch
            {
                // 部分卡型没有该函数，忽略
            }
            return "（该错误码无中文说明）";
        }

        // 统一报错：给出步骤、错误码和中文说明
        private void Fail(string step, short code)
        {
            string desc = GetErrDesc(code);
            lblRun.Text = $"状态：{step}失败({code})";
            lblRun.ForeColor = Color.Red;
            lblHint.Text = $"{step} 失败，错误码 {code}：{desc}";
            MessageBox.Show($"{step} 失败\r\n错误码：{code}\r\n说明：{desc}",
                "插补失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // 开启 X/Y 轴伺服使能
        private void EnableAxes()
        {
            short rx = LTDMC.nmc_set_axis_enable(CardNo, xAxis);
            short ry = LTDMC.nmc_set_axis_enable(CardNo, yAxis);
            if (rx != 0 || ry != 0)
            {
                MessageBox.Show($"使能失败\r\nX轴：{rx} {GetErrDesc(rx)}\r\nY轴：{ry} {GetErrDesc(ry)}");
            }
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            xAxis = (ushort)cmbXAxis.SelectedIndex;
            yAxis = (ushort)cmbYAxis.SelectedIndex;
            EnableAxes();
            lblHint.Text = "已发送使能指令，请观察轴状态机是否变为 4（操作使能）";
        }

        // 启动前确认两个轴都处于"操作使能"(4)
        private bool EnsureEnabled()
        {
            ushort sx = 0, sy = 0;
            LTDMC.nmc_get_axis_state_machine(CardNo, xAxis, ref sx);
            LTDMC.nmc_get_axis_state_machine(CardNo, yAxis, ref sy);
            if (sx == 4 && sy == 4) return true;

            // 读取总线状态，帮助定位"固件不支持功能"（错误码24）这类问题的根因
            ushort busErr = 0;
            LTDMC.nmc_get_errcode(CardNo, 2, ref busErr);
            string busText = busErr == 0 ? "EtherCAT 总线正常"
                           : $"EtherCAT 总线异常(0x{busErr:X4})，可能未用 Motion 扫描下载总线配置文件";

            DialogResult dr = MessageBox.Show(
                $"X 轴状态机={sx}，Y 轴状态机={sy}（4=操作使能）。\r\n{busText}\r\n\r\n未使能的轴无法执行插补，是否立即开启使能？",
                "轴未使能", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes) EnableAxes();

            Thread.Sleep(300);
            LTDMC.nmc_get_axis_state_machine(CardNo, xAxis, ref sx);
            LTDMC.nmc_get_axis_state_machine(CardNo, yAxis, ref sy);
            if (sx == 4 && sy == 4) return true;

            lblHint.Text = $"轴未就绪：X={sx} Y={sy}，需要都等于 4（操作使能）";
            lblRun.Text = "状态：轴未使能";
            lblRun.ForeColor = Color.Red;
            MessageBox.Show($"轴未进入使能状态：X轴={sx}，Y轴={sy}（需要=4）\r\n请先开启使能并确认驱动器无报警。");
            return false;
        }

        // ==================== 插补运动 ====================

        // 开始绘制
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                MessageBox.Show("正在绘制中，请先停止");
                return;
            }
            if (lstShapes.SelectedItem == null)
            {
                MessageBox.Show("请先选择一个形状");
                return;
            }

            xAxis = (ushort)cmbXAxis.SelectedIndex;
            yAxis = (ushort)cmbYAxis.SelectedIndex;
            if (xAxis == yAxis)
            {
                MessageBox.Show("X 轴和 Y 轴不能相同");
                return;
            }

            double size = ParseDouble(txtSize.Text, "图形大小", 50);
            double minV = ParseDouble(txtMinV.Text, "起始速度", 0);
            double maxV = ParseDouble(txtMaxV.Text, "最大速度", 30);
            double tacc = ParseDouble(txtTacc.Text, "加速时间", 0.1);
            double tdec = ParseDouble(txtTdec.Text, "减速时间", 0.1);
            if (maxV <= 0) { MessageBox.Show("最大速度必须大于 0"); return; }
            if (size <= 0) { MessageBox.Show("图形大小必须大于 0"); return; }

            // 生成形状（相对起点的坐标）
            List<PointF> pts = GetShapePoints(lstShapes.SelectedItem.ToString(), size);
            NormalizeToStart(pts);
            shapePoints = pts;
            drawnPoints.Clear();

            // 轴必须使能
            if (!EnsureEnabled()) return;

            // X/Y 两轴必须使用相同的脉冲当量，否则插补轨迹尺寸会失真
            LTDMC.dmc_set_equiv(CardNo, xAxis, Equiv);
            LTDMC.dmc_set_equiv(CardNo, yAxis, Equiv);

            // 记录起笔位置
            double x0 = 0, y0 = 0;
            LTDMC.dmc_get_position_unit(CardNo, xAxis, ref x0);
            LTDMC.dmc_get_position_unit(CardNo, yAxis, ref y0);
            startX = x0;
            startY = y0;

            // 优先连续插补，失败则询问是否降级为单段插补
            if (!TryStartConti(pts, minV, maxV, tacc, tdec))
            {
                DialogResult dr = MessageBox.Show(
                    "连续插补（轨迹前瞻）失败：错误码 6001 = 该卡固件不支持轨迹前瞻功能。\r\n\r\n是否改用【单段插补模式】？程序会自动探测可用的插补方式：\r\n① dmc_line_unit 单位插补 → ② dmc_line_multicoor 脉冲插补 → ③ 比例速度软件插补（保底，一定能动，每段有停顿）",
                    "兼容模式", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr != DialogResult.Yes) return;

                StartSingleMode(pts, minV, maxV, tacc, tdec);
            }

            isRunning = true;
            drawnPoints.Add(new PointF(0, 0));
            lblRun.Text = "状态：绘制中...";
            lblRun.ForeColor = Color.Red;
            timer2.Start();
        }

        // 连续插补模式：写入缓存后一次性启动；成功返回 true
        private bool TryStartConti(List<PointF> pts, double minV, double maxV, double tacc, double tdec)
        {
            ushort[] axisList = { xAxis, yAxis };
            double[] target = new double[2];

            // 停止上次插补并复位缓存
            LTDMC.dmc_conti_stop_list(CardNo, Crd, 0);
            LTDMC.dmc_conti_reset_list(CardNo, Crd);

            rtn = LTDMC.dmc_conti_open_list(CardNo, Crd, 2, axisList);
            if (rtn != 0) { Fail("打开插补缓存 dmc_conti_open_list", rtn); return false; }

            // 合成（矢量）速度
            rtn = LTDMC.dmc_set_vector_profile_unit(CardNo, Crd, minV, maxV, tacc, tdec, minV);
            if (rtn != 0)
            {
                Fail("设置插补速度 dmc_set_vector_profile_unit", rtn);
                LTDMC.dmc_conti_close_list(CardNo, Crd);
                return false;
            }

            // 段间平滑过渡，避免每段减速停顿
            LTDMC.dmc_conti_set_blend(CardNo, Crd, 1);

            // 绝对坐标模式(posi_mode=1)逐段写入
            int mark = 0;
            for (int i = 1; i < pts.Count; i++)
            {
                target[0] = startX + pts[i].X;
                target[1] = startY + pts[i].Y;
                rtn = LTDMC.dmc_conti_line_unit(CardNo, Crd, 2, axisList, target, 1, mark++);
                if (rtn != 0)
                {
                    LTDMC.dmc_conti_close_list(CardNo, Crd);
                    Fail($"写入第 {i} 段插补 dmc_conti_line_unit", rtn);
                    return false;
                }
            }

            rtn = LTDMC.dmc_conti_close_list(CardNo, Crd);
            if (rtn != 0) { Fail("关闭插补缓存 dmc_conti_close_list", rtn); return false; }

            rtn = LTDMC.dmc_conti_start_list(CardNo, Crd);
            if (rtn != 0) { Fail("启动插补 dmc_conti_start_list", rtn); return false; }

            isSingleMode = false;
            lblHint.Text = $"连续插补模式：共 {pts.Count - 1} 段";
            return true;
        }

        // 降级方案：单段插补，在后台线程逐段下发并等待完成
        // 自动探测可用模式（零位移指令探测，不会真的运动）：
        //   1 = dmc_line_unit（unit 插补）
        //   2 = dmc_line_multicoor（脉冲插补）
        //   3 = 比例速度软件插补（两轴 pmove 速度按 dx:dy 分配、同时启动，保底方案）
        private void StartSingleMode(List<PointF> pts, double minV, double maxV, double tacc, double tdec)
        {
            isSingleMode = true;
            stopDraw = false;

            ushort[] axisList = { xAxis, yAxis };

            drawThread = new Thread(() =>
            {
                // —— 首次运行时探测硬件支持哪种插补指令 ——
                if (drawMode == 0)
                {
                    // 探测 mode 1：unit 版（零位移段，指令合法但不动）
                    bool ok1 = LTDMC.dmc_set_vector_profile_unit(CardNo, Crd, minV, maxV, tacc, tdec, minV) == 0
                            && LTDMC.dmc_line_unit(CardNo, Crd, 2, axisList, new double[] { startX, startY }, 1) == 0;
                    if (ok1)
                    {
                        drawMode = 1;
                    }
                    else
                    {
                        // 探测 mode 2：multicoor 脉冲版
                        bool ok2 = LTDMC.dmc_set_vector_profile_multicoor(CardNo, Crd, minV * Equiv, maxV * Equiv, tacc, tdec, minV * Equiv) == 0
                                && LTDMC.dmc_line_multicoor(CardNo, Crd, 2, axisList,
                                       new int[] { (int)Math.Round(startX * Equiv), (int)Math.Round(startY * Equiv) }, 1) == 0;
                        drawMode = ok2 ? 2 : 3;
                    }

                    string name = drawMode == 1 ? "dmc_line_unit 单位插补"
                                : drawMode == 2 ? "dmc_line_multicoor 脉冲插补"
                                : "比例速度软件插补（单轴 pmove）";
                    BeginInvoke(new Action(() => { lblHint.Text = $"插补方式：{name}，共 {pts.Count - 1} 段"; }));
                }

                if (drawMode == 3)
                {
                    RunProportional(pts, minV, maxV, tacc, tdec);
                }
                else
                {
                    RunSegmented(pts, axisList);
                }

                // 回到 UI 线程收尾
                BeginInvoke(new Action(() =>
                {
                    isRunning = false;
                    timer2.Stop();
                    lblRun.Text = stopDraw ? "状态：已停止" : "状态：绘制完成";
                    lblRun.ForeColor = stopDraw ? Color.OrangeRed : Color.Green;
                    RedrawPreview();
                }));
            });

            drawThread.IsBackground = true;
            drawThread.Start();
        }

        // mode 1/2：硬件单段插补，逐段下发并等待完成
        private void RunSegmented(List<PointF> pts, ushort[] axisList)
        {
            for (int i = 1; i < pts.Count; i++)
            {
                if (stopDraw) break;

                double tx = startX + pts[i].X;
                double ty = startY + pts[i].Y;

                if (drawMode == 1)
                {
                    rtn = LTDMC.dmc_line_unit(CardNo, Crd, 2, axisList, new double[] { tx, ty }, 1);
                    if (rtn != 0)
                    {
                        short code = rtn;
                        BeginInvoke(new Action(() => Fail("单段插补 dmc_line_unit", code)));
                        return;
                    }
                    WaitSegmentDone();
                }
                else
                {
                    int[] targetP = { (int)Math.Round(tx * Equiv), (int)Math.Round(ty * Equiv) };
                    rtn = LTDMC.dmc_line_multicoor(CardNo, Crd, 2, axisList, targetP, 1);
                    if (rtn != 0)
                    {
                        short code = rtn;
                        BeginInvoke(new Action(() => Fail("单段插补 dmc_line_multicoor", code)));
                        return;
                    }
                    WaitSegmentDone();
                }
            }

            // 等待坐标系运动完成的局部函数
            void WaitSegmentDone()
            {
                while (LTDMC.dmc_check_done_multicoor(CardNo, Crd) == 0)
                {
                    if (stopDraw)
                    {
                        LTDMC.dmc_stop_multicoor(CardNo, Crd, 0);
                        break;
                    }
                    Thread.Sleep(10);
                }
            }
        }

        // mode 3：比例速度软件插补（保底）
        // 每段把 X/Y 两轴速度按 dx:dy 比例分配、几乎同时启动 pmove，
        // 两轴加减速时间相同 → 轨迹为直线段；段与段之间有停顿。
        // 注意：菱形/五角星这类"每个顶点都要换向"的形状，最容易踩两个坑：
        //   ① 轴刚停稳就发新 pmove 会报 1002（CHECK_DOWN 未完成）→ 该轴不动，另一轴照走，轨迹直接歪掉
        //   ② 起始/停止速度设 0 在总线轴上可能被拒绝 → profile 设置失败也不报，两轴速度比失效
        // 所以这里：所有指令都检查返回值，pmove 对 1002/4 自动重试，min/stop 速度为 0 时
        // 改用该轴最大速度的 5%（保持两轴比例一致，直线不弯）。
        private void RunProportional(List<PointF> pts, double minV, double maxV, double tacc, double tdec)
        {
            double lastX = startX, lastY = startY;

            for (int i = 1; i < pts.Count; i++)
            {
                if (stopDraw) break;

                double tx = startX + pts[i].X;
                double ty = startY + pts[i].Y;
                double dx = tx - lastX;
                double dy = ty - lastY;

                if (Math.Abs(dx) > 1e-9 && Math.Abs(dy) > 1e-9)
                {
                    double len = Math.Sqrt(dx * dx + dy * dy);
                    double kx = Math.Abs(dx) / len;   // X 轴速度占比
                    double ky = Math.Abs(dy) / len;   // Y 轴速度占比

                    double maxX = maxV * kx;
                    double maxY = maxV * ky;
                    double minX = FloorSpeed(minV * kx, maxX);
                    double minY = FloorSpeed(minV * ky, maxY);

                    // ① 设置速度曲线，失败必须立刻报（否则两轴速度比失效，轨迹弯曲）
                    short rpx = LTDMC.dmc_set_profile_unit(CardNo, xAxis, minX, maxX, tacc, tdec, minX);
                    short rpy = LTDMC.dmc_set_profile_unit(CardNo, yAxis, minY, maxY, tacc, tdec, minY);
                    if (rpx != 0 || rpy != 0)
                    {
                        BeginInvoke(new Action(() => Fail("设置速度曲线 dmc_set_profile_unit（比例速度模式）", (short)(rpx != 0 ? rpx : rpy))));
                        return;
                    }

                    // ② 下发运动，1002（轴未停稳）自动重试
                    short rm = PmoveWithRetry(xAxis, dx);
                    if (rm != 0)
                    {
                        BeginInvoke(new Action(() => Fail($"第 {i} 段 X 轴 pmove", rm)));
                        return;
                    }
                    rm = PmoveWithRetry(yAxis, dy);
                    if (rm != 0)
                    {
                        BeginInvoke(new Action(() => Fail($"第 {i} 段 Y 轴 pmove", rm)));
                        return;
                    }

                    WaitBothDone();
                    Thread.Sleep(15); // 稳定后再发下一段，降低下一段报 1002 的概率
                }
                else if (Math.Abs(dx) > 1e-9) // 纯水平段
                {
                    short r = LTDMC.dmc_set_profile_unit(CardNo, xAxis, FloorSpeed(minV, maxV), maxV, tacc, tdec, FloorSpeed(minV, maxV));
                    if (r != 0) { BeginInvoke(new Action(() => Fail("设置速度曲线 dmc_set_profile_unit（水平段）", r))); return; }

                    r = PmoveWithRetry(xAxis, dx);
                    if (r != 0) { BeginInvoke(new Action(() => Fail($"第 {i} 段 X 轴 pmove", r))); return; }
                    WaitAxisDone(xAxis);
                    Thread.Sleep(15);
                }
                else if (Math.Abs(dy) > 1e-9) // 纯垂直段
                {
                    short r = LTDMC.dmc_set_profile_unit(CardNo, yAxis, FloorSpeed(minV, maxV), maxV, tacc, tdec, FloorSpeed(minV, maxV));
                    if (r != 0) { BeginInvoke(new Action(() => Fail("设置速度曲线 dmc_set_profile_unit（垂直段）", r))); return; }

                    r = PmoveWithRetry(yAxis, dy);
                    if (r != 0) { BeginInvoke(new Action(() => Fail($"第 {i} 段 Y 轴 pmove", r))); return; }
                    WaitAxisDone(yAxis);
                    Thread.Sleep(15);
                }

                lastX = tx;
                lastY = ty;
            }

            // 起始/停止速度不能为 0（总线轴会拒绝或行为异常），为 0 时取该轴最大速度的 5%
            double FloorSpeed(double v, double maxOfAxis)
            {
                if (v <= 0) return Math.Max(maxOfAxis * 0.05, 0.01);
                return Math.Min(v, maxOfAxis);
            }

            // 带重试的 pmove：轴刚停止时控制器可能报 1002（轴 CHECK_DOWN 未完成）/4（运动中），
            // 此时指令被拒绝、轴不会动 —— 必须等一下重发，否则另一轴照走、轨迹直接歪掉
            short PmoveWithRetry(ushort axis, double dist)
            {
                short r = LTDMC.dmc_pmove_unit(CardNo, axis, dist, 0); // 相对运动
                int attempts = 0;
                while ((r == 1002 || r == 4 || r == 1001) && attempts < 30 && !stopDraw)
                {
                    Thread.Sleep(10);
                    r = LTDMC.dmc_pmove_unit(CardNo, axis, dist, 0);
                    attempts++;
                }
                return r;
            }

            // 等待两轴都停止
            void WaitBothDone()
            {
                while (LTDMC.dmc_check_done(CardNo, xAxis) == 0 || LTDMC.dmc_check_done(CardNo, yAxis) == 0)
                {
                    if (stopDraw)
                    {
                        LTDMC.dmc_stop(CardNo, xAxis, 0);
                        LTDMC.dmc_stop(CardNo, yAxis, 0);
                        break;
                    }
                    Thread.Sleep(5);
                }
            }

            // 等待单轴停止
            void WaitAxisDone(ushort axis)
            {
                while (LTDMC.dmc_check_done(CardNo, axis) == 0)
                {
                    if (stopDraw)
                    {
                        LTDMC.dmc_stop(CardNo, axis, 0);
                        break;
                    }
                    Thread.Sleep(5);
                }
            }
        }

        // 停止插补
        private void btnStop_Click(object sender, EventArgs e)
        {
            stopDraw = true;
            LTDMC.dmc_conti_stop_list(CardNo, Crd, 0);
            LTDMC.dmc_stop_multicoor(CardNo, Crd, 0);
            isRunning = false;
            timer2.Stop();
            lblRun.Text = "状态：已停止";
            lblRun.ForeColor = Color.OrangeRed;
        }

        // X/Y 坐标清零（以当前位置为原点，总线卡要用 unit 版）
        private void btnZero_Click(object sender, EventArgs e)
        {
            xAxis = (ushort)cmbXAxis.SelectedIndex;
            yAxis = (ushort)cmbYAxis.SelectedIndex;
            LTDMC.dmc_set_position_unit(CardNo, xAxis, 0);
            LTDMC.dmc_set_position_unit(CardNo, yAxis, 0);
            MessageBox.Show("X/Y 轴坐标已清零");
        }

        // 状态轮询：读取当前位置，绘制轨迹，检测完成
        private void timer2_Tick(object sender, EventArgs e)
        {
            double x = 0, y = 0;
            LTDMC.dmc_get_position_unit(CardNo, xAxis, ref x);
            LTDMC.dmc_get_position_unit(CardNo, yAxis, ref y);
            lblPos.Text = $"当前位置：X: {x.ToString("0.###")}  Y: {y.ToString("0.###")}";

            if (!isRunning) return;

            PointF cur = new PointF((float)(x - startX), (float)(y - startY));
            // 距离上一点超过阈值才记录，避免重复点
            PointF last = drawnPoints[drawnPoints.Count - 1];
            if (Math.Abs(cur.X - last.X) > 0.05 || Math.Abs(cur.Y - last.Y) > 0.05)
            {
                drawnPoints.Add(cur);
            }
            RedrawPreview();

            // 单段模式的完成由后台线程收尾，这里只检测连续插补
            if (!isSingleMode && LTDMC.dmc_conti_check_done(CardNo, Crd) != 0)
            {
                isRunning = false;
                timer2.Stop();
                lblRun.Text = "状态：绘制完成";
                lblRun.ForeColor = Color.Green;
                RedrawPreview();
            }
        }

        // 关闭窗口时若还在运行，先停止插补
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopDraw = true;
            if (isRunning)
            {
                LTDMC.dmc_conti_stop_list(CardNo, Crd, 0);
                LTDMC.dmc_stop_multicoor(CardNo, Crd, 0);
            }
            timer2.Stop();
        }

        // 带默认值的容错解析
        private double ParseDouble(string text, string name, double defaultValue)
        {
            double v;
            if (double.TryParse(text, out v)) return v;

            MessageBox.Show($"【{name}】输入不正确，已使用默认值 {defaultValue}");
            return defaultValue;
        }
    }
}
