# Day 64: Designing a Player Class

## 📚 Concept
Build a complete Player class with health, level, XP, inventory, and game methods. Use encapsulation, properties, composition, and clean method design.

## 💻 My Code
```csharp
using System;
using System.Collections.Generic;

class Player
{
    private string _name;
    private int _health;
    private int _maxHealth;
    private int _level;
    private int _experience;

    public string Name { get { return _name; } set { _name = value; } }
    public int Health { get { return _health; } }
    public int Level { get { return _level; } }
    public List&lt;string&gt; Inventory { get; private set; }

    public Player(string name, int maxHealth)
    {
        _name = name;
        _maxHealth = maxHealth;
        _health = maxHealth;
        _level = 1;
        _experience = 0;
        Inventory = new List&lt;string&gt;();
    }

    public void TakeDamage(int amount)
    {
        _health -= amount;
        if (_health &lt; 0) _health = 0;
        Console.WriteLine(_name + " took " + amount + " damage.");
    }

    public void Heal(int amount)
    {
        _health += amount;
        if (_health &gt; _maxHealth) _health = _maxHealth;
        Console.WriteLine(_name + " healed " + amount + ".");
    }

    public void GainExperience(int amount)
    {
        _experience += amount;
        if (_experience &gt;= _level * 100) LevelUp();
    }

    private void LevelUp()
    {
        _level++;
        _maxHealth += 20;
        _health = _maxHealth;
        _experience = 0;
        Console.WriteLine("LEVEL UP! " + _name + " is now level " + _level + "!");
    }

    public void AddItem(string item) { Inventory.Add(item); }
    public void ShowStats()
    {
        Console.WriteLine("=== " + _name + " ===");
        Console.WriteLine("Level: " + _level + " | HP: " + _health + "/" + _maxHealth);
        Console.WriteLine("Inventory: " + string.Join(", ", Inventory));
    }
}
