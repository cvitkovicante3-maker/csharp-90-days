using System;

class Program
{
    static void Main()
    {
        // All defaults used
        SpawnEnemy("Goblin");

        // Override one default
        SpawnEnemy("Orc", 10);

        // Override both defaults
        SpawnEnemy("Dragon", 50, 100);
    }

    // health and mana have default values
    static void SpawnEnemy(string name, int health = 20, int mana = 0)
    {
        Console.WriteLine("Spawned " + name);
        Console.WriteLine("  Health: " + health);
        Console.WriteLine("  Mana: " + mana);
        Console.WriteLine();
    }
}
