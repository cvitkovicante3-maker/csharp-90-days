using System;

class Player
{
    // Private: only this class can change these directly
    private int health;
    private int maxHealth;

    // Public: anyone can call these
    public string name;

    // Constructor sets up private fields
    public Player(string playerName, int playerMaxHealth)
    {
        name = playerName;
        maxHealth = playerMaxHealth;
        health = maxHealth;
    }

    // Public method to read health safely
    public int GetHealth()
    {
        return health;
    }

    // Public method to damage (controlled way to change private field)
    public void TakeDamage(int amount)
    {
        health = health - amount;
        if (health < 0) health = 0;
        Console.WriteLine(name + " took " + amount + " damage. HP: " + health);
    }

    // Public method to heal
    public void Heal(int amount)
    {
        health = health + amount;
        if (health > maxHealth) health = maxHealth;
        Console.WriteLine(name + " healed " + amount + ". HP: " + health);
    }
}

class Program
{
    static void Main()
    {
        Player hero = new Player("Zara", 100);

        // These work because they're public
        Console.WriteLine("Player: " + hero.name);
        hero.TakeDamage(30);
        hero.Heal(10);

        // This would FAIL - health is private
        // Console.WriteLine(hero.health);
        // hero.health = 999;
    }
}
