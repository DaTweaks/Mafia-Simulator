using System;

namespace MafiaSimulator.Data
{
    public class Crew : DataHolder
    {
        private string MyName;
        public string GetName => MyName;

        private int MyCost;
        public int GetCost => MyCost;

        private int MyLoyalty;
        public int GetLoyalty => MyLoyalty;

        private int MyOffense;
        public int GetOffense => MyOffense;

        private int MyDefense;
        public int GetDefense => MyDefense;
        
        private int MySkill;
        public int GetSkill => MySkill;
        
        private int MyCovert;
        public int GetCovert => MyCovert;
        
        private int MyUnlockPopularity;
        public int GetUnlockPopularity => MyUnlockPopularity;

        public Crew(string aFileName) : base(aFileName) { } 
        
        public override void Load()
        {
            var tempVariables = GetVariables();
            
            MyName = IsCorrectCheck(tempVariables["name"],"name");
            Program.ConsoleWriteLine(MyName, ConsoleColor.Green);
            MyCost = ConvertToIntParameter(tempVariables["cost"], "cost");
            MyLoyalty = ConvertToIntParameter(tempVariables["loyalty"], "loyalty");
            MyOffense = ConvertToIntParameter(tempVariables["offense"], "offense");
            MyDefense = ConvertToIntParameter(tempVariables["defense"], "defense");
            MySkill = ConvertToIntParameter(tempVariables["skill"], "skill");
            MyCovert = ConvertToIntParameter(tempVariables["covert"], "covert");
            MyUnlockPopularity = ConvertToIntParameter(tempVariables["popularity"], "popularity");
        }
    }
}