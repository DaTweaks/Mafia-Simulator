using System;
using MafiaSimulator.Utils; // i do as rider commands.

namespace MafiaSimulator
{
    public class MainMenuScene : SceneHolder
    {
        public override void Start()
        {
            while (true)
            {
                Console.Clear();
                try
                {
                    Program.DisplayPlayerStats(ConsoleColor.Blue);
                    Program.ConsoleWriteLine(@"
1 : Heist a Bank!
2 : Check your Warehouse!
3 : Find New Crew Members!
4 : Check out your crew!
4 : Go to the black market!
5 : Kill yourself!", ConsoleColor.Cyan, true);
                    switch (int.TryParse(Console.ReadLine(), out var tempInput) ? tempInput : throw new Exception("This isn't a Number!"))
                    {
                        case 1:
                            Program.ConsoleWriteContinue("Now Planning to Heist a Bank!");
                            SceneManager.LoadScene<BankScene>();
                            break;
                        case 2:
                            Program.ConsoleWriteContinue("Going to your warehouse!");
                            SceneManager.LoadScene<WareHouseScene>();
                            break;
                        case 3:
                            Program.ConsoleWriteContinue("Finding new crew members!");
                            SceneManager.LoadScene<RecruitmentScene>();
                            break;
                        case 4:
                            Program.ConsoleWriteContinue("Calling your Crew members!");
                            SceneManager.LoadScene<CrewMenuScene>();
                            break;
                        case 5:
                            Program.ConsoleWriteContinue("You decided it's your time to go!");
                            SceneManager.LoadScene<EndingScene>();
                            break;
                        default:
                            throw new Exception("This isn't a valid number!");
                    }
                }
                catch (Exception e)
                {
                    Program.ConsoleWriteContinue(e.ToString(), ConsoleColor.Red, ConsoleColor.Red);
                    continue;
                }
                break;
            }
        }
    }
}