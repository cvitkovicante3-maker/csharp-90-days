using System;

class Player
{
    // Private fields — hidden from outside
    private string _name;
    private int _health;
    private int _maxHealth;

    // Public properties — controlled access
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
            if (value < 0) _health = 0;
            else if (value > _maxHealth) _health = _maxHealth;
            else _health = value;
        }
    }

    // Constructor
    public Player(string name, int maxHealth)
    {
        _name = name;
        _maxHealth = maxHealth;
        _health = maxHealth;
    }

    // Public methods — the only way to interact
    public void TakeDamage(int damage)
    {
        Health = _health - damage; // uses setter with clamping
        Console.WriteLine(_name + " took " + damage + " damage. HP: " + _health);
    }

    public void Heal(int amount)
    {
        Health = _health + amount; // uses setter with clamping
        Console.WriteLine(_name + " healed " + amount + ". HP: " + _health);
    }

    public void ShowStats()
    {
        Console.WriteLine(_name + " | HP: " + _health + "/" + _maxHealth);
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
        hero.ShowStats();

        // Can't do this anymore — fields are private
        // hero._health = 999;
    }
}
