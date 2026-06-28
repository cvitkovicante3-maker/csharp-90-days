# Day 56: Inheritance

## 📚 Concept
A child class inherits fields and methods from a parent class using `:`. The child adds its own unique features while reusing the parent's code.

## 💻 My Code
```csharp
using System;

class Enemy
{
    public string name;
    public int health;

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health &lt; 0) health = 0;
        Console.WriteLine(name + " took " + amount + " damage. HP: " + health);
    }
}

class Orc : Enemy
{
    public int rage;
    public void UseRage()
    {
        rage += 10;
        Console.WriteLine(name + " is enraged! Rage: " + rage);
    }
}

class Dragon : Enemy
{
    public int firePower;
    public void FireBreath()
    {
        Console.WriteLine(name + " breathes fire for " + firePower + " damage!");
    }
}
