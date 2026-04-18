# Day 20: Logical AND (&&)

## 📚 Concept
Combine conditions — both must be true for the whole thing to be true. 
Use `&&` (two ampersands). 
Perfect for: "has key AND lock", "ammo AND weapon", "level AND permission".

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        bool hasSword = true;
        bool hasShield = true;
        
        if (hasSword && hasShield)
        {
            Console.WriteLine("Fully equipped!");
        }
    }
}
