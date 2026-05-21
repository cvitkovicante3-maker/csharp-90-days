using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create an empty list of strings
        List<string> inventory = new List<string>();

        // Add items
        inventory.Add("Sword");
        inventory.Add("Potion");
        inventory.Add("Shield");

        Console.WriteLine("Items: " + inventory.Count);

        // Access by index (same as array)
        Console.WriteLine("First item: " + inventory[0]);

        // Loop through
        Console.WriteLine("Inventory:");
        foreach (string item in inventory)
        {
            Console.WriteLine("- " + item);
        }

        // Remove an item
        inventory.Remove("Potion");
        Console.WriteLine("After using potion: " + inventory.Count);

        // Check if list contains something
        if (inventory.Contains("Shield"))
        {
            Console.WriteLine("You have a shield.");
        }

        // Add more after removing
        inventory.Add("Key");
        Console.WriteLine("Final count: " + inventory.Count);
    }
}
