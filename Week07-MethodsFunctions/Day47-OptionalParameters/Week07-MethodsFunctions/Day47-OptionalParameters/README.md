# Day 47: Optional Parameters

## 📚 Concept
Give parameters default values. If the caller skips them, the default is used automatically.

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        SpawnEnemy("Goblin");
        SpawnEnemy("Orc", 10);
        SpawnEnemy("Dragon", 50, 100);
    }

    static void SpawnEnemy(string name, int health = 20, int mana = 0)
    {
        Console.WriteLine("Spawned " + name);
        Console.WriteLine("  Health: " + health);
        Console.WriteLine("  Mana: " + mana);
        Console.WriteLine();
    }
}
