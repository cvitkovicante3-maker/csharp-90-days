# Day 73: Component-Based Design

## 📚 Concept
Build objects by composing reusable components instead of deep inheritance. Each component does one thing. Swap components to change behavior.

## 💻 My Code
```csharp
using System;

class Transform
{
    public int X { get; set; }
    public int Y { get; set; }
    public void Move(int dx, int dy) { X += dx; Y += dy; }
    public void ShowPosition() =&gt; Console.WriteLine($"({X}, {Y})");
}

class Health
{
    public int Current { get; private set; }
    public int Max { get; }
    public Health(int max) { Max = max; Current = max; }
    public void TakeDamage(int amount) { Current = Math.Max(0, Current - amount); }
    public bool IsAlive =&gt; Current &gt; 0;
}

class Weapon
{
    public string Name { get; set; }
    public int Damage { get; set; }
    public void Attack(Health target) { target.TakeDamage(Damage); }
}

class GameObject
{
    public string Name { get; set; }
    public Transform Transform { get; set; }
    public Health Health { get; set; }
    public Weapon Weapon { get; set; }
}
