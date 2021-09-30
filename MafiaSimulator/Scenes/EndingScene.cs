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
            if ((DataManager.myContent[typeof(Player)][0] as Player).GetScore > (DataManager.myContent[typeof(Highscore)][0] as Highscore).AccessScore)
            {
                (DataManager.myContent[typeof(Highscore)][0] as Highscore).Write();
                (DataManager.myContent[typeof(Highscore)][0] as Highscore).AccessName = (DataManager.myContent[typeof(Player)][0] as Player).AccessName;
                (DataManager.myContent[typeof(Highscore)][0] as Highscore).AccessScore = (DataManager.myContent[typeof(Player)][0] as Player).GetScore;
                (DataManager.myContent[typeof(Highscore)][0] as Highscore).AccessDate = DateTime.Today.ToString().Replace(" 00:00:00", "");
            }
            Program.ConsoleWriteContinue("You lost!",ConsoleColor.Red,ConsoleColor.Red);
        }
    }
}