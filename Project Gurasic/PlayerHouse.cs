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
            this.Print(1, 10, "on god ", Color.Red);


        }

    }

}
