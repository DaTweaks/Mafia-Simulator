using System;
using System.Collections.Generic;
using System.IO;
using MafiaSimulator.Data;

namespace MafiaSimulator.Utils
{
    public static class DataManager
    {
        public static List<Bank> myBanks = new List<Bank>();
        public static List<Item> myItems = new List<Item>();
        public static List<Crew> myCrews = new List<Crew>();
        
        public static Highscore myHighScore;

        public static Player myPlayer;

        public static void FetchData()
        {
            FetchBankData();
            FetchItemData();
            FetchCrewData();
            FetchHighscoreData();
            FetchPlayerData();
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

        private static void FetchHighscoreData()
        {
            var tempHighscore = new Highscore(Path.GetFullPath($"GameData/Highscore.txt"));
            tempHighscore.Load();
            myHighScore = tempHighscore;
        }

        private static void FetchPlayerData()
        {
            var tempPlayer = new Player(Path.GetFullPath($"GameData/PlayerStartingValues.txt"));
            tempPlayer.Load();
            myPlayer = tempPlayer;
        }
        
        private static string[] GetFiles(string aPath) => Directory.GetFiles(Path.GetFullPath($"GameData/{aPath}"));
    }
}