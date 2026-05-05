using System;

class Program
{
    static void Main()
    {
        string playerName = "Hero";

        // Loop through each character using index
        for (int i = 0; i < playerName.Length; i++)
        {
            Console.WriteLine("Letter " + i + " is: " + playerName[i]);
        }

        Console.WriteLine("---");

        // Cleaner way: foreach (no index needed)
        foreach (char letter in playerName)
        {
            Console.WriteLine("Found letter: " + letter);
        }

        Console.WriteLine("---");

        // Count how many spaces are in a sentence
        string sentence = "Game Over Player One";
        int spaceCount = 0;

        for (int i = 0; i < sentence.Length; i++)
        {
            if (sentence[i] == ' ')
            {
                spaceCount++;
            }
        }

        Console.WriteLine("Spaces found: " + spaceCount);
    }
}
