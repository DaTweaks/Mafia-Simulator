using System;
using System.Collections.Generic;
using MafiaSimulator.Data;

namespace MafiaSimulator.Scenes
{
    public class CrewMenuScene : SceneHolder
    {
        public override void Start()
        {
            while (true)
            {
                Console.Clear();
                try
                {
                    var player = DataManager.FetchMyContent<Player>(0);

                    var crew = player.Crew;

                    TextManager.DisplayPlayerStats();
                    var lastDigit = 0;
                    for (var i = 0; i < crew.Count; i++, lastDigit++)
                    {
                        TextManager.ConsoleWriteLine(
                            $"{i} : {crew[i].GetName}      Cost: {crew[i].GetCost}");
                    }

                    if (crew.Count == 0)
                        TextManager.ConsoleWriteLine($"it's so empty in here!");

                    TextManager.ConsoleWriteLine($"{lastDigit} : Go back to previous menu");
                    TextManager.ConsoleWriteLine("Please enter your the Crew member you want to inspect");

                    var input = int.TryParse(Console.ReadLine(), out var temp) ? temp : throw new Exception("This isn't a Number!");

                    if (input == lastDigit || lastDigit == 0)
                    {
                        TextManager.ConsoleWriteContinue("Returning to last menu!");
                        return;
                    }

                    if (lastDigit < input || input < 0)
                        throw new Exception("This isn't a valid number!");

                    DisplayCrewInfo(crew[input], player);
                }
                catch (Exception e)
                {
                    TextManager.ConsoleWriteContinue(e.Message, ConsoleColor.Red, ConsoleColor.Red);
                }
            }
        }

        private void DisplayCrewInfo(Crew crew, Player player)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    TextManager.DisplayPlayerStats();
                    crew.ShowStats(true, false);
                    TextManager.ConsoleWriteLine($"1 : Add Items from inventory");
                    TextManager.ConsoleWriteLine($"2 : Remove Items from inventory");
                    TextManager.ConsoleWriteLine($"3 : Go back to previous menu");
                    switch (int.TryParse(Console.ReadLine(), out var tempInput)
                        ? tempInput
                        : throw new Exception("This isn't a Number!"))
                    {
                        case 1:
                            AddItems(crew, player);
                            break;
                        case 2:
                            RemoveItems(crew, player);
                            break;
                        case 3:
                            TextManager.ConsoleWriteContinue("You go to the previous menu!");
                            return;
                        default:
                            throw new Exception("This isn't a valid number!");
                    }
                }
                catch (Exception e)
                {
                    TextManager.ConsoleWriteContinue(e.Message, ConsoleColor.Red,ConsoleColor.Red);
                } 
            }
        }

        private int ShowItems(List<Item> items)
        {
            var lastDigit = 0;
            for (var i = 0; i < items.Count; i++, lastDigit++)
                TextManager.ConsoleWriteLine($"{i} : {items[i].GetName}      Level: {items[i].GetLevel}     Type: {(items[i].GetType == 0 ? "Weapon" : "Armour" )}");
            
            return lastDigit;
        }

        private void AddItems(Crew crew, Player player)
        {
            Console.Clear();
            TextManager.DisplayPlayerStats();
            crew.ShowStats(true, false);
            TextManager.ConsoleWriteLine("Inventory");
                            
            var lastDigit = ShowItems(player.Items);
            TextManager.ConsoleWriteLine($"{lastDigit} : Go back to previous menu");
            TextManager.ConsoleWriteLine("Please enter the Item you want to add!");
                            
            var input = int.TryParse(Console.ReadLine(), out var temp) ? temp : throw new Exception("This isn't a Number!");
                            
            if (input == lastDigit || lastDigit == 0)
            {
                TextManager.ConsoleWriteContinue("Returning to last menu!");
                return;
            }
            
            if (lastDigit < input || input < 0)
                throw new Exception("This isn't a valid number!");
            if(player.Items[input].GetType == 0 ? crew.AccessWeapon != null : crew.AccessArmour != null)
                throw new Exception("This item slot is Occupied!");

            if (player.Items[input].GetType == 0)
                crew.AccessWeapon = player.Items[input];
            else
                crew.AccessArmour = player.Items[input];
                            
            TextManager.ConsoleWriteContinue($"{player.Items[input].GetName} Has been added to this character!");
            player.Items.RemoveAt(input);
        }

        private void RemoveItems(Crew crew, Player player)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    TextManager.DisplayPlayerStats();
                    crew.ShowStats(true, false);
                    TextManager.ConsoleWriteLine($"1 : Remove the weapon");
                    TextManager.ConsoleWriteLine($"2 : Remove the Armour");
                    TextManager.ConsoleWriteLine($"3 : Go back to previous menu");
                    TextManager.ConsoleWriteLine("Please enter the Item you want to Remove!");

                    switch (int.TryParse(Console.ReadLine(), out var tempInput) ? tempInput : throw new Exception("This isn't a Number!"))
                    {
                        case 1:
                            if(crew.AccessWeapon == null)
                                throw new Exception("This slot is already empty!");
                            player.Items.Add(crew.AccessWeapon);
                            crew.AccessWeapon = null;
                            TextManager.ConsoleWriteContinue("The Weapon has been removed!");
                            break;
                        case 2:
                            if(crew.AccessArmour == null)
                                throw new Exception("This slot is already empty!");
                            player.Items.Add(crew.AccessArmour);
                            crew.AccessArmour = null;
                            TextManager.ConsoleWriteContinue("The Armour has been removed!");
                            break;
                        case 3: 
                            TextManager.ConsoleWriteContinue("You go to the previous menu!"); 
                            return;
                        default: 
                            throw new Exception("This isn't a valid number!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}