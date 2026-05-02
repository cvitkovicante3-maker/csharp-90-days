# Day 31: For Loops

## 📚 Concept
Repeat code a set number of times. Three parts in one line: start, condition, increment.

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        for (int i = 1; i &lt;= 5; i++)
        {
            Console.WriteLine("Wave " + i + " starting!");
        }

        for (int i = 3; i &gt; 0; i--)
        {
            Console.WriteLine("Exploding in " + i + "...");
        }
        Console.WriteLine("BOOM!");

        for (int health = 0; health &lt;= 100; health = health + 10)
        {
            Console.WriteLine("Loading... " + health + "%");
        }
    }
}
