using System;
using System.Security.Cryptography;
using MafiaSimulator.Data;

namespace MafiaSimulator
{
    public class Bank : DataHolder
    {
        private string myName;
        public string GetName => myName;

        private int myMoneyReward;
        public int GetMoneyReward => myMoneyReward;

        private int mySecurity;
        public int GetSecurity => mySecurity;

        private int myGullibility;
        public int GetGullibility => myGullibility;

        private int myUnlockPopularity;
        public int GetUnlockPopularity => myUnlockPopularity;

        private int myPopularityReward;
        public int GetPopularityReward => myPopularityReward;

        public Bank(string aFileName) : base(aFileName) { } 
        
        public override void Load()
        {
            var tempVariables = GetVariables();
            
            myName = IsCorrectCheck(tempVariables["name"],"name");
            myMoneyReward = ConvertToIntParameter(tempVariables["moneygained"], "moneygained");
            mySecurity = ConvertToIntParameter(tempVariables["security"], "security");
            myGullibility = ConvertToIntParameter(tempVariables["gullibility"], "gullibility");
            myUnlockPopularity = ConvertToIntParameter(tempVariables["popularity"], "popularity");
            myPopularityReward = ConvertToIntParameter(tempVariables["popularitygained"], "popularitygained");
        }
    }
}