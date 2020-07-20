using Announcer.Utils;
using SDG.Unturned;
using System;
using UnityEngine;

namespace Announcer
{
    public class AnnouncerManager : MonoBehaviour
    {
        public void Awake()
        {
            Console.WriteLine(Main.Config.interval);
            InvokeRepeating("SendRandomMessage", Main.Config.interval, Main.Config.interval);
        }

        private void SendRandomMessage()
        {
            System.Random rng = new System.Random();
            int index = rng.Next(0, Main.Config.messages.Length);
            Color msgColor = new Color();
            ColorUtility.TryParseHtmlString(Main.Config.color, out msgColor);
            UnityThread.executeInUpdate(() =>
            {
                ChatManager.say(Main.Config.messages[index], msgColor, true);
            });
        }
    }
}
