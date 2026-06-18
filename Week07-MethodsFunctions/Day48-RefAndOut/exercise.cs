using System;

class Program
{
    static void Main()
    {
        // ref: variable must already have a value
        int playerHealth = 100;
        Console.WriteLine("Before: " + playerHealth);
        TakeDamage(ref playerHealth, 25);
        Console.WriteLine("After: " + playerHealth);

        Console.WriteLine("---");

        // out: variable can be empty, method must set it
        int bonusDamage;
        CalculateBonus(5, out bonusDamage);
        Console.WriteLine("Bonus damage: " + bonusDamage);

        Console.WriteLine("---");

        // TryParse is a real-world example of out
        string input = "50";
        bool success = int.TryParse(input, out int result);
        Console.WriteLine("Parsed: " + result + " | Success: " + success);
    }

    static void TakeDamage(ref int health, int damage)
    {
        health = health - damage;
        Console.WriteLine("Inside method: " + health);
    }

    static void CalculateBonus(int level, out int bonus)
    {
        bonus = level * 10; // must assign bonus
    }
}
