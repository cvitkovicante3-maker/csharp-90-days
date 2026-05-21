# Day 41: Lists

## 📚 Concept
A dynamic array that grows and shrinks. Use `List&lt;T&gt;` with `.Add()`, `.Remove()`, `.Count`, and `.Contains()`.

## 💻 My Code
```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List&lt;string&gt; inventory = new List&lt;string&gt;();
        inventory.Add("Sword");
        inventory.Add("Potion");
        inventory.Add("Shield");

        Console.WriteLine("Items: " + inventory.Count);
        Console.WriteLine("First: " + inventory[0]);

        foreach (string item in inventory)
        {
            Console.WriteLine("- " + item);
        }

        inventory.Remove("Potion");
        Console.WriteLine("After removal: " + inventory.Count);

        if (inventory.Contains("Shield"))
        {
            Console.WriteLine("You have a shield.");
        }

        inventory.Add("Key");
        Console.WriteLine("Final count: " + inventory.Count);
    }
}
