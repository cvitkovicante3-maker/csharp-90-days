using System;
using System.Collections.Generic;

class Player
{
    // Private fields
    private string _name;
    private int _health;
    private int _maxHealth;
    private int _level;
    private int _experience;

    // Public properties
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public int Health
    {
        get { return _health; }
    }

    public int Level
    {
        get { return _level; }
    }

    // Composition: player HAS an inventory
    public List<string> Inventory { get; private set; }

    // Constructor
    public Player(string name, int maxHealth)
    {
        _name = name;
        _maxHealth = maxHealth;
        _health = maxHealth;
        _level = 1;
        _experience = 0;
        Inventory = new List<string>();
    }

    // Methods
    public void TakeDamage(int amount)
    {
        _health -= amount;
        if (_health < 0) _health = 0;
        Console.WriteLine(_name + " took " + amount + " damage. HP: " + _health + "/" + _maxHealth);
    }

    public void Heal(int amount)
    {
        _health += amount;
        if (_health > _maxHealth) _health = _maxHealth;
        Console.WriteLine(_name + " healed " + amount + ". HP: " + _health + "/" + _maxHealth);
    }

    public void GainExperience(int amount)
    {
        _experience += amount;
        Console.WriteLine(_name + " gained " + amount + " XP. Total: " + _experience);

        if (_experience >= _level * 100)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        _level++;
        _maxHealth += 20;
        _health = _maxHealth;
        _experience = 0;
        Console.WriteLine("LEVEL UP! " + _name + " is now level " + _level + "!");
    }

    public void AddItem(string item)
    {
        Inventory.Add(item);
        Console.WriteLine(item + " added to inventory.");
    }

    public void ShowStats()
    {
        Console.WriteLine("=== " + _name + " ===");
        Console.WriteLine("Level: " + _level);
        Console.WriteLine("HP: " + _health + "/" + _maxHealth);
        Console.WriteLine("XP: " + _experience);
        Console.WriteLine("Inventory: " + string.Join(", ", Inventory));
    }
}

class Program
{
    static void Main()
    {
        Player hero = new Player("Zara", 100);

        hero.ShowStats();
        hero.TakeDamage(30);
        hero.Heal(10);
        hero.AddItem("Sword");
        hero.AddItem("Potion");
        hero.GainExperience(150);
        hero.ShowStats();
    }
}
