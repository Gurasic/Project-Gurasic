using SadCanvas;
using SadConsole.Ansi;
using SadConsole.Debug;
using SadConsole.UI.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

            // The Mighty Boxes
            Surface.DrawBox(new Rectangle(1, 6, 88, 20), ShapeParameters.CreateBorder(new ColoredGlyph(Color.Gray, Color.Black, '*')));
            Surface.DrawBox(new Rectangle(2, 7, 34, 9), ShapeParameters.CreateBorder(new ColoredGlyph(Color.Coral, Color.Black, '#')));
            Surface.DrawBox(new Rectangle(36, 7, 12, 5), ShapeParameters.CreateBorder(new ColoredGlyph(Color.Coral, Color.Black, '#')));
            var playerHouseButton = new SelectionButton(14, 1)
            {
                Text = "Player House",
                Position = new Point(11, 11)
            };
            Controls.Add(playerHouseButton);


            var playerFarmButton = new SelectionButton(6, 1)
            {
                Text = "Farm",
                Position = new Point(39, 9)
            };
            Controls.Add(playerFarmButton);
            playerFarmButton.Click += (s, e) =>
            {
                Game.Instance.Screen = new PlayerFarm(); ;
            };

            }

    }
    internal class PlayerFarm: BaseGameplayGUI
    {
        public static bool[] FarmPotsUnlocked = new bool[11];

        public PlayerFarm()
        {
            FarmPotsUnlocked[0] = true;
            returnButton();
            int startx = 1;
            int starty = 8;
            for (int i = 1; i < 13; i++)
            {
                _ = new Canvas("res/images/Farming_Sprites/Empty_Pot.png")
                {
                    Parent = this,
                    Position = new Point(startx * 13 - 8, starty),
                };
                startx++;
                if (i == 6) {  starty += 10; startx = 1; }
            }
          void PlotState() { }

        }

    }
}