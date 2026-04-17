# Day 19: Else-If Chains

## 📚 Concept
Check multiple conditions in order. The computer checks from top to bottom 
and stops at the first true condition. The final `else` catches anything not matched. 
Perfect for: ranks, grades, difficulty levels!

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        int score = 75;
        
        if (score &gt;= 90)
        {
            Console.WriteLine("Rank: S");
        }
        else if (score &gt;= 70)
        {
            Console.WriteLine("Rank: A");
        }
        else if (score &gt;= 50)
        {
            Console.WriteLine("Rank: B");
        }
        else
        {
            Console.WriteLine("Rank: C");
        }
    }
}
