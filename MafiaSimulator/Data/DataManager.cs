using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using MafiaSimulator.Data;

namespace MafiaSimulator.Utils
{
    public static class DataManager
    {
        public static Dictionary<Type, List<object>> myContent = new Dictionary<Type, List<object>>();

        public static T FetchMyContent<T>(int myPosition) where T : class => myContent[typeof(T)][myPosition] as T; // i do as rider commands
        
        public static void FetchData()
        {
            FetchFolderData("Banks",typeof(Bank));
            FetchFolderData("Items",typeof(Item));
            FetchFolderData("Crew",typeof(Crew));
            FetchFolderData("Highscore",typeof(Highscore));
            FetchFolderData("PlayerStartingValues",typeof(Player));
        }

        public static void FetchFolderData(string aPath, Type aClassType)
        {
            if (aClassType.IsAssignableFrom(typeof(DataHolder)))
            {
                Console.WriteLine("the Class doesn't have the DataHolder extension.");
                Program.ConsoleWriteLine("Press any key to Continue!", ConsoleColor.Red, true);
                Environment.Exit(0);
                return;
            }

            var tempFiles = GetFiles(aPath);
            for (int i = 0; i < tempFiles.Length; i++)
            {
                if (tempFiles[i].ToLower().Contains("template"))
                    continue;
                
                var tempObj = aClassType.GetConstructor(new[] {typeof(string)})
                    ?.Invoke(new object[] {tempFiles[i]});
                (tempObj as DataHolder)?.Load();

                if(!myContent.ContainsKey(aClassType))
                    myContent.Add(aClassType, new List<object>());
                myContent[aClassType].Add(tempObj);
            }
        }

        private static string[] GetFiles(string aPath) => Directory.GetFiles(Path.GetFullPath($"GameData/{aPath}"));
    }
}