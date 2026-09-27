using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Model
{
    /// <summary>
    /// 轴配置参数（适用于X、Y、Z等任意轴）
    /// </summary>
    
    public class AxisInfo
    {
        /// <summary>
        /// 轴号（通常从0开始）
        /// </summary>
        public ushort AxisNo { get; set; } = 0;

        /// <summary>
        /// 脉冲当量（电机每移动一个单位所需的脉冲数）
        /// </summary>
        public double Equiv { get; set; } = 1.0;

        /// <summary>
        /// 最小速度（起始速度，单位：脉冲/秒 或 单位/秒）
        /// </summary>
        public double MinVel { get; set; } = 0.0;

        /// <summary>
        /// 最大速度（运行速度，单位：脉冲/秒 或 单位/秒）
        /// </summary>
        public double MaxVel { get; set; } = 0.0;

        /// <summary>
        /// 停止速度（减速停止时的起始速度）
        /// </summary>
        public double StopVel { get; set; } = 0.0;

        /// <summary>
        /// 加速度（加速时速度变化率）
        /// </summary>
        public double Acc { get; set; } = 0.01;

        /// <summary>
        /// 减速度（减速时速度变化率）
        /// </summary>
        public double Dec { get; set; } = 0.01;

        /// <summary>
        /// 回零模式（回原点方式，对应不同传感器/编码器信号）
        /// </summary>
        public ushort HomeMode { get; set; } = 23;

        /// <summary>
        /// 回零最小速度（回零过程中的起始速度）
        /// </summary>
        public double HomeMinVel { get; set; } = 0.0;

        /// <summary>
        /// 回零最大速度（回零过程中的运行速度）
        /// </summary>
        public double HomeMaxVel { get; set; } = 0.0;

        /// <summary>
        /// 回零加速度
        /// </summary>
        public double HomeAcc { get; set; } = 0.01;

        /// <summary>
        /// 回零减速度
        /// </summary>
        public double HomeDec { get; set; } = 0.01;

        /// <summary>
        /// 回零偏移量（原点触发后的偏移距离或脉冲数）
        /// </summary>
        public double HomeOff { get; set; } = 0.0;
    }

}