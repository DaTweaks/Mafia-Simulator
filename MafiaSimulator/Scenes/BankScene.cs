using System;
using System.Collections.Generic;
using MafiaSimulator.Data;

namespace MafiaSimulator.Scenes
{
    public class BankScene : SceneHolder
    {
        public override void Start()
        {
            while (true)
            {
                try
                {
                    Console.Clear();

                    var player = DataManager.FetchMyContent<Player>(0);
                    
                    var banks = DataManager.FetchMyContentList<Bank>();
                    
                    var tempAvailableBanks = new List<Bank>();
                    
                    for (var i = 0; i < banks.Count; i++)
                        if(banks[i].GetUnlockPopularity <= player.Popularity)
                            tempAvailableBanks.Add(banks[i]);
                    
                    TextManager.DisplayPlayerStats();
                    
                    
                    
                    var lastDigit = 0;
                    for (var i = 0; i < tempAvailableBanks.Count; i++, lastDigit++)
                        TextManager.ConsoleWriteLine($"{i} : {tempAvailableBanks[i].GetName}");
                    
                    if(tempAvailableBanks.Count == 0)
                        TextManager.ConsoleWriteLine($"it's so empty in here!");
                    
                    TextManager.ConsoleWriteLine($"{lastDigit} : Go back to previous menu");
                    TextManager.ConsoleWriteLine("Please enter your the bank you want to Heist!");


                    var input = int.TryParse(Console.ReadLine(), out var temp) ? temp : throw new Exception("This isn't a Number!");

                    if (input == lastDigit || lastDigit == 0)
                    {
                        TextManager.ConsoleWriteContinue("Returning to last menu!");
                        return;
                    }
                    
                    if (lastDigit < input || input < 0)
                        throw new Exception("This isn't a valid number!");
                    
                    if (player.Crew.Count == 0)
                        throw new Exception("You Can't Rob this bank as you don't have any crew members!");

                    if (!DisplayBankInfo(tempAvailableBanks[input], player)) continue;
                    
                    tempAvailableBanks[input].Heist(player);
                    for (var i = 0; i < banks.Count; i++)
                        if (banks[i] == tempAvailableBanks[input])
                            DataManager.MyContent[typeof(Bank)].RemoveAt(i);
                    
                }
                catch (Exception e)
                {
                    TextManager.ConsoleWriteContinue(e.Message, ConsoleColor.Red,ConsoleColor.Red);
                } 
            }
        }

        private bool DisplayBankInfo(Bank bank, Player player)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    TextManager.DisplayPlayerStats();
                    bank.ShowStats();
                    TextManager.ConsoleWriteLine($"1 : Rob This Bank");
                    TextManager.ConsoleWriteLine($"2 : Go back to previous menu");
                    
                    switch (int.TryParse(Console.ReadLine(), out var temp) ? temp : throw new Exception("This isn't a Number!"))
                    {
                        case 1:
                            TextManager.ConsoleWriteContinue("Robbing the bank!");
                            return true;
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