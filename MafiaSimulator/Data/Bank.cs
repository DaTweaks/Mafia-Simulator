using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using MafiaSimulator.Data;
using MafiaSimulator.Scenes;

namespace MafiaSimulator
{
    public class Bank : DataHolder
    {
        private string _name;
        public string GetName => _name;

        private int _moneyReward;
        public int GetMoneyReward => _moneyReward;

        private int _security;
        public int GetSecurity => _security;

        private int _gullibility;
        public int GetGullibility => _gullibility;

        private int _unlockPopularity;
        public int GetUnlockPopularity => _unlockPopularity;

        private int _popularityReward;
        public int GetPopularityReward => _popularityReward;

        public Bank(string fileName) : base(fileName) { }

        public void Heist(Player player)
        {
            Console.Clear();
            var events = new List<string>();

            if (Program.Random.Next(0, _gullibility) == 0)
                events.Add($"They were tricked by: {player.Crew[Program.Random.Next(0, player.Crew.Count)].GetName} And they just gave us all the cash!");

            for (var i = 0; i < player.Crew.Count; i++)
            {
                if (Program.Random.Next(0, _security + player.Crew[i].GetDefense + (player.Crew[i].AccessArmour != null ? player.Crew[i].AccessArmour.GetLevel : 0)) == 0)
                {
                    events.Add($"{player.Crew[i].GetName} Died!, and you lost everything it was equipped with!");
                    if (Program.Random.Next(0, player.Crew[i].GetCovert) == 0)
                    {
                        events.Add($"{player.Crew[i].GetName} Left some evidence.");
                        player.Discovered = new Tuple<int, int>(player.Discovered.Item1 + 1, player.Discovered.Item1);
                    }
                    player.Crew.RemoveAt(i);
                }

                if (Program.Random.Next(0, player.Crew[i].GetSkill) == 0 && player.Crew[i].AccessWeapon != null)
                {
                    events.Add($" {player.Crew[i].GetName} Broke His Weapon!");
                    player.Crew[i].AccessWeapon = null;
                }

                if (Program.Random.Next(0, player.Crew[i].GetSkill) == 0 && player.Crew[i].AccessArmour != null)
                {
                    events.Add($" {player.Crew[i].GetName} Broke His Armour!");
                    player.Crew[i].AccessArmour = null;
                }

                if (Program.Random.Next(0, player.Crew[i].GetLoyalty) == 0)
                {
                    events.Add($"{player.Crew[i].GetName} Decided to leave the team!");
                    player.Crew.RemoveAt(i);
                }
            }
            

            var tempTotalOffense = 0;
            for (var i = 0; i < player.Crew.Count; i++)
                tempTotalOffense += (player.Crew[i].AccessWeapon != null ? player.Crew[i].AccessWeapon.GetLevel : 0) + player.Crew[i].GetOffense;

            TextManager.ConsoleWriteLine("Your Crew came out Victorious and you gained:");
            TextManager.ConsoleWriteLine($"{tempTotalOffense*_moneyReward} Money");
            TextManager.ConsoleWriteLine($"{_popularityReward} Popularity");

            player.Money += tempTotalOffense * _moneyReward;
            player.Popularity += _popularityReward;
            player.Score += 1;

            HeistEnd(events);
        }

        private void HeistEnd(List<string> events)
        {
            while (true)
            {
                try
                {
                    TextManager.DisplayPlayerStats();
                    TextManager.ConsoleWriteLine($"1 : Continue!");
                    TextManager.ConsoleWriteLine($"2 : Show Events!");
                    
                    switch (int.TryParse(Console.ReadLine(), out var temp) ? temp : throw new Exception("This isn't a Number!"))
                    {
                        case 1:
                            TextManager.ConsoleWriteContinue("Continuing!");
                            return;
                        case 2:
                            TextManager.ConsoleWriteLine("The Events:");
                            for (int i = 0; i < events.Count; i++)
                                TextManager.ConsoleWriteLine($"{i}  {events[i]}");
                            TextManager.ConsoleWriteContinue("Continuing!");
                                return;
                        default:
                            throw new Exception("This isn't a valid number!");
                    }
                }
                catch (Exception e)
                {
                    TextManager.ConsoleWriteContinue(e.Message, ConsoleColor.Red,ConsoleColor.Red);
                } 
            }
        }
        
        public void ShowStats()
        {
            TextManager.ConsoleWriteLine($"==================================");
            TextManager.ConsoleWriteLine($"Name         : {_name}");
            TextManager.ConsoleWriteLine($"Reward       : {_moneyReward}");
            TextManager.ConsoleWriteLine($"Security     : {_security}");
            TextManager.ConsoleWriteLine($"Gullibility  : {_gullibility}");
            TextManager.ConsoleWriteLine($"Popularity   : {_popularityReward}");
            TextManager.ConsoleWriteLine($"==================================");
        }
        
        public override void Load()
        {
            var tempVariables = GetVariables();
            
            _name = IsCorrectCheck(tempVariables["name"],"name");
            _moneyReward = ConvertToIntParameter(tempVariables["moneygained"], "moneygained");
            _security = ConvertToIntParameter(tempVariables["security"], "security");
            _gullibility = ConvertToIntParameter(tempVariables["gullibility"], "gullibility");
            _unlockPopularity = ConvertToIntParameter(tempVariables["popularity"], "popularity");
            _popularityReward = ConvertToIntParameter(tempVariables["popularitygained"], "popularitygained");
        }
    }
}