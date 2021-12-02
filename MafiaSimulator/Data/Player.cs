using System;
using System.Collections.Generic;

namespace MafiaSimulator.Data
{
    public class Player : DataHolder
    {
        public string Name;
        
        public int Score;

        public int Money;

        public int Popularity;

        public Tuple<int,int> Discovered;

        public List<Crew> Crew = new List<Crew>();

        public List<Item> Items = new List<Item>();
        
        public Player(string fileName) : base(fileName) { }

        public override void Load()
        {
            var variables = GetVariables();
            
            Discovered = new Tuple<int, int>(0,ConvertToIntParameter(variables["maxdiscovered"], "maxdiscovered"));
            Money = ConvertToIntParameter(variables["money"], "money");
            Popularity = ConvertToIntParameter(variables["popularity"], "popularity");
        }
    }
}