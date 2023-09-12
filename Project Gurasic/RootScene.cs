using SadCanvas;
using SadConsole.Entities;
using SadConsole.UI.Controls;

namespace Project_Gurasic.Scenes
{
    internal class RootScene : SadConsole.UI.ControlsConsole
    {
        public string Title => "RootScene";

        public RootScene() : base(GameSettings.GAME_WIDTH, GameSettings.GAME_HEIGHT)
        {

            var selButton = new SelectionButton(16, 1)
            {
                Text = "Start",
                Position = new Point(36, 17)
            };
            Controls.Add(selButton);
            OnMainMenuText();
            selButton.Click += (s, e) => {
                File.Create("SavedInfo.txt");
                Game.Instance.Screen = new CharacterChreation();
                Game.Instance.DestroyDefaultStartingConsole();
            };
        }
        protected void OnMainMenuText()
        {
            var colors = Controls.GetThemeColors();
            Random random = new Random();
            int x = random.Next(5, 20);
            int y = random.Next(5, 20);
            Surface.Fill(colors.ControlHostForeground, colors.ControlHostBackground, 0, 0);

            this.Print(12, 8, " ________  ________  _____ ______   ___  ________   ________     ", colors.Yellow);
            this.Print(12, 9, "|\\   ____\\|\\   __  \\|\\   _ \\  _   \\|\\  \\|\\   ___  \\|\\   ____\\    ", colors.Yellow);
            this.Print(12, 10, "\\ \\  \\___|\\ \\  \\|\\  \\ \\  \\\\\\__\\ \\  \\ \\  \\ \\  \\\\ \\  \\ \\  \\___|    ", colors.Yellow);
            this.Print(12, 11, " \\ \\  \\  __\\ \\   __  \\ \\  \\\\|__| \\  \\ \\  \\ \\  \\\\ \\  \\ \\  \\  ___  ", colors.Yellow);
            this.Print(12, 12, "  \\ \\  \\|\\  \\ \\  \\ \\  \\ \\  \\    \\ \\  \\ \\  \\ \\  \\\\ \\  \\ \\  \\|\\  \\ ", colors.Yellow);
            this.Print(12, 13, "   \\ \\_______\\ \\__\\ \\__\\ \\__\\    \\ \\__\\ \\__\\ \\__\\\\ \\__\\ \\_______\\", colors.Yellow);
            this.Print(12, 14, "    \\|_______|\\|__|\\|__|\\|__|     \\|__|\\|__|\\|__| \\|__|\\|_______|", colors.Yellow);
            this.Print(36, 29, "Made by: Gurasic", colors.White);

        }

    }
    internal class RootScene2 : AnimatedScreenObject
    {
        public string Title => "RootScene";

        public RootScene2() : base("real",GameSettings.GAME_WIDTH, GameSettings.GAME_HEIGHT)
        {
            var animation = AnimatedScreenObject.FromImage(
            name: "Clumsy Skater",
            filePath: "res/images/afbeelding-11.png",
            frameLayout: new Point(6, 3), // Each frame is 6x3
            frameDuration: TimeSpan.FromSeconds(2),

            pixelPadding: new Point(1, 1), // With 1,1 padding between each frame
            frameStartAndFinish: new Point(0, 15), //x first frae, y last frame
            font: Game.Instance.DefaultFont);

            // Add the animation as a child to the console, the console will handle the rendering
            Children.Add(animation);
            // Position the animation in the parent console
            animation.Position = new Point(2, 2);
            // Make sure it repeats
            animation.Repeat = true;
            //Start playing the animation
            animation.Start();
            Children.Add(animation);
        }
    }
}