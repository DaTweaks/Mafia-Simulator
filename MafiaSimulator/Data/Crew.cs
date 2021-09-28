using System;
using MafiaSimulator.Utils;

namespace MafiaSimulator
{
    public class Crew : DataHolder
    {
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
        
        public Crew(string aFileName) : base(aFileName) { } 
        
        public override void Load()
        {
            var tempVariables = GetVariables();
            
            myName = IsCorrectCheck(tempVariables["name"],"name");
            Console.WriteLine(myName);
            myCost = ConvertToIntParameter(tempVariables["cost"], "cost");
            myLoyalty = ConvertToIntParameter(tempVariables["loyalty"], "loyalty");
            myOffense = ConvertToIntParameter(tempVariables["offense"], "offense");
            myDefense = ConvertToIntParameter(tempVariables["defense"], "defense");
            mySkill = ConvertToIntParameter(tempVariables["skill"], "skill");
            myCovert = ConvertToIntParameter(tempVariables["covert"], "covert");
            myUnlockPopularity = ConvertToIntParameter(tempVariables["popularity"], "popularity");
        }
    }
}