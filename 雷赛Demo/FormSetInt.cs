using System;
using System.Windows.Forms;
using Model;
using Motion;

namespace 雷赛Demo
{
    public partial class FormSetInt : Form
    {
        public FormSetInt()
        {
            InitializeComponent();

            //切换轴时把该轴参数加载到界面
            

            InitUI();
        }

        //当前选中的轴名
        private string CurrentAxis => cboAxisName.SelectedItem?.ToString() ?? "X";

        // ================ 界面 <--> Config 的互相转换 ================

        /// <summary>打开窗体时初始化：IP、轴号、默认选中 X 轴</summary>
        private void InitUI()
        {
            txtIp.Text = Config.Instance.IpAddr ?? "";
            SetNud(nudXNo, Config.Instance.Axes["X"].AxisNo);
            SetNud(nudYNo, Config.Instance.Axes["Y"].AxisNo);
            SetNud(nudZNo, Config.Instance.Axes["Z"].AxisNo);

            //会触发 SelectedIndexChanged → LoadAxisToUI("X")
            cboAxisName.SelectedIndex = 0;
        }

        /// <summary>把内存 Config 中指定轴的参数加载到右侧界面（软限位不在此列，只随"读取控制器"刷新）</summary>
        private void LoadAxisToUI(string axisName)
        {
            if (!Config.Instance.Axes.TryGetValue(axisName, out AxisInfo c))
            {
                return;
            }

            SetNud(nudPulse, (decimal)c.Equiv);
            SetNud(nudStartSpeed, (decimal)c.MinVel);
            SetNud(nudStopSpeed, (decimal)c.StopVel);
            SetNud(nudAccTime, (decimal)c.Acc);
            SetNud(nudDecTime, (decimal)c.Dec);

            SetNud(nudHomeMode, c.HomeMode);
            SetNud(nudHomeLow, (decimal)c.HomeMinVel);
            SetNud(nudHomeHigh, (decimal)c.HomeMaxVel);
            SetNud(nudHomeAcc, (decimal)c.HomeAcc);
            SetNud(nudHomeDec, (decimal)c.HomeDec);
            SetNud(nudHomeOffset, (decimal)c.HomeOff);
        }

        /// <summary>把界面上的轴参数写回内存 Config（不含软限位，AxisInfo 中没有对应字段）</summary>
        private void SaveUIToAxis(string axisName)
        {
            if (!Config.Instance.Axes.TryGetValue(axisName, out AxisInfo c))
            {
                return;
            }

            c.Equiv = (double)nudPulse.Value;
            c.MinVel = (double)nudStartSpeed.Value;
            c.StopVel = (double)nudStopSpeed.Value;
            c.Acc = (double)nudAccTime.Value;
            c.Dec = (double)nudDecTime.Value;

            c.HomeMode = (ushort)nudHomeMode.Value;
            c.HomeMinVel = (double)nudHomeLow.Value;
            c.HomeMaxVel = (double)nudHomeHigh.Value;
            c.HomeAcc = (double)nudHomeAcc.Value;
            c.HomeDec = (double)nudHomeDec.Value;
            c.HomeOff = (double)nudHomeOffset.Value;
        }

        /// <summary>NumericUpDown 赋值前先夹到 Min/Max 范围内，避免越界异常</summary>
        private static void SetNud(NumericUpDown nud, decimal value)
        {
            if (value < nud.Minimum) value = nud.Minimum;
            if (value > nud.Maximum) value = nud.Maximum;
            nud.Value = value;
        }

        // ================ 五个按钮事件 ================

        /// <summary>读取控制器配置：从卡上读当前轴的当量/速度曲线/软限位，回填内存 Config 和界面</summary>
        private void btnReadCtrl_Click(object sender, EventArgs e)
        {
            try
            {
                if (!LS.Instance.IsConnected)
                {
                    MessageBox.Show("请先连接控制器");
                    return;
                }
                string axis = CurrentAxis;

                //当量 + 速度曲线 → Config
                LS.Instance.ReadAxisConfig(axis);

                //软限位 → 界面（不在 Config 里持久化）
                LS.Instance.ReadSoftLimit(axis, out bool en, out double pos, out double neg);
                chkSoftLimit.Checked = en;
                SetNud(nudPosLimit, (decimal)pos);
                SetNud(nudNegLimit, (decimal)neg);

                //Config → 界面
                LoadAxisToUI(axis);

                MessageBox.Show($"已从控制器读取[{axis}]轴配置");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>写入控制器配置：把当前轴界面参数下发到卡（当量+速度曲线+回零+软限位）</summary>
        private void btnWriteCtrl_Click(object sender, EventArgs e)
        {
            try
            {
                if (!LS.Instance.IsConnected)
                {
                    MessageBox.Show("请先连接控制器");
                    return;
                }
                string axis = CurrentAxis;

                //界面 → Config → 卡
                SaveUIToAxis(axis);
                LS.Instance.WirteConfig(axis);
                LS.Instance.WriteSoftLimit(axis, chkSoftLimit.Checked,
                    (double)nudPosLimit.Value, (double)nudNegLimit.Value);

                MessageBox.Show($"[{axis}]轴配置已写入控制器");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>应用到所有轴：当前轴的全部参数（除轴号外）复制给 X/Y/Z 并下发到卡</summary>
        private void btnApplyAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (!LS.Instance.IsConnected)
                {
                    MessageBox.Show("请先连接控制器");
                    return;
                }
                if (MessageBox.Show($"确定把[{CurrentAxis}]轴的全部参数应用到 X/Y/Z 三个轴吗？",
                        "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                string axis = CurrentAxis;
                SaveUIToAxis(axis);
                var src = Config.Instance.Axes[axis];

                foreach (string name in new[] { "X", "Y", "Z" })
                {
                    var dst = Config.Instance.Axes[name];
                    //轴号保留各自的，不覆盖
                    dst.Equiv = src.Equiv;
                    dst.MinVel = src.MinVel;
                    dst.StopVel = src.StopVel;
                    dst.Acc = src.Acc;
                    dst.Dec = src.Dec;
                    dst.HomeMode = src.HomeMode;
                    dst.HomeMinVel = src.HomeMinVel;
                    dst.HomeMaxVel = src.HomeMaxVel;
                    dst.HomeAcc = src.HomeAcc;
                    dst.HomeDec = src.HomeDec;
                    dst.HomeOff = src.HomeOff;

                    LS.Instance.WirteConfig(name);
                    LS.Instance.WriteSoftLimit(name, chkSoftLimit.Checked,
                        (double)nudPosLimit.Value, (double)nudNegLimit.Value);
                }

                MessageBox.Show("已应用到所有轴");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>重载配置文件：放弃界面改动，从 config.json 重新加载并刷新界面</summary>
        private void btnReloadCfg_Click(object sender, EventArgs e)
        {
            try
            {
                Config.Instance.LoadFile();

                txtIp.Text = Config.Instance.IpAddr ?? "";
                SetNud(nudXNo, Config.Instance.Axes["X"].AxisNo);
                SetNud(nudYNo, Config.Instance.Axes["Y"].AxisNo);
                SetNud(nudZNo, Config.Instance.Axes["Z"].AxisNo);

                //配置文件里没有软限位，重载后归零
                chkSoftLimit.Checked = false;
                SetNud(nudPosLimit, 0);
                SetNud(nudNegLimit, 0);

                LoadAxisToUI(CurrentAxis);
                MessageBox.Show("已从配置文件重新加载");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>写入配置文件：把界面上的 IP/轴号/当前轴参数存入 Config 并持久化到 config.json</summary>
        private void btnSaveCfg_Click(object sender, EventArgs e)
        {
            try
            {
                string axis = CurrentAxis;

                SaveUIToAxis(axis);
                Config.Instance.IpAddr = txtIp.Text.Trim();
                Config.Instance.Axes["X"].AxisNo = (ushort)nudXNo.Value;
                Config.Instance.Axes["Y"].AxisNo = (ushort)nudYNo.Value;
                Config.Instance.Axes["Z"].AxisNo = (ushort)nudZNo.Value;

                Config.Instance.SaveFile();
                MessageBox.Show("配置已写入 config.json");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ================ 其他事件 ================

        private void CboAxisName_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAxisToUI(CurrentAxis);
        }
    }
}
