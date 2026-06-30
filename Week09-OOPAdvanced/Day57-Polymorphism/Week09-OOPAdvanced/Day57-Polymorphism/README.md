# Day 57: Polymorphism

## 📚 Concept
One method name, many behaviors. Parent declares `virtual`, child provides `override`. C# picks the right version at runtime.

## 💻 My Code
```csharp
using System;

class Enemy
{
    public string name;
    public virtual void Attack()
    {
        Console.WriteLine(name + " attacks normally.");
    }
}

class Orc : Enemy
{
    public override void Attack()
    {
        Console.WriteLine(name + " swings a heavy axe!");
    }
}

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
        Enemy orc = new Orc(); orc.name = "Gruk";
        Enemy dragon = new Dragon(); dragon.name = "Smaug";
        orc.Attack();
        dragon.Attack();
    }
}
