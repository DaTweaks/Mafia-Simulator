using System;
using MafiaSimulator.Utils;

namespace MafiaSimulator
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            DataManager.FetchData();
            StartMenu();
        }

        public static void ContinueText()
        {
            Console.WriteLine("Press any key to continue!");
            Console.ReadKey(true);
        }
        
        public static void StartMenu()
        {
            
        }
    }
}