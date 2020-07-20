using Announcer.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SDG.Framework.Modules;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Announcer
{
    public class Main : MonoBehaviour, IModuleNexus
    {
        private static GameObject AnnouncerObject;

        public static Main Instance;

        public static Config Config;

        public void initialize()
        {
            Instance = this;
            Console.WriteLine("Announcer by Corbyn loaded");

            UnityThread.initUnityThread();

            AnnouncerObject = new GameObject("Announcer");
            DontDestroyOnLoad(AnnouncerObject);

            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            ConfigHelper.EnsureConfig($"{path}{Path.DirectorySeparatorChar}config.json");

            Config = ConfigHelper.ReadConfig($"{path}{Path.DirectorySeparatorChar}config.json");

            AnnouncerObject.AddComponent<AnnouncerManager>();
        }


        public void shutdown()
        {
            Instance = null;
        }
    }
}
