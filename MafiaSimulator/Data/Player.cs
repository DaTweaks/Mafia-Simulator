using System.Collections.Generic;

namespace MafiaSimulator.Data
{
    public class Player : DataHolder
    {
        public string MyName;
        
        public int MyScore;

        public int MyMoney;

        public int MyPopularity;

        public List<Crew> MyCrew = new List<Crew>();

        public List<Item> MyItems = new List<Item>();
        
        public Player(string aFileName) : base(aFileName) { }
        
        public override void Load()
        {
            var tempVariables = GetVariables();

            MyName = "";
            MyScore = 0;
            MyMoney = ConvertToIntParameter(tempVariables["money"], "money");
            MyPopularity = ConvertToIntParameter(tempVariables["popularity"], "popularity");
        }
    }
}