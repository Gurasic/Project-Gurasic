using Microsoft.Xna.Framework.Input;
using SadConsole.UI;
using SadConsole.UI.Controls;

namespace Project_Gurasic.Scenes
{
     internal class CharacterChreation : SadConsole.UI.ControlsConsole
    {
        public string Title => "CharacterChreation";

        public CharacterChreation() : base(GameSettings.GAME_WIDTH, GameSettings.GAME_HEIGHT)
        {
            var colors = Controls.GetThemeColors();


            //Prints the "Character Creation" Text on top of the screen
            this.Print(1, 1, "Character Creation: ", colors.Yellow);

            //The TextBox and the Text for the "Name" that is displayed on the screen
            this.Print(1, 3, "Name:", colors.Green);
            var txtBoxChrName = new TextBox(10)
            {
                Position = new Point(7, 3),
            };
            txtBoxChrName.Resize(12, 1);

            Controls.Add(txtBoxChrName);

            //The TextBox and the Text for the "Name" that is displayed on the screen
            this.Print(1, 5, "NickName:", colors.Green);
            var txtBoxChrNickName = new TextBox(10)
            {
                Position = new Point(11, 5),
            };
            txtBoxChrName.Resize(14, 1);
            Controls.Add(txtBoxChrNickName);



            // - - | Gender Selection | - -

            // Prints the "Gender" Text 
            this.Print(1, 8, "Gender: ", colors.Green);

            // The Buttons Themselfs

            var selMaleButton = new SelectionButton(8, 1)
            {
                Text = "Male",
                Position = new Point(9, 8)
            };
            var colorMaleButton = selMaleButton.FindThemeColors().Clone();
            colorMaleButton.ControlForegroundNormal.SetColor(Color.LightBlue);
            colorMaleButton.RebuildAppearances();
            selMaleButton.SetThemeColors(colorMaleButton);
            Controls.Add(selMaleButton);

            var selFemaleButton = new SelectionButton(10, 1)
            {
                Text = "Female",
                Position = new Point(18, 8),
            };
            var colorFemaleButton = selFemaleButton.FindThemeColors().Clone();
            colorFemaleButton.ControlForegroundNormal.SetColor(Color.LightPink);
            colorFemaleButton.RebuildAppearances();
            selMaleButton.SetThemeColors(colorFemaleButton);
            Controls.Add(selFemaleButton);

            // The Logic Behind The Selection Buttons
            selMaleButton.PreviousSelection = selFemaleButton;
            selMaleButton.NextSelection = selFemaleButton;
            selFemaleButton.PreviousSelection = selMaleButton;
            selFemaleButton.NextSelection = selMaleButton;



            // - - | Skill Selection | - -


            //The All mighty Box
            Surface.DrawBox(new Rectangle(1, 11, 35, 7), ShapeParameters.CreateBorder(new ColoredGlyph(Color.Yellow, Color.Black, '#')));

            //Prints the "Cosen Skills" Text 
            this.Print(3, 14, "Chosen Skills: ", colors.Orange);

            // Skill Menu Options
            var buttonSkills = new SelectionButton(12, 1)
            {
                Text = "Skills",
                Position = new Point(12, 12)
            };

            var colorbuttonSkills = buttonSkills.FindThemeColors().Clone();
            colorbuttonSkills.ControlForegroundNormal.SetColor(Color.OrangeRed);
            colorbuttonSkills.RebuildAppearances();
            selMaleButton.SetThemeColors(colorbuttonSkills);
            Controls.Add(buttonSkills);
        }

    }
}