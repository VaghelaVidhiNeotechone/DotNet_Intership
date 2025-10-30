using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        Random r = new Random(); // Initialize the Random object once outside the loop
        int Winner = r.Next(1, 10);
        bool win = false;

        while (win == false)
        {
            Console.WriteLine("Welcome to the game!! Please guess a number between 0 and 10. It is " + Winner + " to win!");
            int Guess = int.Parse(Console.ReadLine());

            if (Guess == Winner)
            {
                Console.WriteLine("Well done! " + Guess + " is correct!!");
                win = true;
            }
            else if (Guess > Winner)
            {
                Console.WriteLine("Guess lower!!");
            }
            else if (Guess < Winner)
            {
                Console.WriteLine("Guess higher!!");
            }
        }
    }
}