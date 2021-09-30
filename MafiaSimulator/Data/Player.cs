using System;
using System.Collections.Generic;
using MafiaSimulator.Utils;

namespace MafiaSimulator
{
    public class Player : DataHolder
    {
        private string myName;
        public string AccessName {get => myName; set => myName = value; }

        private int myScore;
        public int GetScore {get => myScore;}
        
        private int myMoney;
        public int GetMoney {get => myMoney;}
        
        private int myPopularity;
        public int GetPopularity {get => myPopularity;}

        public List<Crew> myCrew = new List<Crew>();

        public List<Item> myItems = new List<Item>();
        
        public Player(string aFileName) : base(aFileName) { } 
        
        public override void Load()
        {
            var tempVariables = GetVariables();

            myScore = 0;
            myMoney = ConvertToIntParameter(tempVariables["money"], "money");
            myPopularity = ConvertToIntParameter(tempVariables["popularity"], "popularity");
        }
    }
}