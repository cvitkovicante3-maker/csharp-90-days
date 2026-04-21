# Day 23: Combining Logic

## 📚 Concept
Mix `&&` (AND) and `||` (OR) for complex conditions. 
Use parentheses `()` to force order of operations. 
Inner parentheses calculate first. 
Essential for game logic: (hasAmmo && hasWeapon) || hasMelee.

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        bool isRaining = true;
        bool hasUmbrella = false;
        bool isIndoor = true;
        
        if ((isRaining && hasUmbrella) || isIndoor)
        {
            Console.WriteLine("You stay dry");
        }
    }
}
