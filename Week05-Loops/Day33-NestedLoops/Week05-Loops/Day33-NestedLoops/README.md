# Day 33: Nested Loops

## 📚 Concept
A loop inside another loop. The inner loop runs completely for each run of the outer loop.

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        for (int row = 1; row &lt;= 3; row++)
        {
            for (int col = 1; col &lt;= 3; col++)
            {
                Console.Write("* ");
            }
            Console.WriteLine();
        }

        for (int row = 1; row &lt;= 3; row++)
        {
            for (int col = 1; col &lt;= 3; col++)
            {
                Console.Write("(" + row + "," + col + ") ");
            }
            Console.WriteLine();
        }

        for (int i = 1; i &lt;= 3; i++)
        {
            for (int j = 1; j &lt;= 3; j++)
            {
                Console.Write(i * j + "\t");
            }
            Console.WriteLine();
        }
    }
}
