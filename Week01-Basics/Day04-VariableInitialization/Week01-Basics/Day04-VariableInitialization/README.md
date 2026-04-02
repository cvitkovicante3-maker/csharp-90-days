# Day 4: Variable Initialization

## 📚 Concept
You can declare (create) and assign (store) in one step. 
Combining declaration and assignment is cleaner.

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        string guild = "Dragon Slayers";
        int level = 1;

        Console.WriteLine("Warrior name: " + guild);
        Console.WriteLine("Warrior level: " + level);
    }
}
