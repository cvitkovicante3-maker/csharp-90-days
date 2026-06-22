using System;

class Player
{
    public string name;
    public int health;
    public int level;

    // Constructor: runs when you use 'new Player()'
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
        // Create objects with constructor values
        Player hero = new Player("Zara", 100, 5);
        Player enemy = new Player("Goblin", 50, 2);

        hero.ShowStats();
        enemy.ShowStats();
    }
}
