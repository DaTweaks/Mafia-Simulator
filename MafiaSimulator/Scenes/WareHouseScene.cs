using System;
using System.Collections.Generic;
using MafiaSimulator.Data;

namespace MafiaSimulator.Scenes
{
    public class WareHouseScene : SceneHolder
    {
        public override void Start()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    
                    var aPlayer = DataManager.FetchMyContent<Player>(0);

                    var tempItems = aPlayer.Items;

                    TextManager.DisplayPlayerStats();
                    var aLastDigit = 0;
                    for (var i = 0; i < tempItems.Count; i++, aLastDigit++)
                        TextManager.ConsoleWriteLine($"{i} : {tempItems[i].GetName}      {(tempItems[i].GetType == 0 ? "Offense": "Defense")} : {tempItems[i].GetLevel}     SellCost : {tempItems[i].GetSellCost}");
                    if(tempItems.Count == 0)
                        TextManager.ConsoleWriteLine($"it's so empty in here!");
                    
                    TextManager.ConsoleWriteLine($"{aLastDigit} : Go back to previous menu");
                    TextManager.ConsoleWriteLine("Please enter your the Crew member you want to inspect");
                    
                    var tempInput = int.TryParse(Console.ReadLine(), out var temp) ? temp : throw new Exception("This isn't a Number!");

                    if (tempInput == aLastDigit || aLastDigit == 0)
                    {
                        TextManager.ConsoleWriteContinue("Returning to last menu!");
                        return;
                    }
                    
                    if (aLastDigit < tempInput || tempInput < 0)
                        throw new Exception("This isn't a valid number!");
                    
                    DisplayItemInfo(tempItems[tempInput], aPlayer);
                }
                catch (Exception e)
                {
                    TextManager.ConsoleWriteContinue(e.Message, ConsoleColor.Red,ConsoleColor.Red);
                }
            }
        }

        private void DisplayItemInfo(Item aItem, Player aPlayer)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    TextManager.DisplayPlayerStats();
                    aItem.ShowStats(true, false);
                    TextManager.ConsoleWriteLine($"1 : Sell the item");
                    TextManager.ConsoleWriteLine($"2 : Go back to previous menu");
                    
                    switch (int.TryParse(Console.ReadLine(), out var temp) ? temp : throw new Exception("This isn't a Number!"))
                    {
                        case 1:
                            var tempItems = aPlayer.Items;
                            aPlayer.Money += aItem.GetSellCost;
                            for (var i = 0; i < tempItems.Count; i++)
                                if(tempItems[i] == aItem)
                                    tempItems.RemoveAt(i);
                            return;
                        case 2:
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
    }
}