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
                    Program.ConsoleWriteLine(@"=======================================================================================================================================
 /$$      /$$            /$$$$$$  /$$                  /$$$$$$  /$$                         /$$             /$$                        
| $$$    /$$$           /$$__  $$|__/                 /$$__  $$|__/                        | $$            | $$                        
| $$$$  /$$$$  /$$$$$$ | $$  \__/ /$$  /$$$$$$       | $$  \__/ /$$ /$$$$$$/$$$$  /$$   /$$| $$  /$$$$$$  /$$$$$$    /$$$$$$   /$$$$$$ 
| $$ $$/$$ $$ |____  $$| $$$$    | $$ |____  $$      |  $$$$$$ | $$| $$_  $$_  $$| $$  | $$| $$ |____  $$|_  $$_/   /$$__  $$ /$$__  $$
| $$\  $ | $$ /$$__  $$| $$      | $$ /$$__  $$       /$$  \ $$| $$| $$ | $$ | $$| $$  | $$| $$ /$$__  $$  | $$ /$$| $$  | $$| $$      
| $$ \/  | $$|  $$$$$$$| $$      | $$|  $$$$$$$      |  $$$$$$/| $$| $$ | $$ | $$|  $$$$$$/| $$|  $$$$$$$  |  $$$$/|  $$$$$$/| $$      
|__/     |__/ \_______/|__/      |__/ \_______/       \______/ |__/|__/ |__/ |__/ \______/ |__/ \_______/   \___/   \______/ |__/      
=======================================================================================================================================");
                    var tempHighscore = DataManager.FetchMyContent<HighScore>(0);
                    Program.ConsoleWriteLine($@"
Current HighScore
   Score: {tempHighscore.MyScore}
    Name: {tempHighscore.MyName}
    Date: {tempHighscore.MyDate}");
                    Program.ConsoleWriteLine(@"
1 : Start the game!
2 : Exit The game!", ConsoleColor.Cyan, true);
                    switch (int.TryParse(Console.ReadLine(), out var tempInput) ? tempInput : throw new Exception("This isn't a Number!"))
                    {
                        case 1:
                            Program.ConsoleWriteContinue("Starting the game!");
                            SceneManager.LoadScene<SetupScene>();
                            break;
                        case 2:
                            Program.ConsoleWriteLine("Now Exiting!", ConsoleColor.Red, true);
                            Environment.Exit(0);
                            break;
                        default:
                            throw new Exception("This isn't a valid number!");
                    }
                }
                catch (Exception e)
                {
                    Program.ConsoleWriteContinue(e.Message, ConsoleColor.Red, ConsoleColor.Red);
                }
            }
        }
    }
}