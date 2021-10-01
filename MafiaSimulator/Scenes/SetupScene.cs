using System;
using MafiaSimulator.Utils;

namespace MafiaSimulator
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
                    if (aName.Length <= 0 || aName.Length > 15)
                        throw new Exception($"The Name is too {(aName.Length <= 0 ? "Short" : "Long")}!");
                    DataManager.FetchMyContent<Player>(0).AccessName = aName;
                    SceneManager.LoadScene<MainMenuScene>();
                }
                catch (Exception e)
                {
                    Program.ConsoleWriteContinue(e.ToString(), ConsoleColor.Red, ConsoleColor.Red);
                    continue;
                }
                break;
            }
        }
    }
}