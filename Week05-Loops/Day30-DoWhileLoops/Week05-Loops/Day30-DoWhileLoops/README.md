# Day 30: Do-While Loops

## 📚 Concept
A loop that checks its condition **after** running. The code block always executes at least once.

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        int choice = 0;

        do
        {
            Console.WriteLine("=== GAME MENU ===");
            Console.WriteLine("1. Start Game");
            Console.WriteLine("2. Load Game");
            Console.WriteLine("3. Quit");
            choice = 3;
            Console.WriteLine("You selected: " + choice);
        }
        while (choice != 3);

        Console.WriteLine("Goodbye!");

        Random random = new Random();
        int roll;
        do
        {
            roll = random.Next(1, 7);
            Console.WriteLine("Rolled: " + roll);
        }
        while (roll != 6);

        Console.WriteLine("You rolled a 6!");
    }
}
