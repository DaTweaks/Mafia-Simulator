using System;
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

        public override void Load()
        {
            var tempVariables = GetVariables();
            
            myName = IsCorrectCheck(tempVariables["name"],"name");
            myScore = ConvertToIntParameter(tempVariables["score"], "score");
            myDate = IsCorrectCheck(tempVariables["time"], "time");
        }
    }
}