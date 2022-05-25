using System;
using MafiaSimulator.Data;

namespace MafiaSimulator.Scenes
{
    public class EndingScene : SceneHolder
    {
        public override void Start()
        {
            var highScore = DataManager.currentHighscore;
            highScore.UpdateData();
            var player = DataManager.FetchMyContent<Player>(0);
            if (player.Score > highScore.Variables[0].Score)
            {
                highScore.Variables[0].Name = player.Name;
                highScore.Variables[0].Score = player.Score;
                highScore.Variables[0].Date = DateTime.Today.ToString().Replace(" 00:00:00", "");
                highScore.UpdateTable();
            }
            DataManager.FetchData();
            TextManager.ConsoleWriteContinue("You lost!",ConsoleColor.Red,ConsoleColor.Red);
            SceneManager.LoadScene<StartMenu>();
        }
    }
}