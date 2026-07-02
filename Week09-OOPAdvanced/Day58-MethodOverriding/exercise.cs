using System;

class Enemy
{
    public string name;

    public virtual void Attack()
    {
        Console.WriteLine(name + " lunges forward!");
    }

    public virtual void TakeDamage(int amount)
    {
        Console.WriteLine(name + " takes " + amount + " damage.");
    }
}

class Orc : Enemy
{
    public int rage;

    // Call parent's version, then add custom behavior
    public override void Attack()
    {
        base.Attack(); // parent's attack first
        Console.WriteLine(name + " follows up with a rage-powered smash!");
    }

    // Completely replace parent's behavior
    public override void TakeDamage(int amount)
    {
        int reduced = amount - 2; // armor reduces damage
        Console.WriteLine(name + " blocks 2 damage!");
        base.TakeDamage(reduced);
    }
}

class BossOrc : Orc
{
    // sealed = no further overriding allowed
    public sealed override void Attack()
    {
        base.Attack();
        Console.WriteLine(name + " summons minions!");
    }
}

class Program
{
    static void Main()
    {
        Orc grunt = new Orc();
        grunt.name = "Grunt";
        grunt.Attack();

        Console.WriteLine("---");

        BossOrc boss = new BossOrc();
        boss.name = "Gorak";
        boss.Attack();
        boss.TakeDamage(10);
    }
}
