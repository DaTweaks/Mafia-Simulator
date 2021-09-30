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
            var tempArray = File.ReadAllLines(myFileName);

            myName = (DataManager.myContent[typeof(Player)][0] as Player).AccessName;
            myScore = (DataManager.myContent[typeof(Player)][0] as Player).GetScore;
            myDate = DateTime.Today.ToString().Replace(" 00:00:00", "");

            tempArray[0] = EditLine(tempArray[0], myName);
            tempArray[1] = EditLine(tempArray[1], myScore.ToString());
            tempArray[2] = EditLine(tempArray[2], myDate);

            File.WriteAllLines(myFileName, tempArray);
        }
        
        private string EditLine(string aLine, string aReplaceVariable)
        {
            var tempStringSplit = aLine.Split(':');

            tempStringSplit[0] += ": ";

            var tempAfterKeySplit = tempStringSplit[1].Split('#');

            tempAfterKeySplit[0] = aReplaceVariable;
            tempAfterKeySplit[1] = " #" + tempAfterKeySplit[1];

            string tempJoin = "";
            
            for (int i = 0; i < tempAfterKeySplit.Length; i++)
                tempJoin += tempAfterKeySplit[i];

            return tempStringSplit[0] + tempJoin;
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