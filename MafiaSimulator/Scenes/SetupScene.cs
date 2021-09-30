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
                    (DataManager.myContent[typeof(Player)][0] as Player).AccessName = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Program.ConsoleWriteLine(e.ToString(), ConsoleColor.Red);
                    Program.ConsoleWriteLine("Press any key to continue!", ConsoleColor.Red, true);
                    continue;
                }
                break;
            }
        }
    }
}