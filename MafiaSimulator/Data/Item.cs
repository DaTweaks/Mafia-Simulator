using System;

namespace MafiaSimulator.Data
{
    public class Item : DataHolder
    {
        private string _name; 
        public string GetName => _name;

        private int _type;
        public int GetType => _type;

        private int _level;
        public int GetLevel => _level;
        
        private int _unlockPopularity;
        public int GetUnlockPopularity => _unlockPopularity;
        
        private int _cost;
        public int GetCost => _cost;
        
        private int _sellCost;
        public int GetSellCost => _sellCost;

        public Item(string fileName) : base(fileName) { } 
        
        public void ShowStats(bool showSellCost = false, bool showCost = true)
        {
            TextManager.ConsoleWriteLine($"==================================");
            TextManager.ConsoleWriteLine($"Name     : {_name}");
            TextManager.ConsoleWriteLine($"{(_type == 0 ? "Offense" : "Defense")}  : {_level}");
            if(showCost)
                TextManager.ConsoleWriteLine($"Cost     : {_cost}");
            if (showSellCost)
                TextManager.ConsoleWriteLine($"Sellcost : {_cost}");
            TextManager.ConsoleWriteLine($"==================================");
        }
        
        public override void Load()
        {
            var variables = GetVariables();
            
            _name = IsCorrectCheck(variables["name"],"name");
            _type = ConvertToIntParameter(variables["type"], "type");
            _level = ConvertToIntParameter(variables["level"], "level");
            _unlockPopularity = ConvertToIntParameter(variables["popularity"], "popularity");
            _cost = ConvertToIntParameter(variables["cost"], "cost");
            _sellCost = ConvertToIntParameter(variables["sellcost"], "sellcost");
        }
    }
}