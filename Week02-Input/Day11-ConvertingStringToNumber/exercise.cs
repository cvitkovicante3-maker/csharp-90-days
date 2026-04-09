using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter damage value: ");
        string text = Console.ReadLine();
        int damage = int.Parse(text);
        
        int total = damage + 10; // Bonus damage
        Console.WriteLine($"Total damage: {total}");
    }
}
