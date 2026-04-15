# Day 17: If Statements

## 📚 Concept
Run code only when a condition is true. The `if` checks the condition in parentheses. 
If true, it runs the code in braces `{ }`. If false, it skips the block entirely. 
This is how games make decisions!

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        int health = 25;
        
        if (health &lt; 50)
        {
            Console.WriteLine("Warning: Low health!");
        }
    }
}
