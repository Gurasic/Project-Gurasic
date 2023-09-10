using SadCanvas;
using SadConsole.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Gurasic
{
    internal class Test : BaseGameplayGUI
    {
        public Test()
        {

            GameSettings.LastScreen = this;
            this.Print(1, 13, "It Works ", Color.Red);

        }
    }
}
