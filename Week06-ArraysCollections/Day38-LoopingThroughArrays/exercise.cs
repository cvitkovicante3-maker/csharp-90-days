using System;

class Program
{
    static void Main()
    {
        int[] scores = { 45, 80, 62, 95, 30 };

        // for loop: you get the index (i)
        Console.WriteLine("Scores with index:");
        for (int i = 0; i < scores.Length; i++)
        {
            Console.WriteLine("Slot " + i + ": " + scores[i]);
        }

        Console.WriteLine("---");

        // foreach loop: you get only the value
        Console.WriteLine("Scores only:");
        foreach (int points in scores)
        {
            Console.WriteLine(points);
        }

        Console.WriteLine("---");

        // Calculate total with a loop
        int total = 0;
        for (int i = 0; i < scores.Length; i++)
        {
            total = total + scores[i];
        }
        Console.WriteLine("Total score: " + total);

        // String array with foreach
        string[] weapons = { "Sword", "Bow", "Axe" };
        foreach (string w in weapons)
        {
            Console.WriteLine("Equipped: " + w);
        }
    }
}
