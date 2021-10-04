using System;
using System.IO;

namespace MafiaSimulator.Data
{
    public class HighScore : DataHolder
    {
        public HighScore(string aFileName) : base(aFileName) { } 
        
        public string myName;

        public int myScore;

        public string myDate;
        
        public override void Write()
        {
            var tempArray = File.ReadAllLines(myFileName);

            tempArray[0] = EditLine(tempArray[0], DataManager.FetchMyContent<Player>(0).MyName);
            tempArray[1] = EditLine(tempArray[1], DataManager.FetchMyContent<Player>(0).MyScore.ToString());
            tempArray[2] = EditLine(tempArray[2], DateTime.Today.ToString().Replace(" 00:00:00", ""));

            File.WriteAllLines(myFileName, tempArray);
        }
        
        private string EditLine(string aLine, string aReplaceVariable)
        {
            var tempStringSplit = aLine.Split(':');

            tempStringSplit[0] += ":";

            var tempAfterKeySplit = tempStringSplit[1].Split('#');

            tempAfterKeySplit[0] = tempAfterKeySplit[0].Replace(tempAfterKeySplit[0].Trim(), aReplaceVariable);
            tempAfterKeySplit[1] = "#" + tempAfterKeySplit[1];

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