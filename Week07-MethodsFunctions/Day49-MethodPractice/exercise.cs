using System;

class Program
{
    static void Main()
    {
        int playerHealth = 100;
        int enemyHealth = 80;

        ShowStatus("Player", playerHealth);
        ShowStatus("Enemy", enemyHealth);

        // Player attacks enemy
        int damage = CalculateDamage(15, true); // 15 base, critical hit
        ApplyDamage(ref enemyHealth, damage);
        Console.WriteLine("Player hits Enemy for " + damage + "!");

        // Enemy attacks back
        damage = CalculateDamage(10, false);
        ApplyDamage(ref playerHealth, damage);
        Console.WriteLine("Enemy hits Player for " + damage + "!");

        Console.WriteLine("---");
        ShowStatus("Player", playerHealth);
        ShowStatus("Enemy", enemyHealth);

        // Heal player
        Heal(ref playerHealth, 20);
        Console.WriteLine("Player uses potion!");
        ShowStatus("Player", playerHealth);
    }

    static void ShowStatus(string name, int health)
    {
        Console.WriteLine(name + " HP: " + health);
    }

    static int CalculateDamage(int baseDamage, bool isCritical)
    {
        if (isCritical)
        {
            return baseDamage * 2;
        }
        return baseDamage;
    }

    static void ApplyDamage(ref int health, int damage)
    {
        health = health - damage;
        if (health < 0) health = 0;
    }

    static void Heal(ref int health, int amount, bool showMessage = true)
    {
        health = health + amount;
        if (health > 100) health = 100;
        if (showMessage)
        {
            Console.WriteLine("Healed " + amount + " HP.");
        }
    }
}
