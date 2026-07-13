using System;

// Abstract base class — all enemies derive from this
abstract class Enemy
{
    public string name;
    public int health;
    public int damage;

    public Enemy(string enemyName, int enemyHealth, int enemyDamage)
    {
        name = enemyName;
        health = enemyHealth;
        damage = enemyDamage;
    }

    // Every enemy MUST implement this
    public abstract void Attack();

    // Shared behavior
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
}

// Goblin — fast but weak
class Goblin : Enemy
{
    public Goblin(string name) : base(name, 30, 5) { }

    public override void Attack()
    {
        Console.WriteLine(name + " the Goblin stabs quickly for " + damage + " damage!");
    }
}

// Orc — tough with rage mechanic
class Orc : Enemy
{
    public int rage;

    public Orc(string name) : base(name, 80, 12) { }

    public override void Attack()
    {
        int totalDamage = damage + rage;
        Console.WriteLine(name + " the Orc smashes for " + totalDamage + " damage!");
        rage = 0; // consume rage
    }

    public void BuildRage()
    {
        rage += 5;
        Console.WriteLine(name + " builds rage: " + rage);
    }
}

// Dragon — flying boss
class Dragon : Enemy
{
    public Dragon(string name) : base(name, 200, 25) { }

    public override void Attack()
    {
        Console.WriteLine(name + " the Dragon breathes fire for " + damage + " damage!");
    }

    public void Fly()
    {
        Console.WriteLine(name + " takes to the skies!");
    }
}

class Program
{
    static void Main()
    {
        Enemy goblin = new Goblin("Skitter");
        Enemy orc = new Orc("Gruk");
        Enemy dragon = new Dragon("Smaug");

        goblin.Attack();
        goblin.TakeDamage(10);

        Console.WriteLine("---");

        ((Orc)orc).BuildRage();
        ((Orc)orc).BuildRage();
        orc.Attack();

        Console.WriteLine("---");

        dragon.Attack();
        ((Dragon)dragon).Fly();
        dragon.TakeDamage(50);
    }
}
