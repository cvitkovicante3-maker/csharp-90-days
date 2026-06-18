# Day 48: Ref and Out

## 📚 Concept
`ref` lets a method modify the original variable. `out` forces the method to assign a value to the variable.

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        int playerHealth = 100;
        Console.WriteLine("Before: " + playerHealth);
        TakeDamage(ref playerHealth, 25);
        Console.WriteLine("After: " + playerHealth);

        int bonusDamage;
        CalculateBonus(5, out bonusDamage);
        Console.WriteLine("Bonus: " + bonusDamage);

        string input = "50";
        bool success = int.TryParse(input, out int result);
        Console.WriteLine("Parsed: " + result + " | Success: " + success);
    }

    static void TakeDamage(ref int health, int damage)
    {
        health = health - damage;
    }

    static void CalculateBonus(int level, out int bonus)
    {
        bonus = level * 10;
    }
}
