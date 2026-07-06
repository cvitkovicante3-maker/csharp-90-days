using System;

// --- INHERITANCE approach ---
class Enemy
{
    public string name;
    public int health;

    public void TakeDamage(int amount)
    {
        health -= amount;
        Console.WriteLine(name + " took " + amount + " damage.");
    }
}

class Dragon : Enemy
{
    public void Fly()
    {
        Console.WriteLine(name + " takes to the skies!");
    }
}

// --- COMPOSITION approach ---
class Weapon
{
    public string name;
    public int damage;

    public void Attack()
    {
        Console.WriteLine("Attacks with " + name + " for " + damage + " damage!");
    }
}

class Armor
{
    public string name;
    public int defense;

    public void Block()
    {
        Console.WriteLine(name + " blocks " + defense + " damage.");
    }
}

// Player COMPPOSED of Weapon and Armor
class Player
{
    public string name;
    public Weapon weapon;    // has a Weapon
    public Armor armor;      // has an Armor

    public Player(string playerName, Weapon w, Armor a)
    {
        name = playerName;
        weapon = w;
        armor = a;
    }

    public void Fight()
    {
        Console.WriteLine(name + " enters combat!");
        weapon.Attack();
        armor.Block();
    }
}

class Program
{
    static void Main()
    {
        // Inheritance
        Dragon dragon = new Dragon();
        dragon.name = "Smaug";
        dragon.health = 200;
        dragon.TakeDamage(30);
        dragon.Fly();

        Console.WriteLine("---");

        // Composition
        Weapon sword = new Weapon { name = "Flame Sword", damage = 50 };
        Armor plate = new Armor { name = "Steel Plate", defense = 20 };

        Player hero = new Player("Zara", sword, plate);
        hero.Fight();

        Console.WriteLine("---");

        // Swap components easily
        Weapon axe = new Weapon { name = "Battle Axe", damage = 70 };
        hero.weapon = axe;
        hero.Fight();
    }
}
