using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phantom.Settings
{
    public class Config
    {
        public Dictionary<string, string> Authentication = new Dictionary<string, string>();

        public List<string> InGameModerators = new List<string>();

        public List<ulong> DiscordModerators = new List<ulong>();

        public string Token = "NzQxMjU1MjYzMDcxMzcxMjk0.Xy05wg.gniag6845R3G_GjtkPhdewffn70";

        public string Prefix = "p!";
    }

    public static class Configuration
    {
        private static Config _Config { get; set; }

        public static Config GetConfig() { return _Config; }

        public static void SaveConfig() => File.WriteAllText("Config.json", JsonConvert.SerializeObject(_Config));

        public static void LoadConfig() => _Config = JsonConvert.DeserializeObject<Config>(File.ReadAllText("Config.json"));

        public static void SetupConfig() 
        {
            if (!File.Exists("Config.json"))
            {
                Config config = new Config();
                config.Authentication.Add("usr_a70acb66-ede6-47ac-977b-6ed840de65b9", "authcookie_957b11e1-ae8a-47a4-8e42-17846ba6f64b");
                config.InGameModerators.AddRange(new List<string>() { "usr_c59bb3f7-00c8-4cc1-9408-9ee9309e0443" });
                config.DiscordModerators.AddRange(new List<ulong>()
                {
                    714088721565220905,
                    261410011060633600
                });

                File.WriteAllText("Config.json", JsonConvert.SerializeObject(config));
            }
            LoadConfig();
        }
    }
}
