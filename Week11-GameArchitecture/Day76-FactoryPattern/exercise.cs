using System;

// --- PRODUCT INTERFACE ---
interface IEnemy
{
    string Name { get; }
    int Health { get; }
    void Attack();
}

// --- CONCRETE PRODUCTS ---
class Goblin : IEnemy
{
    public string Name => "Goblin";
    public int Health => 30;

    public void Attack()
    {
        Console.WriteLine(Name + " stabs with a rusty dagger!");
    }
}

class Orc : IEnemy
{
    public string Name => "Orc";
    public int Health => 80;

    public void Attack()
    {
        Console.WriteLine(Name + " smashes with a war hammer!");
    }
}

class Dragon : IEnemy
{
    public string Name => "Dragon";
    public int Health => 200;

    public void Attack()
    {
        Console.WriteLine(Name + " unleashes a fire storm!");
    }
}

// --- FACTORY ---
class EnemyFactory
{
    public static IEnemy CreateEnemy(string type)
    {
        switch (type.ToLower())
        {
            case "goblin":
                return new Goblin();
            case "orc":
                return new Orc();
            case "dragon":
                return new Dragon();
            default:
                throw new ArgumentException("Unknown enemy type: " + type);
        }
    }

    // Random enemy for procedural generation
    public static IEnemy CreateRandomEnemy()
    {
        string[] types = { "goblin", "orc", "dragon" };
        Random random = new Random();
        return CreateEnemy(types[random.Next(types.Length)]);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Spawning Enemies ===\n");

        // Create specific enemies
        IEnemy goblin = EnemyFactory.CreateEnemy("goblin");
        IEnemy orc = EnemyFactory.CreateEnemy("orc");

        goblin.Attack();
        Console.WriteLine($"HP: {goblin.Health}\n");

        orc.Attack();
        Console.WriteLine($"HP: {orc.Health}\n");

        // Create random enemies
        Console.WriteLine("--- Random Spawns ---");
        for (int i = 0; i < 3; i++)
        {
            IEnemy random = EnemyFactory.CreateRandomEnemy();
            Console.WriteLine($"Spawned: {random.Name} ({random.Health} HP)");
            random.Attack();
            Console.WriteLine();
        }
    }
}
