using System;
using MafiaSimulator.Data;

namespace MafiaSimulator.Scenes
{
    public class EndingScene : SceneHolder
    {
        public override void Start()
        {
            Console.Clear();
            var tempHighscore = DataManager.FetchMyContent<HighScore>(0);
            var tempPlayer = DataManager.FetchMyContent<Player>(0);
            if (tempPlayer.MyScore > tempHighscore.MyScore)
            {
                tempHighscore.Write();
                tempHighscore.MyName = tempPlayer.MyName;
                tempHighscore.MyScore = tempPlayer.MyScore;
                tempHighscore.MyDate = DateTime.Today.ToString().Replace(" 00:00:00", "");
            }
            DataManager.FetchFolderData<Player>("PlayerStartingValues");
            Program.ConsoleWriteContinue("You lost!",ConsoleColor.Red,ConsoleColor.Red);
        }
    }
}