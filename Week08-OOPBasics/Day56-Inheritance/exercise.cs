using System;

// Parent class (base)
class Enemy
{
    public string name;
    public int health;

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health < 0) health = 0;
        Console.WriteLine(name + " took " + amount + " damage. HP: " + health);
    }
}

// Child class (derived)
class Orc : Enemy
{
    public int rage;

    public void UseRage()
    {
        rage += 10;
        Console.WriteLine(name + " is enraged! Rage: " + rage);
    }
}

// Another child class
class Dragon : Enemy
{
    public int firePower;

    public void FireBreath()
    {
        Console.WriteLine(name + " breathes fire for " + firePower + " damage!");
    }
}

class Program
{
    static void Main()
    {
        Orc orc = new Orc();
        orc.name = "Gruk";
        orc.health = 80;
        orc.rage = 0;

        // Uses inherited method
        orc.TakeDamage(20);
        // Uses own method
        orc.UseRage();

        Console.WriteLine("---");

        Dragon dragon = new Dragon();
        dragon.name = "Smaug";
        dragon.health = 200;
        dragon.firePower = 50;

        dragon.TakeDamage(30);
        dragon.FireBreath();
    }
}
