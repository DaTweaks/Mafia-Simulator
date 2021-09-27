using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace MafiaSimulator
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            FetchGameData();
        }
        
        public static void FetchGameData()
        {
            var banks = GetFileVariables("Banks");
            var items = GetFileVariables("Items");
            var crew = GetFileVariables("Crew");
            for (int i = 0; i < banks.Count; i++)
            {
                // NAME (can't be empty)
                // MONEYGAINED (> 0, the amount of money gained by a completed heist)
                // SECURITY (> 0, how secure the bank is)
                // GULLIBILITY (> 0, how easily tricked the bank is)
                // POPULARITY (> 0, the amount of popularity needed to unlock)
                // POPULARITYGAINED (> 0, the amount of popularity gained from heisting) 
            }
            for (int i = 0; i < items.Count; i++)
            {
                for (int j = 0; j < items[i].Count; j++)
                {
                    Console.WriteLine(items[i][j]);
                }
            }
            for (int i = 0; i < crew.Count; i++)
            {
                for (int j = 0; j < crew[i].Count; j++)
                {
                    Console.WriteLine(crew[i][j]);
                }
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
                    {
                        textinfo.Add(tempText.GetString(tempArray));
                    }
                    fileInfo.Add(textinfo);
                }
            }

            return fileInfo;
        }
       
    }
}