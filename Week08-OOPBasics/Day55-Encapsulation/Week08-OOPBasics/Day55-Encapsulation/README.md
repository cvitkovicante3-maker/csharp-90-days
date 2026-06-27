# Day 55: Encapsulation

## 📚 Concept
Bundle data and methods into a class and hide internal details. Use private fields with public properties/methods as controlled gates.

## 💻 My Code
```csharp
using System;

class Player
{
    private string _name;
    private int _health;
    private int _maxHealth;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public int Health
    {
        get { return _health; }
        set
        {
            if (value &lt; 0) _health = 0;
            else if (value &gt; _maxHealth) _health = _maxHealth;
            else _health = value;
        }
    }

    public Player(string name, int maxHealth)
    {
        _name = name;
        _maxHealth = maxHealth;
        _health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        Health = _health - damage;
        Console.WriteLine(_name + " took " + damage + " damage. HP: " + _health);
    }

    public void Heal(int amount)
    {
        Health = _health + amount;
        Console.WriteLine(_name + " healed " + amount + ". HP: " + _health);
    }

    public void ShowStats()
    {
        Console.WriteLine(_name + " | HP: " + _health + "/" + _maxHealth);
    }
}
