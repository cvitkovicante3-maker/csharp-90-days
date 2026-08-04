using System;
using System.Collections.Generic;

// --- EVENT ARGS ---
class BattleEventArgs : EventArgs
{
    public string Attacker { get; set; }
    public string Target { get; set; }
    public int Damage { get; set; }
}

// --- ITEM ---
class Item
{
    public string Name { get; set; }
    public string Effect { get; set; }

    public Item(string name, string effect)
    {
        Name = name;
        Effect = effect;
    }
}

// --- PLAYER ---
class Player
{
    public string Name { get; private set; }
    public int Health { get; private set; }
    private int _maxHealth;
    public List<Item> Inventory { get; private set; }

    public event EventHandler<BattleEventArgs> Attacked;
    public event EventHandler Died;

    public Player(string name, int health)
    {
        Name = name;
        Health = health;
        _maxHealth = health;
        Inventory = new List<Item>();
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health < 0) Health = 0;

        Console.WriteLine(Name + " took " + amount + " damage. HP: " + Health);

        if (Health == 0)
        {
            Died?.Invoke(this, EventArgs.Empty);
        }
    }

    public void Attack(Enemy target)
    {
        int damage = 15;
        Console.WriteLine(Name + " attacks " + target.Name + "!");
        target.TakeDamage(damage);

        Attacked?.Invoke(this, new BattleEventArgs
        {
            Attacker = Name,
            Target = target.Name,
            Damage = damage
        });
    }

    public void UseItem(Item item)
    {
        if (item.Effect == "heal")
        {
            Health += 25;
            if (Health > _maxHealth) Health = _maxHealth;
            Console.WriteLine(Name + " used " + item.Name + ". HP: " + Health);
        }
        Inventory.Remove(item);
    }

    public void ShowStats()
    {
        Console.WriteLine(Name + " | HP: " + Health);
    }
}

// --- ENEMY (abstract) ---
abstract class Enemy
{
    public string Name { get; protected set; }
    public int Health { get; protected set; }
    public int Damage { get; protected set; }

    public event EventHandler<BattleEventArgs> Attacked;
    public event EventHandler Died;

    public void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health < 0) Health = 0;
        Console.WriteLine(Name + " took " + amount + " damage. HP: " + Health);

        if (Health == 0)
        {
            Died?.Invoke(this, EventArgs.Empty);
        }
    }

    public abstract void Attack(Player target);

    protected void RaiseAttackedEvent(Player target, int damage)
    {
        Attacked?.Invoke(this, new BattleEventArgs
        {
            Attacker = Name,
            Target = target.Name,
            Damage = damage
        });
    }
}

class Goblin : Enemy
{
    public Goblin()
    {
        Name = "Goblin";
        Health = 30;
        Damage = 5;
    }

    public override void Attack(Player target)
    {
        Console.WriteLine(Name + " stabs " + target.Name + "!");
        target.TakeDamage(Damage);
        RaiseAttackedEvent(target, Damage);
    }
}

class Orc : Enemy
{
    public Orc()
    {
        Name = "Orc";
        Health = 60;
        Damage = 12;
    }

    public override void Attack(Player target)
    {
        Console.WriteLine(Name + " smashes " + target.Name + "!");
        target.TakeDamage(Damage);
        RaiseAttackedEvent(target, Damage);
    }
}

// --- GAME MANAGER ---
class GameManager
{
    private Player _player;
    private List<Enemy> _enemies;
    private bool _gameOver;

    public GameManager()
    {
        _enemies = new List<Enemy>();
    }

    public void StartGame()
    {
        Console.WriteLine("=== BATTLE START ===\n");

        _player = new Player("Zara", 100);
        _player.Inventory.Add(new Item("Health Potion", "heal"));
        _player.Inventory.Add(new Item("Health Potion", "heal"));

        _enemies.Add(new Goblin());
        _enemies.Add(new Orc());

        // Subscribe to events
        _player.Died += OnPlayerDied;
        foreach (Enemy e in _enemies)
        {
            e.Died += OnEnemyDied;
        }

        ShowStatus();
    }

    public void PlayerTurn(int action, int targetIndex)
    {
        if (_gameOver) return;

        if (action == 1 && targetIndex < _enemies.Count) // Attack
        {
            _player.Attack(_enemies[targetIndex]);
        }
        else if (action == 2 && _player.Inventory.Count > 0) // Use item
        {
            _player.UseItem(_player.Inventory[0]);
        }

        CheckWinCondition();
        if (!_gameOver) EnemyTurn();
    }

    private void EnemyTurn()
    {
        Console.WriteLine("\n--- ENEMY TURN ---");
        foreach (Enemy e in _enemies)
        {
            if (e.Health > 0)
            {
                e.Attack(_player);
            }
        }
        Console.WriteLine("------------------\n");

        ShowStatus();
    }

    private void OnPlayerDied(object sender, EventArgs e)
    {
        Console.WriteLine("\n*** " + _player.Name + " HAS FALLEN! GAME OVER! ***");
        _gameOver = true;
    }

    private void OnEnemyDied(object sender, EventArgs e)
    {
        Enemy dead = (Enemy)sender;
        Console.WriteLine("*** " + dead.Name + " DEFEATED! ***");
        _enemies.Remove(dead);
    }

    private void CheckWinCondition()
    {
        if (_enemies.Count == 0 && !_gameOver)
        {
            Console.WriteLine("\n*** ALL ENEMIES DEFEATED! VICTORY! ***");
            _gameOver = true;
        }
    }

    public void ShowStatus()
    {
        Console.WriteLine("=== STATUS ===");
        _player.ShowStats();
        foreach (Enemy e in _enemies)
        {
            Console.WriteLine(e.Name + " | HP: " + e.Health);
        }
        Console.WriteLine("==============\n");
    }

    public bool IsGameOver() { return _gameOver; }
}

// --- PROGRAM ---
class Program
{
    static void Main()
    {
        GameManager game = new GameManager();
        game.StartGame();

        // Simulate a few turns
        game.PlayerTurn(1, 0); // Attack first enemy
        if (!game.IsGameOver())
        {
            game.PlayerTurn(1, 0); // Attack again
        }
        if (!game.IsGameOver())
        {
            game.PlayerTurn(2, 0); // Use potion
        }
    }
}
