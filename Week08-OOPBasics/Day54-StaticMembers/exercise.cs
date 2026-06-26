using System;

class Player
{
    // Non-static: each player has their own
    public string name;
    public int health;

    // Static: shared by ALL players
    public static int playerCount = 0;
    public static int totalScore = 0;

    public Player(string playerName, int playerHealth)
    {
        name = playerName;
        health = playerHealth;
        playerCount++;        // count every new player
        totalScore += 100;    // bonus for joining
    }

    public void ShowStats()
    {
        Console.WriteLine(name + " | HP: " + health);
    }

    // Static method: belongs to the class
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
        // Access static members through the class name
        Console.WriteLine("Players at start: " + Player.playerCount);

        Player hero = new Player("Zara", 100);
        Player sidekick = new Player("Milo", 80);

        hero.ShowStats();
        sidekick.ShowStats();

        // Static method and fields
        Player.ShowGameStats();
    }
}
