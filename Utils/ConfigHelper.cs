using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SDG.Framework.IO.Deserialization;
using System;
using System.IO;

namespace Announcer.Utils
{
    public class Config
    {
        public int interval { get; set; }
        public string color { get; set; }
        public string[] messages { get; set; }
    }

    public class ConfigHelper
    {
        public static void EnsureConfig(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("No config.json");

                JArray array = new JArray();
                array.Add("This server is powered by Hyperspawn Plugins!");
                array.Add("Hyperspawn Plugins! - discord.gg/ADUmgFt");

                JObject announcerConfig = new JObject();
                announcerConfig.Add("interval", 600);
                announcerConfig.Add("color", "#00FFFF");
                announcerConfig["messages"] = array;

                // write JSON directly to a file
                using (StreamWriter file = File.CreateText(path))
                using (JsonTextWriter writer = new JsonTextWriter(file))
                {
                    announcerConfig.WriteTo(writer);
                    Console.WriteLine("Generated Announcer config");
                }
            }
        }

        public static Config ReadConfig(string path)
        {
            JObject o1 = JObject.Parse(File.ReadAllText(path));

            // read JSON directly from a file
            using (StreamReader file = File.OpenText(path))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                return JsonConvert.DeserializeObject<Config>(JToken.ReadFrom(reader).ToString());
            }
        }
    }
}
