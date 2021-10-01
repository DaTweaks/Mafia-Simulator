using System;
using MafiaSimulator.Data;
using MafiaSimulator.Utils;

namespace MafiaSimulator
{
    public class EndingScene : SceneHolder
    {
        public override void Start()
        {
            Console.Clear();
            var tempHighscore = DataManager.FetchMyContent<Highscore>(0);
            var tempPlayer = DataManager.FetchMyContent<Player>(0);
            if (tempPlayer.GetScore > tempHighscore.AccessScore)
            {
                tempHighscore.Write();
                tempHighscore.AccessName = tempPlayer.AccessName;
                tempHighscore.AccessScore = tempPlayer.GetScore;
                tempHighscore.AccessDate = DateTime.Today.ToString().Replace(" 00:00:00", "");
            }
            DataManager.FetchFolderData("PlayerStartingValues",typeof(Player));
            Program.ConsoleWriteContinue("You lost!",ConsoleColor.Red,ConsoleColor.Red);
        }
    }
}