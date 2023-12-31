﻿
using Project_Gurasic.Scenes;
using SadConsole.UI.Controls;


namespace Project_Gurasic
{
   
    internal class BaseGameplayGUI : SadConsole.UI.ControlsConsole
    {
       
        public string Title => "CharacterChreation";
        public static int PlayerTimeLeft = 1;
        public static int PlayerTimeRight = 1;
        public static int PlayerDay = 1;
        public static String PlayerSeason = "[Spring]";
        public static int PlayerWeather = 1;

        public BaseGameplayGUI() : base(160, 160)
        {


            // Character Information Box
            Surface.DrawBox(new Rectangle(0, 27, 19, 3), ShapeParameters.CreateBorder(new ColoredGlyph(Color.AnsiBlueBright, Color.Black, '#')));

            // Character Information Button
            var PlayerInfoButton = new SelectionButton(13, 1)
            {
                Text = "[Player Info]",
                Position = new Point(3, 28),
                ShowEnds = false

            };
            Controls.Add(PlayerInfoButton);

            // Character Information Logic
            PlayerInfoButton.Click += (s, e) =>
            {
                Game.Instance.Screen = new PlayerInfo();
            };

            // Inventory Box
            Surface.DrawBox(new Rectangle(19, 27, 17, 3), ShapeParameters.CreateBorder(new ColoredGlyph(Color.SlateBlue, Color.Black, '#')));

            // Inventory Button 
            var PlayerInventoryButton = new SelectionButton(11, 1)
            {
                Text = "[Inventory]",
                Position = new Point(22, 28),
                ShowEnds = false

            };
            Controls.Add(PlayerInventoryButton);

            // Inventory Logic
            PlayerInventoryButton.Click += (s, e) =>
            {
                Game.Instance.Screen = new PlayerInventory();
            };

            // Skills Box
            Surface.DrawBox(new Rectangle(36, 27, 14, 3), ShapeParameters.CreateBorder(new ColoredGlyph(Color.AnsiBlueBright, Color.Black, '#')));

            // Skills Button 
            var PlayerSkillsButton = new SelectionButton(11, 1)
            {
                Text = "[Skills]",
                Position = new Point(37, 28),
                ShowEnds = false

            };
            Controls.Add(PlayerSkillsButton);

            // Move Box
            Surface.DrawBox(new Rectangle(50, 27, 14, 3), ShapeParameters.CreateBorder(new ColoredGlyph(Color.SlateBlue, Color.Black, '#')));
           
            // Move Button 
            var PlayerMoveButton = new SelectionButton(11, 1)
            {
                Text = "[Move]",
                Position = new Point(51, 28),
                ShowEnds = false

            };
            Controls.Add(PlayerMoveButton);


            // Inventory Logic
            PlayerSkillsButton.Click += (s, e) =>
            {
                Game.Instance.Screen = new PlayerSkills();
            };

            // Season Box
            Surface.DrawBox(new Rectangle(76, 0, 14, 3), ShapeParameters.CreateBorder(new ColoredGlyph(Color.AnsiBlueBright, Color.Black, '#')));

            // Season Logic
            if (PlayerDay == 31 && PlayerSeason == "[Spring]")
            {
                PlayerSeason = "[Summer]";
                PlayerDay = 1;
            }
            else if (PlayerDay == 31 && PlayerSeason == "[Summer]")
            {
                PlayerSeason = "[Fall]";
                PlayerDay = 1;
            }
            else if (PlayerDay == 31 && PlayerSeason == "[Fall]")
            {
                PlayerSeason = "[Winter]";
                PlayerDay = 1;
            }
            else if (PlayerDay == 31 && PlayerSeason == "[Winter]")
            {
                PlayerSeason = "[Spring]";
                PlayerDay = 1;
            }

            // Displaying Seasons Logic
            if (PlayerSeason == "[Spring]")
            {
                this.Print(79, 1, PlayerSeason, Color.LightPink);
            }
            else if (PlayerSeason == "[Summer]")
            {
                this.Print(79, 1, PlayerSeason, Color.LightGoldenrodYellow);
            }
            else if (PlayerSeason == "[Fall]")
            {
                this.Print(80, 1, PlayerSeason, Color.AnsiYellow);
            }
            else if (PlayerSeason == "[Winter]")
            {
                this.Print(79, 1, PlayerSeason, Color.LightSteelBlue);
            }

            // Day Box
            Surface.DrawBox(new Rectangle(69, 2, 11, 3), ShapeParameters.CreateBorder(new ColoredGlyph(Color.AnsiBlueBright, Color.Black, '#')));
            this.Print(71, 3, "Day: " + PlayerDay, Color.LightSteelBlue);

            // Day Box

            if (PlayerWeather == 1) { this.Print(68, 1, "[Sunny]", Color.AnsiYellowBright); }
            if (PlayerWeather == 2) { this.Print(68, 1, "[Cludy]", Color.DarkGray); }
            if (PlayerWeather == 3) { this.Print(68, 1, "[Rainy]", Color.CornflowerBlue); }
            Surface.DrawBox(new Rectangle(66, 0, 11, 3), ShapeParameters.CreateBorder(new ColoredGlyph(Color.AnsiBlueBright, Color.Black, '#')));


            // Time box
            Surface.DrawBox(new Rectangle(79, 2, 11, 3), ShapeParameters.CreateBorder(new ColoredGlyph(Color.AnsiBlueBright, Color.Black, '#')));

            // Time Logic
            String empty0 = "0";
            String empty02 = "0";
            if (PlayerTimeRight == 60) { PlayerTimeLeft++; PlayerTimeRight = 0; }
            if (PlayerTimeLeft == 24) { PlayerDay++; PlayerTimeLeft = 1; }
            if (PlayerTimeRight == 10) { empty02 = ""; }
            if (PlayerTimeLeft == 10) { empty0 = ""; }

            this.Print(82,3, empty0 + PlayerTimeLeft + ":" + empty02 + PlayerTimeRight, Color.LightSteelBlue);
        }
        public void returnButton() 
        {
            // Return Box
            Surface.DrawBox(new Rectangle(0, 1, 14, 3), ShapeParameters.CreateBorder(new ColoredGlyph(Color.SlateBlue, Color.Black, '#')));

            // Return Button 
            var PlayerReturnButton = new SelectionButton(11, 1)
            {
                Text = "[Return]",
                Position = new Point(1, 2),
                ShowEnds = false

            };
            Controls.Add(PlayerReturnButton);

            PlayerReturnButton.Click += (s, e) =>
            {
                Game.Instance.Screen = GameSettings.LastScreen;
            };
        }
    }
    internal class PlayerInfo : SadConsole.UI.ControlsConsole
    {
        public PlayerInfo() : base(160, 160)
        {

            var colors = Controls.GetThemeColors();

            // The Mighty Box
            Surface.DrawBox(new Rectangle(1, 1, 88, 28), ShapeParameters.CreateBorder(new ColoredGlyph(Color.AnsiBlueBright, Color.Black, '#')));

            // - - - Reading Data From PlayerInfo.txt - - -

            // Name
            string PlayerName = File.ReadLines("PlayerInfo.txt").Skip(4).Take(1).First();
            this.Print(3, 3, "Player Name: ", Color.LightSlateGray);
            this.Print(16, 3, PlayerName, Color.Snow);

            // NickName
            string PlayerNickName = File.ReadLines("PlayerInfo.txt").Skip(7).Take(1).First();
            this.Print(3, 4, "Player Nickname: ", Color.LightSlateGray);
            this.Print(20, 4, PlayerNickName, Color.Snow);

            // Gender
            string PlayerGender = File.ReadLines("PlayerInfo.txt").Skip(10).Take(1).First();
            this.Print(3, 6, "Gender: ", Color.LightSlateGray);
            if (PlayerGender == "[Female]") { this.Print(11, 6, "[Female]", Color.LightPink); }
            if (PlayerGender == "[Male]") { this.Print(11, 6, "[Male]", Color.LightBlue); }

            // Traits
            this.Print(3, 8, "Traits: ", Color.LightSlateGray);
            this.Print(3, 10, "Positive Traits: ", Color.LightGreen);
            this.Print(3, 13, "Negative Traits: ", Color.Coral);
            this.Print(3, 11, "[---]", Color.Gray);
            this.Print(3, 14, "[---]", Color.Gray);
            int startingSpacePositive = 3;
            int startingSpaceNegative = 3;
            for (int i = 0; i < TraitSelection.ChosenTraitsPositive.Length; i++)
            {
                this.Print(startingSpacePositive, 11, TraitSelection.ChosenTraitsPositive[i], Color.Green);
                startingSpacePositive += TraitSelection.SpaceBettwenTraitsPositive[i];
            }
            for (int i = 0; i < TraitSelection.ChosenTraitsNegative.Length; i++)
            {
                this.Print(startingSpaceNegative, 14, TraitSelection.ChosenTraitsNegative[i], Color.Red);
                startingSpaceNegative += TraitSelection.SpaceBettwenTraitsNegative[i];
            }

            // Stats

            this.Print(45, 3, "Stats: ", Color.LightSlateGray);

            string PlayerHealthValue = File.ReadLines("PlayerInfo.txt").Skip(15).Take(1).First();
            this.Print(45, 5, "Health", colors.Red);
            this.Print(47, 6, PlayerHealthValue, colors.RedDark);

            string PlayerDefenseValue = File.ReadLines("PlayerInfo.txt").Skip(17).Take(1).First();
            this.Print(53, 5, "Defense", colors.Gray);
            this.Print(55, 6, PlayerDefenseValue, colors.GrayDark);

            string PlayerAttackValue = File.ReadLines("PlayerInfo.txt").Skip(19).Take(1).First();
            this.Print(62, 5, "Attack", colors.Cyan);
            this.Print(63, 6, PlayerAttackValue, colors.CyanDark);

            string PlayerCharaismaValue = File.ReadLines("PlayerInfo.txt").Skip(21).Take(1).First();
            this.Print(70, 5, "Charisma", colors.Purple);
            this.Print(73, 6, PlayerCharaismaValue, colors.PurpleDark);

            string PlayerLuckValue = File.ReadLines("PlayerInfo.txt").Skip(23).Take(1).First();
            this.Print(80, 5, "Luck", colors.Green);
            this.Print(81, 6, PlayerLuckValue, colors.GreenDark);

            // Return Button
            var ReturnButton = new SelectionButton(11, 1)
            {
                Text = "[Return]",
                Position = new Point(4, 26),
                ShowEnds = false

            };
            Controls.Add(ReturnButton);

            // Player Info Logic
            ReturnButton.Click += (s, e) =>
            {
                Game.Instance.Screen = GameSettings.LastScreen;
            };
        }
    }
    class InventoryItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }

    internal class PlayerInventory : SadConsole.UI.ControlsConsole
    {
        public static int InventorySize = 10;
        public static int InventorySpacing = 2;
        InventoryItem[] inventory = new InventoryItem[InventorySize];

        // This is were the magic happens

        public void AddItem(string name, int quantity)
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] != null && inventory[i].Name == name)
                {
                    inventory[i].Quantity += quantity;
                    return; 
                }
            }
  
            InventoryItem newItem = new InventoryItem
            {
                Name = name,
                Quantity = quantity
            };

            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] == null)
                {
                    inventory[i] = newItem;
                    break;
                }
            }
        }

        public void RemoveItem(string name, int quantityToRemove)
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] != null && inventory[i].Name == name)
                {
                    if (inventory[i].Quantity <= quantityToRemove)
                    {  
                        inventory[i] = null;
                    }
                    else
                    {
                        inventory[i].Quantity -= quantityToRemove;
                    }
                    return; 
                }
            } 
        }
        public void DisplayInventory(int rows)
        {
            int startX = 6; 
            int startY = 5; 
            int itemsPerRow = 5; 

            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] != null)
                {
                    this.Print(startX, startY, $"{inventory[i].Name} [{inventory[i].Quantity}]", Color.Gray);
                }
                else
                {
                    this.Print(startX, startY, " ", Color.Gray);
                }

                startX += 16; 

                if ((i + 1) % itemsPerRow == 0)
                {
                    startX = 6; 
                    startY += 2; 
                }

                if ((i + 1) % (itemsPerRow * rows) == 0)
                {
                    startY += 2; 
                }
            }
        }
        public PlayerInventory() : base(160, 160)
        {
            // The Mighty Box
            Surface.DrawBox(new Rectangle(1, 1, 88, 28), ShapeParameters.CreateBorder(new ColoredGlyph(Color.AnsiBlueBright, Color.Black, '#')));

            this.Print(4, 3, "Inventory: ", Color.LightSlateGray);
            this.Print(68, 3, "Inventory size: " + InventorySize, Color.LightSlateGray);
   
            DisplayInventory(InventorySpacing);

            // Return Button
            var ReturnButton = new SelectionButton(11, 1)
            {
                Text = "[Return]",
                Position = new Point(2, 26),
                ShowEnds = false

            };
            Controls.Add(ReturnButton);

            // Player Info Logic
            ReturnButton.Click += (s, e) =>
            {
                Game.Instance.Screen = GameSettings.LastScreen;
            };
        }
    }
    class SkillInfo
    {
        public string Name { get; set; }
        public int Sequence { get; set; }
        public int Level { get; set; }
        public int CurrentExp { get; set; }
        public int TargetExp { get; set; }
        public ProgressBar ProgressBar { get; set; }
    }
    internal class PlayerSkills : SadConsole.UI.ControlsConsole
    {
        private Dictionary<string, SkillInfo> _skillCache = new Dictionary<string, SkillInfo>(StringComparer.OrdinalIgnoreCase);

        String[] PlayerSkillsArray = new String[10];

        public void SetSkill(string name, int level, int currentExp, int targetExp)
        {
            int startx = 4, starty = 5;
            float progressBar = Math.Min(currentExp, targetExp) / (float)targetExp;
            // If skill does not yet exist, add it
            if (!_skillCache.TryGetValue(name, out SkillInfo skillInfo))
            {
                var highestSeq = _skillCache.Count > 0 ? _skillCache.Values.Max(x => x.Sequence) : -1;
                highestSeq++;

                skillInfo = new SkillInfo { Name = name, Sequence = highestSeq };
                _skillCache.Add(name, skillInfo);

                // Add progress bar when its a new skill
                int startxBar = 4;
                startx += 20 * skillInfo.Sequence;
                skillInfo.ProgressBar = new ProgressBar(16, 1, HorizontalAlignment.Left) { Position = new Point(startx, starty + 1) };
                skillInfo.ProgressBar.BackgroundGlyph = '=';
                skillInfo.ProgressBar.DisplayText = "";
                skillInfo.ProgressBar.Progress = progressBar;
                Controls.Add(skillInfo.ProgressBar);
            }

            // Set properties
            skillInfo.Level = level;
            skillInfo.CurrentExp = currentExp;
            skillInfo.TargetExp = targetExp;
            skillInfo.TargetExp = Convert.ToInt32(CalculateRequiredExpForLevel(skillInfo.Level));
            if (currentExp >= targetExp)
            {
                skillInfo.CurrentExp = 0; skillInfo.Level++;
                skillInfo.ProgressBar.Progress = 0;
                skillInfo.TargetExp = Convert.ToInt32(CalculateRequiredExpForLevel(skillInfo.Level));
            }

            // Update rendering

            this.Print(startx, starty, "                ", Color.White);
            this.Print(startx, starty, skillInfo.Name, Color.White);
            var levelText = "Lv: " + skillInfo.Level;
            this.Print(startx + skillInfo.ProgressBar.Width - levelText.Length, starty, levelText, Color.AnsiWhite);
        }

        private double baseExp = 20; 
        private double initialMultiplier = 0.5; 
        private double increment = 0.3; 

        public double CalculateRequiredExpForLevel(int level)
        {
            double expMultiplier = initialMultiplier + (level - 1) * increment;
            return baseExp * Math.Pow(expMultiplier, level - 1);
        }
        public PlayerSkills() : base(160, 160) 
        {

            // The Mighty Box
            Surface.DrawBox(new Rectangle(1, 1, 88, 28), ShapeParameters.CreateBorder(new ColoredGlyph(Color.AnsiBlueBright, Color.Black, '#')));

            this.Print(4, 3, "Player Skills: ", Color.LightSlateGray);

            // Return Button
            var ReturnButton = new SelectionButton(11, 1)
            {
                Text = "[Return]",
                Position = new Point(2, 26),
                ShowEnds = false

            };
            Controls.Add(ReturnButton);

            SetSkill("Test", 1, 21, 20);
            SetSkill("Test2", 1, 0, 20);
            SetSkill("Test3", 1, 0, 20);


            // Player Info Logic
            ReturnButton.Click += (s, e) =>
            {
                Game.Instance.Screen = GameSettings.LastScreen;
            };   
            
        }

    }
}