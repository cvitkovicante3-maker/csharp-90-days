# Day 26: Ternary Operator

## 📚 Concept
A one-line shortcut for simple if/else: `condition ? trueValue : falseValue`

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        int health = 25;

        string statusQuick = health &gt; 50 ? "Healthy" : "Wounded";
        Console.WriteLine("Status: " + statusQuick);

        Console.WriteLine("Player is: " + (health &gt; 0 ? "Alive" : "Dead"));

        int damage = 10;
        int bonus = 5;
        int totalDamage = health &lt; 30 ? damage + bonus : damage;
        Console.WriteLine("Total damage: " + totalDamage);
    }
}
