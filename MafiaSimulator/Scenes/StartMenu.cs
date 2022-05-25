using System;
using MafiaSimulator.Data;

namespace MafiaSimulator.Scenes
{
    public class StartMenu : SceneHolder
    {
        public override void Start()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    TextManager.ConsoleWriteLine(@"=======================================================================================================================================
 /$$      /$$            /$$$$$$  /$$                  /$$$$$$  /$$                         /$$             /$$                        
| $$$    /$$$           /$$__  $$|__/                 /$$__  $$|__/                        | $$            | $$                        
| $$$$  /$$$$  /$$$$$$ | $$  \__/ /$$  /$$$$$$       | $$  \__/ /$$ /$$$$$$/$$$$  /$$   /$$| $$  /$$$$$$  /$$$$$$    /$$$$$$   /$$$$$$ 
| $$ $$/$$ $$ |____  $$| $$$$    | $$ |____  $$      |  $$$$$$ | $$| $$_  $$_  $$| $$  | $$| $$ |____  $$|_  $$_/   /$$__  $$ /$$__  $$
| $$\  $ | $$ /$$__  $$| $$      | $$ /$$__  $$       /$$  \ $$| $$| $$ | $$ | $$| $$  | $$| $$ /$$__  $$  | $$ /$$| $$  | $$| $$      
| $$ \/  | $$|  $$$$$$$| $$      | $$|  $$$$$$$      |  $$$$$$/| $$| $$ | $$ | $$|  $$$$$$/| $$|  $$$$$$$  |  $$$$/|  $$$$$$/| $$      
|__/     |__/ \_______/|__/      |__/ \_______/       \______/ |__/|__/ |__/ |__/ \______/ |__/ \_______/   \___/   \______/ |__/      
=======================================================================================================================================");
                    var highscore = DataManager.currentHighscore;
                    highscore.UpdateData();
                    TextManager.ConsoleWriteLine($@"
Current HighScore
    Name: {highscore.Variables[0].Name}
   Score: {highscore.Variables[0].Score}
    Date: {highscore.Variables[0].Date}");
                    TextManager.ConsoleWriteLine(@"
1 : Start the game!
2 : See the Leaderboard!
3 : Exit The game!", ConsoleColor.Cyan, true);
                    switch (int.TryParse(Console.ReadLine(), out var tempInput) ? tempInput : throw new Exception("This isn't a Number!"))
                    {
                        case 1:
                            TextManager.ConsoleWriteContinue("Starting the game!");
                            SceneManager.LoadScene<SetupScene>();
                            break;
                        case 2:
                            Console.Clear();
                            highscore.UpdateData(5);
                            for (int i = 0; i < DataManager.currentHighscore.Variables.Count && i < 5; i++)
                            {
                                TextManager.ConsoleWriteLine($@"{i+1} -
Name: {highscore.Variables[i].Name}
Score: {highscore.Variables[i].Score}
Date: {highscore.Variables[i].Date}");
                            }
                            TextManager.ConsoleWriteContinue();
                            break;
                        case 3:
                            TextManager.ConsoleWriteLine("Now Exiting!", ConsoleColor.Red, true);
                            Environment.Exit(0);
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