﻿using SadCanvas;
using SadConsole.Debug;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Gurasic
{
    internal class PlayerHouse : BaseGameplayGUI
    {

        public PlayerHouse()
        {
            GameSettings.LastScreen = this;

            _ = new Canvas("res/images/chiken.png")
            {
                Parent = this,
                Position = new Point(10, 10),
            };

        }

    }

}
