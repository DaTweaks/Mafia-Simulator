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
                    
                    var player = DataManager.FetchMyContent<Player>(0);

                    var items = player.Items;

                    TextManager.DisplayPlayerStats();
                    var lastDigit = 0;
                    for (var i = 0; i < items.Count; i++, lastDigit++)
                        TextManager.ConsoleWriteLine($"{i} : {items[i].GetName}      {(items[i].GetType == 0 ? "Offense": "Defense")} : {items[i].GetLevel}     SellCost : {items[i].GetSellCost}");
                    if(items.Count == 0)
                        TextManager.ConsoleWriteLine($"it's so empty in here!");
                    
                    TextManager.ConsoleWriteLine($"{lastDigit} : Go back to previous menu");
                    TextManager.ConsoleWriteLine("Please enter your the Crew member you want to inspect");
                    
                    var tempInput = int.TryParse(Console.ReadLine(), out var temp) ? temp : throw new Exception("This isn't a Number!");

                    if (tempInput == lastDigit || lastDigit == 0)
                    {
                        TextManager.ConsoleWriteContinue("Returning to last menu!");
                        return;
                    }
                    
                    if (lastDigit < tempInput || tempInput < 0)
                        throw new Exception("This isn't a valid number!");
                    
                    DisplayItemInfo(items[tempInput], player);
                }
                catch (Exception e)
                {
                    TextManager.ConsoleWriteContinue(e.Message, ConsoleColor.Red,ConsoleColor.Red);
                }
            }
        }

        private void DisplayItemInfo(Item item, Player player)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    TextManager.DisplayPlayerStats();
                    item.ShowStats(true, false);
                    TextManager.ConsoleWriteLine($"1 : Sell the item");
                    TextManager.ConsoleWriteLine($"2 : Go back to previous menu");
                    
                    switch (int.TryParse(Console.ReadLine(), out var temp) ? temp : throw new Exception("This isn't a Number!"))
                    {
                        case 1:
                            var tempItems = player.Items;
                            player.Money += item.GetSellCost;
                            for (var i = 0; i < tempItems.Count; i++)
                                if(tempItems[i] == item)
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