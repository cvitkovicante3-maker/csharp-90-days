using System;

class Player
{
    // Field: raw storage
    public string name;

    // Property: controlled access
    private int _health;
    public int Health
    {
        get { return _health; }
        set
        {
            if (value < 0) _health = 0;
            else if (value > 100) _health = 100;
            else _health = value;
        }
    }

    // Auto-property: C# creates the field for you
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

        // Try to set health beyond limits
        hero.Health = 150;  // clamps to 100
        hero.ShowStats();

        hero.Health = -20;  // clamps to 0
        hero.ShowStats();
    }
}
