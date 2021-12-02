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
                try
                {
                    Console.Clear();
                    TextManager.ConsoleWriteLine("Input your Name!");
                    var name = Console.ReadLine();
                    if (string.IsNullOrEmpty(name) || name.Length <= 0 || name.Length > 15)
                        throw new Exception($"The Name is too {(string.IsNullOrWhiteSpace(name) || name.Length <= 0 ? "Short" : "Long")}!");
                    DataManager.FetchMyContent<Player>(0).Name = name;
                    SceneManager.LoadScene<MainMenuScene>();
                }
                catch (Exception e)
                {
                    TextManager.ConsoleWriteContinue(e.Message, ConsoleColor.Red, ConsoleColor.Red);
                    continue;
                }
                break;
            }
        }
    }
}