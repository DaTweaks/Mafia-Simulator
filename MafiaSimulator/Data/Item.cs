using System;
using MafiaSimulator.Utils;

namespace MafiaSimulator
{
    public class Item : DataHolder
    {
        private string myName; 
        public string AccessName {get => myName;}

        private int myType;
        public int AccessType {get => myType;}

        private int myLevel;
        public int AccessLevel {get => myLevel;}
        
        public Item(string aFileName) : base(aFileName) { } 
        
        public override void Load()
        {
            var tempVariables = GetVariables();
            
            myName = IsCorrectCheck(tempVariables["name"],"name");
            Console.WriteLine(myName);
            myType = ConvertToIntParameter(tempVariables["type"], "type");
            myLevel = ConvertToIntParameter(tempVariables["level"], "level");
        }
    }
}