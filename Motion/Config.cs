using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Model;

namespace Motion
{
    public class Config
    {
        private static readonly Lazy<Config> instance = new Lazy<Config>(() => new Config());

        public static Config Instance
        {
            get => instance.Value;
        }
        [JsonConstructor]
        private Config()
        {
            Axes = new Dictionary<string, AxisInfo>
            {
                { "X", new AxisInfo() },
                { "Y", new AxisInfo() },
                { "Z", new AxisInfo() },
            };
        }

        private string filePath = "config.json";

        public Dictionary<string, AxisInfo> Axes { get; set; }
        public string IpAddr { get; set; }
        public string FilePath
        {
            get => filePath;
            set => filePath = value;
        }

        public void SaveFile()
        {
            string str = JsonSerializer.Serialize(this);
            File.WriteAllText(FilePath, str);
        }

        public void LoadFile()
        {
            if (!File.Exists(FilePath))
            {
                return;
            }
            string str = File.ReadAllText(FilePath);

            try
            {
                Config c = JsonSerializer.Deserialize<Config>(str);
                IpAddr = c.IpAddr;
                Axes = c.Axes;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}
