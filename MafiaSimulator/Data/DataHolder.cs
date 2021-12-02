using System;
using System.Collections.Generic;
using System.IO;

namespace MafiaSimulator.Data
{
    public abstract class DataHolder
    {
        protected string myFileName;
        
        protected DataHolder(string fileName) => myFileName = fileName;

        public virtual void Write() {}

        protected Dictionary<string, string> GetVariables()
        {
            var lines = File.ReadAllLines(myFileName);
            var variables = new Dictionary<string, string>();
            
            for (var i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("#") || !lines[i].Contains(":"))
                    continue;
                
                var stringSplit = lines[i].Split(':');
                var key = stringSplit[0];

                var value = "";
                
                for (int j = 1; j < stringSplit.Length; j++)
                    value += stringSplit[j];

                var tempIndex = value.IndexOf('#');

                if (tempIndex != -1)
                    value = value.Substring(0,tempIndex);
                
                variables.Add(key.Trim().ToLower(),value.Trim());
            }

            return variables;
        }
        
        protected int ConvertToIntParameter(string variable, string key)
        {
            if (!int.TryParse(variable, out var tempConverted))
                ConvertFailed(key, myFileName);
            return tempConverted;
        }

        protected string IsCorrectCheck(string variable, string key)
        {
            if (string.IsNullOrEmpty(variable))
                ConvertFailed(key, myFileName);
            return variable;
        }
        
        private void ConvertFailed(string key, string fileName)
        {
            Console.WriteLine($"Converting Failed! at the file: {fileName} at the key: {key}");
            TextManager.ConsoleWriteLine("Press any key to Continue!", ConsoleColor.Red);
            Environment.Exit(0); 
        }

        public abstract void Load();
    }
}