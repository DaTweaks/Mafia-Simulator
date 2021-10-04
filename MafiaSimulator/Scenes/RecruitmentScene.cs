using System;
using System.Collections.Generic;
using MafiaSimulator.Data;

namespace MafiaSimulator.Scenes
{
    public class RecruitmentScene : SceneHolder // *iT iS nEvEr InStAnSiAtEd* quiet rider. it is, but only through reflections
    {
        public override void Start()
        {
            while (true)
            {
                Console.Clear();
                try
                {
                    var tempPlayer = DataManager.FetchMyContent<Player>(0);
                    var tempCrew = DataManager.FetchMyContentList<Crew>();
                    
                    var tempAvailableCrews = new List<Crew>();
                    
                    for (var i = 0; i < tempCrew.Count; i++)
                        if(tempCrew[i].GetUnlockPopularity <= tempPlayer.MyPopularity)
                            tempAvailableCrews.Add(tempCrew[i]);
                    
                    Program.DisplayPlayerStats();
                    var aLastDigit = 0;
                    for (var i = 0; i < tempAvailableCrews.Count; i++)
                    {
                        aLastDigit++;
                        Program.ConsoleWriteLine($"{i} : {tempAvailableCrews[i].GetName}      Cost: {tempAvailableCrews[i].GetCost}");
                    }
                    if(tempAvailableCrews.Count == 0)
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
                    
                    if (DisplayCrewInfo(tempAvailableCrews[tempInput], tempPlayer))
                    {
                        tempPlayer.MyMoney -= tempAvailableCrews[tempInput].GetCost;
                        tempPlayer.MyCrew.Add(tempAvailableCrews[tempInput]);

                        for (var i = 0; i < tempCrew.Count; i++)
                            if (tempCrew[i] == tempAvailableCrews[tempInput])
                                DataManager.MyContent[typeof(Crew)].RemoveAt(i);
                    }
                }
                catch (Exception e)
                {
                    Program.ConsoleWriteContinue(e.Message, ConsoleColor.Red,ConsoleColor.Red);
                }
            }
        }

        private bool DisplayCrewInfo(Crew aCrew, Player aPlayer)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Program.DisplayPlayerStats();
                    aCrew.ShowStats(true);
                    Program.ConsoleWriteLine($"1 : Recruit him");
                    Program.ConsoleWriteLine($"2 : Go back to previous menu");
                    

                    switch (int.TryParse(Console.ReadLine(), out var temp) ? temp : throw new Exception("This isn't a Number!"))
                    {
                        case 1:
                            var tempResult = aPlayer.MyMoney >= aCrew.GetCost;

                            if (tempResult)
                                Program.ConsoleWriteContinue("You have recruited him!");
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