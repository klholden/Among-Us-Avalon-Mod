﻿using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace AvalonMod
{
    [HarmonyPatch]
    public static class HudManagerPatch
    {
        // Methods


        static int counter = 0;

        public static MLPJGKEACMM KillButton = null;
        static System.Random random = new System.Random();
        static string GameSettingsText = null;



      
        public static void UpdateGameSettingsText(PIEFJFEOGOL __instance)
        {


            if (__instance.GameSettings.Text.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).Count() == 19)
            {
                GameSettingsText = __instance.GameSettings.Text;


            }
            if (GameSettingsText != null)
            {
                if (CustomGameOptions.showOberon)
                    __instance.GameSettings.Text = GameSettingsText + "Show Oberon: On" + "\n";
                else
                    __instance.GameSettings.Text = GameSettingsText + "Show Oberon: Off" + "\n";
                __instance.GameSettings.Text += "Oberon Kill Cooldown: " + CustomGameOptions.OberonKillCD.ToString() + "s";
            }

        }
        public static void updateGameOptions(KMOGFLPJLLK options)
        {
            Il2CppSystem.Collections.Generic.List<FFGALNAPKCD> allplayer = FFGALNAPKCD.AllPlayerControls;

            foreach (FFGALNAPKCD player in allplayer)
            {
                player.RpcSyncSettings(options);

            }

        }

        public static void updateOOCJALPKPEP(OOCJALPKPEP __instance)
        {


            foreach (HDJGDMFCHDN HDJGDMFCHDN in __instance.HBDFFAHBIGI)
            {

                if (HDJGDMFCHDN.NameText.Text == PlayerControlPatch.Oberon.name)
                {
                    if (CustomGameOptions.showOberon | PlayerControlPatch.isOberon(FFGALNAPKCD.LocalPlayer))
                    {
                        HDJGDMFCHDN.NameText.Color = new Color(1, (float)(204.0 / 255.0), 0, 1);

                    }

                }
            }
        }

        [HarmonyPatch(typeof(PIEFJFEOGOL), "Update")]
        public static void Postfix(PIEFJFEOGOL __instance)
        {
            KillButton = __instance.KillButton;
            if (OOCJALPKPEP.Instance != null)
            {
                updateOOCJALPKPEP(OOCJALPKPEP.Instance);
            }

            UpdateGameSettingsText(__instance);
      
            if (FFGALNAPKCD.AllPlayerControls.Count > 1 & PlayerControlPatch.Oberon != null)
            {

                if (PlayerControlPatch.isOberon(FFGALNAPKCD.LocalPlayer))
                {

                    FFGALNAPKCD.LocalPlayer.nameText.Color = new Color(1, (float)(204.0 / 255.0), 0, 1);
                    if (FFGALNAPKCD.LocalPlayer.NDGFFHMFGIG.DLPCKPBIJOE)
                    {
                        KillButton.gameObject.SetActive(false);
                        KillButton.isActive = false;
                    }
                    else {
                        KillButton.gameObject.SetActive(true);
                        KillButton.isActive = true;
                        KillButton.SetCoolDown(PlayerControlPatch.OberonKillTimer(), FFGALNAPKCD.GameOptions.IGHCIKIDAMO + 15.0f);
                        PlayerControlPatch.closestPlayer = PlayerControlPatch.getClosestPlayer(FFGALNAPKCD.LocalPlayer);
                        double dist = PlayerControlPatch.getDistBetweenPlayers(FFGALNAPKCD.LocalPlayer, PlayerControlPatch.closestPlayer);
                        if (dist < KMOGFLPJLLK.JMLGACIOLIK[FFGALNAPKCD.GameOptions.DLIBONBKPKL])
                        {
                            KillButton.SetTarget(PlayerControlPatch.closestPlayer);
                        }
                      if (Input.GetKeyInt(KeyCode.Q))
                        {
                            KillButton.PerformKill();
                        }
                    }
                }
                else if (FFGALNAPKCD.LocalPlayer.NDGFFHMFGIG.DAPKNDBLKIA)
                {
                    if (FFGALNAPKCD.LocalPlayer.NDGFFHMFGIG.DLPCKPBIJOE)
                    {
                        KillButton.gameObject.SetActive(false);
                        KillButton.isActive = false;
                    }
                    else
                    {
                        KillButton.gameObject.SetActive(true);
                        KillButton.isActive = true;
                    }
                }

            }



            
            if (counter < 30)
            {

                counter++;
                return;
            }
            counter = 0;
          
            
          
            if (GameOptionMenuPatch.showOberonOption != null && GameOptionMenuPatch.OberonCooldown!=null)
            {
                var isOptionsMenuActive = GameObject.FindObjectsOfType<PHCKLDDNJNP>().Count != 0;
                GameOptionMenuPatch.showOberonOption.gameObject.SetActive(isOptionsMenuActive);
                GameOptionMenuPatch.OberonCooldown.gameObject.SetActive(isOptionsMenuActive);

            }


            
        }

    }

    [HarmonyPatch]
    public static class OOCJALPKPEPPatchClose
    {

        [HarmonyPatch(typeof(OOCJALPKPEP), "Close")]
        public static void Postfix(OOCJALPKPEP __instance)
        {
            PlayerControlPatch.lastKilled = DateTime.UtcNow;
            PlayerControlPatch.lastKilled = PlayerControlPatch.lastKilled.AddSeconds(8);

        }
    }
}
