# Day 21: Logical OR (||)

## 📚 Concept
At least one condition must be true. Use `||` (two pipes, found above the Enter key). 
True if EITHER side is true (or both). 
Perfect for alternative solutions: key OR lockpick, jump OR fly.

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        bool hasKey = false;
        bool hasLockpick = true;
        
        if (hasKey || hasLockpick)
        {
            Console.WriteLine("Door unlocked!");
        }
    }
}
