using System;
using System.Collections.Generic;
using System.IO;

namespace MafiaSimulator.Utils
{
    public abstract class DataHolder
    {
        private string myFileName;
        
        protected DataHolder(string aFileName)
        {
            myFileName = aFileName;
        }

        public void Write()
        {
            
        }

        protected Dictionary<string, string> GetVariables()
        {
            var tempLines = File.ReadAllLines(myFileName); // Note to self, could not be full path

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
            if (!int.TryParse(aVariable, out var tempConverted) || tempConverted < 0)
                ConvertFailed(aKey, myFileName);
            return tempConverted;
        }

        protected string IsCorrectCheck(string aVariable, string aKey)
        {
            if (string.IsNullOrEmpty(aVariable))
                ConvertFailed(aKey, myFileName);
            return aVariable;
        }
        
        protected void ConvertFailed(string aKey, string aFileName)
        {
            Console.WriteLine($"Converting Failed! at the file: {aFileName} at the key: {aKey}");
            Program.ContinueText();
            Environment.Exit(0); 
        }

        public abstract void Load();
    }
}