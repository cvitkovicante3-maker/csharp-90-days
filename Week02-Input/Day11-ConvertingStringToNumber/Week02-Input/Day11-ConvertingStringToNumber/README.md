# Day 11: Converting String to Number

## 📚 Concept
Input comes as text (string), but you need numbers for math. 
Use `int.Parse()` to convert "50" (text) into 50 (number). 
Without this, you can't do math on user input!

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter damage value: ");
        string text = Console.ReadLine();
        int damage = int.Parse(text);
        
        int total = damage + 10; // Bonus damage
        Console.WriteLine($"Total damage: {total}");
    }
}
