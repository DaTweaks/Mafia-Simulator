using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using MafiaSimulator.Data;
using MafiaSimulator.Scenes;

namespace MafiaSimulator
{
    public class Bank : DataHolder
    {
        private string myName;
        public string GetName => myName;

        private int myMoneyReward;
        public int GetMoneyReward => myMoneyReward;

        private int mySecurity;
        public int GetSecurity => mySecurity;

        private int myGullibility;
        public int GetGullibility => myGullibility;

        private int myUnlockPopularity;
        public int GetUnlockPopularity => myUnlockPopularity;

        private int myPopularityReward;
        public int GetPopularityReward => myPopularityReward;

        public Bank(string aFileName) : base(aFileName) { }

        public void Heist(Player aPlayer)
        {
            Console.Clear();
            var tempEvents = new List<string>();

            if (Program.RNG.Next(0, myGullibility) == 0)
                tempEvents.Add($"They were tricked by: {aPlayer.MyCrew[Program.RNG.Next(0, aPlayer.MyCrew.Count)].GetName} And they just gave us all the cash!");

            for (var i = 0; i < aPlayer.MyCrew.Count; i++)
            {
                if (Program.RNG.Next(0, mySecurity + aPlayer.MyCrew[i].GetDefense + (aPlayer.MyCrew[i].AccessArmour != null ? aPlayer.MyCrew[i].AccessArmour.GetLevel : 0)) == 0)
                {
                    tempEvents.Add($"{aPlayer.MyCrew[i].GetName} Died!, and you lost everything it was equipped with!");
                    if (Program.RNG.Next(0, aPlayer.MyCrew[i].GetCovert) == 0)
                    {
                        tempEvents.Add($"{aPlayer.MyCrew[i].GetName} Left some evidence.");
                        aPlayer.MyDiscovered = new Tuple<int, int>(aPlayer.MyDiscovered.Item1 + 1, aPlayer.MyDiscovered.Item1);
                    }
                    aPlayer.MyCrew.RemoveAt(i);
                }

                if (Program.RNG.Next(0, aPlayer.MyCrew[i].GetSkill) == 0 && aPlayer.MyCrew[i].AccessWeapon != null)
                {
                    tempEvents.Add($" {aPlayer.MyCrew[i].GetName} Broke His Weapon!");
                    aPlayer.MyCrew[i].AccessWeapon = null;
                }

                if (Program.RNG.Next(0, aPlayer.MyCrew[i].GetSkill) == 0 && aPlayer.MyCrew[i].AccessArmour != null)
                {
                    tempEvents.Add($" {aPlayer.MyCrew[i].GetName} Broke His Armour!");
                    aPlayer.MyCrew[i].AccessArmour = null;
                }

                if (Program.RNG.Next(0, aPlayer.MyCrew[i].GetLoyalty) == 0)
                {
                    tempEvents.Add($"{aPlayer.MyCrew[i].GetName} Decided to leave the team!");
                    aPlayer.MyCrew.RemoveAt(i);
                }
            }
            

            var tempTotalOffense = 0;
            for (var i = 0; i < aPlayer.MyCrew.Count; i++)
                tempTotalOffense += (aPlayer.MyCrew[i].AccessWeapon != null ? aPlayer.MyCrew[i].AccessWeapon.GetLevel : 0) + aPlayer.MyCrew[i].GetOffense;

            Program.ConsoleWriteLine("Your Crew came out Victorious and you gained:");
            Program.ConsoleWriteLine($"{tempTotalOffense*myMoneyReward} Money");
            Program.ConsoleWriteLine($"{myPopularityReward} Popularity");

            aPlayer.MyMoney += tempTotalOffense * myMoneyReward;
            aPlayer.MyPopularity += myPopularityReward;
            aPlayer.MyScore += 1;

            HeistEnd(tempEvents);
        }

        private void HeistEnd(List<string> tempEvents)
        {
            while (true)
            {
                try
                {
                    Program.DisplayPlayerStats();
                    Program.ConsoleWriteLine($"1 : Continue!");
                    Program.ConsoleWriteLine($"2 : Show Events!");
                    
                    switch (int.TryParse(Console.ReadLine(), out var temp) ? temp : throw new Exception("This isn't a Number!"))
                    {
                        case 1:
                            Program.ConsoleWriteContinue("Continuing!");
                            return;
                        case 2:
                            Program.ConsoleWriteLine("The Events:");
                            for (int i = 0; i < tempEvents.Count; i++)
                                Program.ConsoleWriteLine($"{i}  {tempEvents[i]}");
                            Program.ConsoleWriteContinue("Continuing!");
                                return;
                        default:
                            throw new Exception("This isn't a valid number!");
                    }
                }
                catch (Exception e)
                {
                    Program.ConsoleWriteContinue(e.Message, ConsoleColor.Red,ConsoleColor.Red);
                } 
            }
        }
        
        public void ShowStats()
        {
            Program.ConsoleWriteLine($"==================================");
            Program.ConsoleWriteLine($"Name         : {myName}");
            Program.ConsoleWriteLine($"Reward       : {myMoneyReward}");
            Program.ConsoleWriteLine($"Security     : {mySecurity}");
            Program.ConsoleWriteLine($"Gullibility  : {myGullibility}");
            Program.ConsoleWriteLine($"Popularity   : {myPopularityReward}");
            Program.ConsoleWriteLine($"==================================");
        }
        
        public override void Load()
        {
            var tempVariables = GetVariables();
            
            myName = IsCorrectCheck(tempVariables["name"],"name");
            myMoneyReward = ConvertToIntParameter(tempVariables["moneygained"], "moneygained");
            mySecurity = ConvertToIntParameter(tempVariables["security"], "security");
            myGullibility = ConvertToIntParameter(tempVariables["gullibility"], "gullibility");
            myUnlockPopularity = ConvertToIntParameter(tempVariables["popularity"], "popularity");
            myPopularityReward = ConvertToIntParameter(tempVariables["popularitygained"], "popularitygained");
        }
    }
}