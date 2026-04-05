# Day 7: Floating Point Numbers

## 📚 Concept
Use `float` for decimals (health bars, positions, percentages). 
The `f` suffix tells C# it's a float, not a double (double is more precise but heavier).
Essential for game coordinates and physics.

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        float health = 100.0f;
        float damage = 23.5f;
        
        health = health - damage;
        Console.WriteLine("Health: " + health);
    }
}
