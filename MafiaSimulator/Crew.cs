namespace MafiaSimulator
{
    public class Crew
    {
        public Crew(
            string name, 
            int cost, 
            int loyalty, 
            int offense, 
            int defense,
            int skill,
            int covert,
            int unlockPopularity
        )
        {
            myName = name;
            myCost = cost;
            myLoyalty = loyalty;
            myOffense = offense;
            myDefense = defense;
            mySkill = skill;
            myCovert = covert;
            myUnlockPopularity = unlockPopularity;

        }

        private string myName;
        public string AccessName {get => myName;}
            
        private int myCost;
        public int AccessCost {get => myCost;}
        
        private int myLoyalty;
        public int AccessLoyalty {get => myLoyalty;}
        
        private int myOffense;
        public int AccessOffense {get => myOffense;}
        
        private int myDefense;
        public int AccessDefense {get => myDefense;}
        
        private int mySkill;
        public int AccessSkill {get => mySkill;}
        
        private int myCovert;
        public int AccessCovert {get => myCovert;}
        
        private int myUnlockPopularity;
        public int AccessUnlockPopularity {get => myUnlockPopularity;}
    }
}