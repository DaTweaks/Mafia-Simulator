using System;
using MafiaSimulator.Data;

namespace MafiaSimulator.Scenes
{
    public static class SceneManager
    {
        public static void LoadScene<T>()
        {
            Console.Clear();
            Type tempType = typeof(T);
            if (tempType.IsAssignableFrom(typeof(SceneHolder)))
            {
                Program.ConsoleWriteContinue("the desired Scene doesn't have the SceneHolder Extension", ConsoleColor.Red, ConsoleColor.Red);
                Environment.Exit(0);
            }

            if (tempType != typeof(EndingScene) && CheckPlayerStats())
                LoadScene<EndingScene>();
            
            
            var tempObj = Activator.CreateInstance(tempType);
            (tempObj as SceneHolder)?.Start();
        }
        
        /// <returns>returns true if the player is dead.</returns>
        private static bool CheckPlayerStats()
        {
            var tempPlayer = DataManager.FetchMyContent<Player>(0);
            return tempPlayer.MyMoney <= 0 || tempPlayer.MyDiscovered.Item1 >= tempPlayer.MyDiscovered.Item2;
        }
    }
}