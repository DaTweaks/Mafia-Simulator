using System;
using MafiaSimulator.Data;

namespace MafiaSimulator.Scenes
{
    public static class SceneManager
    {
        public static void LoadScene<T>()
        {
            Console.Clear();
            Type type = typeof(T);
            if (type.IsAssignableFrom(typeof(SceneHolder)))
            {
                TextManager.ConsoleWriteContinue("the desired Scene doesn't have the SceneHolder Extension", ConsoleColor.Red, ConsoleColor.Red);
                Environment.Exit(0);
            }

            if (type != typeof(EndingScene) && CheckPlayerStats())
                LoadScene<EndingScene>();
            
            
            var obj = Activator.CreateInstance(type);
            (obj as SceneHolder)?.Start();
        }
        
        /// <returns>returns true if the player is dead.</returns>
        private static bool CheckPlayerStats()
        {
            var player = DataManager.FetchMyContent<Player>(0);
            return 
                player.Money <= 0 
                || player.Discovered.Item1 >= player.Discovered.Item2;
        }
    }
}