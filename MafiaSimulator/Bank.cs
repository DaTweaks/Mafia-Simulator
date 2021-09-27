using System.Security.Cryptography;

namespace MafiaSimulator
{
    public class Bank
    {
        public Bank(
            string name, 
            int moneyReward, 
            int security, 
            int gullibility, 
            int unlockPopularity, 
            int popularityReward
            )
        {
            myName = name;
            myMoneyReward = moneyReward;
            mySecurity = security;
            myGullibility = gullibility;
            myUnlockPopularity = unlockPopularity;
            myPopularityReward = popularityReward;
        }

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
        
    }
}