using System;

class Program
{
    static void Main()
    {
        int playerHealth = 30;

        // Ternary: pick a string based on health
        string status = playerHealth > 50 ? "Healthy" : "Wounded";
        Console.WriteLine(status);

        // Ternary used directly inside WriteLine
        Console.WriteLine(playerHealth > 0 ? "Player is alive" : "Player is dead");

        // Ternary with numbers: bonus damage if health is low
        int damage = 10;
        int totalDamage = playerHealth < 40 ? damage + 5 : damage;
        Console.WriteLine("Damage: " + totalDamage);
    }
}
