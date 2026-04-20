# Day 22: Switch Statements

## 📚 Concept
A cleaner way to check one variable against many values. 
Use `switch` to check a variable, `case` for each possible value, 
and `break` to exit. Much cleaner than many `else if` statements!

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        int direction = 2;
        
        switch (direction)
        {
            case 1:
                Console.WriteLine("Going North");
                break;
            case 2:
                Console.WriteLine("Going South");
                break;
            case 3:
                Console.WriteLine("Going East");
                break;
            case 4:
                Console.WriteLine("Going West");
                break;
            default:
                Console.WriteLine("Unknown direction");
                break;
        }
    }
}
