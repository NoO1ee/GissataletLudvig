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
        string[] menuOptions = { $"{CO.Green("Lätt (30)")}", $"{CO.Yellow("Medium (60)")}", $"{CO.Red("Svår (120)")}", $"{CO.Cyan("Leaderboard")}", $"{CO.Red("Exit")}" };
        int menuSelecter = 0;

        while (true)
        {
            Console.Clear();

            for (int i = 0; i < menuOptions.Length; i++)
            {
                if (i == menuSelecter)
                {
                    Console.WriteLine($"\t{menuOptions[i]}\t{CO.Magenta("<")}{CO.Blue("-")}{CO.Cyan("-")}");
                    Console.CursorVisible = false;
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
                        Game.StartGame(1);
                        break;
                    case 1:
                        Game.StartGame(2);
                        break;
                    case 2:
                        Game.StartGame(3);
                        break;
                    case 3:
                        Console.Clear();
                        Game.DisplayLeaderBoard();
                        Thread.Sleep(5000);
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
