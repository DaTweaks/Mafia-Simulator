using System;
using System.Collections.Generic;
using System.IO;

namespace MafiaSimulator.Data
{
    public static class DataManager
    {
        public static Dictionary<Type, List<object>> MyContent = new Dictionary<Type, List<object>>();
        
        public static void FetchData()
        {
            MyContent.Clear();
            FetchFolderData<Bank>("Banks");
            FetchFolderData<Item>("Items");
            FetchFolderData<Crew>("Crew");
            FetchFolderData<HighScore>("HighScore");
            FetchFolderData<Player>("PlayerStartingValues");
        }

        private static void FetchFolderData<T>(string aPath)
        {
            var aClassType = typeof(T);
            if (aClassType.IsAssignableFrom(typeof(DataHolder)))
            {
                Console.WriteLine("the Class doesn't have the DataHolder extension.");
                TextManager.ConsoleWriteLine("Press any key to Continue!", ConsoleColor.Red, true);
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

                if(!MyContent.ContainsKey(aClassType))
                    MyContent.Add(aClassType, new List<object>());
                MyContent[aClassType].Add(tempObj);
            }
        }

        public static T FetchMyContent<T>(int myPosition) where T : DataHolder => MyContent[typeof(T)][myPosition] as T;

        public static List<T> FetchMyContentList<T>() where T : DataHolder
        {
            List<T> tempClassList = new List<T>();

            var tempObjectList = MyContent[typeof(T)];
            
            for (int i = 0; i < tempObjectList.Count; i++)
                tempClassList.Add(tempObjectList[i] as T);
            
            return tempClassList;
        }

        private static string[] GetFiles(string aPath) => Directory.GetFiles(Path.GetFullPath($"GameData/{aPath}"));
    }
}