# Day 38: Looping Through Arrays

## 📚 Concept
Put an array inside a loop to visit every item automatically. Use `for` when you need the index, `foreach` when you only need the value.

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        int[] scores = { 45, 80, 62, 95, 30 };

        for (int i = 0; i &lt; scores.Length; i++)
        {
            Console.WriteLine("Slot " + i + ": " + scores[i]);
        }

        foreach (int points in scores)
        {
            Console.WriteLine(points);
        }

        int total = 0;
        for (int i = 0; i &lt; scores.Length; i++)
        {
            total = total + scores[i];
        }
        Console.WriteLine("Total score: " + total);

        string[] weapons = { "Sword", "Bow", "Axe" };
        foreach (string w in weapons)
        {
            Console.WriteLine("Equipped: " + w);
        }
    }
}
