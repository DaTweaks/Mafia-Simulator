using System;
using System.Reflection;

namespace MafiaSimulator
{
    public static class MenuManager
    {
        public static void LoadScene(Type aScene)
        {
            if (aScene.IsAssignableFrom(typeof(SceneHolder)))
            {
                Console.WriteLine("the desired Scene doesn't have the SceneHolder Extension");
                Program.ConsoleWriteLine("Press any key to Continue!", ConsoleColor.Red, true);
                Environment.Exit(0);
            }

            var tempObj = Activator.CreateInstance(aScene);
            (tempObj as SceneHolder)?.Start();
        }
    }
}