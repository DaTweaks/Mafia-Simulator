using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Threading;

namespace MafiaSimulator
{
    internal class Program
    {
        public static List<Bank> loadedBanks = new List<Bank>();
        public static List<item> loadedItems = new List<item>();
        public static List<Crew> loadedCrews = new List<Crew>();

        public static Tuple<string, int> highscore;
        
        public static void FetchGameData()
        {
            try
            {
                var tempBanks = GetFoldersFileVariables("Banks");
                var tempItems = GetFoldersFileVariables("Items");
                var tempCrew = GetFoldersFileVariables("Crew");
                var tempHighscore = GetFileVariables("Highscore");
            
                highscore = new Tuple<string, int>(tempHighscore[0], Convert.ToInt32(tempHighscore[1]));
                for (int i = 0; i < tempBanks.Count; i++)
                {
                    loadedBanks.Add(
                        new Bank(
                            tempBanks[i][0],
                            Convert.ToInt32(tempBanks[i][1]),
                            Convert.ToInt32(tempBanks[i][2]),
                            Convert.ToInt32(tempBanks[i][3]),
                            Convert.ToInt32(tempBanks[i][4]),  
                            Convert.ToInt32(tempBanks[i][5])
                        )
                    );
                }
                for (int i = 0; i < tempItems.Count; i++)
                {
                    loadedItems.Add(
                        new item(
                            tempItems[i][0],
                            Convert.ToInt32(tempItems[i][1]),
                            Convert.ToInt32(tempItems[i][2])
                        )
                    );
                }
                for (int i = 0; i < tempCrew.Count; i++)
                {
                    loadedCrews.Add(
                        new Crew(
                            tempCrew[i][0],
                            FileLineConvert(tempCrew.Count, 1)
                            Convert.ToInt32(tempCrew[i][1]),
                            Convert.ToInt32(tempCrew[i][2]),
                            Convert.ToInt32(tempCrew[i][3]),
                            Convert.ToInt32(tempCrew[i][4]),
                            Convert.ToInt32(tempCrew[i][5]),
                            Convert.ToInt32(tempCrew[i][6]),
                            Convert.ToInt32(tempCrew[i][7])
                        )
                    );
                }
            }
            catch (Exception e)
            {
                
            }

        }

        public static int FileLineConvert(string fileName, int lineNumber, string toConvert)
        {
            int tempConverted;
            if(!int.TryParse(toConvert, out tempConverted))
            {
                Console.WriteLine($"Converting Failed! at the file: {fileName} at the line: {lineNumber}");
                ContinueText();
                Environment.Exit(0);
            }
            return tempConverted;
        }

        public static List<string> GetFileVariables(string tempPath)
        {
            using (FileStream tempFileStream = File.OpenRead(Path.GetFullPath($"Gamedata/{tempPath}")))
            {
                byte[] tempArray = new byte[tempFileStream.Length];
                var tempText = new UTF8Encoding(true);
                List<string> fileInfo = new List<string>();
                while (tempFileStream.Read(tempArray,0,tempArray.Length) > 0)
                    fileInfo.Add(tempText.GetString(tempArray));
                return fileInfo;
            }
        }
        
        public static List<List<string>> GetFoldersFileVariables(string tempPath)
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
        public static void Main(string[] args)
        {
            FetchGameData();
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