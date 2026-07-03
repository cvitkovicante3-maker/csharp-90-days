using System;

// Abstract class — cannot use 'new Enemy()'
abstract class Enemy
{
    public string name;
    public int health;

    // Abstract method — no body, MUST be overridden
    public abstract void Attack();

    // Normal method — inherited as-is
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health < 0) health = 0;
        Console.WriteLine(name + " took " + amount + " damage. HP: " + health);
    }
}

// Concrete class — must implement all abstract methods
class Orc : Enemy
{
    public override void Attack()
    {
        Console.WriteLine(name + " swings a brutal axe!");
    }
}

class Dragon : Enemy
{
    public override void Attack()
    {
        Console.WriteLine(name + " unleashes a fire storm!");
    }
}

class Program
{
    static void Main()
    {
        // Enemy e = new Enemy(); // ERROR! Cannot instantiate abstract class

        Enemy orc = new Orc();
        orc.name = "Gruk";
        orc.health = 80;

        Enemy dragon = new Dragon();
        dragon.name = "Smaug";
        dragon.health = 200;

        orc.Attack();
        orc.TakeDamage(20);

        Console.WriteLine("---");

        dragon.Attack();
        dragon.TakeDamage(50);
    }
}
