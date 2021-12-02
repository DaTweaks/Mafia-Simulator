using System;

namespace MafiaSimulator.Data
{
    internal static class TextManager
    {
        public static void DisplayPlayerStats(ConsoleColor messageColor = ConsoleColor.Cyan)
        {
            var player = DataManager.FetchMyContent<Player>(0);
            ConsoleWriteLine("======================================", messageColor);
            ConsoleWriteLine($" Name        : {player.Name}", messageColor);
            ConsoleWriteLine($" Score       : {player.Score}", messageColor);
            ConsoleWriteLine($" Money       : {player.Money}", messageColor);
            ConsoleWriteLine($" Popularity  : {player.Popularity}", messageColor);
            ConsoleWriteLine($" Discovered  : {player.Discovered.Item1} / {player.Discovered.Item2}", messageColor);
            ConsoleWriteLine("======================================", messageColor);
        }
        
        public static void ConsoleWriteLine(string message, ConsoleColor messageColor = ConsoleColor.Cyan, bool pause = false)
        {
            ConsoleColor tempColor = Console.ForegroundColor;
            Console.ForegroundColor = messageColor;
            Console.WriteLine(message);
            Console.ForegroundColor = tempColor;
            if(pause) 
                Console.ReadKey(true);
        }

        public static void ConsoleWriteContinue(string message = "",ConsoleColor messageColor = ConsoleColor.Cyan, ConsoleColor continueMessageColor = ConsoleColor.Green)
        {
            if(!string.IsNullOrEmpty(message)) 
                ConsoleWriteLine(message, messageColor);
            ConsoleWriteLine("Press any key to continue!", continueMessageColor, true);
        }

        public static void ConsoleWriteSpacer(ConsoleColor messageColor = ConsoleColor.Cyan)
        {
            ConsoleWriteLine("======================================", messageColor);
        }
    }
}