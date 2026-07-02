# Day 58: Method Overriding

## 📚 Concept
Replace or extend a parent's method with `override`. Use `base.Method()` to call the parent's version. Use `sealed` to prevent further overriding.

## 💻 My Code
```csharp
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

    public override void Attack()
    {
        base.Attack();
        Console.WriteLine(name + " follows up with a rage-powered smash!");
    }

    public override void TakeDamage(int amount)
    {
        int reduced = amount - 2;
        Console.WriteLine(name + " blocks 2 damage!");
        base.TakeDamage(reduced);
    }
}

class BossOrc : Orc
{
    public sealed override void Attack()
    {
        base.Attack();
        Console.WriteLine(name + " summons minions!");
    }
}
