# Day 60: Interfaces

## 📚 Concept
An interface is a pure contract — no implementation. Classes implement interfaces and MUST provide all members. A class can implement multiple interfaces.

## 💻 My Code
```csharp
using System;

interface IDamageable
{
    void TakeDamage(int amount);
    bool IsAlive();
}

interface IHealable
{
    void Heal(int amount);
}

class Player : IDamageable, IHealable
{
    public string name;
    public int health;

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health &lt; 0) health = 0;
        Console.WriteLine(name + " took " + amount + " damage.");
    }

    public bool IsAlive() { return health &gt; 0; }
    public void Heal(int amount) { health += amount; }
}

class Wall : IDamageable
{
    public int durability;
    public void TakeDamage(int amount) { durability -= amount; }
    public bool IsAlive() { return durability &gt; 0; }
}
