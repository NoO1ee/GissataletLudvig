using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GissataletLudvig;

internal class Game
{
    static string[] leaderboard = new string[5];
    static int leaderboardIndex = 0;
    public static void Leaderboard(int attempts, string name, string time)
    {
        string score = $"{name},{attempts},{time}";

        if (leaderboardIndex < leaderboard.Length)
        {
            leaderboard[leaderboardIndex] = score;
            leaderboardIndex++;
        }
        else
        {
            string[] lastScore = leaderboard[4].Split(',');
            if (int.Parse(lastScore[1]) > attempts)
                lastScore[4] = score;
        }

        for (int i = 0; i < leaderboardIndex - 1; i++)
        {
            for (int j = 0; j < leaderboardIndex - 1 - i; j++)
            {
                int attempt1 = int.Parse(leaderboard[j].Split(',')[1]);
                int attempt2 = int.Parse(leaderboard[j + 1].Split(",")[1]);

                if (attempt1 > attempt2)
                {
                    string temp = leaderboard[j];
                    leaderboard[j] = leaderboard[j + 1];
                    leaderboard[j + 1] = temp;
                }
            }
        }

        
    }

    public static void DisplayLeaderBoard()
    {
        Console.WriteLine($"{CO.Green("\nLEADERBOARD")}\n{"Rank",-5}{"Name",-15}{"Attempts",-10}{"Time",-10}");
        Console.WriteLine(new string('-', 40));

        for (int i = 0; i < leaderboardIndex; i++)
        {
            string[] score = leaderboard[i].Split(",");
            Console.WriteLine($"{i + 1,-5}{score[0],-15}{score[1],-10}{score[2],-10}");
        }
    }



    public static void StartGame(int difficulty)
    {
        Console.Clear();
        var time = new Stopwatch();
        int gussedNum;
        int attempts = 0;
        int randomNum = 0;
        int maxNum = 0;

        var random = new Random();

        if (difficulty == 1)
        {
            randomNum = random.Next(1, 31);
            maxNum = 31;
        }
        else if (difficulty == 2)
        {
            maxNum = 61;
            randomNum = random.Next(1, 61);
        }
        else if (difficulty == 3)
        {
            maxNum = 121;
            randomNum = random.Next(1, 121);
        }


        do
        {
            Console.CursorVisible = true;
            Console.WriteLine($"Guess a number between {(difficulty == 1 ? $"{CO.Green("1-30")}" : difficulty == 2 ? $"{CO.Yellow("1-60")}" : $"{CO.Red("1-120")}")}\n{CO.Green("You have 30 sec on you and 10 attempts.")}");
            Console.Write("Your guess: ");
            time.Start();
            if (int.TryParse(Console.ReadLine(), out gussedNum))
            {
                Console.Clear();
                Console.WriteLine(gussedNum < randomNum ? $"{CO.Magenta(Convert.ToString(gussedNum))} is too {CO.Red("low")}" : gussedNum == randomNum ? CO.Green("Correct guess") : $"{CO.Magenta(Convert.ToString(gussedNum))} is too {CO.Red("high")}");

                int close = Math.Abs(gussedNum - randomNum);

                if (close <= 3 && gussedNum != randomNum)
                {
                    Console.WriteLine(CO.Yellow("You are close now"));
                }

                if (gussedNum <= 0 || gussedNum >= maxNum)
                {
                    Console.Clear();
                    Console.WriteLine($"{CO.Red("Invalid input ")}(Either negativ or over {maxNum})");
                }

                attempts++;


            }



        } while (gussedNum != randomNum && time.ElapsedMilliseconds < 30000 && attempts < 10);
        time.Stop();
        TimeSpan ts = time.Elapsed;
        string elapsedTime = string.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);
        Console.Clear();

        if (gussedNum == randomNum)
        {
            Console.CursorVisible = false;
            Console.WriteLine($"Good job you guessed it right :)\n\nThe right number was: {CO.Green(Convert.ToString(randomNum))}!\nAttempts it took: {CO.Green(Convert.ToString(attempts))}\nTime: {CO.Green(elapsedTime)}\n\nPlease press {CO.Magenta("ANY")} key to continue!");
            Leaderboard(attempts, Program.name!, elapsedTime);
            DisplayLeaderBoard();
            Thread.Sleep(2000);
            Console.CursorVisible = true;

        }

        else
        {
            Console.WriteLine($"{CO.Red("Time's up!")} The number was {randomNum}\nAttempts made: {CO.Green(Convert.ToString(attempts))}\nPlease press {CO.Magenta("ANY")} key to continue!");
            Thread.Sleep(2000);
        }


        Console.ReadKey(true);
    }
}
