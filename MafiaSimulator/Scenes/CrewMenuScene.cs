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
                    var tempPlayer = DataManager.FetchMyContent<Player>(0);

                    var tempCrew = tempPlayer.MyCrew;

                    Program.DisplayPlayerStats();
                    var aLastDigit = 0;
                    for (var i = 0; i < tempCrew.Count; i++, aLastDigit++)
                    {
                        Program.ConsoleWriteLine(
                            $"{i} : {tempCrew[i].GetName}      Cost: {tempCrew[i].GetCost}");
                    }

                    if (tempCrew.Count == 0)
                        Program.ConsoleWriteLine($"it's so empty in here!");

                    Program.ConsoleWriteLine($"{aLastDigit} : Go back to previous menu");
                    Program.ConsoleWriteLine("Please enter your the Crew member you want to inspect");

                    var tempInput = int.TryParse(Console.ReadLine(), out var temp) ? temp : throw new Exception("This isn't a Number!");

                    if (tempInput == aLastDigit || aLastDigit == 0)
                    {
                        Program.ConsoleWriteContinue("Returning to last menu!");
                        return;
                    }

                    if (aLastDigit < tempInput || tempInput < 0)
                        throw new Exception("This isn't a valid number!");

                    DisplayCrewInfo(tempCrew[tempInput], tempPlayer);
                }
                catch (Exception e)
                {
                    Program.ConsoleWriteContinue(e.Message, ConsoleColor.Red, ConsoleColor.Red);
                }
            }
        }

        private void DisplayCrewInfo(Crew aCrew, Player aPlayer)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Program.DisplayPlayerStats();
                    aCrew.ShowStats(true, false);
                    Program.ConsoleWriteLine($"1 : Add Items from inventory");
                    Program.ConsoleWriteLine($"2 : Remove Items from inventory");
                    Program.ConsoleWriteLine($"3 : Go back to previous menu");
                    switch (int.TryParse(Console.ReadLine(), out var tempInput)
                        ? tempInput
                        : throw new Exception("This isn't a Number!"))
                    {
                        case 1:
                            AddItems(aCrew, aPlayer);
                            break;
                        case 2:
                            RemoveItems(aCrew, aPlayer);
                            break;
                        case 3:
                            Program.ConsoleWriteContinue("You go to the previous menu!");
                            return;
                        default:
                            throw new Exception("This isn't a valid number!");
                    }
                }
                catch (Exception e)
                {
                    Program.ConsoleWriteContinue(e.Message, ConsoleColor.Red,ConsoleColor.Red);
                } 
            }
        }

        private int ShowItems(List<Item> tempItems)
        {
            var aLastDigit = 0;
            for (var i = 0; i < tempItems.Count; i++, aLastDigit++)
                Program.ConsoleWriteLine($"{i} : {tempItems[i].GetName}      Level: {tempItems[i].GetLevel}     Type: {(tempItems[i].GetType == 0 ? "Weapon" : "Armour" )}");
            
            return aLastDigit;
        }

        private void AddItems(Crew aCrew, Player aPlayer)
        {
            Console.Clear();
            Program.DisplayPlayerStats();
            aCrew.ShowStats(true, false);
            Program.ConsoleWriteLine("Inventory");
                            
            var aLastDigit = ShowItems(aPlayer.MyItems);
            Program.ConsoleWriteLine($"{aLastDigit} : Go back to previous menu");
            Program.ConsoleWriteLine("Please enter the Item you want to add!");
                            
            var tempResult = int.TryParse(Console.ReadLine(), out var temp) ? temp : throw new Exception("This isn't a Number!");
                            
            if (tempResult == aLastDigit || aLastDigit == 0)
            {
                Program.ConsoleWriteContinue("Returning to last menu!");
                return;
            }
            
            if (aLastDigit < tempResult || tempResult < 0)
                throw new Exception("This isn't a valid number!");
            if(aPlayer.MyItems[tempResult].GetType == 0 ? aCrew.AccessWeapon != null : aCrew.AccessArmour != null)
                throw new Exception("This item slot is Occupied!");

            if (aPlayer.MyItems[tempResult].GetType == 0)
                aCrew.AccessWeapon = aPlayer.MyItems[tempResult];
            else
                aCrew.AccessArmour = aPlayer.MyItems[tempResult];
                            
            Program.ConsoleWriteContinue($"{aPlayer.MyItems[tempResult].GetName} Has been added to this character!");
            aPlayer.MyItems.RemoveAt(tempResult);
        }

        private void RemoveItems(Crew aCrew, Player aPlayer)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Program.DisplayPlayerStats();
                    aCrew.ShowStats(true, false);
                    Program.ConsoleWriteLine($"1 : Remove the weapon");
                    Program.ConsoleWriteLine($"2 : Remove the Armour");
                    Program.ConsoleWriteLine($"3 : Go back to previous menu");
                    Program.ConsoleWriteLine("Please enter the Item you want to Remove!");

                    switch (int.TryParse(Console.ReadLine(), out var tempInput) ? tempInput : throw new Exception("This isn't a Number!"))
                    {
                        case 1:
                            if(aCrew.AccessWeapon == null)
                                throw new Exception("This slot is already empty!");
                            aPlayer.MyItems.Add(aCrew.AccessWeapon);
                            aCrew.AccessWeapon = null;
                            Program.ConsoleWriteContinue("The Weapon has been removed!");
                            break;
                        case 2:
                            if(aCrew.AccessArmour == null)
                                throw new Exception("This slot is already empty!");
                            aPlayer.MyItems.Add(aCrew.AccessArmour);
                            aCrew.AccessArmour = null;
                            Program.ConsoleWriteContinue("The Armour has been removed!");
                            break;
                        case 3: 
                            Program.ConsoleWriteContinue("You go to the previous menu!"); 
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