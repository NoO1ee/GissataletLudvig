using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GissataletLudvig;

internal class Easy
{
    public static void StartEasyGame()
    {
        Console.Clear();
        var time = new Stopwatch();
        var random = new Random();
        int gussedNum;
        int ranNum = random.Next(1, 31);
        int attempts = 0;




        do
        {
            Console.CursorVisible = true;
            Console.WriteLine($"Guess a number between {CO.Yellow("1-30")}");
            Console.Write("Your guess: ");
            time.Start();
            if (int.TryParse(Console.ReadLine(), out gussedNum))
            {
                Console.Clear();
                Console.WriteLine(gussedNum < ranNum ? $"{CO.Magenta(Convert.ToString(gussedNum))} is too {CO.Red("low")}" : gussedNum == ranNum ? CO.Green("Correct guess") : $"{CO.Magenta(Convert.ToString(gussedNum))} is too {CO.Red("high")}");

                int close = Math.Abs(gussedNum - ranNum);

                if (close <= 3 && gussedNum != ranNum)
                {
                    Console.WriteLine(CO.Yellow("You are close now"));
                }

                if (gussedNum <= 0 || gussedNum >= 31)
                {
                    Console.Clear();
                    Console.WriteLine($"{CO.Red("Invalid input ")}(Either negativ or over 30)");
                }

                attempts++;

            }



        } while (gussedNum != ranNum);
        time.Stop();
        TimeSpan ts = time.Elapsed;
        string elapsedTime = string.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);
        Console.Clear();
        Console.WriteLine($"Good job you guessed it right :)\n\nThe right number was: {CO.Green(Convert.ToString(ranNum))}!\nAttempts it took: {CO.Green(Convert.ToString(attempts))}\nTime: {CO.Green(elapsedTime)}\n\nPlease press {CO.Magenta("ANY")} key to continue!");
        Console.ReadKey(true);
    }
}
