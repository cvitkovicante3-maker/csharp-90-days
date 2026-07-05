# Day 61: Inheritance Chains

## 📚 Concept
Inheritance can go multiple levels deep. A child inherits from a parent that already inherits from another. The child gets everything from all ancestors.

## 💻 My Code
```csharp
using System;

class Entity
{
    public string name;
    public void Spawn() { Console.WriteLine(name + " has spawned."); }
}

class Character : Entity
{
    public int health;
    public void TakeDamage(int amount)
    {
        health -= amount;
        Console.WriteLine(name + " took " + amount + " damage.");
    }
}

class Player : Character
{
    public int experience;
    public void GainXp(int amount)
    {
        experience += amount;
        Console.WriteLine(name + " gained " + amount + " XP.");
    }
}

class Enemy : Character
{
    public int damage;
    public void Attack(Player target)
    {
        Console.WriteLine(name + " attacks " + target.name + "!");
        target.TakeDamage(damage);
    }
}
