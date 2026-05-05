# Day 34: Looping Through Strings

## 📚 Concept
Use a loop to visit every character in a string. `string[i]` gets the character at position `i`. `.Length` tells you how many characters there are.

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        string playerName = "Hero";

        for (int i = 0; i &lt; playerName.Length; i++)
        {
            Console.WriteLine("Letter " + i + " is: " + playerName[i]);
        }

        foreach (char letter in playerName)
        {
            Console.WriteLine("Found letter: " + letter);
        }

        string sentence = "Game Over Player One";
        int spaceCount = 0;
        for (int i = 0; i &lt; sentence.Length; i++)
        {
            if (sentence[i] == ' ')
            {
                spaceCount++;
            }
        }
        Console.WriteLine("Spaces found: " + spaceCount);
    }
}
