using System;
using System.Security.Cryptography;
using MafiaSimulator.Utils;

namespace MafiaSimulator
{
    public class Bank : DataHolder
    {
        private string myName;
        public string AccessName {get => myName;}
                 
        private int myMoneyReward;
        public int AccessMoneyReward {get => myMoneyReward;}
             
        private int mySecurity;
        public int AccessSecurity {get => mySecurity;}
             
        private int myGullibility;
        public int AccessGullibility {get => myGullibility;}
             
        private int myUnlockPopularity;
        public int AccessUnlockPopularity {get => myUnlockPopularity;}
             
        private int myPopularityReward;
        public int AccessPopularityReward {get => myPopularityReward;}

        public Bank(string aFileName) : base(aFileName) { } 
        
        public override void Load()
        {
            var tempVariables = GetVariables();
            
            myName = IsCorrectCheck(tempVariables["name"],"name");
            Console.WriteLine(myName);
            myMoneyReward = ConvertToIntParameter(tempVariables["moneygained"], "moneygained");
            mySecurity = ConvertToIntParameter(tempVariables["security"], "security");
            myGullibility = ConvertToIntParameter(tempVariables["gullibility"], "gullibility");
            myUnlockPopularity = ConvertToIntParameter(tempVariables["popularity"], "popularity");
            myPopularityReward = ConvertToIntParameter(tempVariables["popularitygained"], "popularitygained");
        }
    }
}