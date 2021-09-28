using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
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
            DataManager.myHighScore.Write();
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