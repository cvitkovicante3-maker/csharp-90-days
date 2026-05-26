using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> scores = new List<int> { 45, 92, 12, 78, 60 };

        // Sort: smallest to largest
        scores.Sort();
        Console.WriteLine("Sorted:");
        foreach (int s in scores) Console.WriteLine(s);

        // Reverse: flip order
        scores.Reverse();
        Console.WriteLine("Reversed:");
        foreach (int s in scores) Console.WriteLine(s);

        // Find index of a value
        int index = scores.IndexOf(78);
        Console.WriteLine("Index of 78: " + index);

        // Insert at a specific position
        scores.Insert(0, 99);
        Console.WriteLine("After inserting 99 at start:");
        foreach (int s in scores) Console.WriteLine(s);

        // Remove by index
        scores.RemoveAt(2);
        Console.WriteLine("After removing index 2:");
        foreach (int s in scores) Console.WriteLine(s);

        // Clear everything
        scores.Clear();
        Console.WriteLine("Count after clear: " + scores.Count);
    }
}
