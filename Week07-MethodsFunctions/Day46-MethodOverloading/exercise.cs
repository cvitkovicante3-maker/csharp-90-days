using System;

class Program
{
    static void Main()
    {
        // C# picks the right method automatically
        Heal(20);                    // calls the int version
        Heal("Player One");          // calls the string version
        Heal(50, "Player Two");      // calls the two-parameter version
    }

    // Same name, different parameters
    static void Heal(int amount)
    {
        Console.WriteLine("Healed for " + amount + " HP.");
    }

    static void Heal(string target)
    {
        Console.WriteLine("Healed " + target + " fully.");
    }

    static void Heal(int amount, string target)
    {
        Console.WriteLine("Healed " + target + " for " + amount + " HP.");
    }
}
