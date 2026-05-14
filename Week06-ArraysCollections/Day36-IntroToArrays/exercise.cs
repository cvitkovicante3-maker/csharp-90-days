using System;

class Program
{
    static void Main()
    {
        // Create an array with 3 player scores
        int[] scores = { 100, 250, 75 };

        // Access each value by index
        Console.WriteLine("Score 1: " + scores[0]);
        Console.WriteLine("Score 2: " + scores[1]);
        Console.WriteLine("Score 3: " + scores[2]);

        // Total number of items
        Console.WriteLine("Total scores: " + scores.Length);

        // Change a value
        scores[1] = 300;
        Console.WriteLine("Updated score 2: " + scores[1]);

        // Create an empty array first, fill it later
        string[] enemies = new string[3];
        enemies[0] = "Goblin";
        enemies[1] = "Orc";
        enemies[2] = "Dragon";

        Console.WriteLine("Enemy at index 0: " + enemies[0]);
    }
}
