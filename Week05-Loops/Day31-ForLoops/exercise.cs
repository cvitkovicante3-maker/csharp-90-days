using System;

class Program
{
    static void Main()
    {
        // Count from 1 to 5
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine("Wave " + i + " starting!");
        }

        // Count down from 3
        for (int i = 3; i > 0; i--)
        {
            Console.WriteLine("Exploding in " + i + "...");
        }
        Console.WriteLine("BOOM!");

        // Step by 10s
        for (int health = 0; health <= 100; health = health + 10)
        {
            Console.WriteLine("Loading... " + health + "%");
        }
        Console.WriteLine("Game ready!");
    }
}
