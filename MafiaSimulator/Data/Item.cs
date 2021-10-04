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

        public Item(string aFileName) : base(aFileName) { } 
        
        public override void Load()
        {
            var tempVariables = GetVariables();
            
            myName = IsCorrectCheck(tempVariables["name"],"name");
            myType = ConvertToIntParameter(tempVariables["type"], "type");
            myLevel = ConvertToIntParameter(tempVariables["level"], "level");
        }
    }
}