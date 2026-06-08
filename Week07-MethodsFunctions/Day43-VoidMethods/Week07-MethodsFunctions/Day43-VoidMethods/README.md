# Day 43: Void Methods

## 📚 Concept
A `void` method is a reusable block of code that does something but doesn't return a value. Call it by name to run it.

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        ShowWelcome();
        ShowHealth();
        ShowGoodbye();
    }

    static void ShowWelcome()
    {
        Console.WriteLine("=== GAME STARTED ===");
        Console.WriteLine("Welcome, Player!");
    }

    static void ShowHealth()
    {
        int health = 100;
        Console.WriteLine("Health: " + health);
    }

    static void ShowGoodbye()
    {
        Console.WriteLine("Thanks for playing!");
        Console.WriteLine("===================");
    }
}
