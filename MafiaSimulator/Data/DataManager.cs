using System;
using System.Collections.Generic;
using System.IO;

namespace MafiaSimulator.Utils
{
    public static class DataManager
    {
        public static List<Bank> myBanks = new List<Bank>();
        public static List<Item> myItems = new List<Item>();
        public static List<Crew> myCrews = new List<Crew>();
        
        private static Tuple<string, int> myHighScore;

        public static void FetchData()
        {
            FetchBankData();
            FetchItemData();
            FetchCrewData();
        }
        
        
        private static void FetchBankData()
        {
            
            var tempFiles = GetFiles("Banks");
            for (int i = 0; i < tempFiles.Length; i++)
            {
                if(tempFiles[i].ToLower().Contains("template"))
                    continue;
                var tempBank = new Bank(tempFiles[i]);
                tempBank.Load();
                myBanks.Add(tempBank);
            }
        }

        private static void FetchItemData()
        {
            var tempFiles = GetFiles("Items");
            for (int i = 0; i < tempFiles.Length; i++)
            {
                if(tempFiles[i].ToLower().Contains("template"))
                    continue;
                var tempItem = new Item(tempFiles[i]);
                tempItem.Load();
                myItems.Add(tempItem);
            }
        }

        private static void FetchCrewData()
        {
            var tempFiles = GetFiles("Crew");
            for (int i = 0; i < tempFiles.Length; i++)
            {
                if(tempFiles[i].ToLower().Contains("template"))
                    continue;
                var tempCrew = new Crew(tempFiles[i]);
                tempCrew.Load();
                myCrews.Add(tempCrew);
            }
        }
        
        private static string[] GetFiles(string aPath) => Directory.GetFiles(Path.GetFullPath($"GameData/{aPath}"));
    }
}