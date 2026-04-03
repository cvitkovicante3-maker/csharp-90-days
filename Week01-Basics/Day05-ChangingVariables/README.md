# Day 5: Changing Variables

## 📚 Concept
Variables can change their value (that's why they're called variables!).
Assignment replaces the old value with a new one.

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        int score = 0;
        Console.WriteLine("Start: " + score);
        
        score = 100;
        Console.WriteLine("After bonus: " + score);
        
        score = 250;
        Console.WriteLine("Final: " + score);
    }
}
