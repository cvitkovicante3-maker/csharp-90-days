# Day 76: Factory Pattern

## 📚 Concept
Centralize object creation in a factory method. Callers don't need to know the exact class being instantiated. Easy to extend with new types.

## 💻 My Code
```csharp
using System;

interface IEnemy
{
    string Name { get; }
    int Health { get; }
    void Attack();
}

class Goblin : IEnemy
{
    public string Name =&gt; "Goblin";
    public int Health =&gt; 30;
    public void Attack() { Console.WriteLine("Goblin stabs!"); }
}

class EnemyFactory
{
    public static IEnemy CreateEnemy(string type)
    {
        switch (type.ToLower())
        {
            case "goblin": return new Goblin();
            case "orc": return new Orc();
            case "dragon": return new Dragon();
            default: throw new ArgumentException("Unknown: " + type);
        }
    }

    public static IEnemy CreateRandomEnemy()
    {
        string[] types = { "goblin", "orc", "dragon" };
        return CreateEnemy(types[new Random().Next(types.Length)]);
    }
}
