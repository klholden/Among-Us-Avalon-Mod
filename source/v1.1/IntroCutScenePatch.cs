using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AvalonMod
{
    [HarmonyPatch]
    public static class IntroCutScenePatch
    {
        [HarmonyPatch(typeof(PENEIDJGGAF.CKACLKCOJFO), "MoveNext")]
        public static void Postfix(PENEIDJGGAF.CKACLKCOJFO __instance)
        {
            if (PlayerControlPatch.isOberon(FFGALNAPKCD.LocalPlayer))
            {
                __instance.field_Public_PENEIDJGGAF_0.Title.Text = "Oberon";
                __instance.field_Public_PENEIDJGGAF_0.Title.Color = new Color(1, (float)(204.0 / 255.0), 0, 1);
                __instance.field_Public_PENEIDJGGAF_0.ImpostorText.Text = "Blindly shoot the [FF0000FF]Crewmates";
                __instance.field_Public_PENEIDJGGAF_0.BackgroundBar.material.color = new Color(1, (float)(204.0 / 255.0), 0, 1);

            }

        }


    }
}
