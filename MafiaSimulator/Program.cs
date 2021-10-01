using System;
using System.Threading;
using MafiaSimulator.Data;
using MafiaSimulator.Scenes;

namespace MafiaSimulator
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            DataManager.FetchData();
            Console.ForegroundColor = ConsoleColor.Cyan;
            SceneManager.LoadScene<StartMenu>();
        }

        public static void DisplayPlayerStats(ConsoleColor aColor)
        {
            var tempPlayer = DataManager.FetchMyContent<Player>(0);
            ConsoleWriteLine("======================================", aColor);
            ConsoleWriteLine($" Name        : {tempPlayer.MyName}", aColor);
            ConsoleWriteLine($" Score       : {tempPlayer.MyScore}", aColor);
            ConsoleWriteLine($" Money       : {tempPlayer.MyMoney}", aColor);
            ConsoleWriteLine($" Popularity  : {tempPlayer.MyPopularity}", aColor);
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

        public static void ConsoleWriteContinue(string aMessage = "",ConsoleColor aMessageColor = ConsoleColor.Cyan, ConsoleColor aContinueColor = ConsoleColor.Green)
        {
            if(!string.IsNullOrEmpty(aMessage)) 
                ConsoleWriteLine(aMessage, aMessageColor);
            ConsoleWriteLine("Press any key to continue!", aContinueColor, true);
        }
    }
}