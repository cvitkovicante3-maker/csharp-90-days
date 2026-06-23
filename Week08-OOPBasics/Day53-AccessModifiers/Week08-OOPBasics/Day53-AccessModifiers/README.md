# Day 53: Access Modifiers

## 📚 Concept
Control visibility with `public` (open to all) and `private` (class only). Protect data by making fields private and providing controlled public methods.

## 💻 My Code
```csharp
using System;

class Player
{
    private int health;
    private int maxHealth;
    public string name;

    public Player(string playerName, int playerMaxHealth)
    {
        name = playerName;
        maxHealth = playerMaxHealth;
        health = maxHealth;
    }

    public int GetHealth()
    {
        return health;
    }

    public void TakeDamage(int amount)
    {
        health = health - amount;
        if (health &lt; 0) health = 0;
        Console.WriteLine(name + " took " + amount + " damage. HP: " + health);
    }

    public void Heal(int amount)
    {
        health = health + amount;
        if (health &gt; maxHealth) health = maxHealth;
        Console.WriteLine(name + " healed " + amount + ". HP: " + health);
    }
}

class Program
{
    static void Main()
    {
        Player hero = new Player("Zara", 100);
        Console.WriteLine("Player: " + hero.name);
        hero.TakeDamage(30);
        hero.Heal(10);
    }
}
