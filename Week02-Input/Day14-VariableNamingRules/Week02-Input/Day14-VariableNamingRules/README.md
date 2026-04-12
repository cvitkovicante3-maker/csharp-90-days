# Day 14: Variable Naming Rules

## 📚 Concept
Names must start with letter or underscore, no spaces, case-sensitive. 
Use camelCase for variables (first word lowercase, others capitalized). 
Be descriptive!

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        int playerHealth = 100;    // Good: descriptive
        int _secretLevel = 5;      // Good: underscore start
        float speed2 = 10.5f;      // Good: number at end
        
        // 2speed = 5;              // BAD: starts with number
        // player health = 100;     // BAD: has space
        
        Console.WriteLine($"Health: {playerHealth}");
    }
}
