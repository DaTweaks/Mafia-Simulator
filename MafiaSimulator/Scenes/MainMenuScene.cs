using System;
using MafiaSimulator.Data;

// i do as rider commands.

namespace MafiaSimulator.Scenes
{
    public class MainMenuScene : SceneHolder
    {
        public override void Start()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    TextManager.DisplayPlayerStats(ConsoleColor.Blue);
                    TextManager.ConsoleWriteLine(@"
1 : Heist a Bank!
2 : Check your Warehouse!
3 : Find New Crew Members!
4 : Check out your crew!
5 : Go to the black market!
6 : Kill yourself!", ConsoleColor.Cyan, true);
                    switch (int.TryParse(Console.ReadLine(), out var tempInput) ? tempInput : throw new Exception("This isn't a Number!")) // TODO : Replace with a better solution.
                    {
                        case 1:
                            TextManager.ConsoleWriteContinue("Now Planning to Heist a Bank!");
                            SceneManager.LoadScene<BankScene>();
                            break;
                        case 2:
                            TextManager.ConsoleWriteContinue("Going to your warehouse!");
                            SceneManager.LoadScene<WareHouseScene>();
                            break;
                        case 3:
                            TextManager.ConsoleWriteContinue("Finding new crew members!");
                            SceneManager.LoadScene<RecruitmentScene>();
                            break;
                        case 4:
                            TextManager.ConsoleWriteContinue("Calling your Crew members!");
                            SceneManager.LoadScene<CrewMenuScene>();
                            break;
                        case 5:
                            TextManager.ConsoleWriteContinue("Going to the black market!");
                            SceneManager.LoadScene<BlackmarketScene>();
                            break;
                        case 6:
                            TextManager.ConsoleWriteContinue("You decided it's your time to go!");
                            SceneManager.LoadScene<EndingScene>();
                            break;
                        default:
                            throw new Exception("This isn't a valid number!");
                    }
                }
                catch (Exception e)
                {
                    TextManager.ConsoleWriteContinue(e.Message, ConsoleColor.Red, ConsoleColor.Red);
                }
            }
        }
    }
}