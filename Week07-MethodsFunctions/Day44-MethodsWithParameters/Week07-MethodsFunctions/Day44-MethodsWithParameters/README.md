# Day 44: Methods with Parameters

## 📚 Concept
Pass data into a method using parameters. The method uses that data to perform its action.

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        GreetPlayer("Zara");
        GreetPlayer("Milo");

        ShowDamage("Goblin", 25);
        ShowDamage("Dragon", 150);

        PrintHealthBar("Hero", 80);
        PrintHealthBar("Enemy", 30);
    }

    static void GreetPlayer(string name)
    {
        Console.WriteLine("Welcome, " + name + "!");
    }

    static void ShowDamage(string target, int amount)
    {
        Console.WriteLine(target + " takes " + amount + " damage!");
    }

    static void PrintHealthBar(string name, int health)
    {
        Console.WriteLine(name + " health: " + health + "/100");
    }
}
