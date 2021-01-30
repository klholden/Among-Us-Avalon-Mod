using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace AvalonMod
{
    public class Player
    {
        public FFGALNAPKCD playerdata;
        public bool isOberon;

        public Player(FFGALNAPKCD playerdata)
        {
            this.playerdata = playerdata;
            isOberon = false;


        }
        public void Update()
        {
            if (isOberon & (CustomGameOptions.showOberon | this == PlayerController.getLocalPlayer()))
            {
                playerdata.nameText.Color = new Color(48 / 255.0f, 223 / 255.0f, 48 / 255.0f);

            }
        }
    }
}
