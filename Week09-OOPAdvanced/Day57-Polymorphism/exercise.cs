using System;

// Parent class
class Enemy
{
    public string name;

    // virtual = can be overridden by children
    public virtual void Attack()
    {
        Console.WriteLine(name + " attacks normally.");
    }
}

// Child class 1
class Orc : Enemy
{
    // override = provide custom behavior
    public override void Attack()
    {
        Console.WriteLine(name + " swings a heavy axe!");
    }
}

// Child class 2
class Dragon : Enemy
{
    public override void Attack()
    {
        Console.WriteLine(name + " breathes scorching fire!");
    }
}

class Program
{
    static void Main()
    {
        Enemy orc = new Orc();
        orc.name = "Gruk";

        Enemy dragon = new Dragon();
        dragon.name = "Smaug";

        // Same method call, different results
        orc.Attack();
        dragon.Attack();
    }
}
