# Day 25: Nested If Statements

## 📚 Concept
An `if` inside another `if`. Use when a second check only matters if the first one passes.

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        bool hasKey = true;
        bool doorIsLocked = true;

        if (hasKey)
        {
            Console.WriteLine("You have a key.");

            if (doorIsLocked)
            {
                Console.WriteLine("Door unlocked!");
            }
            else
            {
                Console.WriteLine("Door is already open.");
            }
        }
        else
        {
            Console.WriteLine("You need a key to proceed.");
        }
    }
}
