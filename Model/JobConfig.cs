using System;

namespace Model
{
    public class JobConfig
    {
        public string Name { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double WaitTime { get; set; }
        public bool Enable { get; set; }
    }
}
