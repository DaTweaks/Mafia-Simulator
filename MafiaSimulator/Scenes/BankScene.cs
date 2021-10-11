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

                    var aPlayer = DataManager.FetchMyContent<Player>(0);
                    
                    var tempBanks = DataManager.FetchMyContentList<Bank>();
                    
                    var tempAvailableBanks = new List<Bank>();
                    
                    for (var i = 0; i < tempBanks.Count; i++)
                        if(tempBanks[i].GetUnlockPopularity <= aPlayer.MyPopularity)
                            tempAvailableBanks.Add(tempBanks[i]);
                    
                    Program.DisplayPlayerStats();
                    
                    
                    
                    var aLastDigit = 0;
                    for (var i = 0; i < tempAvailableBanks.Count; i++, aLastDigit++)
                        Program.ConsoleWriteLine($"{i} : {tempAvailableBanks[i].GetName}");
                    
                    if(tempAvailableBanks.Count == 0)
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
                    
                    if (aPlayer.MyCrew.Count == 0)
                        throw new Exception("You Can't Rob this bank as you don't have any crew members!");
                    
                    if (DisplayBankInfo(tempAvailableBanks[tempInput], aPlayer))
                    {
                        tempAvailableBanks[tempInput].Heist(aPlayer);
                        for (var i = 0; i < tempBanks.Count; i++)
                            if (tempBanks[i] == tempAvailableBanks[tempInput])
                                DataManager.MyContent[typeof(Bank)].RemoveAt(i);
                    }
                }
                catch (Exception e)
                {
                    Program.ConsoleWriteContinue(e.Message, ConsoleColor.Red,ConsoleColor.Red);
                } 
            }
        }

        private bool DisplayBankInfo(Bank aBank, Player aPlayer)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Program.DisplayPlayerStats();
                    aBank.ShowStats();
                    Program.ConsoleWriteLine($"1 : Rob This Bank");
                    Program.ConsoleWriteLine($"2 : Go back to previous menu");
                    
                    switch (int.TryParse(Console.ReadLine(), out var temp) ? temp : throw new Exception("This isn't a Number!"))
                    {
                        case 1:
                            Program.ConsoleWriteContinue("Robbing the bank!");
                            return true;
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