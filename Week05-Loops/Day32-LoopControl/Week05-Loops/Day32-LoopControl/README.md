# Day 32: Loop Control (break/continue)

## 📚 Concept
`break` exits a loop immediately. `continue` skips to the next iteration.

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        for (int room = 1; room &lt;= 10; room++)
        {
            Console.WriteLine("Searching room " + room);
            if (room == 4)
            {
                Console.WriteLine("Key found! Stopping search.");
                break;
            }
        }

        for (int wave = 1; wave &lt;= 5; wave++)
        {
            if (wave == 2 || wave == 4)
            {
                Console.WriteLine("Wave " + wave + " skipped");
                continue;
            }
            Console.WriteLine("Fighting wave " + wave);
        }
    }
}
