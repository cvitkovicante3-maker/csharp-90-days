using System;

class Program
{
    static void Main()
    {
        int secretNumber = 7;
        int guess = 0;
        int attempts = 0;
        int maxAttempts = 3;

        Console.WriteLine("Guess the number (1-10)! You have " + maxAttempts + " tries.");

        while (guess != secretNumber && attempts < maxAttempts)
        {
            attempts++;

            // Simulating guesses for demo
            if (attempts == 1) guess = 3;
            else if (attempts == 2) guess = 7;

            Console.WriteLine("Attempt " + attempts + ": You guessed " + guess);

            if (guess == secretNumber)
            {
                Console.WriteLine("Correct! You win!");
                break;
            }
            else if (attempts < maxAttempts)
            {
                Console.WriteLine("Wrong! Try again.");
            }
            else
            {
                Console.WriteLine("Out of attempts! Game over.");
            }
        }

        Console.WriteLine("---");

        // Bonus: print a victory banner with nested loops
        for (int row = 1; row <= 3; row++)
        {
            for (int star = 1; star <= 5; star++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }
}
