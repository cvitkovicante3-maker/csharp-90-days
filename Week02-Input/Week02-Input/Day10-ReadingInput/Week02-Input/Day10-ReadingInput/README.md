# Day 10: Reading User Input

## 📚 Concept
`Console.ReadLine()` pauses the program and waits for the user to type something. 
The program waits here until Enter is pressed. Input comes as text (string).

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter player name: ");
        string input = Console.ReadLine();
        
        Console.WriteLine($"Welcome, {input}!");
    }
}
