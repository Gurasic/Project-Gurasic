﻿using Microsoft.Xna.Framework.Input;
using SadConsole.UI;
using SadConsole.UI.Controls;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

namespace Project_Gurasic.Scenes
{
    internal class CharacterChreation : SadConsole.UI.ControlsConsole
    {
        Random random = new Random();
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

            // - - | Stats | - -

            // Prints the "Stats" Text 
            this.Print(46, 3, "Stats:  (Base)", colors.Green);


            // - Health -

            int playerHealth = 100;

            // Prints the "Health" Text 
            this.Print(46, 5, "Health", colors.Red);

            // Prints the health value
            this.Print(48, 6, Convert.ToString(playerHealth), colors.RedDark);


            // - Defense -

            int playerDefense = 100;

            // Prints the "Defense" Text 
            this.Print(54, 5, "Defense", colors.Gray);

            // Prints the Defense value
            this.Print(56, 6, Convert.ToString(playerDefense), colors.GrayDark);


            // - Attack -

            int playerAttack = 100;

            // Prints the "Attack" Text 
            this.Print(63, 5, "Attack", colors.Cyan);

            // Prints the Attack value
            this.Print(64, 6, Convert.ToString(playerAttack), colors.CyanDark);


            // - Charisma -

            int playerCharisma = 20;

            // Prints the "Charisma" Text 
            this.Print(71, 5, "Charisma", colors.Silver);

            // Prints the Charisma value
            this.Print(74, 6, Convert.ToString(playerCharisma), colors.SilverDark);

            // - Luck -

            int playerLuck = 50;

            // Prints the "Luck" Text 
            this.Print(81, 5, "Luck", colors.Green);

            // Prints the Luck value
            this.Print(82, 6, Convert.ToString(playerLuck), colors.GreenDark);


            // - - | Traits Selection | - -


            //The All mighty Box
            Surface.DrawBox(new Rectangle(1, 11, 35, 7), ShapeParameters.CreateBorder(new ColoredGlyph(Color.Yellow, Color.Black, '#')));

            //Prints the "Cosen Traits" Text 
            this.Print(3, 14, "Chosen Traits: ", colors.Orange);

            // Traits Menu Options
            var buttonSkills = new SelectionButton(12, 1)
            {
                Text = "Traits",
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