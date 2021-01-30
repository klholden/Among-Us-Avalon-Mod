﻿using BepInEx;
using BepInEx.Configuration;
using BepInEx.IL2CPP;
using BepInEx.IL2CPP.UnityEngine;
using HarmonyLib;
using Hazel;
using Il2CppDumper;
using InnerNet;
using Microsoft.Extensions.DependencyInjection;
using Steamworks;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using UnhollowerBaseLib;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AvalonMod
{







    [BepInPlugin("org.bepinex.plugins.AvalonMod", "Avalon Mod", "1.0.0.0")]
    public class AvalonMod : BasePlugin
    {
        public static BepInEx.Logging.ManualLogSource log;
        private readonly Harmony harmony;
        public ConfigEntry<string> Name { get; set; }
        public ConfigEntry<string> Ip { get; set; }
        public ConfigEntry<ushort> Port { get; set; }


        public AvalonMod()
        {
            log = Log;
            this.harmony = new Harmony("Avalon Mod");

        }
        public override void Load()
        {
            log.LogMessage("Avalon Mod loaded");

            Name = Config.Bind("Custom", "Name", "Custom");
            Ip = Config.Bind("Custom", "Ipv4 or Hostname", "127.0.0.1");
            Port = Config.Bind("Custom", "Port", (ushort)22023);

            var defaultRegions = AOBNFCIHAJL.DefaultRegions.ToList();
            var ip = Ip.Value;
            if (Uri.CheckHostName(Ip.Value).ToString() == "Dns")
            {
                log.LogMessage("Resolving " + ip + " ...");
                try
                {
                    foreach (IPAddress address in Dns.GetHostAddresses(Ip.Value))
                    {
                        if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            ip = address.ToString(); break;
                        }
                    }
                }
                catch
                {
                    log.LogMessage("Hostname could not be resolved" + ip);
                }

                log.LogMessage("IP is " + ip);

            }


            var port = Port.Value;

            defaultRegions.Insert(0, new OIBMKGDLGOG(
                Name.Value, ip, new[]
                {
                    new PLFDMKKDEMI($"{Name.Value}-Master-1", ip, port)
                })
            );

            AOBNFCIHAJL.DefaultRegions = defaultRegions.ToArray();


            this.harmony.PatchAll();


        }
    }




   



    







   


   

}



