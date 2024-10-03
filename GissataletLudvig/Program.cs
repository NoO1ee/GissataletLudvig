using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace GissataletLudvig;

internal class Program
{
    static string? name;
    public static Stopwatch time = new Stopwatch();

    static void Main(string[] args)
    {
        AskName();
        Menu.StartMenu();
    }

    private static void AskName()
    {
        while (true)
        {
            Console.Write("Hello!\nWhat is your name: ");
            name = Console.ReadLine();
            bool isValid = CheckNameIsValid(name!);
            if (isValid)
            {
                Console.Clear();
                Visible(!isValid, 2, $"{CO.Red("Invalid name")} (Can't have numbers in the name)");

            }
            else
            {
                Visible(false, 2, $"Hello {CO.Blue(name!)}");
                break;
            }
        }


    }

    static bool CheckNameIsValid(string user)
    {
        return Regex.IsMatch(user, @"\d");
    }

    public static void Visible(bool check, int seconds, string msg)
    {
        seconds = seconds * 1000;
        Console.Clear();
        Console.CursorVisible = check;
        Console.WriteLine(msg);
        Thread.Sleep(seconds);
        Console.CursorVisible = !check;
    }

}

