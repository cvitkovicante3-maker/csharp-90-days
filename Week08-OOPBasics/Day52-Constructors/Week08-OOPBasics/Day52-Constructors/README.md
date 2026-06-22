# Day 52: Constructors

## 📚 Concept
A constructor is a special method that runs automatically when creating an object. It sets up initial values. Same name as the class, no return type.

## 💻 My Code
```csharp
using System;

class Player
{
    public string name;
    public int health;
    public int level;

    public Player(string playerName, int playerHealth, int playerLevel)
    {
        name = playerName;
        health = playerHealth;
        level = playerLevel;
    }

    public void ShowStats()
    {
        Console.WriteLine(name + " | HP: " + health + " | Lv: " + level);
    }
}

class Program
{
    static void Main()
    {
        Player hero = new Player("Zara", 100, 5);
        Player enemy = new Player("Goblin", 50, 2);
        hero.ShowStats();
        enemy.ShowStats();
    }
}
