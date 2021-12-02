using System;
using MafiaSimulator.Data;

namespace MafiaSimulator.Scenes
{
    public class EndingScene : SceneHolder
    {
        public override void Start()
        {
            var highScore = DataManager.FetchMyContent<HighScore>(0);
            var player = DataManager.FetchMyContent<Player>(0);
            if (player.Score > highScore.Score)
            {
                highScore.Write();
                highScore.Name = player.Name;
                highScore.Score = player.Score;
                highScore.Date = DateTime.Today.ToString().Replace(" 00:00:00", "");
            }
            DataManager.FetchData();
            TextManager.ConsoleWriteContinue("You lost!",ConsoleColor.Red,ConsoleColor.Red);
            SceneManager.LoadScene<StartMenu>();
        }
    }
}