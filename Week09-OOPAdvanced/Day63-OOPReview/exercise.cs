using System;

// Abstract base
abstract class Enemy
{
    public string name;
    public int health;

    public abstract void Attack();

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health < 0) health = 0;
        Console.WriteLine(name + " took " + amount + " damage. HP: " + health);
    }
}

// Interface
interface IFlyable
{
    void Fly();
}

// Orc inherits Enemy
class Orc : Enemy
{
    public override void Attack()
    {
        Console.WriteLine(name + " swings an axe!");
    }
}

// Dragon inherits Enemy AND implements IFlyable
class Dragon : Enemy, IFlyable
{
    public override void Attack()
    {
        Console.WriteLine(name + " breathes fire!");
    }

    public void Fly()
    {
        Console.WriteLine(name + " takes to the skies!");
    }
}

// Composition: Weapon component
class Weapon
{
    public string name;
    public int damage;

    public void Strike(Enemy target)
    {
        Console.WriteLine("Striking with " + name + "!");
        target.TakeDamage(damage);
    }
}

// Player uses composition
class Player
{
    public string name;
    public Weapon weapon;

    public Player(string n, Weapon w)
    {
        name = n;
        weapon = w;
    }

    public void Fight(Enemy target)
    {
        Console.WriteLine(name + " attacks " + target.name + "!");
        weapon.Strike(target);
    }
}

class Program
{
    static void Main()
    {
        Enemy orc = new Orc { name = "Gruk", health = 80 };
        Enemy dragon = new Dragon { name = "Smaug", health = 200 };

        Weapon sword = new Weapon { name = "Steel Sword", damage = 25 };
        Player hero = new Player("Zara", sword);

        orc.Attack();
        hero.Fight(orc);

        Console.WriteLine("---");

        dragon.Attack();
        ((Dragon)dragon).Fly();
        hero.Fight(dragon);
    }
}
