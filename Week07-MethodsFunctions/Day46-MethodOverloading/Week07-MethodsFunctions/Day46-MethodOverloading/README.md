# Day 46: Method Overloading

## 📚 Concept
Multiple methods with the same name but different parameters. C# picks the right one based on what you pass.

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        Heal(20);
        Heal("Player One");
        Heal(50, "Player Two");
    }

    static void Heal(int amount)
    {
        Console.WriteLine("Healed for " + amount + " HP.");
    }

    static void Heal(string target)
    {
        Console.WriteLine("Healed " + target + " fully.");
    }

    static void Heal(int amount, string target)
    {
        Console.WriteLine("Healed " + target + " for " + amount + " HP.");
    }
}
