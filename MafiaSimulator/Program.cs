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

        public static Random Random;
        
        public static void Main(string[] args)
        {
            DataManager.FetchData();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Random = new Random();
            Fullscreen();
            SceneManager.LoadScene<StartMenu>();
        }
        
        private static void Fullscreen()
        {
            var process = Process.GetCurrentProcess();
            ShowWindow(process.MainWindowHandle, 3);
        }
        
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int cmdShow);
        
    }
}