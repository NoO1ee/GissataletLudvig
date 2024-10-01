using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GissataletLudvig;
internal class Menu
{
    public static void StartMenu()
    {
        string[] menuOptions = { "Lätt (30)", "Medium (60)", "Svår (120)", "Leaderboard", "Exit" };
        int menuSelecter = 0;

        while (true)
        {
            Console.Clear();

            for (int i = 0; i < menuOptions.Length; i++)
            {
                if (i == menuSelecter)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{menuOptions[i]}\t<--");
                    Console.ResetColor();
                }
                else
                    Console.WriteLine(menuOptions[i]);
            }

            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.DownArrow && menuSelecter < menuOptions.Length - 1)
                menuSelecter++;
            else if (key == ConsoleKey.UpArrow && menuSelecter >= 1)
                menuSelecter--;
            else if (key == ConsoleKey.Enter)
            {
                switch (menuSelecter)
                {
                    case 0:
                        //Easy.StarGame();
                        break;
                    case 1:
                        //Medium.StarGame();
                        break;
                    case 2:
                        //Hard.StarGame();
                        break;
                    case 3:
                        //Leaderboard.CheckLeaderboard();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Thank you for playing :)");
                        Thread.Sleep(1000);
                        Environment.Exit(0);
                        break;
                }
            }
        }



    }
}
