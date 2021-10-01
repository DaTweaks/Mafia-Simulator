using System;
using MafiaSimulator.Data;

namespace MafiaSimulator.Scenes
{
    public class SetupScene : SceneHolder
    {
        public override void Start()
        {
            while (true)
            {
                Console.Clear();
                try
                {
                    Program.ConsoleWriteLine("Input your Name!");
                    string aName = Console.ReadLine();
                    if (string.IsNullOrEmpty(aName) || aName.Length <= 0 || aName.Length > 15)
                        throw new Exception($"The Name is too {(string.IsNullOrWhiteSpace(aName) || aName.Length <= 0 ? "Short" : "Long")}!");
                    DataManager.FetchMyContent<Player>(0).MyName = aName;
                    SceneManager.LoadScene<MainMenuScene>();
                }
                catch (Exception e)
                {
                    Program.ConsoleWriteContinue(e.Message, ConsoleColor.Red, ConsoleColor.Red);
                    continue;
                }
                break;
            }
        }
    }
}