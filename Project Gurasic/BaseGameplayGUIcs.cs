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
        public static int PlayerTime = 700;

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
                Game.Instance.DestroyDefaultStartingConsole();
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
                Game.Instance.DestroyDefaultStartingConsole();
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
                Game.Instance.DestroyDefaultStartingConsole();
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
        public static int InventorySpace = 50;
        InventoryItem[] inventory = new InventoryItem[InventorySpace];

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
            } //$"{inventory[i].Name} [{inventory[i].Quantity}]"
        }
        public void DisplayInventory(int rows)
        {
            int startX = 7; 
            int startY = 6; 
            int itemsPerRow = 5; 

            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] != null)
                {
                    // Print the symbol for the item at the specified coordinates
                    this.Print(startX, startY, $"{inventory[i].Name} [{inventory[i].Quantity}]", Color.Gray);
                }
                else
                {
                    // If the slot is empty, print a space
                    this.Print(startX, startY, " ", Color.Gray);
                }

                // Move to the next column
                startX += 16; // Adjust this value for the desired spacing

                // Check if it's time to move to the next row
                if ((i + 1) % itemsPerRow == 0)
                {
                    startX = 7; // Reset the X-coordinate for the next row
                    startY += 2; // Adjust this value for the desired vertical spacing
                }

                // Check if it's time to move to the next section (new row)
                if ((i + 1) % (itemsPerRow * rows) == 0)
                {
                    startY += 2; // Add extra vertical spacing for new sections
                }
            }
        }
        public PlayerInventory() : base(160, 160)
        {
            // The Mighty Box
            Surface.DrawBox(new Rectangle(1, 1, 88, 28), ShapeParameters.CreateBorder(new ColoredGlyph(Color.AnsiBlueBright, Color.Black, '#')));

            this.Print(4, 3, "Inventory: ", Color.LightSlateGray);
            this.Print(68, 3, "Inventory size: " + InventorySpace, Color.LightSlateGray);

            for (int i = 1; i < 51; i++) { AddItem("item" + i, 1); }

            DisplayInventory(10);

            // Return Button*
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
                Game.Instance.DestroyDefaultStartingConsole();
            };
        }


    }

}
