using System;

// Interface = pure contract, no implementation
interface IDamageable
{
    void TakeDamage(int amount);
    bool IsAlive();
}

interface IHealable
{
    void Heal(int amount);
}

// Class implements multiple interfaces
class Player : IDamageable, IHealable
{
    public string name;
    public int health;

    public Player(string playerName, int playerHealth)
    {
        name = playerName;
        health = playerHealth;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health < 0) health = 0;
        Console.WriteLine(name + " took " + amount + " damage. HP: " + health);
    }

    public bool IsAlive()
    {
        return health > 0;
    }

    public void Heal(int amount)
    {
        health += amount;
        Console.WriteLine(name + " healed " + amount + ". HP: " + health);
    }
}

// Different class, same interface
class Wall : IDamageable
{
    public int durability;

    public Wall(int startDurability)
    {
        durability = startDurability;
    }

    public void TakeDamage(int amount)
    {
        durability -= amount;
        if (durability < 0) durability = 0;
        Console.WriteLine("Wall took " + amount + " damage. Durability: " + durability);
    }

    public bool IsAlive()
    {
        return durability > 0;
    }
}

class Program
{
    static void Main()
    {
        IDamageable player = new Player("Zara", 100);
        IDamageable wall = new Wall(50);

        player.TakeDamage(30);
        wall.TakeDamage(20);

        Console.WriteLine("Player alive? " + player.IsAlive());
        Console.WriteLine("Wall standing? " + wall.IsAlive());

        // Can heal player because it's also IHealable
        IHealable healer = (IHealable)player;
        healer.Heal(15);
    }
}
