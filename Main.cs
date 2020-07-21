using Announcer.Utils;
using SDG.Framework.Modules;
using System;
using System.IO;
using System.Reflection;
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
