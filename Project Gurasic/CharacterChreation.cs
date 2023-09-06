using Microsoft.Xna.Framework.Input;
using SadConsole.Input;
using SadConsole.UI;
using SadConsole.UI.Controls;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Text.Json;
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
            String txtBoxNameline = File.ReadLines("SavedInfo.txt").Skip(0).Take(1).First();
            txtBoxChrName.Text = txtBoxNameline;
            Controls.Add(txtBoxChrName);

            //The TextBox and the Text for the "Name" that is displayed on the screen
            this.Print(1, 5, "NickName:", colors.Green);
            var txtBoxChrNickName = new TextBox(10)
            {
                Position = new Point(11, 5),
            };
            txtBoxChrName.Resize(14, 1);
            String txtBoxNickNameline = File.ReadLines("SavedInfo.txt").Skip(1).Take(1).First();
            txtBoxChrNickName.Text = txtBoxNickNameline;
            Controls.Add(txtBoxChrNickName);

            //Finish Button
            var finishbutton = new SelectionButton(8, 1)
            {
                Text = "Finish",
                Position = new Point(2, 25)
            };
            Controls.Add(finishbutton);

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

            int playerDefense = 10;

            // Prints the "Defense" Text 
            this.Print(54, 5, "Defense", colors.Gray);

            // Prints the Defense value
            this.Print(56, 6, Convert.ToString(playerDefense), colors.GrayDark);


            // - Attack -

            int playerAttack = 15;

            // Prints the "Attack" Text 
            this.Print(63, 5, "Attack", colors.Cyan);

            // Prints the Attack value
            this.Print(64, 6, Convert.ToString(playerAttack), colors.CyanDark);


            // - Charisma -

            int playerCharisma = 20;

            // Prints the "Charisma" Text 
            this.Print(71, 5, "Charisma", colors.Purple);

            // Prints the Charisma value
            this.Print(74, 6, Convert.ToString(playerCharisma), colors.PurpleDark);

            // - Luck -

            int playerLuck = 50;

            // Prints the "Luck" Text 
            this.Print(81, 5, "Luck", colors.Green);

            // Prints the Luck value
            this.Print(82, 6, Convert.ToString(playerLuck), colors.GreenDark);


            // - - | Traits Selection | - -

            // Getting Trait Data
            ReadingTraitData();

            void ReadingTraitData()
            {
                int startingSpacePositive = 3;
                int startingSpaceNegative = 3;
                this.Print(startingSpacePositive, 15, "[---]", colors.Gray);
                for (int i = 0; i < TraitSelection.ChosenTraitsPositive.Length; i++)
                {
                    this.Print(startingSpacePositive, 15, TraitSelection.ChosenTraitsPositive[i], colors.Green);
                    startingSpacePositive += TraitSelection.SpaceBettwenTraitsPositive[i];
                }
                for (int i = 0; i < TraitSelection.ChosenTraitsNegative.Length; i++)
                {
                    this.Print(startingSpaceNegative, 16, TraitSelection.ChosenTraitsNegative[i], colors.Red);
                    startingSpaceNegative += TraitSelection.SpaceBettwenTraitsNegative[i];
                }
            }

            //The All mighty Box
            Surface.DrawBox(new Rectangle(1, 11, 39, 7), ShapeParameters.CreateBorder(new ColoredGlyph(Color.Yellow, Color.Black, '#')));

            //Prints the "Cosen Traits" Text 
            this.Print(3, 14, "Chosen Traits: ", colors.Orange);

            // Traits Menu Options
            var buttonTraits = new SelectionButton(12, 1)
            {
                Text = "Traits",
                Position = new Point(14, 12)
            };

            var colorbuttonTraits = buttonTraits.FindThemeColors().Clone();
            colorbuttonTraits.ControlForegroundNormal.SetColor(Color.OrangeRed);
            colorbuttonTraits.RebuildAppearances();
            selMaleButton.SetThemeColors(colorbuttonTraits);
            Controls.Add(buttonTraits);



            // ----- Saving Data to a .txt file -----

            String playerGender = null;

            // Checks the geneder button that is pressed and uptades playerGender String acordingly
            selFemaleButton.Click += (s, e) => { playerGender = "Female"; };
            selMaleButton.Click += (s, e) => { playerGender = "Male"; };
            finishbutton.Click += (s, e) =>
            {
                using (StreamWriter writer = new StreamWriter("PlayerInfo.txt"))
                {
                    writer.WriteLine("- - - Player Info - - -");
                    writer.WriteLine(" ");
                    writer.WriteLine(" ");
                    writer.WriteLine("Player Name:");
                    writer.WriteLine(txtBoxChrName.Text);
                    writer.WriteLine(" ");
                    writer.WriteLine("Player Nickname:");
                    writer.WriteLine(txtBoxChrNickName.Text);
                    writer.WriteLine(" ");
                    writer.WriteLine("Player Gender:");
                    writer.WriteLine(playerGender);
                    writer.WriteLine(" ");
                    writer.WriteLine(" ");
                    writer.WriteLine(" - - - Stats - - -");
                    writer.WriteLine("Health:");
                    writer.WriteLine(playerHealth);
                    writer.WriteLine("Defense: ");
                    writer.WriteLine(playerDefense);
                    writer.WriteLine("Attack: ");
                    writer.WriteLine(playerAttack);
                    writer.WriteLine("Charisma: ");
                    writer.WriteLine(playerCharisma);
                    writer.WriteLine("Luck: ");
                    writer.WriteLine(playerLuck);
                    writer.WriteLine(" ");
                    writer.WriteLine(" ");
                    writer.WriteLine("- - - Traits - - -");
                    writer.WriteLine("Positive Traits:");
                    writer.WriteLine(" ");
                    for (int i = 0; i < TraitSelection.ChosenTraitsPositive.Length; i++)
                    {
                        writer.WriteLine(TraitSelection.ChosenTraitsPositive[i]);
                    }
                    writer.WriteLine(" ");
                    writer.WriteLine("Negative Traits:");
                    writer.WriteLine(" ");
                    for (int i = 0; i < TraitSelection.ChosenTraitsNegative.Length; i++)
                    {
                        writer.WriteLine(TraitSelection.ChosenTraitsNegative[i]);
                    }
                }

                string fileName = "PlayerData.json";
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(txtBoxChrName.Text, options);
                File.WriteAllText(fileName, txtBoxChrName.Text);

                using (StreamWriter writer = new StreamWriter("SavedInfo.txt"))
                {
                    writer.WriteLine(" ");
                    writer.WriteLine(" ");
                    writer.Close();
                }
            };

            buttonTraits.Click += (s, e) =>
            {

                using (StreamWriter writer = new StreamWriter("SavedInfo.txt"))
                {
                    writer.WriteLine(txtBoxChrName.Text);
                    writer.WriteLine(txtBoxChrNickName.Text);
                    writer.Close();
                }
                Game.Instance.Screen = new TraitSelection();
                Game.Instance.DestroyDefaultStartingConsole();
            };
  
        }
    }
    internal class TraitSelection : SadConsole.UI.ControlsConsole
    {
        public string Title => "TraitSelection";

        private readonly ScreenSurface _mouseCursor;

        // The array that will Store the data
        public static string[] ChosenTraitsPositive = new string[3];
        public static string[] ChosenTraitsNegative = new string[4];
        public static int[] SpaceBettwenTraitsPositive = new int[3];
        public static int[] SpaceBettwenTraitsNegative = new int[4];
        public TraitSelection() : base(GameSettings.GAME_WIDTH, GameSettings.GAME_HEIGHT)
        {
            UseKeyboard = false;
            UseMouse = true;

            var colors = Controls.GetThemeColors();
            int amountOfTraitsYouGet = 3;
            int SperationBetwenTraits = 1;

            // Prints the "Trait Selector" Text on top of the screen
            this.Print(1, 1, "Trait Selector: ", colors.Yellow);

            // Prints the amount of traits the player can choose

            this.Print(40, 1, "Choose " + amountOfTraitsYouGet + " Traits", colors.Yellow);

            // Prints the chosen Traits
            this.Print(1, 20, "You Chose: ", colors.Yellow);

            // Another All Might Box Were the traits are explained
            Surface.DrawBox(new Rectangle(52, 3, 37, 13), ShapeParameters.CreateBorder(new ColoredGlyph(Color.Yellow, Color.Black, '#')));

            // Finish Button
            var finishbutton = new SelectionButton(8, 1)
            {
                Text = "Finish",
                Position = new Point(2, 25),

            };
            Controls.Add(finishbutton);

            // Prints the "Positive Traits" Text
            this.Print(1, 4, "Positive Traits: ", colors.Green);

            // Prints the "Negative Traits" Text
            this.Print(1, 8, "Negative Traits: ", colors.Red);

            _mouseCursor = new SadConsole.ScreenSurface(1, 1);
            _mouseCursor.Surface.SetGlyph(0, 0, 178);
            _mouseCursor.UseMouse = false;

            Children.Add(_mouseCursor);


            // Positive Trais Buttons
            var strongTraitButton = new SelectionButton(10, 1)
            {
                Text = "[Strong]",
                Position = new Point(1, 5),
                ShowEnds = false
            };
            Controls.Add(strongTraitButton);

            var SkilledTraitButton = new SelectionButton(11, 1)
            {
                Text = "[Skilled]",
                Position = new Point(11, 5),
                ShowEnds = false

            };
            Controls.Add(SkilledTraitButton);

            var BigTraitButton = new SelectionButton(7, 1)
            {
                Text = "[Big]",
                Position = new Point(22, 5),
                ShowEnds = false

            };
            Controls.Add(BigTraitButton);


            // Negative Traits Buttons
            var weakTraitButton = new SelectionButton(8, 1)
            {
                Text = "[Weak]",
                Position = new Point(1, 9),
                ShowEnds = false
            };
            Controls.Add(weakTraitButton);

            var softSkinTraitButton = new SelectionButton(13, 1)
            {
                Text = "[Soft Skin]",
                Position = new Point(9, 9),
                ShowEnds = false
            };
            Controls.Add(softSkinTraitButton);
  
            var dumbTraitButton = new SelectionButton(8, 1)
            {
                Text = "[Dumb]",
                Position = new Point(22, 9),
                ShowEnds = false

            };
            Controls.Add(dumbTraitButton);

            var smallTraitButton = new SelectionButton(9, 1)
            {
                Text = "[Small]",
                Position = new Point(30, 9),
                ShowEnds = false
            };
            Controls.Add(smallTraitButton);


 

            // All the Logic Behind the Traits (just displaying them)
            bool strongTraitBool = true;
            strongTraitButton.Click += (s, e) =>
            {
                if (strongTraitBool)
                {
                    TraitDisplay(9, 21, colors.Green, "[Strong]", 0);
                    strongTraitBool = false;
                    ChosenTraitsPositive[0] = "[Strong]";
                    SpaceBettwenTraitsPositive[0] = 9;
                }
                this.Print(40, 1, $"Choose {amountOfTraitsYouGet} Traits", colors.Yellow);
            };

            bool skillledTraitBool = true;
            SkilledTraitButton.Click += (s, e) =>
            {
                if (skillledTraitBool) 
                {    
                    TraitDisplay(10, 21, colors.Green, "[Skilled]", 0);
                    skillledTraitBool = false;
                    ChosenTraitsPositive[1] = "[Skilled]";
                    SpaceBettwenTraitsPositive[1] = 10;
                }
                this.Print(40, 1, $"Choose {amountOfTraitsYouGet} Traits", colors.Yellow);
            };

            bool bigTraitBool = true;
            BigTraitButton.Click += (s, e) =>
            {
                if (bigTraitBool)
                {
                    TraitDisplay(6, 21, colors.Green, "[Big]", 0);
                    bigTraitBool = false;
                    ChosenTraitsPositive[2] = "[Big]";
                    SpaceBettwenTraitsPositive[2] = 6;
                }
                this.Print(40, 1, $"Choose {amountOfTraitsYouGet} Traits", colors.Yellow);
            };

            bool weakTraitBool = true;
            weakTraitButton.Click += (s, e) =>
            {
                if (weakTraitBool) 
                { 
                    TraitDisplay(7, 21, colors.Red, "[Weak]", 1);
                    weakTraitBool = false;
                    ChosenTraitsNegative[0] = "[Weak]";
                    SpaceBettwenTraitsNegative[0] = 7;
                }
                this.Print(40, 1, $"Choose {amountOfTraitsYouGet} Traits", colors.Yellow);
            };

            bool softSkinTraitBool = true;
            softSkinTraitButton.Click += (s, e) =>
            {
                if (softSkinTraitBool) 
                { 
                    TraitDisplay(12, 21, colors.Red, "[Soft Skin]", 1);
                    softSkinTraitBool = false;
                    ChosenTraitsNegative[1] = "[Soft Skin]";
                    SpaceBettwenTraitsNegative[1] = 12;
                }
                this.Print(40, 1, $"Choose {amountOfTraitsYouGet} Traits", colors.Yellow);
            };

            bool dumbTraitBool = true;
            dumbTraitButton.Click += (s, e) =>
            {
                if (dumbTraitBool) 
                { 
                    TraitDisplay(7, 21, colors.Red, "[Dumb]", 1);
                    dumbTraitBool = false;
                    ChosenTraitsNegative[2] = "[Dumb]";
                    SpaceBettwenTraitsNegative[2] = 7;
                }
                this.Print(40, 1, $"Choose {amountOfTraitsYouGet} Traits", colors.Yellow);
            };

            bool smallTraitBool = true;
            smallTraitButton.Click += (s, e) =>
            {
                if (smallTraitBool) 
                { 
                    TraitDisplay(8, 21, colors.Red, "[Small]", 1);
                    smallTraitBool = false;
                    ChosenTraitsNegative[3] = "[Small]";
                    SpaceBettwenTraitsNegative[3] = 8;
                }
                this.Print(40, 1, $"Choose {amountOfTraitsYouGet} Traits", colors.Yellow);
            };

            // Finish Button Logic, It just takes you back to the CharacterChreation Screen
            finishbutton.Click += (s, e) =>
            {
                Game.Instance.Screen = new CharacterChreation();
                Game.Instance.DestroyDefaultStartingConsole();
            };

            // The method that displays the traits the player choose in a line
            void TraitDisplay(int Space, int YLvL, Color Get, String Trait, int amountoftraits)
            {

                if (amountOfTraitsYouGet != 0)
                {
                   if (amountoftraits == 1) { amountOfTraitsYouGet++; }
                   else { amountOfTraitsYouGet--; }
                   this.Print(SperationBetwenTraits, YLvL, Trait, Get);
                   SperationBetwenTraits += Space;
                }
                else
                {
                    SadConsole.UI.Window.Message("- - - You cant chose more Traits - - -", "Close");
                }

            }
        }
        public override bool ProcessMouse(MouseScreenObjectState state)
        {
            _mouseCursor.IsVisible = state.IsOnScreenObject;
            _mouseCursor.Position = state.CellPosition;
            var colors = Controls.GetThemeColors();

            // Strong Trait Info
            for (int i = 2; i < 10; i++) 
            { 
                if (_mouseCursor.Position == state.CellPosition.WithX(i).WithY(5))
                {
                    this.Print(66, 4, "[Strong]", colors.Green);
                    this.Print(54, 6, "This Trait Increses the Attack", colors.Gray);
                    this.Print(54, 7, "Stat by 10 And Defense by 5", colors.Gray);
                }
            }
            return base.ProcessMouse(state);
        }

    }
}