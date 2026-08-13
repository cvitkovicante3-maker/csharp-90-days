using System;

// --- COMPONENTS ---

class Transform
{
    public int X { get; set; }
    public int Y { get; set; }

    public void Move(int dx, int dy)
    {
        X += dx;
        Y += dy;
    }

    public void ShowPosition() => Console.WriteLine($"Position: ({X}, {Y})");
}

class Health
{
    public int Current { get; private set; }
    public int Max { get; }

    public Health(int max)
    {
        Max = max;
        Current = max;
    }

    public void TakeDamage(int amount)
    {
        Current = Math.Max(0, Current - amount);
        Console.WriteLine($"Took {amount} damage. HP: {Current}/{Max}");
    }

    public bool IsAlive => Current > 0;
}

class Weapon
{
    public string Name { get; set; }
    public int Damage { get; set; }

    public void Attack(Health targetHealth)
    {
        Console.WriteLine($"Attacking with {Name} for {Damage} damage!");
        targetHealth.TakeDamage(Damage);
    }
}

// --- GAME OBJECT ---

class GameObject
{
    public string Name { get; set; }
    public Transform Transform { get; set; }
    public Health Health { get; set; }
    public Weapon Weapon { get; set; }

    public GameObject(string name)
    {
        Name = name;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"=== {Name} ===");
        Transform?.ShowPosition();
        Console.WriteLine($"Health: {Health?.Current}/{Health?.Max}");
        Console.WriteLine($"Weapon: {Weapon?.Name} ({Weapon?.Damage} dmg)");
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        // Build a player from components
        GameObject player = new GameObject("Hero");
        player.Transform = new Transform { X = 0, Y = 0 };
        player.Health = new Health(100);
        player.Weapon = new Weapon { Name = "Iron Sword", Damage = 15 };

        // Build an enemy from components
        GameObject enemy = new GameObject("Goblin");
        enemy.Transform = new Transform { X = 5, Y = 0 };
        enemy.Health = new Health(30);
        enemy.Weapon = new Weapon { Name = "Rusty Dagger", Damage = 5 };

        player.ShowInfo();
        enemy.ShowInfo();

        // Combat: player attacks enemy
        Console.WriteLine("--- COMBAT ---");
        player.Weapon.Attack(enemy.Health);

        // Enemy moves closer
        enemy.Transform.Move(-2, 0);
        enemy.Transform.ShowPosition();
    }
}
