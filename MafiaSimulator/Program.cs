using System;
using System.Diagnostics;
using System.Media;
using System.Net.Security;
using System.Runtime.InteropServices;
using System.Threading;
using MafiaSimulator.Data;
using MafiaSimulator.Scenes;

namespace MafiaSimulator
{
    internal class Program
    {

        public static Random RNG;
        
        public static void Main(string[] args)
        {
            DataManager.FetchData();
            Console.ForegroundColor = ConsoleColor.Cyan;
            RNG = new Random();
            Fullscreen();
            SceneManager.LoadScene<StartMenu>();
        }
        
        private static void Fullscreen()
        {
            var tempProcess = Process.GetCurrentProcess();
            ShowWindow(tempProcess.MainWindowHandle, 3);
        }
        
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int cmdShow);
        
        public static void DisplayPlayerStats(ConsoleColor aColor = ConsoleColor.Cyan)
        {
            var tempPlayer = DataManager.FetchMyContent<Player>(0);
            ConsoleWriteLine("======================================", aColor);
            ConsoleWriteLine($" Name        : {tempPlayer.MyName}", aColor);
            ConsoleWriteLine($" Score       : {tempPlayer.MyScore}", aColor);
            ConsoleWriteLine($" Money       : {tempPlayer.MyMoney}", aColor);
            ConsoleWriteLine($" Popularity  : {tempPlayer.MyPopularity}", aColor);
            ConsoleWriteLine($" Discovered  : {tempPlayer.MyDiscovered.Item1} / {tempPlayer.MyDiscovered.Item2}", aColor);
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

        public static bool CheckCorrect(int aLastDigit, int tempListCount, string message, int tempInput)
        {
            if(tempListCount == 0)
                Program.ConsoleWriteLine($"it's so empty in here!");
                    
            Program.ConsoleWriteLine($"{aLastDigit} : Go back to previous menu");
            Program.ConsoleWriteLine(message);

            if (tempInput == aLastDigit || aLastDigit == 0)
            {
                Program.ConsoleWriteContinue("Returning to last menu!");
                return true;
            }
                    
            if (aLastDigit < tempInput || tempInput < 0)
                throw new Exception("This isn't a valid number!");

            return false;
        }
        
        public static void ConsoleWriteSpacer(ConsoleColor aColor = ConsoleColor.Cyan)
        {
            ConsoleWriteLine("======================================", aColor);
        }
    }
}