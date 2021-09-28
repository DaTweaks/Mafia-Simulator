using System;
using System.Collections.Generic;
using MafiaSimulator.Utils;

namespace MafiaSimulator
{
    public class Player : DataHolder
    {
        private string myName;
        public string AccessName {get => myName;}

        private int myScore;
        public int AccessScore {get => myScore;}
        
        private int myMoney;
        public int AccessMoney {get => myMoney;}
        
        private int myPopularity;
        public int AccessPopularity {get => myPopularity;}

        public List<Crew> myCrew = new List<Crew>();

        public List<Item> myItems = new List<Item>();
        
        public Player(string aFileName) : base(aFileName) { } 
        
        public override void Load()
        {
            var tempVariables = GetVariables();

            myMoney = ConvertToIntParameter(tempVariables["money"], "money");
            myPopularity = ConvertToIntParameter(tempVariables["popularity"], "popularity");
        }
    }
}