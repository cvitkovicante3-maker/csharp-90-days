# Day 42: List Methods

## 📚 Concept
Lists have built-in methods: Sort, Reverse, IndexOf, Insert, RemoveAt, and Clear. They modify the list directly.

## 💻 My Code
```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List&lt;int&gt; scores = new List&lt;int&gt; { 45, 92, 12, 78, 60 };

        scores.Sort();
        Console.WriteLine("Sorted:");
        foreach (int s in scores) Console.WriteLine(s);

        scores.Reverse();
        Console.WriteLine("Reversed:");
        foreach (int s in scores) Console.WriteLine(s);

        int index = scores.IndexOf(78);
        Console.WriteLine("Index of 78: " + index);

        scores.Insert(0, 99);
        Console.WriteLine("After insert:");
        foreach (int s in scores) Console.WriteLine(s);

        scores.RemoveAt(2);
        Console.WriteLine("After RemoveAt:");
        foreach (int s in scores) Console.WriteLine(s);

        scores.Clear();
        Console.WriteLine("Count after clear: " + scores.Count);
    }
}
