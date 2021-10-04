using System;

namespace MafiaSimulator.Data
{
    public class Crew : DataHolder
    {
        private string myName;
        public string GetName => myName;

        private int myCost;
        public int GetCost => myCost;

        private int myLoyalty;
        public int GetLoyalty => myLoyalty;

        private int myOffense;
        public int GetOffense => myOffense;

        private int myDefense;
        public int GetDefense => myDefense;
        
        private int mySkill;
        public int GetSkill => mySkill;
        
        private int myCovert;
        public int GetCovert => myCovert;
        
        private int MyUnlockPopularity;
        public int GetUnlockPopularity => MyUnlockPopularity;

        public Crew(string aFileName) : base(aFileName) { } 
        
        public override void Load()
        {
            var tempVariables = GetVariables();
            
            myName = IsCorrectCheck(tempVariables["name"],"name");
            myCost = ConvertToIntParameter(tempVariables["cost"], "cost");
            myLoyalty = ConvertToIntParameter(tempVariables["loyalty"], "loyalty");
            myOffense = ConvertToIntParameter(tempVariables["offense"], "offense");
            myDefense = ConvertToIntParameter(tempVariables["defense"], "defense");
            mySkill = ConvertToIntParameter(tempVariables["skill"], "skill");
            myCovert = ConvertToIntParameter(tempVariables["covert"], "covert");
            MyUnlockPopularity = ConvertToIntParameter(tempVariables["popularity"], "popularity");
        }
    }
}