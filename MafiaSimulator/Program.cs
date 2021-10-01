using System;
using System.Diagnostics;
using System.Net.Security;
using System.Runtime.InteropServices;
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
            ConsoleWriteLine($"   : {tempPlayer.MyDiscovered}", aColor);
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