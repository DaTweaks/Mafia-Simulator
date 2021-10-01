using System;
using System.Collections.Generic;
using MafiaSimulator.Data;

namespace MafiaSimulator.Scenes
{
    public class RecruitmentScene : SceneHolder
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
                    
                    var tempAvaliableCrews = new List<Crew>();
                    
                    for (int i = 0; i < tempCrew.Count; i++)
                        if(tempCrew[i].GetUnlockPopularity <= tempPlayer.MyPopularity)
                            tempAvaliableCrews.Add(tempCrew[i]);
                    
                    Program.DisplayPlayerStats();
                    int lastdigit = 0;
                    for (int i = 0; i < tempAvaliableCrews.Count; i++)
                    {
                        lastdigit++;
                        Program.ConsoleWriteLine($"{i} : {tempAvaliableCrews[i].GetName}      Cost: {tempAvaliableCrews[i].GetCost}");
                    }
                    if(tempAvaliableCrews.Count == 0)
                        Program.ConsoleWriteLine($"it's so empty in here!");
                    
                    Program.ConsoleWriteLine($"{lastdigit} : Go back to previous menu");
                    Program.ConsoleWriteLine("Please enter your the Crew member you want to inspect");
                    
                    var tempInput = int.TryParse(Console.ReadLine(), out var temp) ? temp : throw new Exception("This isn't a Number!");

                    if (tempInput == lastdigit || lastdigit == 0)
                    {
                        Program.ConsoleWriteContinue("Returning to last menu!");
                        return;
                    }
                    
                    if (lastdigit < tempInput || tempInput < 0)
                        throw new Exception("This isn't a valid number!");
                    
                    if (DisplayCrewInfo(tempAvaliableCrews[tempInput], tempPlayer))
                    {
                        tempPlayer.MyMoney -= tempAvaliableCrews[tempInput].GetCost;
                        tempPlayer.MyCrew.Add(tempAvaliableCrews[tempInput]);

                        for (int i = 0; i < tempCrew.Count; i++)
                            if (tempCrew[i] == tempAvaliableCrews[tempInput])
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
                    Program.ConsoleWriteLine($"==================================");
                    Program.ConsoleWriteLine($"Name     : {aCrew.GetName}");
                    Program.ConsoleWriteLine($"Offense  : {aCrew.GetOffense}");
                    Program.ConsoleWriteLine($"Defense  : {aCrew.GetDefense}");
                    Program.ConsoleWriteLine($"Covert   : {aCrew.GetCovert}");
                    Program.ConsoleWriteLine($"Skill    : {aCrew.GetSkill}");
                    Program.ConsoleWriteLine($"Cost     : {aCrew.GetCost}");
                    Program.ConsoleWriteLine($"==================================");
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