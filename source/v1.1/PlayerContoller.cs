
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace AvalonMod
{
    class PlayerController
    {
        public static List<Player> players;
        public static void Update()
        {
            if (players != null)
            {
                foreach (Player player in players)
                {
                    if(player.playerdata!=null)
                    player.Update();
                }
            }
        }

        public static void InitPlayers()
        {
            players = new List<Player>();
            foreach (FFGALNAPKCD player in FFGALNAPKCD.AllPlayerControls)
            {
                players.Add(new Player(player));
            }

        }

        public static Player getPlayerById(byte id)
        {
            foreach (Player player in players)
            {
                if (player.playerdata.PlayerId == id)
                {
                    return player;
                }
            }
            return null;
        }
        public static Player getOberon()
        {
            foreach (Player player in players)
            {
                if (player.isOberon)
                {
                    return player;
                }
            }
            return null;
        }

        public static Player getLocalPlayer()
        {
            foreach (Player player in players)
            {
                if (player.playerdata == FFGALNAPKCD.LocalPlayer)
                {
                    return player;
                }
            }
            return null;
        }
    }
}


