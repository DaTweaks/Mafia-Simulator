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
            highScore.UpdateTable(new HighScore.HighscoreVariables(player.Name, player.Score, DateTime.Today.ToString().Replace(" 00:00:00", "")));
            DataManager.FetchData();
            TextManager.ConsoleWriteContinue("You lost!",ConsoleColor.Red,ConsoleColor.Red);
            SceneManager.LoadScene<StartMenu>();
        }
    }
}