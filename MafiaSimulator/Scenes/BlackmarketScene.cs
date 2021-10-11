using System;
using System.Collections.Generic;
using MafiaSimulator.Data;

namespace MafiaSimulator.Scenes
{
    public class BlackmarketScene : SceneHolder
    {
        public override void Start()
        {
            while (true)
            {
                Console.Clear();
                try
                {
                    var tempPlayer = DataManager.FetchMyContent<Player>(0);
                    var tempItems = DataManager.FetchMyContentList<Item>();
                    
                    var tempAvailableItems = new List<Item>();
                    
                    for (var i = 0; i < tempItems.Count; i++)
                        if(tempItems[i].GetUnlockPopularity <= tempPlayer.MyPopularity)
                            tempAvailableItems.Add(tempItems[i]);
                    
                    Program.DisplayPlayerStats();
                    
                    var aLastDigit = 0;
                    for (var i = 0; i < tempAvailableItems.Count; i++, aLastDigit++)
                        Program.ConsoleWriteLine($"{i} : {tempAvailableItems[i].GetName}      {(tempAvailableItems[i].GetType == 0 ? "Offense": "Defense")} : {tempAvailableItems[i].GetLevel}     Cost : {tempAvailableItems[i].GetCost}");
                    
                    if(tempAvailableItems.Count == 0)
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
                    
                    if (DisplayItemInfo(tempAvailableItems[tempInput], tempPlayer))
                    {
                        tempPlayer.MyMoney -= tempAvailableItems[tempInput].GetCost;
                        tempPlayer.MyItems.Add(tempAvailableItems[tempInput]);
                    }
                }
                catch (Exception e)
                {
                    Program.ConsoleWriteContinue(e.Message, ConsoleColor.Red,ConsoleColor.Red);
                }
            }
        }

        private bool CheckCorrect(int aLastDigit, int tempListCount, string message)
        {
            if(tempListCount == 0)
                Program.ConsoleWriteLine($"it's so empty in here!");
                    
            Program.ConsoleWriteLine($"{aLastDigit} : Go back to previous menu");
            Program.ConsoleWriteLine("Please enter your the Crew member you want to inspect");
                    
            var tempInput = int.TryParse(Console.ReadLine(), out var temp) ? temp : throw new Exception("This isn't a Number!");

            if (tempInput == aLastDigit || aLastDigit == 0)
            {
                Program.ConsoleWriteContinue("Returning to last menu!");
                return true;
            }
                    
            if (aLastDigit < tempInput || tempInput < 0)
                throw new Exception("This isn't a valid number!");

            return false;
        }

        private bool DisplayItemInfo(Item aItem, Player aPlayer)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Program.DisplayPlayerStats();
                    aItem.ShowStats();
                    Program.ConsoleWriteLine($"1 : Buy this Item");
                    Program.ConsoleWriteLine($"2 : Go back to previous menu");
                    
                    switch (int.TryParse(Console.ReadLine(), out var temp) ? temp : throw new Exception("This isn't a Number!"))
                    {
                        case 1:
                            var tempResult = aPlayer.MyMoney >= aItem.GetCost;

                            if (tempResult)
                                Program.ConsoleWriteContinue("You Bought this item!");
                            else
                                Program.ConsoleWriteContinue("You don't have enough money!", ConsoleColor.Red, ConsoleColor.Red);

                            return tempResult;
                        case 2:
                            Program.ConsoleWriteContinue("You go to the previous menu!");
                            return false;
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
    }
}