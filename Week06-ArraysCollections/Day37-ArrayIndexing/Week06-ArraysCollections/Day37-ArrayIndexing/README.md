# Day 37: Array Indexing

## 📚 Concept
Work with array positions safely. First index is `0`, last is `Length - 1`. Always check bounds before accessing.

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        int[] scores = { 45, 80, 62, 95, 30 };

        Console.WriteLine("First score: " + scores[0]);

        int lastIndex = scores.Length - 1;
        Console.WriteLine("Last score: " + scores[lastIndex]);

        int checkIndex = 2;
        if (checkIndex &gt;= 0 && checkIndex &lt; scores.Length)
        {
            Console.WriteLine("Safe access at " + checkIndex + ": " + scores[checkIndex]);
        }
        else
        {
            Console.WriteLine("Index out of bounds!");
        }

        for (int i = 0; i &lt; scores.Length; i++)
        {
            Console.WriteLine("Index " + i + " = " + scores[i]);
        }
    }
}
