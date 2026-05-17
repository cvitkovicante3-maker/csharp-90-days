# Day 39: Array Methods

## 📚 Concept
Built-in tools to sort, reverse, search, and clear arrays. Call them through `Array.MethodName(array)`.

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        int[] scores = { 45, 92, 78, 12, 60 };

        Array.Sort(scores);
        Console.WriteLine("Sorted:");
        foreach (int s in scores) Console.WriteLine(s);

        Array.Reverse(scores);
        Console.WriteLine("Reversed:");
        foreach (int s in scores) Console.WriteLine(s);

        string[] weapons = { "Sword", "Bow", "Axe", "Staff" };
        int position = Array.IndexOf(weapons, "Axe");
        Console.WriteLine("Axe is at index: " + position);

        int missing = Array.IndexOf(weapons, "Shield");
        Console.WriteLine("Shield is at index: " + missing);

        int[] temp = { 1, 2, 3, 4, 5 };
        Array.Clear(temp, 0, temp.Length);
        Console.WriteLine("After clear:");
        foreach (int t in temp) Console.WriteLine(t);
    }
}
