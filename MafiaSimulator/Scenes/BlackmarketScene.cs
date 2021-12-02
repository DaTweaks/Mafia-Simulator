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
                    var player = DataManager.FetchMyContent<Player>(0);
                    var items = DataManager.FetchMyContentList<Item>();
                    
                    var availableItems = new List<Item>();
                    
                    for (var i = 0; i < items.Count; i++)
                        if(items[i].GetUnlockPopularity <= player.Popularity)
                            availableItems.Add(items[i]);
                    
                    TextManager.DisplayPlayerStats();
                    
                    var lastDigit = 0;
                    for (var i = 0; i < availableItems.Count; i++, lastDigit++)
                        TextManager.ConsoleWriteLine($"{i} : {availableItems[i].GetName}      {(availableItems[i].GetType == 0 ? "Offense": "Defense")} : {availableItems[i].GetLevel}     Cost : {availableItems[i].GetCost}");
                    
                    if(availableItems.Count == 0)
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
                    
                    if (DisplayItemInfo(availableItems[input], player))
                    {
                        player.Money -= availableItems[input].GetCost;
                        player.Items.Add(availableItems[input]);
                    }
                }
                catch (Exception e)
                {
                    TextManager.ConsoleWriteContinue(e.Message, ConsoleColor.Red,ConsoleColor.Red);
                }
            }
        }

        private bool DisplayItemInfo(Item item, Player player)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    TextManager.DisplayPlayerStats();
                    item.ShowStats();
                    TextManager.ConsoleWriteLine($"1 : Buy this Item");
                    TextManager.ConsoleWriteLine($"2 : Go back to previous menu");
                    
                    switch (int.TryParse(Console.ReadLine(), out var temp) ? temp : throw new Exception("This isn't a Number!"))
                    {
                        case 1:
                            var result = player.Money >= item.GetCost;

                            if (result)
                                TextManager.ConsoleWriteContinue("You Bought this item!");
                            else
                                TextManager.ConsoleWriteContinue("You don't have enough money!", ConsoleColor.Red, ConsoleColor.Red);

                            return result;
                        case 2:
                            TextManager.ConsoleWriteContinue("You go to the previous menu!");
                            return false;
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