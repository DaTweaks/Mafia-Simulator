using System;
using System.Threading;
using MafiaSimulator.Data;
using MafiaSimulator.Utils;

namespace MafiaSimulator
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            DataManager.FetchData();
            Console.ForegroundColor = ConsoleColor.Cyan;
            StartMenu();
        }

        public static void ConsoleWriteLine(string aMessage, ConsoleColor aColor = ConsoleColor.Cyan, bool tempWait = false)
        {
            ConsoleColor tempColor = Console.ForegroundColor;
            Console.ForegroundColor = aColor;
            Console.WriteLine(aMessage);
            Console.ForegroundColor = tempColor;
            if(tempWait) 
                Console.ReadKey(true);
        }
        
        public static void StartMenu()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    ConsoleWriteLine(@"
=======================================================================================================================================
 /$$      /$$            /$$$$$$  /$$                  /$$$$$$  /$$                         /$$             /$$                        
| $$$    /$$$           /$$__  $$|__/                 /$$__  $$|__/                        | $$            | $$                        
| $$$$  /$$$$  /$$$$$$ | $$  \__/ /$$  /$$$$$$       | $$  \__/ /$$ /$$$$$$/$$$$  /$$   /$$| $$  /$$$$$$  /$$$$$$    /$$$$$$   /$$$$$$ 
| $$ $$/$$ $$ |____  $$| $$$$    | $$ |____  $$      |  $$$$$$ | $$| $$_  $$_  $$| $$  | $$| $$ |____  $$|_  $$_/   /$$__  $$ /$$__  $$
| $$\  $ | $$ /$$__  $$| $$      | $$ /$$__  $$       /$$  \ $$| $$| $$ | $$ | $$| $$  | $$| $$ /$$__  $$  | $$ /$$| $$  | $$| $$      
| $$ \/  | $$|  $$$$$$$| $$      | $$|  $$$$$$$      |  $$$$$$/| $$| $$ | $$ | $$|  $$$$$$/| $$|  $$$$$$$  |  $$$$/|  $$$$$$/| $$      
|__/     |__/ \_______/|__/      |__/ \_______/       \______/ |__/|__/ |__/ |__/ \______/ |__/ \_______/   \___/   \______/ |__/      
=======================================================================================================================================", ConsoleColor.White);
                    ConsoleWriteLine($@"
Current Highscore
   Score: {(DataManager.myContent[typeof(Highscore)][0] as Highscore).AccessScore}
    Name: {(DataManager.myContent[typeof(Highscore)][0] as Highscore).AccessName}
    Date: {(DataManager.myContent[typeof(Highscore)][0] as Highscore).AccessDate}");
                    ConsoleWriteLine(@"
1 : Start the game!
2 : Exit The game!", ConsoleColor.Cyan, true);
                    switch (int.TryParse(Console.ReadLine(), out var tempInput) ? tempInput : throw new Exception("This isn't a Number!"))
                    {
                        case 1:
                            ConsoleWriteLine("Starting the game!");
                            ConsoleWriteLine("Press any key to continue!", ConsoleColor.Green, true);
                            MenuManager.LoadScene(typeof(SetupScene));
                            break;
                        case 2:
                            ConsoleWriteLine("Now Exiting!", ConsoleColor.Red);
                            Thread.Sleep(1000);
                            Environment.Exit(0);
                            break;
                        default:
                            throw new Exception("This isn't a valid number!");
                    }
                }
                catch (Exception e)
                {
                    ConsoleWriteLine(e.ToString(), ConsoleColor.Red, true);
                }
            }
        }
    }
}