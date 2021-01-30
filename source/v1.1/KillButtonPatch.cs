using HarmonyLib;
using Hazel;
using Il2CppSystem.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalonMod
{
    [HarmonyPatch]
    public static class KillButtonPatch
    {
 

        [HarmonyPatch(typeof(MLPJGKEACMM), "PerformKill")]
        static bool Prefix(MethodBase __originalMethod)
        {
            if (PlayerControlPatch.isOberon(FFGALNAPKCD.LocalPlayer))
            {
                if (PlayerControlPatch.OberonKillTimer() == 0)
                {
                    var dist = PlayerControlPatch.getDistBetweenPlayers(FFGALNAPKCD.LocalPlayer, PlayerControlPatch.closestPlayer);
                    if (dist < KMOGFLPJLLK.JMLGACIOLIK[FFGALNAPKCD.GameOptions.DLIBONBKPKL])
                    {
                        // Verify that the player to be killed is a crewmate.
                        if (!PlayerControlPatch.closestPlayer.NDGFFHMFGIG.DAPKNDBLKIA)
                        {
                            MessageWriter writer = FMLLKEACGIO.Instance.StartRpcImmediately(FFGALNAPKCD.LocalPlayer.NetId, (byte)CustomRPC.OberonKill, Hazel.SendOption.None, -1);
                            writer.Write(FFGALNAPKCD.LocalPlayer.PlayerId);
                            writer.Write(PlayerControlPatch.closestPlayer.PlayerId);
                            FMLLKEACGIO.Instance.FinishRpcImmediately(writer);
                            FFGALNAPKCD.LocalPlayer.MurderPlayer(PlayerControlPatch.closestPlayer);

                        }

                        PlayerControlPatch.lastKilled = DateTime.UtcNow;
                    }
                }

                return false;
            }
            return true;



        }


    }

}
