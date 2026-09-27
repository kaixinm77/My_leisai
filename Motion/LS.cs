using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace Motion
{
    public class LS
    {
        private static readonly Lazy<LS> instance = new Lazy<LS>(() => new LS());
        private ushort cardNo = 8;
        private bool isConnected = false;

        public static LS Instance
        {
            get => instance.Value;
        }

        private LS() { }

        public ushort CardNo
        {
            get => cardNo;
            set => cardNo = value;
        }
        public bool IsConnected
        {
            get => isConnected;
            private set => isConnected = value;
        }

        public void Connect(string ip)
        {
            short rtn = LTDMC.dmc_board_init_eth(CardNo, ip);

            if (rtn == 0)
            {
                IsConnected = true;

                //开启线程监听轴状态
                Thread start = new Thread(StartListener);
                start.IsBackground = true;
                start.Start();
            }
        }

        //轴对应的位置
        public ConcurrentDictionary<string, double> AxisPos =
            new ConcurrentDictionary<string, double>();

        //开始监听轴状态
        public void StartListener()
        {
            while (isConnected)
            {
                Thread.Sleep(50);

                double pos = 0;
                foreach (var item in Config.Instance.Axes)
                {
                    short sRtn = LTDMC.dmc_get_encoder_unit(CardNo, item.Value.AxisNo, ref pos);
                    if (sRtn != 0)
                    {
                        Console.WriteLine($"读取{item.Value.AxisNo}轴失败,错误码{sRtn}");
                    }
                    else
                    {
                        AxisPos[item.Key] = pos;
                    }
                }
            }
        }

        //检测结果的方法
        public void CheckResult(short rtn, string operation)
        {
            if (rtn != 0)
            {
                // 拼接详细的报错信息，包含操作名、错误码和具体原因
                string fullMessage = $"【运动控制卡操作失败】操作: [{operation}]，错误码: {rtn}";

                // 4. 抛出包含详细信息的异常
                throw new Exception(fullMessage);
            }
        }

        public void DIsConnect()
        {
            short res = LTDMC.dmc_board_close();
            if (res != 0)
            {
                CheckResult(res, "关闭控制卡");
            }
            isConnected = false;
        }

        // ================ 作业生命周期控制 ================

        //作业取消令牌：由 LS 统一管理，窗体只调用 StartJob/StopJob/EndJob
        private CancellationTokenSource jobCts;

        /// <summary>当前作业是否正在执行</summary>
        public bool IsJobRunning => jobCts != null;

        /// <summary>
        /// 开始作业：创建新的取消令牌并返回。
        /// 作业循环中把它传给 MoveAbs / Task.Delay。
        /// </summary>
        public CancellationToken StartJob()
        {
            jobCts = new CancellationTokenSource();
            return jobCts.Token;
        }

        /// <summary>
        /// 停止作业：①取消令牌（正在等待的 MoveAbs/Task.Delay 立即退出）②三根轴减速停止。
        /// 取消令牌只让"等待"退出，轴本身还在走，必须下停轴指令。
        /// </summary>
        public void StopJob()
        {
            jobCts?.Cancel();

            Stop("X");
            Stop("Y");
            Stop("Z");
        }

        /// <summary>
        /// 作业结束（全部完成/被停止/出错）后调用：释放并复位，允许再次开始作业。
        /// </summary>
        public void EndJob()
        {
            jobCts?.Dispose();
            jobCts = null;
        }

        public string GetAxisVel(string axisName)
        {
            if (!Config.Instance.Axes.ContainsKey(axisName))
            {
                return "0.0";
            }
            double currentPos =0.0;
            var c = Config.Instance.Axes[axisName]; //通过key获取轴对象AxisInfo
            LTDMC.dmc_get_position_unit(CardNo, c.AxisNo, ref currentPos);
            return currentPos.ToString("0.###");
        }
        public void Enable()
        {
            short rtn = LTDMC.nmc_set_axis_enable(cardNo, 255);
            CheckResult(rtn, "开始使能");
        }

        public void WirteConfig()
        {
            WirteConfig("X");
            WirteConfig("Y");
            WirteConfig("Z");
        }

        public void WirteConfig(string axisName)
        {
            if (!Config.Instance.Axes.ContainsKey(axisName))
            {
                return;
            }
            var c = Config.Instance.Axes[axisName]; //通过key获取轴对象AxisInfo

            // 3. 统一处理卡号和轴号（按底层API要求转为 ushort 或 int）
            ushort cardNo = CardNo;
            ushort axisNo = c.AxisNo;

            short res = 0;

            // ================ 1. 设置脉冲当量 ================
            // 注意：如果 dmc_set_equiv 的第三个参数是 int 类型，这里需要强转 (int)c.Equiv，如果是 double 则不需要
            res = LTDMC.dmc_set_equiv(cardNo, axisNo, c.Equiv);
            CheckResult(res, $"设置[{axisName}]轴的脉冲当量");

            // ================ 2. 设置速度与加减速参数 ================
            // 通常使用 dmc_set_profile 设置起速、运行速度、加速时间、减速时间
            // 注意：如果底层要求加减速为时间(秒)，而你存的是加速度值，此处API可能需要替换为 dmc_set_profile_unit 等
            res = LTDMC.dmc_set_profile_unit(
                cardNo,
                axisNo,
                c.MinVel,
                c.MaxVel,
                c.Acc,
                c.Dec,
                c.StopVel
            );
            CheckResult(res, $"设置[{axisName}]轴的速度轮廓参数");

            // ================ 3. 设置回零参数 ================
            // 3.1 设置回零模式 (回零模式通常为整型)
            res = LTDMC.nmc_set_home_profile(
                cardNo,
                axisNo,
                c.HomeMode,
                c.HomeMinVel,
                c.HomeMaxVel,
                c.HomeAcc,
                c.HomeDec,
                c.HomeOff
            );
            CheckResult(res, $"设置[{axisName}]轴的回零模式");
        }

        public void ClearErr()
        {
            var rtn = LTDMC.nmc_clear_errcode(CardNo, 2);
            CheckResult(rtn, "关闭控制卡");
        }

        public void Gohome()
        {
            Gohome("X");
            Gohome("Y");
            Gohome("Z");
        }

        private void Gohome(string axisName)
        {
            if (!Config.Instance.Axes.ContainsKey(axisName))
            {
                return;
            }
            var c = Config.Instance.Axes[axisName]; //通过key获取轴对象AxisInfo

            short res = LTDMC.nmc_home_move(CardNo, c.AxisNo);
            CheckResult(res, "回零操作");
        }

        public void SetSpead(double vel)
        {
            Config.Instance.Axes["X"].MaxVel = vel;
            Config.Instance.Axes["Y"].MaxVel = vel;
            Config.Instance.Axes["Z"].MaxVel = vel;
        }

        /// <summary>
        /// 从控制卡读取指定轴的脉冲当量和速度曲线，更新到内存 Config。
        /// </summary>
        public void ReadAxisConfig(string axisName)
        {
            if (!Config.Instance.Axes.ContainsKey(axisName))
            {
                return;
            }
            var c = Config.Instance.Axes[axisName];

            //脉冲当量
            double equiv = 0;
            var res = LTDMC.dmc_get_equiv(CardNo, c.AxisNo, ref equiv);
            CheckResult(res, $"读取[{axisName}]轴脉冲当量");
            c.Equiv = equiv;

            //速度曲线（unit 版）
            double minV = 0, maxV = 0, tacc = 0, tdec = 0, stopV = 0;
            res = LTDMC.dmc_get_profile_unit(CardNo, c.AxisNo, ref minV, ref maxV, ref tacc, ref tdec, ref stopV);
            CheckResult(res, $"读取[{axisName}]轴速度曲线");
            c.MinVel = minV;
            c.MaxVel = maxV;
            c.Acc = tacc;
            c.Dec = tdec;
            c.StopVel = stopV;
        }

        /// <summary>
        /// 把指定轴的配置（脉冲当量 + 速度曲线 + 回零参数）下发到控制卡。
        /// </summary>
        public void WriteSoftLimit(string axisName, bool enable, double posLimit, double negLimit)
        {
            if (!Config.Instance.Axes.ContainsKey(axisName))
            {
                return;
            }
            var c = Config.Instance.Axes[axisName];

            //source_sel=0(指令位置) SL_action=0(减速停)
            var res = LTDMC.dmc_set_softlimit_unit(CardNo, c.AxisNo,
                (ushort)(enable ? 1 : 0), 0, 0, negLimit, posLimit);
            CheckResult(res, $"设置[{axisName}]轴软限位");
        }

        /// <summary>
        /// 从控制卡读取指定轴的软限位状态。
        /// </summary>
        public void ReadSoftLimit(string axisName, out bool enable, out double posLimit, out double negLimit)
        {
            enable = false;
            posLimit = 0;
            negLimit = 0;
            if (!Config.Instance.Axes.ContainsKey(axisName))
            {
                return;
            }
            var c = Config.Instance.Axes[axisName];

            ushort en = 0, src = 0, act = 0;
            double p = 0, n = 0;
            var res = LTDMC.dmc_get_softlimit_unit(CardNo, c.AxisNo, ref en, ref src, ref act, ref n, ref p);
            CheckResult(res, $"读取[{axisName}]轴软限位");
            enable = en != 0;
            posLimit = p;
            negLimit = n;
        }

        public void Jog(string axisName, ushort dir)
        {
            if (!Config.Instance.Axes.ContainsKey(axisName))
            {
                return;
            }
            var c = Config.Instance.Axes[axisName]; //通过key获取轴对象AxisInfo

            short res = LTDMC.dmc_vmove(CardNo, c.AxisNo, dir);
            CheckResult(res, "Jog运动操作");
        }

        public async Task MoveAbs(string axisName, double pos, CancellationToken token = default)
        {
            if (!Config.Instance.Axes.ContainsKey(axisName))
            {
                return;
            }
            var c = Config.Instance.Axes[axisName]; //通过key获取轴对象AxisInfo

            var res = LTDMC.dmc_pmove_unit(CardNo, c.AxisNo, pos, 1);
            CheckResult(res, "绝对运动操作");

            //轮询等待本轴运动完成：dmc_check_done 返回 0 表示已停止
            //每 10ms 查询一次，让出线程，不卡 UI、不烧 CPU
            while (LTDMC.dmc_check_done(CardNo, c.AxisNo) != 0)
            {
                //收到取消请求立即抛出 OperationCanceledException，退出等待
                token.ThrowIfCancellationRequested();
                await Task.Delay(10, token);
            }
        }

        public void Stop(string axisName, ushort mode = 0)
        {
            if (!Config.Instance.Axes.ContainsKey(axisName))
            {
                return;
            }
            var c = Config.Instance.Axes[axisName]; //通过key获取轴对象AxisInfo
            var res = LTDMC.dmc_stop(cardNo, c.AxisNo, mode);
            CheckResult(res, "停止操作");
        }

        public bool AxisRun(string axisName)
        {
            if (!Config.Instance.Axes.ContainsKey(axisName))
            {
                return false;
            }
            var c = Config.Instance.Axes[axisName]; //通过key获取轴对象AxisInfo

            var run = LTDMC.dmc_check_done(CardNo, c.AxisNo);
            if (run == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 轴状态
        /// </summary>
        /// <param name="axisName"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool AxisStateMachine(string axisName, out string text)
        {
            if (!Config.Instance.Axes.ContainsKey(axisName))
            {
                text = "未连接";
                return false;
            }
            var c = Config.Instance.Axes[axisName]; //通过key获取轴对象AxisInfo

            ushort usAxisStateMachine = 0;
            LTDMC.nmc_get_axis_state_machine(CardNo, c.AxisNo, ref usAxisStateMachine);
            switch (usAxisStateMachine)
            {
                case 0:
                    text = "轴处于未启动状态";
                    return false;

                case 1:
                    text = "轴处于启动禁止状态";
                    return false;
                case 2:
                    text = "轴处于准备启动状态";
                    return false;
                case 3:
                    text = "轴处于启动状态";
                    return false;
                case 4:
                    text = "轴处于操作使能状态";
                    return true;
                case 5:
                    text = "轴处于停止状态";
                    return false;
                case 6:
                    text = "轴处于错误触发状态";
                    return false;
                case 7:
                    text = "轴处于错误状态";
                    return false;
                default:
                    text = "未知错误";
                    return false;
            }
        }
    }
}
