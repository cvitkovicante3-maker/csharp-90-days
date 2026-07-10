# Day 63: OOP Review

## 📚 Concept
Review day — combine classes, inheritance, polymorphism, abstract classes, interfaces, encapsulation, and composition into a working system.

## 💻 My Code
```csharp
using System;

abstract class Enemy
{
    public string name;
    public int health;
    public abstract void Attack();
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health &lt; 0) health = 0;
        Console.WriteLine(name + " took " + amount + " damage.");
    }
}

interface IFlyable { void Fly(); }

class Orc : Enemy
{
    public override void Attack() { Console.WriteLine(name + " swings axe!"); }
}

class Dragon : Enemy, IFlyable
{
    public override void Attack() { Console.WriteLine(name + " breathes fire!"); }
    public void Fly() { Console.WriteLine(name + " flies!"); }
}

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

class Player
{
    public string name;
    public Weapon weapon;
    public Player(string n, Weapon w) { name = n; weapon = w; }
    public void Fight(Enemy target)
    {
        Console.WriteLine(name + " attacks " + target.name + "!");
        weapon.Strike(target);
    }
}
