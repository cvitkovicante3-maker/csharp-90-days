# Day 29: While Loops

## 📚 Concept
Repeat code while a condition is true. Checks condition BEFORE each run.

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        int health = 30;
        while (health &lt; 100)
        {
            health = health + 10;
            Console.WriteLine("Healing... Health: " + health);
        }
        Console.WriteLine("Health is full!");

        int countdown = 3;
        while (countdown &gt; 0)
        {
            Console.WriteLine("Starting in: " + countdown);
            countdown--;
        }
        Console.WriteLine("Go!");
    }
}
