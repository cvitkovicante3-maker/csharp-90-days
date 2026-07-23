using System;
using System.Collections.Generic;

class GameManager
{
    // Singleton pattern: only one GameManager
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new GameManager();
            return _instance;
        }
    }

    private Player _player;
    private List<Enemy> _enemies;
    private bool _gameOver;

    private GameManager()
    {
        _enemies = new List<Enemy>();
        _gameOver = false;
    }

    public void StartGame()
    {
        Console.WriteLine("=== GAME START ===");
        _player = new Player("Hero", 100);

        _enemies.Add(new Goblin("Skitter"));
        _enemies.Add(new Orc("Gruk"));

        ShowStatus();
    }

    public void PlayerAttack(int enemyIndex)
    {
        if (_gameOver || enemyIndex >= _enemies.Count) return;

        Enemy target = _enemies[enemyIndex];
        Console.WriteLine(_player.Name + " attacks " + target.name + "!");
        target.TakeDamage(20);

        if (!target.IsAlive())
        {
            Console.WriteLine(target.name + " defeated!");
            _enemies.RemoveAt(enemyIndex);
        }

        CheckWinCondition();
        if (!_gameOver) EnemyTurn();
    }

    private void EnemyTurn()
    {
        foreach (Enemy e in _enemies)
        {
            Console.WriteLine();
            e.Attack();
            _player.TakeDamage(e.damage);
        }

        CheckLoseCondition();
        ShowStatus();
    }

    private void CheckWinCondition()
    {
        if (_enemies.Count == 0)
        {
            Console.WriteLine("\n*** ALL ENEMIES DEFEATED! YOU WIN! ***");
            _gameOver = true;
        }
    }

    private void CheckLoseCondition()
    {
        if (_player.Health <= 0)
        {
            Console.WriteLine("\n*** YOU DIED! GAME OVER! ***");
            _gameOver = true;
        }
    }

    public void ShowStatus()
    {
        Console.WriteLine("\n--- STATUS ---");
        _player.ShowStats();
        Console.WriteLine("Enemies remaining: " + _enemies.Count);
        foreach (Enemy e in _enemies)
        {
            Console.WriteLine("- " + e.name + " HP: " + e.health);
        }
        Console.WriteLine("--------------\n");
    }

    public bool IsGameOver() { return _gameOver; }
}

// Reuse classes from previous days (simplified)
class Player
{
    public string Name { get; private set; }
    private int _health;
    public int Health { get { return _health; } }

    public Player(string name, int health) { Name = name; _health = health; }
    public void TakeDamage(int amount)
    {
        _health -= amount;
        if (_health < 0) _health = 0;
        Console.WriteLine(Name + " took " + amount + " damage. HP: " + _health);
    }
    public void ShowStats() { Console.WriteLine(Name + " HP: " + _health); }
}

abstract class Enemy
{
    public string name;
    public int health;
    public int damage;
    public Enemy(string n, int h, int d) { name = n; health = h; damage = d; }
    public abstract void Attack();
    public void TakeDamage(int a) { health -= a; if (health < 0) health = 0; }
    public bool IsAlive() { return health > 0; }
}

class Goblin : Enemy
{
    public Goblin(string n) : base(n, 30, 5) { }
    public override void Attack() { Console.WriteLine(name + " stabs for " + damage + "!"); }
}

class Orc : Enemy
{
    public Orc(string n) : base(n, 80, 12) { }
    public override void Attack() { Console.WriteLine(name + " smashes for " + damage + "!"); }
}

class Program
{
    static void Main()
    {
        GameManager game = GameManager.Instance;
        game.StartGame();

        while (!game.IsGameOver())
        {
            Console.WriteLine("Press Enter to attack next enemy...");
            Console.ReadLine();
            game.PlayerAttack(0);
        }
    }
}
