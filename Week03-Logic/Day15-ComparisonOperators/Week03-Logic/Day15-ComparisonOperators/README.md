# Day 15: Comparison Operators

## 📚 Concept
Check if values are equal, greater, or less than each other. 
The result is `bool` (true or false). 
Essential for game logic: "Is player level high enough?" "Is health zero?"

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        int score = 100;
        int highScore = 100;
        
        bool isEqual = (score == highScore);
        Console.WriteLine($"Tied record? {isEqual}");
    }
}
