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
                            ConsoleWriteContinue("Starting the game!", ConsoleColor.Cyan, ConsoleColor.Green);
                            SceneManager.LoadScene(typeof(SetupScene));
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
                    ConsoleWriteContinue(e.ToString(), ConsoleColor.Red, ConsoleColor.Red);
                }
            }
        }
        
        public static void DisplayPlayerStats(ConsoleColor aColor)
        {
            ConsoleWriteLine("======================================", aColor);
            ConsoleWriteLine($" Name        : {(DataManager.myContent[typeof(Player)][0] as Player).AccessName}", aColor);
            ConsoleWriteLine($" Score       : {(DataManager.myContent[typeof(Player)][0] as Player).GetScore}", aColor);
            ConsoleWriteLine($" Money       : {(DataManager.myContent[typeof(Player)][0] as Player).GetMoney}", aColor);
            ConsoleWriteLine($" Popularity  : {(DataManager.myContent[typeof(Player)][0] as Player).GetPopularity}", aColor);
            ConsoleWriteLine("======================================", aColor);
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

        public static void ConsoleWriteContinue(string aMessage,ConsoleColor aMessageColor = ConsoleColor.Cyan, ConsoleColor aContinueColor = ConsoleColor.Green)
        {
            ConsoleWriteLine(aMessage, aMessageColor);
            ConsoleWriteLine("Press any key to continue!", aContinueColor, true);
        }
    }
}