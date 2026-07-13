# Day 65: Enemy Class Hierarchy

## 📚 Concept
Build an abstract Enemy base class with shared behavior. Child classes override Attack() and add unique mechanics. Easy to extend with new enemy types.

## 💻 My Code
```csharp
using System;

abstract class Enemy
{
    public string name;
    public int health;
    public int damage;

    public Enemy(string n, int h, int d) { name = n; health = h; damage = d; }
    public abstract void Attack();
    public void TakeDamage(int a) { health -= a; if (health &lt; 0) health = 0; }
    public bool IsAlive() { return health &gt; 0; }
}

class Goblin : Enemy
{
    public Goblin(string n) : base(n, 30, 5) { }
    public override void Attack() { Console.WriteLine(name + " stabs for " + damage + "!"); }
}

class Orc : Enemy
{
    public int rage;
    public Orc(string n) : base(n, 80, 12) { }
    public override void Attack() { Console.WriteLine(name + " smashes for " + (damage + rage) + "!"); rage = 0; }
    public void BuildRage() { rage += 5; }
}

class Dragon : Enemy
{
    public Dragon(string n) : base(n, 200, 25) { }
    public override void Attack() { Console.WriteLine(name + " breathes fire!"); }
    public void Fly() { Console.WriteLine(name + " flies!"); }
}
