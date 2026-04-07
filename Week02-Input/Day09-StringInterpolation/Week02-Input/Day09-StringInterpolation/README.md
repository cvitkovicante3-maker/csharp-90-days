# Day 9: String Interpolation

## 📚 Concept
Use `$` before quotes and `{ }` to insert variables into text. 
This is the modern, preferred way in C# — much cleaner than concatenation with `+`.

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        string enemy = "Goblin";
        int hp = 50;
        
        Console.WriteLine($"The {enemy} has {hp} HP!");
    }
}
