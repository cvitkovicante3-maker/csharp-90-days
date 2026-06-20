using System;

// The blueprint (class)
class Player
{
    // Fields (data this object stores)
    public string name;
    public int health;
    public int level;

    // Method (what this object can do)
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
        // Create an object (instance) from the Player blueprint
        Player hero = new Player();

        // Set the fields
        hero.name = "Zara";
        hero.health = 100;
        hero.level = 5;

        // Call the method
        hero.ShowStats();

        Console.WriteLine("---");

        // Create a second object
        Player enemy = new Player();
        enemy.name = "Goblin";
        enemy.health = 50;
        enemy.level = 2;

        enemy.ShowStats();
    }
}
