using System;

class Program
{
    static void Main()
    {
        int[] scores = { 45, 80, 62, 95, 30 };

        // First element is always index 0
        Console.WriteLine("First score: " + scores[0]);

        // Last element is Length - 1
        int lastIndex = scores.Length - 1;
        Console.WriteLine("Last score: " + scores[lastIndex]);

        // Safe check: only access if index is valid
        int checkIndex = 2;
        if (checkIndex >= 0 && checkIndex < scores.Length)
        {
            Console.WriteLine("Safe access at " + checkIndex + ": " + scores[checkIndex]);
        }
        else
        {
            Console.WriteLine("Index " + checkIndex + " is out of bounds!");
        }

        // Loop through every index
        Console.WriteLine("All scores:");
        for (int i = 0; i < scores.Length; i++)
        {
            Console.WriteLine("Index " + i + " = " + scores[i]);
        }
    }
}
