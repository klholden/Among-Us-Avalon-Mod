using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnhollowerBaseLib;
using UnityEngine;







namespace AvalonMod
{
    [HarmonyPatch(typeof(PHCKLDDNJNP))]
    public static class GameOptionMenuPatch
    {
        public static BCLDBBKFJPK showOberonOption;
        public static PCGDGFIAJJI OberonCooldown;


        [HarmonyPostfix]
        [HarmonyPatch("Start")]
        public static void Postfix1(PHCKLDDNJNP __instance)
        {
            if (GameObject.FindObjectsOfType<BCLDBBKFJPK>().Count == 4)
            {
               
                    BCLDBBKFJPK showAnonymousvote = GameObject.FindObjectsOfType<BCLDBBKFJPK>().ToList().Where(x => x.TitleText.Text == "Anonymous Votes").First();
                    showOberonOption = GameObject.Instantiate(showAnonymousvote);

                    showOberonOption.TitleText.Text = "Show Oberon";

                    showOberonOption.NHLMDAOEOAE = CustomGameOptions.showOberon;
                    showOberonOption.CheckMark.enabled = CustomGameOptions.showOberon;

                    PCGDGFIAJJI killcd = GameObject.FindObjectsOfType<PCGDGFIAJJI>().ToList().Where(x => x.TitleText.Text == "Kill Cooldown").First();

                    OberonCooldown = GameObject.Instantiate(killcd);
                    OberonCooldown.gameObject.name = "OberonCDText";
                    OberonCooldown.TitleText.Text = "Oberon Kill Cooldown";
                    OberonCooldown.Value = CustomGameOptions.OberonKillCD;
                    OberonCooldown.ValueText.Text = CustomGameOptions.OberonKillCD.ToString();


                    LLKOLCLGCBD[] options = new LLKOLCLGCBD[__instance.KJFHAPEDEBH.Count + 2];
                    __instance.KJFHAPEDEBH.ToArray().CopyTo(options, 0);
                    options[options.Length - 2] = showOberonOption;
                    options[options.Length - 1] = OberonCooldown;
                    __instance.KJFHAPEDEBH = new Il2CppReferenceArray<LLKOLCLGCBD>(options);
                
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch("Update")]
        public static void Postfix2(PHCKLDDNJNP __instance)
        {
            BCLDBBKFJPK showAnonymousvote = GameObject.FindObjectsOfType<BCLDBBKFJPK>().ToList().Where(x => x.TitleText.Text == "Anonymous Votes").First();
            if (OberonCooldown != null & showOberonOption != null){
                showOberonOption.transform.position = showAnonymousvote.transform.position - new Vector3(0, 5.5f, 0);
                OberonCooldown.transform.position = showAnonymousvote.transform.position - new Vector3(0, 6f, 0);
            }

        }
    }
    [HarmonyPatch]
    public static class ToggleButtonPatch
    {
        [HarmonyPatch(typeof(BCLDBBKFJPK), "Toggle")]
        public static bool Prefix(BCLDBBKFJPK __instance)
        {

            if (__instance.TitleText.Text == "Show Oberon")
            {
                CustomGameOptions.showOberon = !CustomGameOptions.showOberon;
                FFGALNAPKCD.LocalPlayer.RpcSyncSettings(FFGALNAPKCD.GameOptions);

                __instance.NHLMDAOEOAE = CustomGameOptions.showOberon;
                __instance.CheckMark.enabled = CustomGameOptions.showOberon;
                return false;

            }
            return true;

        }

    }
    [HarmonyPatch(typeof(PCGDGFIAJJI))]
    public static class NumberOptionPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch("Increase")]
        public static bool Prefix1(PCGDGFIAJJI __instance)
        {
            if (__instance.TitleText.Text == "Oberon Kill Cooldown")
            {
                CustomGameOptions.OberonKillCD = Math.Min(CustomGameOptions.OberonKillCD + 2.5f, 40);
                FFGALNAPKCD.LocalPlayer.RpcSyncSettings(FFGALNAPKCD.GameOptions);
                GameOptionMenuPatch.OberonCooldown.NHLMDAOEOAE = CustomGameOptions.OberonKillCD;
                GameOptionMenuPatch.OberonCooldown.Value = CustomGameOptions.OberonKillCD;
                GameOptionMenuPatch.OberonCooldown.ValueText.Text = CustomGameOptions.OberonKillCD.ToString();
                return false;
            }

            return true;
        }

        [HarmonyPrefix]
        [HarmonyPatch("Decrease")]
        public static bool Prefix2(PCGDGFIAJJI __instance)
        {
            if (__instance.TitleText.Text == "Oberon Kill Cooldown")
            {
                CustomGameOptions.OberonKillCD = Math.Max(CustomGameOptions.OberonKillCD - 2.5f, 10);

                FFGALNAPKCD.LocalPlayer.RpcSyncSettings(FFGALNAPKCD.GameOptions);
                GameOptionMenuPatch.OberonCooldown.NHLMDAOEOAE = CustomGameOptions.OberonKillCD;
                GameOptionMenuPatch.OberonCooldown.Value = CustomGameOptions.OberonKillCD;
                GameOptionMenuPatch.OberonCooldown.ValueText.Text = CustomGameOptions.OberonKillCD.ToString();


                return false;
            }

            return true;
        }
    }
}

