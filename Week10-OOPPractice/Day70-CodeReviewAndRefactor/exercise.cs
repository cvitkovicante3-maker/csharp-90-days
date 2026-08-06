using System;
using System.Collections.Generic;

// REFACTORED: Base event args for all combat events
class CombatEventArgs : EventArgs
{
    public string Attacker { get; set; }
    public string Target { get; set; }
    public int Damage { get; set; }
}

// REFACTORED: Interface for anything that can fight
interface ICombatant
{
    string Name { get; }
    int Health { get; }
    bool IsAlive { get; }
    void TakeDamage(int amount);
    event EventHandler<CombatEventArgs> Attacked;
    event EventHandler Died;
}

// REFACTORED: Cleaner Player class
class Player : ICombatant
{
    public string Name { get; private set; }
    public int Health { get; private set; }
    public bool IsAlive => Health > 0;

    private readonly int _maxHealth;
    public List<Item> Inventory { get; }

    public event EventHandler<CombatEventArgs> Attacked;
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
        Health = Math.Max(0, Health - amount);
        Console.WriteLine($"{Name} took {amount} damage. HP: {Health}");

        if (!IsAlive) Died?.Invoke(this, EventArgs.Empty);
    }

    public void Attack(ICombatant target)
    {
        const int BASE_DAMAGE = 15;
        Console.WriteLine($"{Name} attacks {target.Name}!");
        target.TakeDamage(BASE_DAMAGE);

        Attacked?.Invoke(this, new CombatEventArgs
        {
            Attacker = Name,
            Target = target.Name,
            Damage = BASE_DAMAGE
        });
    }

    public void UseItem(Item item)
    {
        if (!Inventory.Contains(item)) return;

        if (item.Effect == "heal")
        {
            Health = Math.Min(_maxHealth, Health + 25);
            Console.WriteLine($"{Name} used {item.Name}. HP: {Health}");
        }
        Inventory.Remove(item);
    }

    public void ShowStats() => Console.WriteLine($"{Name} | HP: {Health}");
}

// REFACTORED: Simplified Enemy with template method pattern
abstract class Enemy : ICombatant
{
    public string Name { get; protected set; }
    public int Health { get; protected set; }
    public int Damage { get; protected set; }
    public bool IsAlive => Health > 0;

    public event EventHandler<CombatEventArgs> Attacked;
    public event EventHandler Died;

    public void TakeDamage(int amount)
    {
        Health = Math.Max(0, Health - amount);
        Console.WriteLine($"{Name} took {amount} damage. HP: {Health}");

        if (!IsAlive) Died?.Invoke(this, EventArgs.Empty);
    }

    public void Attack(ICombatant target)
    {
        Console.WriteLine($"{Name} {GetAttackVerb()} {target.Name}!");
        target.TakeDamage(Damage);

        Attacked?.Invoke(this, new CombatEventArgs
        {
            Attacker = Name,
            Target = target.Name,
            Damage = Damage
        });
    }

    // Each enemy defines their attack description
    protected abstract string GetAttackVerb();

    public void ShowStats() => Console.WriteLine($"{Name} | HP: {Health}");
}

class Goblin : Enemy
{
    public Goblin()
    {
        Name = "Goblin";
        Health = 30;
        Damage = 5;
    }
    protected override string GetAttackVerb() => "stabs";
}

class Orc : Enemy
{
    public Orc()
    {
        Name = "Orc";
        Health = 60;
        Damage = 12;
    }
    protected override string GetAttackVerb() => "smashes";
}

class Dragon : Enemy
{
    public Dragon()
    {
        Name = "Dragon";
        Health = 150;
        Damage = 25;
    }
    protected override string GetAttackVerb() => "breathes fire on";
}

// REFACTORED: Cleaner Item
record Item(string Name, string Effect);

// REFACTORED: Streamlined GameManager
class GameManager
{
    private Player _player;
    private List<Enemy> _enemies;
    private bool _gameOver;

    public GameManager() => _enemies = new List<Enemy>();

    public void StartGame()
    {
        Console.WriteLine("=== BATTLE START ===\n");

        _player = new Player("Zara", 100);
        _player.Inventory.Add(new Item("Health Potion", "heal"));

        _enemies.Add(new Goblin());
        _enemies.Add(new Orc());

        _player.Died += (_, _) => EndGame(false);
        foreach (var enemy in _enemies)
            enemy.Died += OnEnemyDied;

        ShowStatus();
    }

    public void PlayerTurn(int action, int targetIndex = 0)
    {
        if (_gameOver) return;

        switch (action)
        {
            case 1 when targetIndex < _enemies.Count:
                _player.Attack(_enemies[targetIndex]);
                break;
            case 2 when _player.Inventory.Count > 0:
                _player.UseItem(_player.Inventory[0]);
                break;
        }

        CheckWinCondition();
        if (!_gameOver) EnemyTurn();
    }

    private void EnemyTurn()
    {
        Console.WriteLine("\n--- ENEMY TURN ---");
        foreach (var enemy in _enemies.Where(e => e.IsAlive))
            enemy.Attack(_player);
        Console.WriteLine("------------------\n");

        ShowStatus();
    }

    private void OnEnemyDied(object sender, EventArgs e)
    {
        if (sender is Enemy dead)
        {
            Console.WriteLine($"*** {dead.Name} DEFEATED! ***");
            _enemies.Remove(dead);
        }
    }

    private void CheckWinCondition()
    {
        if (_enemies.Count == 0 && !_gameOver)
            EndGame(true);
    }

    private void EndGame(bool victory)
    {
        _gameOver = true;
        var message = victory ? "VICTORY!" : "GAME OVER!";
        Console.WriteLine($"\n*** ALL ENEMIES DEFEATED! {message} ***");
    }

    public void ShowStatus()
    {
        Console.WriteLine("=== STATUS ===");
        _player.ShowStats();
        foreach (var enemy in _enemies)
            enemy.ShowStats();
        Console.WriteLine("==============\n");
    }

    public bool IsGameOver() => _gameOver;
}

class Program
{
    static void Main()
    {
        var game = new GameManager();
        game.StartGame();

        game.PlayerTurn(1, 0);
        if (!game.IsGameOver()) game.PlayerTurn(1, 0);
        if (!game.IsGameOver()) game.PlayerTurn(2);
    }
}
