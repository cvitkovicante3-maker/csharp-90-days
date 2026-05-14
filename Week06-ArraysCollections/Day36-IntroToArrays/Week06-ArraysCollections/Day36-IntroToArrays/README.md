# Day 36: Intro to Arrays

## 📚 Concept
An array stores multiple values of the same type in one variable. Access each value by its index (position), starting at 0.

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        int[] scores = { 100, 250, 75 };
        Console.WriteLine("Score 1: " + scores[0]);
        Console.WriteLine("Score 2: " + scores[1]);
        Console.WriteLine("Score 3: " + scores[2]);
        Console.WriteLine("Total scores: " + scores.Length);

        scores[1] = 300;
        Console.WriteLine("Updated score 2: " + scores[1]);

        string[] enemies = new string[3];
        enemies[0] = "Goblin";
        enemies[1] = "Orc";
        enemies[2] = "Dragon";
        Console.WriteLine("Enemy at index 0: " + enemies[0]);
    }
}
