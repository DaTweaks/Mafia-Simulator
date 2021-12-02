using System;

namespace MafiaSimulator.Data
{
    public class Crew : DataHolder
    {
        private string _name;
        public string GetName => _name;

        private int _cost;
        public int GetCost => _cost;

        private int _loyalty;
        public int GetLoyalty => _loyalty;

        private int _offense;
        public int GetOffense => _offense;

        private int _defense;
        public int GetDefense => _defense;
        
        private int _skill;
        public int GetSkill => _skill;
        
        private int _covert;
        public int GetCovert => _covert;
        
        private int _unlockPopularity;
        public int GetUnlockPopularity => _unlockPopularity;
        
        private Item _weapon;
        public Item AccessWeapon { get => _weapon; set => _weapon = value; }
        
        private Item _armour;
        public Item AccessArmour { get => _armour; set => _armour = value; }
        

        public Crew(string fileName) : base(fileName) { }

        public void ShowStats(bool showItems = false, bool showCost = true)
        {
            TextManager.ConsoleWriteLine($"==================================");
            TextManager.ConsoleWriteLine($"Name     : {_name}");
            TextManager.ConsoleWriteLine($"Offense  : {_offense}");
            TextManager.ConsoleWriteLine($"Defense  : {_defense}");
            TextManager.ConsoleWriteLine($"Covert   : {_covert}");
            TextManager.ConsoleWriteLine($"Skill    : {_skill}");
            if (showItems)
            {
                TextManager.ConsoleWriteLine($"Weapon   : {(_weapon == null ? "Empty" : _weapon.GetName)}");
                TextManager.ConsoleWriteLine($"Armour   : {(_armour == null ? "Empty" : _armour.GetName)}");
            }
            if(showCost)
                TextManager.ConsoleWriteLine($"Cost     : {_cost}");
            TextManager.ConsoleWriteLine($"==================================");
        }
        
        public override void Load()
        {
            var variables = GetVariables();
            
            _name = IsCorrectCheck(variables["name"],"name");
            _cost = ConvertToIntParameter(variables["cost"], "cost");
            _loyalty = ConvertToIntParameter(variables["loyalty"], "loyalty");
            _offense = ConvertToIntParameter(variables["offense"], "offense");
            _defense = ConvertToIntParameter(variables["defense"], "defense");
            _skill = ConvertToIntParameter(variables["skill"], "skill");
            _covert = ConvertToIntParameter(variables["covert"], "covert");
            _unlockPopularity = ConvertToIntParameter(variables["popularity"], "popularity");
        }
    }
}