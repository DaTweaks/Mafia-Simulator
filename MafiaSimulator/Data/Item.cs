using System;

namespace MafiaSimulator.Data
{
    public class Item : DataHolder
    {
        private string MyName; 
        public string GetName => MyName;

        private int MyType;
        public int GetType => MyType;

        private int MyLevel;
        public int GetLevel => MyLevel;

        public Item(string aFileName) : base(aFileName) { } 
        
        public override void Load()
        {
            var tempVariables = GetVariables();
            
            MyName = IsCorrectCheck(tempVariables["name"],"name");
            Program.ConsoleWriteLine(MyName, ConsoleColor.Green);
            MyType = ConvertToIntParameter(tempVariables["type"], "type");
            MyLevel = ConvertToIntParameter(tempVariables["level"], "level");
        }
    }
}