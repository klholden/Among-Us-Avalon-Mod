using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalonMod
{
    [HarmonyPatch(typeof(BOCOFLHKCOJ), "Start")]
    public static class VersionShowerPatch
    {
        // Methods
        public static void Postfix(BOCOFLHKCOJ __instance)
        {
            __instance.text.Text += "\nloaded Avalon Mod v1.1 by lynnmakes ";



        }
    }

}
