using System;

namespace MafiaSimulator.Data
{
    public class Item : DataHolder
    {
        private string myName; 
        public string GetName => myName;

        private int myType;
        public int GetType => myType;

        private int myLevel;
        public int GetLevel => myLevel;
        
        private int myCost;
        public int GetCost => myCost;
        
        private int mySellCost;
        public int GetSellCost => mySellCost;

        public Item(string aFileName) : base(aFileName) { } 
        
        public void ShowStats(bool tempShowSellCost = false, bool tempShowCost = true)
        {
            Program.ConsoleWriteLine($"==================================");
            Program.ConsoleWriteLine($"Name     : {myName}");
            Program.ConsoleWriteLine($"{(myType == 0 ? "Offense" : "Defense")}  : {myLevel}");
            if(tempShowCost)
                Program.ConsoleWriteLine($"Cost     : {myCost}");
            if (tempShowSellCost)
                Program.ConsoleWriteLine($"Sellcost : {myCost}");
            Program.ConsoleWriteLine($"==================================");
        }
        
        public override void Load()
        {
            var tempVariables = GetVariables();
            
            myName = IsCorrectCheck(tempVariables["name"],"name");
            myType = ConvertToIntParameter(tempVariables["type"], "type");
            myLevel = ConvertToIntParameter(tempVariables["level"], "level");   
            myCost = ConvertToIntParameter(tempVariables["cost"], "cost");
            mySellCost = ConvertToIntParameter(tempVariables["sellcost"], "sellcost");
        }
    }
}