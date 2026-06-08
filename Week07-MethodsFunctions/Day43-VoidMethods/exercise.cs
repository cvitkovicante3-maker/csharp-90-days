using System;

class Program
{
    static void Main()
    {
        // Call the methods
        ShowWelcome();
        ShowHealth();
        ShowGoodbye();
    }

    // A void method: does something, returns nothing
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
