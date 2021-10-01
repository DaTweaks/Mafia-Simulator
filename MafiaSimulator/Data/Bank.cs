using System;
using System.Security.Cryptography;
using MafiaSimulator.Data;

namespace MafiaSimulator
{
    public class Bank : DataHolder
    {
        private string MyName;
        public string GetName => MyName;

        private int MyMoneyReward;
        public int GetMoneyReward => MyMoneyReward;

        private int MySecurity;
        public int GetSecurity => MySecurity;

        private int MyGullibility;
        public int GetGullibility => MyGullibility;

        private int MyUnlockPopularity;
        public int GetUnlockPopularity => MyUnlockPopularity;

        private int MyPopularityReward;
        public int GetPopularityReward => MyPopularityReward;

        public Bank(string aFileName) : base(aFileName) { } 
        
        public override void Load()
        {
            var tempVariables = GetVariables();
            
            MyName = IsCorrectCheck(tempVariables["name"],"name");
            Program.ConsoleWriteLine(MyName, ConsoleColor.Green);
            MyMoneyReward = ConvertToIntParameter(tempVariables["moneygained"], "moneygained");
            MySecurity = ConvertToIntParameter(tempVariables["security"], "security");
            MyGullibility = ConvertToIntParameter(tempVariables["gullibility"], "gullibility");
            MyUnlockPopularity = ConvertToIntParameter(tempVariables["popularity"], "popularity");
            MyPopularityReward = ConvertToIntParameter(tempVariables["popularitygained"], "popularitygained");
        }
    }
}