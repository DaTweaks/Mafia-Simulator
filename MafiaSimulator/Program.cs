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
            SceneManager.LoadScene<StartMenu>();
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

        public static void ConsoleWriteContinue(string aMessage = "",ConsoleColor aMessageColor = ConsoleColor.Cyan, ConsoleColor aContinueColor = ConsoleColor.Green)
        {
            if(!string.IsNullOrEmpty(aMessage)) 
                ConsoleWriteLine(aMessage, aMessageColor);
            ConsoleWriteLine("Press any key to continue!", aContinueColor, true);
        }
    }
}