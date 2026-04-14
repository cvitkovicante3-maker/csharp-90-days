# Day 16: Boolean Variables

## 📚 Concept
`bool` stores true/false values (switches, states, flags). 
Named after mathematician George Boole. 
Perfect for game states: isJumping, isGrounded, hasKey.

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        bool isAlive = true;
        bool hasWeapon = false;
        
        Console.WriteLine($"Living: {isAlive}");
        Console.WriteLine($"Armed: {hasWeapon}");
    }
}
