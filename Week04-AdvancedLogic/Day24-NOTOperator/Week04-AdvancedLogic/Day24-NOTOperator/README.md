# Day 24: NOT Operator (!)

## 📚 Concept
Flip true to false, or false to true. Use `!` (exclamation mark). 
Read `if (!isPaused)` as "if not paused". 
Useful for toggles: `isVisible = !isVisible`.

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        bool isPaused = false;
        
        if (!isPaused)
        {
            Console.WriteLine("Game is running");
        }
    }
}
