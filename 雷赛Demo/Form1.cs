using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Motion;

namespace 雷赛Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string filePath = "points.json";
        List<JobConfig> jobConfigs = new List<JobConfig>();

        private void Form1_Load(object sender, EventArgs e)
        {
            Config.Instance.LoadFile();
            try
            {
                LS.Instance.Connect(Config.Instance.IpAddr);

                LS.Instance.WirteConfig();

                LS.Instance.Enable();

                string str = File.ReadAllText(filePath);
                jobConfigs = JsonSerializer.Deserialize<List<JobConfig>>(str);
                dgvPoints.DataSource = jobConfigs;
                nudSpeed.Value = (decimal)Config.Instance.Axes["X"].MaxVel;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            timer1.Start();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                if (!LS.Instance.IsConnected)
                {
                    return;
                }
                LS.Instance.Gohome();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClearError_Click(object sender, EventArgs e)
        {
            try
            {
                LS.Instance.ClearErr();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnYPlus_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                var strs = ((Button)sender).Tag.ToString().Split(',');
                LS.Instance.Jog(strs[0], Convert.ToUInt16(strs[1]));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnYPlus_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                var strs = ((Button)sender).Tag.ToString().Split(',');
                LS.Instance.Stop(strs[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nudSpeed_ValueChanged(object sender, EventArgs e)
        {
            LS.Instance.SetSpead((double)nudSpeed.Value);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetAxisRun("X", indXMove, label1);
            GetAxisRun("Y", indYMove, label2);
            GetAxisRun("Z", indZMove, label3);
            GetAxisStateMachine("X", indXAlarm, label4);
            GetAxisStateMachine("Y", indYAlarm, label5);
            GetAxisStateMachine("Z", indZAlarm, label6);
            
            tsslX.Text= "X轴的位置："+LS.Instance.GetAxisVel("X");
            tsslY.Text = "Y轴的位置：" +LS.Instance.GetAxisVel("Y");
            tsslZ.Text = "Z轴的位置：" +LS.Instance.GetAxisVel("Z");
        }

        private void GetAxisStateMachine(string v, Label Alarm, Label label)
        {
            if (LS.Instance.AxisStateMachine(v, out string text))
            {
                Alarm.BackColor = Color.Lime;
                label.Text = "运行中";
            }
            else
            {
                Alarm.BackColor = Color.Red;
                label.Text = "未运动";
            }
            label.Text = text;
        }

        private void GetAxisRun(string Axis, Label l1, Label label)
        {
            if (LS.Instance.AxisRun(Axis))
            {
                l1.BackColor = Color.Red;
            }
            else
            {
                l1.BackColor = Color.Lime;
            }
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            //防止重复开始：上一轮作业还在跑就不再启动
            if (LS.Instance.IsJobRunning)
            {
                MessageBox.Show("作业正在执行中，请先停止");
                return;
            }
            btnStart.Enabled = false;
            var list = dgvPoints.DataSource as List<JobConfig>;
            var token = LS.Instance.StartJob();
            try
            {
                foreach (var item in list)
                {
                    if (item.Enable)
                    {
                        //X/Y/Z 同时发出、同时运动（带取消令牌）
                        Task tx = LS.Instance.MoveAbs("X", item.X, token);
                        Task ty = LS.Instance.MoveAbs("Y", item.Y, token);
                        Task tz = LS.Instance.MoveAbs("Z", item.Z, token);

                        //等三根轴全部到位，本点位才算完成
                        await Task.WhenAll(tx, ty, tz);

                        //停留时间(毫秒)后再去下一个点位
                        await Task.Delay((int)item.WaitTime, token);
                    }
                }
            }
            catch (OperationCanceledException)
            {
                //点了"停止作业"走这里，属于正常中止，不是错误
                MessageBox.Show("作业已停止");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                //无论正常完成、报错还是取消，都复位，允许下次再开始
                LS.Instance.EndJob();
                btnStart.Enabled = true;
            }
            MessageBox.Show("作业全部完成");
        }

        private async void btnMoveX_Click(object sender, EventArgs e)
        {
            await LS.Instance.MoveAbs("X",(double)nudLocX.Value);
        }

        private async void btnMoveY_Click(object sender, EventArgs e)
        {
            await LS.Instance.MoveAbs("Y", (double)nudLocY.Value);

        }

        private async void btnMoveZ_Click(object sender, EventArgs e)
        {
            await LS.Instance.MoveAbs("Z", (double)nudLocZ.Value);

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                //取消作业循环 + 三根轴减速停止，都在 LS 里处理
                LS.Instance.StopJob();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void menuOpen_Click(object sender, EventArgs e)
        {
            FormSetInt formSet = new FormSetInt();
            if (formSet.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    LS.Instance.Connect(Config.Instance.IpAddr);

                    LS.Instance.WirteConfig();

                    LS.Instance.Enable();

                    string str = File.ReadAllText(filePath);
                    jobConfigs = JsonSerializer.Deserialize<List<JobConfig>>(str);
                    dgvPoints.DataSource = jobConfigs;
                    nudSpeed.Value = (decimal)Config.Instance.Axes["X"].MaxVel;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
