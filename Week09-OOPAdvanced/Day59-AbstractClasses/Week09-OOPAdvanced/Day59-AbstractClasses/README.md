# Day 59: Abstract Classes

## 📚 Concept
An abstract class cannot be instantiated. It forces child classes to implement certain methods. Use `abstract` on the class and on methods with no body.

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
        Console.WriteLine(name + " took " + amount + " damage. HP: " + health);
    }
}

class Orc : Enemy
{
    public override void Attack()
    {
        Console.WriteLine(name + " swings a brutal axe!");
    }
}

class Dragon : Enemy
{
    public override void Attack()
    {
        Console.WriteLine(name + " unleashes a fire storm!");
    }
}
