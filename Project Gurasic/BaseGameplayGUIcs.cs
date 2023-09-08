using Project_Gurasic.Scenes;
using SadConsole.UI;
using SadConsole.UI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Gurasic
{
    internal class BaseGameplayGUI : SadConsole.UI.ControlsConsole
    {
        public string Title => "CharacterChreation";

        public BaseGameplayGUI() : base(160, 160)
        {

            this.Print(1, 1, "Test ", Color.Red);

            // Character Information Box
            Surface.DrawBox(new Rectangle(0, 27, 18, 3), ShapeParameters.CreateBorder(new ColoredGlyph(Color.AnsiBlueBright, Color.Black, '#')));
            
            // Character Information Button
            var PlayerInfoButton = new SelectionButton(11, 1)
            {
                Text = "[Player Info]",
                Position = new Point(3, 28),
                ShowEnds = false

            };
            Controls.Add(PlayerInfoButton);

            // Player Info Logic
            PlayerInfoButton.Click += (s, e) =>
            {
                Game.Instance.Screen = new PlayerInfo();
                Game.Instance.DestroyDefaultStartingConsole();
            };
        }
    }
    internal class PlayerInfo : SadConsole.UI.ControlsConsole
    {
        public PlayerInfo() : base(160, 160)
        {
            // The Mighty Box
            Surface.DrawBox(new Rectangle(1, 1, 88, 28), ShapeParameters.CreateBorder(new ColoredGlyph(Color.AnsiBlueBright, Color.Black, '#')));

            // - - - Reading Data From PlayerInfo.txt - - -

            // Name
            string PlayerName = File.ReadLines("PlayerInfo.txt").Skip(4).Take(1).First();
            this.Print(3, 3, "Player Name: ", Color.Gray);
            this.Print(16, 3, PlayerName, Color.Green);


            // Return Button
            var PlayerInfoButton = new SelectionButton(11, 1)
            {
                Text = "[Return]",
                Position = new Point(4, 26),
                ShowEnds = false

            };
            Controls.Add(PlayerInfoButton);

            // Player Info Logic
            PlayerInfoButton.Click += (s, e) =>
            {
                Game.Instance.Screen = GameSettings.LastScreen;
                Game.Instance.DestroyDefaultStartingConsole();
            };
        }
    }
}
