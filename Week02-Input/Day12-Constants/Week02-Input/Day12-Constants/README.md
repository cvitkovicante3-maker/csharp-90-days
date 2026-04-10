# Day 12: Constants

## 📚 Concept
Values that never change (like game rules) should be `const`. 
Use `const` for max stats, gravity values, version numbers. 
These cannot be changed later in the code.

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        const int MAX_HEALTH = 100;
        const string GAME_VERSION = "1.0";
        
        Console.WriteLine($"Max HP: {MAX_HEALTH}");
        Console.WriteLine($"Version: {GAME_VERSION}");
    }
}
