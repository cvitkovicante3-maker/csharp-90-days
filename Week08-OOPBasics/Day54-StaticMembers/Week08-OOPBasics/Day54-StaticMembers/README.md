# Day 54: Static Members

## 📚 Concept
`static` members belong to the class, not to any object. Only one copy exists, shared by all instances. Access with `ClassName.Member`.

## 💻 My Code
```csharp
using System;

class Player
{
    public string name;
    public int health;

    public static int playerCount = 0;
    public static int totalScore = 0;

    public Player(string playerName, int playerHealth)
    {
        name = playerName;
        health = playerHealth;
        playerCount++;
        totalScore += 100;
    }

    public void ShowStats()
    {
        Console.WriteLine(name + " | HP: " + health);
    }

    public static void ShowGameStats()
    {
        Console.WriteLine("Total players: " + playerCount);
        Console.WriteLine("Total score: " + totalScore);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Players at start: " + Player.playerCount);

        Player hero = new Player("Zara", 100);
        Player sidekick = new Player("Milo", 80);

        hero.ShowStats();
        sidekick.ShowStats();
        Player.ShowGameStats();
    }
}
