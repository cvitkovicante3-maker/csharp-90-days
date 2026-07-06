# Day 62: Composition vs Inheritance

## 📚 Concept
Inheritance = "is a" relationship. Composition = "has a" relationship. Build objects by combining smaller parts instead of rigid class hierarchies.

## 💻 My Code
```csharp
using System;

// Inheritance
class Enemy
{
    public string name;
    public int health;
    public void TakeDamage(int amount) { health -= amount; }
}

class Dragon : Enemy
{
    public void Fly() { Console.WriteLine(name + " takes to the skies!"); }
}

// Composition
class Weapon
{
    public string name;
    public int damage;
    public void Attack() { Console.WriteLine("Attacks with " + name + "!"); }
}

class Armor
{
    public string name;
    public int defense;
    public void Block() { Console.WriteLine(name + " blocks " + defense + "."); }
}

class Player
{
    public string name;
    public Weapon weapon;
    public Armor armor;

    public Player(string n, Weapon w, Armor a)
    {
        name = n; weapon = w; armor = a;
    }

    public void Fight()
    {
        Console.WriteLine(name + " fights!");
        weapon.Attack();
        armor.Block();
    }
}
