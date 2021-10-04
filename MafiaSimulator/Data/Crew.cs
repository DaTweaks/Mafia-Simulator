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
        
        private int myUnlockPopularity;
        public int GetUnlockPopularity => myUnlockPopularity;
        
        private Item myWeapon;
        public Item AccessWeapon { get => myWeapon; set => myWeapon = value; }
        
        private Item myArmour;
        public Item AccessArmour { get => myArmour; set => myArmour = value; }
        

        public Crew(string aFileName) : base(aFileName) { }

        public void ShowStats(bool tempShowItems = false, bool tempShowCost = true)
        {
            Program.ConsoleWriteLine($"==================================");
            Program.ConsoleWriteLine($"Name     : {myName}");
            Program.ConsoleWriteLine($"Offense  : {myOffense}");
            Program.ConsoleWriteLine($"Defense  : {myDefense}");
            Program.ConsoleWriteLine($"Covert   : {myCovert}");
            Program.ConsoleWriteLine($"Skill    : {mySkill}");
            if (tempShowItems)
            {
                Program.ConsoleWriteLine($"Weapon   : {(myWeapon == null ? "Empty" : myWeapon.GetName)}");
                Program.ConsoleWriteLine($"Armour   : {(myArmour == null ? "Empty" : myArmour.GetName)}");
            }
            if(tempShowCost)
                Program.ConsoleWriteLine($"Cost     : {myCost}");
            Program.ConsoleWriteLine($"==================================");
        }
        
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
            myUnlockPopularity = ConvertToIntParameter(tempVariables["popularity"], "popularity");
        }
    }
}