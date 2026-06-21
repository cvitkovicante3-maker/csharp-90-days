# Day 51: Fields & Properties

## 📚 Concept
Fields store raw data. Properties wrap fields with `get` and `set` to add rules and control access.

## 💻 My Code
```csharp
using System;

class Player
{
    public string name;

    private int _health;
    public int Health
    {
        get { return _health; }
        set
        {
            if (value &lt; 0) _health = 0;
            else if (value &gt; 100) _health = 100;
            else _health = value;
        }
    }

    public int Level { get; set; }

    public void ShowStats()
    {
        Console.WriteLine(name + " | HP: " + Health + " | Lv: " + Level);
    }
}

class Program
{
    static void Main()
    {
        Player hero = new Player();
        hero.name = "Zara";
        hero.Health = 100;
        hero.Level = 5;
        hero.ShowStats();

        hero.Health = 150;
        hero.ShowStats();

        hero.Health = -20;
        hero.ShowStats();
    }
}
