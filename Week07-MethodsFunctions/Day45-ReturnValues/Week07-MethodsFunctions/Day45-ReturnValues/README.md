# Day 45: Return Values

## 📚 Concept
A method can send a value back using `return`. Declare the type instead of `void`, then use `return` to give the result.

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        int total = AddNumbers(10, 20);
        Console.WriteLine("Total: " + total);

        Console.WriteLine("Double damage: " + Multiply(15, 2));

        bool alive = IsAlive(25);
        if (alive) Console.WriteLine("Player survives!");

        string title = GetRankName(3);
        Console.WriteLine("Rank: " + title);
    }

    static int AddNumbers(int a, int b)
    {
        return a + b;
    }

    static int Multiply(int a, int b)
    {
        return a * b;
    }

    static bool IsAlive(int health)
    {
        return health &gt; 0;
    }

    static string GetRankName(int rank)
    {
        if (rank == 1) return "Bronze";
        if (rank == 2) return "Silver";
        if (rank == 3) return "Gold";
        return "Unknown";
    }
}
