using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace 雷赛基础运动
{
    public partial class Form1 : Form
    {
        // 板卡号与IP地址从 App.config 读取
        private readonly ushort CardNo = Convert.ToUInt16(ConfigurationManager.AppSettings["CardNo"]);
        private readonly string IpAddress = ConfigurationManager.AppSettings["IpAddress"];

        private readonly IniFileHelper ini; // ini 配置文件操作
        private short rtn;                   // 函数返回值
        private ushort Axis;                 // 当前操作的轴号
        private bool isConnected = false;   // 板卡是否已连接

        public Form1()
        {
            InitializeComponent();

            // config.ini 保存在程序运行目录下（修复了原来路径里多一个空格的 bug）
            ini = new IniFileHelper(Path.Combine(Application.StartupPath, "config.ini"));

            // 轴号下拉框：0 ~ 7 轴
            for (int i = 0; i <= 7; i++)
            {
                cmbAxis.Items.Add(i);
            }
            cmbAxis.SelectedIndex = 0; // 默认选择 0 轴
        }

        // 窗体加载：连接控制卡并启动状态轮询
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // 连接控制卡
                rtn = LTDMC.dmc_board_init_eth(CardNo, IpAddress);
                if (rtn != 0)
                {
                    lbl_Connect.Text = "板卡连接失败";
                    lbl_Connect.ForeColor = Color.Red;
                    MessageBox.Show("初始化板卡失败，请检查网线连接与 App.config 中的 IP 设置",
                        "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                isConnected = true;
                lbl_Connect.Text = "板卡已连接";
                lbl_Connect.ForeColor = Color.Green;

                ApplyProfile();      // 把界面上的速度参数与脉冲当量下发到卡
                ApplyHomeProfile();  // 把界面上的回零参数下发到卡
                timer1.Start(); // 开启状态轮询
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "初始化异常");
            }
        }

        // 窗体关闭：停止轮询并断开板卡
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            if (isConnected)
            {
                LTDMC.dmc_board_close();
            }
        }

        // ==================== 轴选择 ====================

        // 切换轴号：先加载该轴在 ini 中保存的参数，再下发到控制卡
        private void cmbAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAxis.SelectedItem == null) return;
            Axis = (ushort)cmbAxis.SelectedIndex; 

            LoadConfig();      // 加载该轴配置到界面
            if (isConnected)   // 连接成功后才下发参数
            {
                rtn = LTDMC.dmc_set_equiv(CardNo, Axis, Convert.ToDouble(txtEquiv.Text));
                rtn = LTDMC.dmc_set_profile_unit(CardNo, Axis, Convert.ToDouble(txtMinVel.Text), Convert.ToDouble(txtMaxVel.Text), Convert.ToDouble(txtTacc.Text), Convert.ToDouble(txtTdec.Text), Convert.ToDouble(txtStopVel.Text));
                rtn = LTDMC.nmc_set_home_profile(CardNo, Axis, 23, Convert.ToDouble(txtHomeVelLow.Text), Convert.ToDouble(txtHomeVelHigh.Text), Convert.ToDouble(txtHomeAcc.Text), Convert.ToDouble(txtHomeDec.Text), Convert.ToDouble(txtHomeOffset.Text));
            }
        }

        // ==================== 配置文件读写 ====================

        // 把界面参数写入 config.ini
        private void btn_SaveConfig_Click(object sender, EventArgs e)
        {
            string section = $"{Axis}轴";
            ini.WriteIniString(section, "Dis", txtDis.Text);
            ini.WriteIniString(section, "Equ", txtEquiv.Text);
            ini.WriteIniString(section, "MinVel", txtMinVel.Text);
            ini.WriteIniString(section, "MaxVel", txtMaxVel.Text);
            ini.WriteIniString(section, "AccTime", txtTacc.Text);
            ini.WriteIniString(section, "DecTime", txtTdec.Text);
            ini.WriteIniString(section, "StopVel", txtStopVel.Text);
        }

        // 从 config.ini 加载参数到界面（修复了原来 txtTdec/txtStopVel 读错键的 bug）
        private void btn_LoadConfig_Click(object sender, EventArgs e)
        {
            LoadConfig();
            ApplyProfile();
        }

        private void LoadConfig()
        {
            string section = $"{Axis}轴";
            SetTextIfNotEmpty(txtDis, ini.GetIniString(section, "Dis"));
            SetTextIfNotEmpty(txtEquiv, ini.GetIniString(section, "Equ"));
            SetTextIfNotEmpty(txtMinVel, ini.GetIniString(section, "MinVel"));
            SetTextIfNotEmpty(txtMaxVel, ini.GetIniString(section, "MaxVel"));
            SetTextIfNotEmpty(txtTacc, ini.GetIniString(section, "AccTime"));
            SetTextIfNotEmpty(txtTdec, ini.GetIniString(section, "DecTime"));
            SetTextIfNotEmpty(txtStopVel, ini.GetIniString(section, "StopVel"));

            string homeSection = $"{Axis}轴回零";
            SetTextIfNotEmpty(txtHomeVelLow, ini.GetIniString(homeSection, "HomeVelLow"));
            SetTextIfNotEmpty(txtHomeVelHigh, ini.GetIniString(homeSection, "HomeVelHigh"));
            SetTextIfNotEmpty(txtHomeAcc, ini.GetIniString(homeSection, "HomeAcc"));
            SetTextIfNotEmpty(txtHomeDec, ini.GetIniString(homeSection, "HomeDec"));
            SetTextIfNotEmpty(txtHomeOffset, ini.GetIniString(homeSection, "HomeOffset"));
        }

        // ==================== 回零 ====================

        // 把回零参数写入 config.ini
        private void btn_SaveHomeConfig_Click(object sender, EventArgs e)
        {
            string homeSection = $"{Axis}轴回零";
            ini.WriteIniString(homeSection, "HomeVelLow", txtHomeVelLow.Text);
            ini.WriteIniString(homeSection, "HomeVelHigh", txtHomeVelHigh.Text);
            ini.WriteIniString(homeSection, "HomeAcc", txtHomeAcc.Text);
            ini.WriteIniString(homeSection, "HomeDec", txtHomeDec.Text);
            ini.WriteIniString(homeSection, "HomeOffset", txtHomeOffset.Text);
        }

        // 从 config.ini 加载回零参数到界面
        private void btn_LoadHomeConfig_Click(object sender, EventArgs e)
        {
            LoadConfig();
            ApplyHomeProfile();
        }

        // 把界面上的回零参数下发到控制卡（home_mode=23 为总线回零模式）
        private void ApplyHomeProfile()
        {
            if (!isConnected) return;

            double lowVel = ParseDouble(txtHomeVelLow.Text, "回零低速", 10);
            double highVel = ParseDouble(txtHomeVelHigh.Text, "回零高速", 40);
            double acc = ParseDouble(txtHomeAcc.Text, "回零加速时间", 0.1);
            double dec = ParseDouble(txtHomeDec.Text, "回零减速时间", 0.1);
            double offset = ParseDouble(txtHomeOffset.Text, "回零偏移", 0);

            LTDMC.nmc_set_home_profile(CardNo, Axis, 23, lowVel, highVel, acc, dec, offset);
        }

        // 启动回零：先下发回零参数，再触发回零运动
        private void btn_Home_Click(object sender, EventArgs e)
        {
            ApplyHomeProfile();
            rtn = LTDMC.nmc_home_move(CardNo, Axis); // 总线轴回零
            if (rtn != 0)
            {
                MessageBox.Show($"启动回零失败，错误码：{rtn}");
            }
        }

        private void SetTextIfNotEmpty(TextBox tb, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                tb.Text = value;
            }
        }

        // 把界面上的速度参数与脉冲当量下发到控制卡
        private void ApplyProfile()
        {
            if (!isConnected) return;

            double minVel = ParseDouble(txtMinVel.Text, "最小速度", 0);
            double maxVel = ParseDouble(txtMaxVel.Text, "最大速度", 50);
            double tacc = ParseDouble(txtTacc.Text, "加速时间", 0.1);
            double tdec = ParseDouble(txtTdec.Text, "减速时间", 0.1);
            double stopVel = ParseDouble(txtStopVel.Text, "停止速度", 0);
            double equiv = ParseDouble(txtEquiv.Text, "脉冲当量", 1);

            LTDMC.dmc_set_profile_unit(CardNo, Axis, minVel, maxVel, tacc, tdec, stopVel);
            LTDMC.dmc_set_equiv(CardNo, Axis, equiv);
        }

        private double ParseDouble(string text, string name, double defaultValue)
        {
            double v;
            if (double.TryParse(text, out v)) return v;

            MessageBox.Show($"【{name}】输入不正确，已使用默认值 {defaultValue}");
            return defaultValue;
        }

        // ==================== 运动控制 ====================

        // 停止运动
        private void btn_Stop_Click(object sender, EventArgs e)
        {
            rtn = LTDMC.dmc_stop(CardNo, Axis, 0);
            if (rtn != 0)
            {
                MessageBox.Show($"停止运动失败，错误码：{rtn}");
            }
        }

        // 关闭伺服使能（255 表示对所有轴操作）
        private void btn_Disable_Click(object sender, EventArgs e)
        {
            rtn = LTDMC.nmc_set_axis_disable(CardNo, 255);
            if (rtn != 0)
            {
                MessageBox.Show($"关闭使能失败，错误码：{rtn}");
            }
        }

        // 开启伺服使能（255 表示对所有轴操作）
        private void btn_Enable_Click(object sender, EventArgs e)
        {
            rtn = LTDMC.nmc_set_axis_enable(CardNo, 255);
            if (rtn != 0)
            {
                MessageBox.Show($"开启使能失败，错误码：{rtn}");
            }
        }

        // 清除总线错误码（通道 2 为 EtherCAT 端口）
        private void btn_ClearErr_Click(object sender, EventArgs e)
        {
            rtn = LTDMC.nmc_clear_errcode(CardNo, 2);
            if (rtn != 0)
            {
                MessageBox.Show($"清除错误失败，错误码：{rtn}");
            }
        }

        // 正转点动：按下启动、松开停止
        private void btn_JogPos_MouseDown(object sender, MouseEventArgs e)
        {
            rtn = LTDMC.dmc_vmove(CardNo, Axis, 0); // 0 = 正方向
            if (rtn != 0)
            {
                MessageBox.Show($"启动点动失败，错误码：{rtn}");
            }
        }

        private void btn_JogPos_MouseUp(object sender, MouseEventArgs e)
        {
            LTDMC.dmc_stop(CardNo, Axis, 0); // 停止点动运动
        }

        // 反转点动：按下启动、松开停止
        private void btn_JogNeg_MouseDown(object sender, MouseEventArgs e)
        {
            rtn = LTDMC.dmc_vmove(CardNo, Axis, 1); // 1 = 负方向
            if (rtn != 0)
            {
                MessageBox.Show($"启动点动失败，错误码：{rtn}");
            }
        }

        private void btn_JogNeg_MouseUp(object sender, MouseEventArgs e)
        {
            LTDMC.dmc_stop(CardNo, Axis, 0); // 停止点动运动
        }

        // 打开插补运动窗口（Form2）
        private void btn_Interp_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                MessageBox.Show("板卡未连接，无法使用插补运动");
                return;
            }
            // 把主界面的脉冲当量传给插补窗口，保证 X/Y 两轴当量一致
            double equiv;
            if (!double.TryParse(txtEquiv.Text, out equiv)) equiv = 1;

            Form2 form2 = new Form2(CardNo, equiv);
            form2.Show();
        }

        // ==================== 状态轮询 ====================

        private void timer1_Tick(object sender, EventArgs e)
        {
            // 获取当前速度
            double currentSpeed = 0;
            rtn = LTDMC.dmc_read_current_speed_unit(CardNo, Axis, ref currentSpeed);
            tb_CurrentVel.Text = currentSpeed.ToString("0.###");

            // 获取当前位置
            double currentPos = 0;
            LTDMC.dmc_get_position_unit(CardNo, Axis, ref currentPos);
            tb_CurrentPos.Text = currentPos.ToString("0.###");

            // 获取编码器位置
            double encodePos = 0;
            LTDMC.dmc_get_encoder_unit(CardNo, Axis, ref encodePos);
            tb_Encoder.Text = encodePos.ToString("0.###");

            // 获取当前轴的运动状态（返回 0 表示正在运行）
            string run = LTDMC.dmc_check_done(CardNo, Axis) == 0 ? "正在运行中" : "停止中";
            tb_RunState.Text = run;

            // 读取指定轴状态机
            ushort usAxisStateMachine = 0;
            LTDMC.nmc_get_axis_state_machine(CardNo, Axis, ref usAxisStateMachine);
            switch (usAxisStateMachine)
            {
                case 0:
                    tb_StateMachine.Text = "轴处于未启动状态";
                    tb_StateMachine.BackColor = Color.Red;
                    break;
                case 1:
                    tb_StateMachine.Text = "轴处于启动禁止状态";
                    tb_StateMachine.BackColor = Color.Red;
                    break;
                case 2:
                    tb_StateMachine.Text = "轴处于准备启动状态";
                    tb_StateMachine.BackColor = Color.Red;
                    break;
                case 3:
                    tb_StateMachine.Text = "轴处于启动状态";
                    tb_StateMachine.BackColor = Color.Red;
                    break;
                case 4:
                    tb_StateMachine.Text = "轴处于操作使能状态";
                    tb_StateMachine.BackColor = Color.Green;
                    break;
                case 5:
                    tb_StateMachine.Text = "轴处于停止状态";
                    tb_StateMachine.BackColor = Color.Red;
                    break;
                case 6:
                    tb_StateMachine.Text = "轴处于错误触发状态";
                    tb_StateMachine.BackColor = Color.Red;
                    break;
                case 7:
                    tb_StateMachine.Text = "轴处于错误状态";
                    tb_StateMachine.BackColor = Color.Red;
                    break;
            }

            // 读取总线状态（通道 2 为 EtherCAT 端口）
            ushort usErrorCode = 0;
            LTDMC.nmc_get_errcode(CardNo, 2, ref usErrorCode);
            if (usErrorCode == 0)
            {
                tb_EthercatState.Text = "EtherCAT总线正常";
                tb_EthercatState.BackColor = Color.Green;
            }
            else
            {
                tb_EthercatState.Text = $"EtherCAT总线出错(0x{usErrorCode:X})";
                tb_EthercatState.BackColor = Color.Red;
            }

            // 读取轴IO状态：bit1 正(右)限位 / bit2 负(左)限位 / bit4 原点信号
            uint state = LTDMC.dmc_axis_io_status(CardNo, Axis);

            // 使能灯：轴状态机处于"操作使能状态"时为绿
            panel_Enable.BackColor = usAxisStateMachine == 4 ? Color.Green : Color.Red;

            // 回原灯：检测到原点信号时为绿
            panel_Home.BackColor = (state & 16) == 16 ? Color.Green : Color.Red;

            // 左限位（负限位）：触发时为红
            panel_NegLimit.BackColor = (state & 4) == 4 ? Color.Red : Color.Green;

            // 右限位（正限位）：触发时为红
            panel_PosLimit.BackColor = (state & 2) == 2 ? Color.Red : Color.Green;
        }
    }
}
