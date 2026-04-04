# Day 6: Basic Math Operations

## 📚 Concept
Computers can calculate using `+`, `-`, `*`, `/`. 
Math happens on the right side of `=` first, then result is stored in the variable.

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        int attack = 10;
        int bonus = 5;
        int totalDamage = attack + bonus;
        
        Console.WriteLine("Damage: " + totalDamage);
    }
}
