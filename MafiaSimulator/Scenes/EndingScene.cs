﻿using System;
using MafiaSimulator.Data;

namespace MafiaSimulator.Scenes
{
    public class EndingScene : SceneHolder
    {
        public override void Start()
        {
            var tempHighScore = DataManager.FetchMyContent<HighScore>(0);
            var tempPlayer = DataManager.FetchMyContent<Player>(0);
            if (tempPlayer.MyScore > tempHighScore.MyScore)
            {
                tempHighScore.Write();
                tempHighScore.MyName = tempPlayer.MyName;
                tempHighScore.MyScore = tempPlayer.MyScore;
                tempHighScore.MyDate = DateTime.Today.ToString().Replace(" 00:00:00", "");
            }
            DataManager.FetchData();
            Program.ConsoleWriteContinue("You lost!",ConsoleColor.Red,ConsoleColor.Red);
            SceneManager.LoadScene<StartMenu>();
        }
    }
}