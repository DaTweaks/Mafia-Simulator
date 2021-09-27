using System;
using System.IO;
using System.Text;

namespace MafiaSimulator
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            FetchGameData();
        }
        
        public static void FetchGameData()
        {
            var bankData = Directory.GetFiles(Path.GetFullPath("GameData/Banks"));
            for (int i = 0; i < bankData.Length; i++)
            {
                using (FileStream tempFileStream = File.OpenRead(Path.GetFullPath(bankData[i])))
                {
                    byte[] tempArray = new byte[tempFileStream.Length];
                    var tempText = new UTF8Encoding(true);
                    while (tempFileStream.Read(tempArray,0,tempArray.Length) > 0)
                    {
                        Console.WriteLine(tempText.GetString(tempArray));
                    }
                }
            }
        }
    }
}