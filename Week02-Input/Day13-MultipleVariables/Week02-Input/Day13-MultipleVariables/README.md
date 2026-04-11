# Day 13: Multiple Variables

## 📚 Concept
Declare related variables together for cleaner code. 
Use commas to declare same-type variables on one line. 
Good for coordinates (x, y, z) or color channels (r, g, b).

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        int x = 10, y = 20, z = 30;
        string a = "Red", b = "Blue";
        
        Console.WriteLine($"Position: ({x}, {y}, {z})");
        Console.WriteLine($"Colors: {a} and {b}");
    }
}
