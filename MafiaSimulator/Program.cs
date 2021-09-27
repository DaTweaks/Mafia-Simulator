using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace MafiaSimulator
{
    internal class Program
    {
        public static List<Bank> loadedBanks = new List<Bank>();
        public static List<item> loadedItems = new List<item>();
        public static List<Crew> loadedCrews = new List<Crew>();
        public static void Main(string[] args)
        {
            FetchGameData();
        }
        
        public static void FetchGameData()
        {
            var tempBanks = GetFileVariables("Banks");
            var tempItems = GetFileVariables("Items");
            var tempCrew = GetFileVariables("Crew");
            for (int i = 0; i < loadedBanks.Count; i++)
            {
                loadedBanks.Add(
                    new Bank(
                        tempBanks[i][0], 
                        // NAME
                        Convert.ToInt32(tempBanks[i][1]), 
                        // MONEYGAINED
                        Convert.ToInt32(tempBanks[i][2]), 
                        // SECURITY
                        Convert.ToInt32(tempBanks[i][3]), 
                        // GULLIBILITY 
                        Convert.ToInt32(tempBanks[i][4]), 
                        // POPULARITY 
                        Convert.ToInt32(tempBanks[i][5])
                        // POPULARITYGAINED 
                        )
                    );
            }
            for (int i = 0; i < tempItems.Count; i++)
            {
                loadedItems.Add(
                    new item(
                        tempItems[i][0], 
                        // NAME
                        Convert.ToInt32(tempItems[i][1]), 
                        // TYPE
                        Convert.ToInt32(tempItems[i][2])
                        // LEVEL
                        )
                    );
            }
            for (int i = 0; i < tempCrew.Count; i++)
            {
                loadedCrews.Add(
                    new Crew(
                        tempCrew[i][0], 
                        // NAME
                        Convert.ToInt32(tempCrew[i][1]),
                        // COST
                        Convert.ToInt32(tempCrew[i][2]),
                        // LOYALTY
                        Convert.ToInt32(tempCrew[i][3]),
                        // OFFENSE
                        Convert.ToInt32(tempCrew[i][4]),
                        // DEFENSE
                        Convert.ToInt32(tempCrew[i][5]),
                        // SKILL
                        Convert.ToInt32(tempCrew[i][6]),
                        // COVERT
                        Convert.ToInt32(tempCrew[i][7])
                        // POPULARITY
                        )
                    );
            }
        }

        public static List<List<string>> GetFileVariables(string tempPath)
        {
            var files = Directory.GetFiles(Path.GetFullPath($"GameData/{tempPath}"));
            List<List<string>> fileInfo = new List<List<string>>();
            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Contains("TEMPLATE"))
                    break;
                
                using (FileStream tempFileStream = File.OpenRead(Path.GetFullPath(files[i])))
                {
                    byte[] tempArray = new byte[tempFileStream.Length];
                    var tempText = new UTF8Encoding(true);
                    List<string> textinfo = new List<string>();
                    while (tempFileStream.Read(tempArray,0,tempArray.Length) > 0)
                        textinfo.Add(tempText.GetString(tempArray));
                    
                    fileInfo.Add(textinfo);
                }
            }

            return fileInfo;
        }
       
    }
}