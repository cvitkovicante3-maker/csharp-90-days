# Day 50: Classes & Objects

## 📚 Concept
A class is a blueprint. An object is an instance built from that blueprint. Classes bundle data (fields) and behavior (methods) together.

## 💻 My Code
```csharp
using System;

class Player
{
    public string name;
    public int health;
    public int level;

    public void ShowStats()
    {
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Health: " + health);
        Console.WriteLine("Level: " + level);
    }
}

class Program
{
    static void Main()
    {
        Player hero = new Player();
        hero.name = "Zara";
        hero.health = 100;
        hero.level = 5;
        hero.ShowStats();

        Player enemy = new Player();
        enemy.name = "Goblin";
        enemy.health = 50;
        enemy.level = 2;
        enemy.ShowStats();
    }
}
