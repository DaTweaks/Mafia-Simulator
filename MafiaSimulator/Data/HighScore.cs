using System;
using System.IO;

namespace MafiaSimulator.Data
{
    public class HighScore : DataHolder
    {
        public HighScore(string fileName) : base(fileName) { } 
        
        public string Name;

        public int Score;

        public string Date;
        
        public override void Write()
        {
            var lines = File.ReadAllLines(myFileName);

            lines[0] = EditLine(lines[0], DataManager.FetchMyContent<Player>(0).Name);
            lines[1] = EditLine(lines[1], DataManager.FetchMyContent<Player>(0).Score.ToString());
            lines[2] = EditLine(lines[2], DateTime.Today.ToString().Replace(" 00:00:00", ""));

            File.WriteAllLines(myFileName, lines);
        }
        
        private string EditLine(string aLine, string aReplaceVariable)
        {
            var stringSplit = aLine.Split(':');

            stringSplit[0] += ":";

            var tempAfterKeySplit = stringSplit[1].Split('#');

            tempAfterKeySplit[0] = tempAfterKeySplit[0].Replace(tempAfterKeySplit[0].Trim(), aReplaceVariable);
            tempAfterKeySplit[1] = "#" + tempAfterKeySplit[1];

            var join = "";
            
            for (int i = 0; i < tempAfterKeySplit.Length; i++)
                join += tempAfterKeySplit[i];

            return stringSplit[0] + join;
        }
        
        public override void Load()
        {
            var variables = GetVariables();
            
            Name = IsCorrectCheck(variables["name"],"name");
            Score = ConvertToIntParameter(variables["score"], "score");
            Date = IsCorrectCheck(variables["time"], "time");
        }
    }
}