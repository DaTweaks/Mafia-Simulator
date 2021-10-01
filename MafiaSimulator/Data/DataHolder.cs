using System;
using System.Collections.Generic;
using System.IO;

namespace MafiaSimulator.Data
{
    public abstract class DataHolder
    {
        protected string MyFileName;
        
        protected DataHolder(string aFileName) => MyFileName = aFileName;

        public virtual void Write() {}

        protected Dictionary<string, string> GetVariables()
        {
            var tempLines = File.ReadAllLines(MyFileName);
            Dictionary<string, string> tempVariables = new Dictionary<string, string>();
            
            for (int i = 0; i < tempLines.Length; i++)
            {
                if (tempLines[i].StartsWith("#") || !tempLines[i].Contains(":"))
                    continue;
                
                var tempStringSplit = tempLines[i].Split(':');
                var tempKey = tempStringSplit[0];

                var tempValue = "";
                
                for (int j = 1; j < tempStringSplit.Length; j++)
                    tempValue += tempStringSplit[j];

                var tempIndex = tempValue.IndexOf('#');

                if (tempIndex != -1)
                    tempValue = tempValue.Substring(0,tempIndex);
                
                tempVariables.Add(tempKey.Trim().ToLower(),tempValue.Trim());
            }

            return tempVariables;
        }
        
        protected int ConvertToIntParameter(string aVariable, string aKey)
        {
            if (!int.TryParse(aVariable, out var tempConverted))
                ConvertFailed(aKey, MyFileName);
            return tempConverted;
        }

        protected string IsCorrectCheck(string aVariable, string aKey)
        {
            if (string.IsNullOrEmpty(aVariable))
                ConvertFailed(aKey, MyFileName);
            return aVariable;
        }
        
        protected void ConvertFailed(string aKey, string aFileName)
        {
            Console.WriteLine($"Converting Failed! at the file: {aFileName} at the key: {aKey}");
            Program.ConsoleWriteLine("Press any key to Continue!", ConsoleColor.Red);
            Environment.Exit(0); 
        }

        public abstract void Load();
    }
}