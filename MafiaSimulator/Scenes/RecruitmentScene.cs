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
                    var player = DataManager.FetchMyContent<Player>(0);
                    var crew = DataManager.FetchMyContentList<Crew>();
                    
                    var availableCrews = new List<Crew>();
                    
                    for (var i = 0; i < crew.Count; i++)
                        if(crew[i].GetUnlockPopularity <= player.Popularity)
                            availableCrews.Add(crew[i]);
                    
                    TextManager.DisplayPlayerStats();
                    var lastDigit = 0;
                    for (var i = 0; i < availableCrews.Count; i++, lastDigit++)
                        TextManager.ConsoleWriteLine($"{i} : {availableCrews[i].GetName}      Cost: {availableCrews[i].GetCost}");
                    
                    if(availableCrews.Count == 0)
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
                    
                    if (DisplayCrewInfo(availableCrews[input], player))
                    {
                        player.Money -= availableCrews[input].GetCost;
                        player.Crew.Add(availableCrews[input]);

                        for (var i = 0; i < crew.Count; i++)
                            if (crew[i] == availableCrews[input])
                                DataManager.MyContent[typeof(Crew)].RemoveAt(i);
                    }
                }
                catch (Exception e)
                {
                    TextManager.ConsoleWriteContinue(e.Message, ConsoleColor.Red,ConsoleColor.Red);
                }
            }
        }

        private bool DisplayCrewInfo(Crew crew, Player player)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    TextManager.DisplayPlayerStats();
                    crew.ShowStats(true);
                    TextManager.ConsoleWriteLine($"1 : Recruit him");
                    TextManager.ConsoleWriteLine($"2 : Go back to previous menu");
                    

                    switch (int.TryParse(Console.ReadLine(), out var temp) ? temp : throw new Exception("This isn't a Number!"))
                    {
                        case 1:
                            var input = player.Money >= crew.GetCost;

                            if (input)
                                TextManager.ConsoleWriteContinue("You have recruited him!");
                            else
                                TextManager.ConsoleWriteContinue("You don't have enough money!", ConsoleColor.Red, ConsoleColor.Red);

                            return input;
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