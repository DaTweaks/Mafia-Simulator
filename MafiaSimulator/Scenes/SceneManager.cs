using System;
using System.Reflection;

namespace MafiaSimulator
{
    public static class SceneManager
    {
        public static void LoadScene(Type aScene)
        {
            if (aScene.IsAssignableFrom(typeof(SceneHolder)))
            {
                Program.ConsoleWriteContinue("the desired Scene doesn't have the SceneHolder Extension", ConsoleColor.Red, ConsoleColor.Red);
                Environment.Exit(0);
            }

            var tempObj = Activator.CreateInstance(aScene);
            (tempObj as SceneHolder)?.Start();
        }
    }
}