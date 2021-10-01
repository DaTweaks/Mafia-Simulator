using System;

namespace MafiaSimulator.Scenes
{
    public static class SceneManager
    {
        public static void LoadScene<T>()
        {
            Type tempType = typeof(T);
            if (tempType.IsAssignableFrom(typeof(SceneHolder)))
            {
                Program.ConsoleWriteContinue("the desired Scene doesn't have the SceneHolder Extension", ConsoleColor.Red, ConsoleColor.Red);
                Environment.Exit(0);
            }

            var tempObj = Activator.CreateInstance(tempType);
            (tempObj as SceneHolder)?.Start();
        }
    }
}