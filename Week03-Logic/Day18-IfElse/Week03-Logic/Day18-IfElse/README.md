# Day 18: If-Else

## 📚 Concept
Provide an alternative path when the `if` condition is false. 
Like a fork in the road: you go one way or the other, never both. 
Essential for game logic: hit or miss, alive or dead, door open or locked.

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        int ammo = 0;
        
        if (ammo &gt; 0)
        {
            Console.WriteLine("Bang!");
        }
        else
        {
            Console.WriteLine("Click... out of ammo!");
        }
    }
}
