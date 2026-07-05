using System;

// Grandparent
class Entity
{
    public string name;

    public void Spawn()
    {
        Console.WriteLine(name + " has spawned.");
    }
}

// Parent inherits from Entity
class Character : Entity
{
    public int health;

    public void TakeDamage(int amount)
    {
        health -= amount;
        Console.WriteLine(name + " took " + amount + " damage. HP: " + health);
    }
}

// Child inherits from Character
class Player : Character
{
    public int experience;

    public void GainXp(int amount)
    {
        experience += amount;
        Console.WriteLine(name + " gained " + amount + " XP. Total: " + experience);
    }
}

// Another child of Character
class Enemy : Character
{
    public int damage;

    public void Attack(Player target)
    {
        Console.WriteLine(name + " attacks " + target.name + "!");
        target.TakeDamage(damage);
    }
}

class Program
{
    static void Main()
    {
        Player hero = new Player();
        hero.name = "Zara";
        hero.health = 100;
        hero.experience = 0;

        Enemy goblin = new Enemy();
        goblin.name = "Goblin";
        goblin.health = 30;
        goblin.damage = 10;

        hero.Spawn();        // from Entity
        hero.TakeDamage(5);  // from Character
        hero.GainXp(50);     // from Player

        Console.WriteLine("---");

        goblin.Spawn();      // from Entity
        goblin.Attack(hero); // from Enemy
    }
}
