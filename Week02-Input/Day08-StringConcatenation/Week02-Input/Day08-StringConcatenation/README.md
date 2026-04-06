# Day 8: String Concatenation

## 📚 Concept
Join text together with `+`. This is the "old way" of combining strings (before we learned interpolation). Use `" "` to add spaces between words.

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        string title = "Epic";
        string type = "RPG";
        string fullTitle = title + " " + type;
        
        Console.WriteLine(fullTitle);
    }
}
