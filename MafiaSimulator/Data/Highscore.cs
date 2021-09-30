using System;
using System.IO;
using MafiaSimulator.Utils;

namespace MafiaSimulator.Data
{
    public class Highscore : DataHolder
    {
        public Highscore(string aFileName) : base(aFileName) { } 
        
        private string myName;
        public string AccessName {get => myName; set => myName = value; }

        private int myScore;
        public int AccessScore {get => myScore; set => myScore = value; }

        private string myDate;
        public string AccessDate {get => myDate; set => myDate = value; }
        
        public override void Write()
        {
            var tempVariables = GetVariables();

            var tempArray = File.ReadAllLines(myFileName);

            for (int i = 0; i < tempArray.Length; i++)
            {
                if (tempArray[i].StartsWith("#") || !tempArray[i].Contains(":"))
                    continue;

                var tempStringSplit = tempArray[i].Split(':');
                var tempKey = tempStringSplit[0]+":";

                var tempValue = "";
                
                for (int j = 1; j < tempStringSplit.Length; j++)
                    tempValue += tempStringSplit[j];

                var tempIndex = tempValue.IndexOf('#');

                if (tempIndex != -1)
                    tempValue = tempValue.Substring(0,tempIndex);
                
                tempVariables.Add(tempKey.Trim().ToLower(),tempValue.Trim());
            }

            myName = (DataManager.myContent[typeof(Player)][0] as Player).AccessName;
            myScore = (DataManager.myContent[typeof(Player)][0] as Player).GetScore;
            myDate = DateTime.Today.ToString().Replace(" 00:00:00", "");

            File.WriteAllLines(myFileName, tempArray);
        }
        
        private string EditLine(string aLine, string aReplaceVariable)
        {
            if (aLine.StartsWith("#") || !aLine.Contains(":"))
                return aLine;
            
            var tempStringSplit = aLine.Split(':');

            string tempValue = "";
            
            for (int j = 1; j < tempStringSplit.Length; j++)
                tempValue += tempStringSplit[j];
            
            
        }
        
        public override void Load()
        {
            var tempVariables = GetVariables();
            
            myName = IsCorrectCheck(tempVariables["name"],"name");
            myScore = ConvertToIntParameter(tempVariables["score"], "score");
            myDate = IsCorrectCheck(tempVariables["time"], "time");
        }
    }
}