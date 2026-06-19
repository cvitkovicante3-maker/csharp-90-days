# Day 49: Method Practice

## 📚 Concept
Review day — combine void, return values, parameters, overloading, optional params, ref, and out into a working system.

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        int playerHealth = 100;
        int enemyHealth = 80;

        ShowStatus("Player", playerHealth);
        ShowStatus("Enemy", enemyHealth);

        int damage = CalculateDamage(15, true);
        ApplyDamage(ref enemyHealth, damage);
        Console.WriteLine("Player hits for " + damage + "!");

        damage = CalculateDamage(10, false);
        ApplyDamage(ref playerHealth, damage);

        Heal(ref playerHealth, 20);
        ShowStatus("Player", playerHealth);
    }

    static void ShowStatus(string name, int health)
    {
        Console.WriteLine(name + " HP: " + health);
    }

    static int CalculateDamage(int baseDamage, bool isCritical)
    {
        return isCritical ? baseDamage * 2 : baseDamage;
    }

    static void ApplyDamage(ref int health, int damage)
    {
        health = health - damage;
        if (health &lt; 0) health = 0;
    }

    static void Heal(ref int health, int amount, bool showMessage = true)
    {
        health = health + amount;
        if (health &gt; 100) health = 100;
        if (showMessage) Console.WriteLine("Healed " + amount + " HP.");
    }
}
