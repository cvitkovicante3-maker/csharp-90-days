using System;

class Program
{
    static void Main()
    {
        int[] scores = { 45, 92, 78, 12, 60 };

        // Sort: smallest to largest
        Array.Sort(scores);
        Console.WriteLine("Sorted scores:");
        foreach (int s in scores)
        {
            Console.WriteLine(s);
        }

        Console.WriteLine("---");

        // Reverse: flip the order
        Array.Reverse(scores);
        Console.WriteLine("Reversed:");
        foreach (int s in scores)
        {
            Console.WriteLine(s);
        }

        Console.WriteLine("---");

        // Find the index of a value
        string[] weapons = { "Sword", "Bow", "Axe", "Staff" };
        int position = Array.IndexOf(weapons, "Axe");
        Console.WriteLine("Axe is at index: " + position);

        // If not found, IndexOf returns -1
        int missing = Array.IndexOf(weapons, "Shield");
        Console.WriteLine("Shield is at index: " + missing);

        Console.WriteLine("---");

        // Clear: wipes values back to default (0 for numbers, null for strings)
        int[] temp = { 1, 2, 3, 4, 5 };
        Array.Clear(temp, 0, temp.Length);
        Console.WriteLine("After clear:");
        foreach (int t in temp)
        {
            Console.WriteLine(t);
        }
    }
}
