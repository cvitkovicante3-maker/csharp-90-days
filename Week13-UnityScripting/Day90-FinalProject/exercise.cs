using System;
using System.Collections.Generic;
using System.Threading;

// ==================== INTERFACES ====================
public interface IDamageable
{
    string Name { get; }
    int Health { get; }
    int MaxHealth { get; }
    void TakeDamage(int damage);
    bool IsAlive { get; }
}

public interface IAttacker
{
    int AttackDamage { get; }
    void Attack(IDamageable target);
}

// ==================== EVENT SYSTEM (Observer Pattern) ====================
public static class GameEvents
{
    public static event Action<string> OnGameMessage;
    public static event Action OnPlayerDied;
    public static event Action OnEnemyDefeated;
    public static event Action OnScoreChanged;

    public static void PublishMessage(string msg) => OnGameMessage?.Invoke(msg);
    public static void PlayerDied() => OnPlayerDied?.Invoke();
    public static void EnemyDefeated() => OnEnemyDefeated?.Invoke();
    public static void ScoreChanged() => OnScoreChanged?.Invoke();
}

// ==================== ITEM SYSTEM ====================
public class Item
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Value { get; set; }
    
    public Item(string name, string description, int value)
    {
        Name = name;
        Description = description;
        Value = value;
    }
}

// ==================== BASE ENTITY (Abstract Class) ====================
public abstract class Entity : IDamageable, IAttacker
{
    public string Name { get; protected set; }
    public int Health { get; protected set; }
    public int MaxHealth { get; protected set; }
    public int AttackDamage { get; protected set; }
    public bool IsAlive => Health > 0;

    protected Random rand = new Random();

    public Entity(string name, int health, int attackDamage)
    {
        Name = name;
        MaxHealth = health;
        Health = health;
        AttackDamage = attackDamage;
    }

    public virtual void TakeDamage(int damage)
    {
        Health = Math.Max(0, Health - damage);
        GameEvents.PublishMessage($"{Name} took {damage} damage! [{Health}/{MaxHealth} HP]");
        if (!IsAlive)
        {
            GameEvents.PublishMessage($"💀 {Name} has been defeated!");
        }
    }

    public virtual void Attack(IDamageable target)
    {
        if (!IsAlive) return;
        int damage = AttackDamage + rand.Next(-2, 3);
        damage = Math.Max(1, damage);
        GameEvents.PublishMessage($"⚔️ {Name} attacks {target.Name} for {damage} damage!");
        target.TakeDamage(damage);
    }

    public void Heal(int amount)
    {
        Health = Math.Min(MaxHealth, Health + amount);
        GameEvents.PublishMessage($"❤️ {Name} healed for {amount} HP!");
    }
}

// ==================== PLAYER CLASS ====================
public class Player : Entity
{
    public int Experience { get; private set; }
    public int Level { get; private set; } = 1;
    public List<Item> Inventory { get; private set; } = new List<Item>();
    public int Gold { get; private set; }

    public Player(string name) : base(name, 100, 15) { }

    public void GainExperience(int xp)
    {
        Experience += xp;
        if (Experience >= Level * 50)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        Level++;
        MaxHealth += 20;
        Health = MaxHealth;
        AttackDamage += 5;
        Experience = 0;
        GameEvents.PublishMessage($"🎉 LEVEL UP! {Name} is now Level {Level}!");
    }

    public void AddGold(int amount)
    {
        Gold += amount;
        GameEvents.PublishMessage($"💰 Gained {amount} gold!");
    }

    public void AddItem(Item item)
    {
        Inventory.Add(item);
        GameEvents.PublishMessage($"📦 Acquired: {item.Name}");
    }

    public bool UseItem(int index)
    {
        if (index < 0 || index >= Inventory.Count)
        {
            Console.WriteLine("Invalid item!");
            return false;
        }
        
        var item = Inventory[index];
        if (item.Name == "Health Potion")
        {
            Heal(30);
            Inventory.RemoveAt(index);
            return true;
        }
        
        GameEvents.PublishMessage($"Cannot use {item.Name} right now!");
        return false;
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        if (!IsAlive)
        {
            GameEvents.PlayerDied();
        }
    }
}

// ==================== ENEMY HIERARCHY ====================
public abstract class Enemy : Entity
{
    public int ExperienceReward { get; protected set; }
    public int GoldReward { get; protected set; }
    public string EnemyType { get; protected set; }

    public Enemy(string name, int health, int attackDamage, int xp, int gold, string type) 
        : base(name, health, attackDamage)
    {
        ExperienceReward = xp;
        GoldReward = gold;
        EnemyType = type;
    }

    public virtual void OnDefeated(Player player)
    {
        player.GainExperience(ExperienceReward);
        player.AddGold(GoldReward);
        GameEvents.EnemyDefeated();
    }
}

public class Goblin : Enemy
{
    public Goblin() : base("Goblin", 40, 8, 25, 10, "Goblin") { }
    
    public override void Attack(IDamageable target)
    {
        base.Attack(target);
        if (rand.Next(100) < 25 && IsAlive && target.IsAlive)
        {
            GameEvents.PublishMessage("🗡️ Goblin strikes again!");
            base.Attack(target);
        }
    }
}

public class Orc : Enemy
{
    public Orc() : base("Orc", 80, 12, 60, 25, "Orc") { }
    
    public override void TakeDamage(int damage)
    {
        if (rand.Next(100) < 20)
        {
            GameEvents.PublishMessage("🛡️ Orc blocked the attack!");
            return;
        }
        base.TakeDamage(damage);
    }
}

public class Dragon : Enemy
{
    public Dragon() : base("Dragon", 150, 20, 150, 100, "Dragon") { }
    
    public override void Attack(IDamageable target)
    {
        base.Attack(target);
        if (IsAlive && target.IsAlive)
        {
            GameEvents.PublishMessage("🔥 Dragon breathes fire!");
            target.TakeDamage(5);
        }
    }
}

// ==================== UI MANAGER ====================
public class UIManager
{
    public int Score { get; private set; }
    public int HighScore { get; private set; }
    public int EnemiesDefeated { get; private set; }

    public void AddScore(int points)
    {
        Score += points;
        if (Score > HighScore) HighScore = Score;
        GameEvents.ScoreChanged();
    }

    public void RegisterKill(string enemyType)
    {
        EnemiesDefeated++;
        int points = enemyType switch
        {
            "Goblin" => 100,
            "Orc" => 250,
            "Dragon" => 1000,
            _ => 50
        };
        AddScore(points);
    }

    public void DrawBattleScreen(Player player, Enemy enemy)
    {
        Console.Clear();
        DrawBox("BATTLE");
        DrawHealthBar(player.Name, player.Health, player.MaxHealth, ConsoleColor.Green);
        DrawHealthBar(enemy.Name, enemy.Health, enemy.MaxHealth, ConsoleColor.Red);
        Console.WriteLine();
        DrawStats(player);
        Console.WriteLine();
    }

    private void DrawHealthBar(string name, int current, int max, ConsoleColor color)
    {
        int width = 20;
        double percent = (double)current / max;
        int filled = (int)(width * percent);
        
        Console.Write($"{name,-10} [");
        Console.ForegroundColor = color;
        Console.Write(new string('█', filled).PadRight(width, '░'));
        Console.ResetColor();
        Console.WriteLine($"] {current}/{max}");
    }

    public void DrawStats(Player player)
    {
        Console.WriteLine($"Level: {player.Level} | XP: {player.Experience} | Gold: {player.Gold}");
        Console.WriteLine($"Score: {Score} | High: {HighScore} | Kills: {EnemiesDefeated}");
    }

    public void DrawInventory(Player player)
    {
        Console.WriteLine("\n--- INVENTORY ---");
        if (player.Inventory.Count == 0)
        {
            Console.WriteLine("(empty)");
            return;
        }
        for (int i = 0; i < player.Inventory.Count; i++)
        {
            Console.WriteLine($"[{i}] {player.Inventory[i].Name} - {player.Inventory[i].Description}");
        }
    }

    public void DrawBox(string title)
    {
        int width = 40;
        Console.WriteLine("╔" + new string('═', width) + "╗");
        int padding = (width - title.Length) / 2;
        Console.WriteLine("║" + new string(' ', padding) + title + new string(' ', width - padding - title.Length) + "║");
        Console.WriteLine("╚" + new string('═', width) + "╝");
    }

    public void ShowMessage(string msg)
    {
        Console.WriteLine($">>> {msg}");
        Thread.Sleep(400);
    }
}

// ==================== STATE MACHINE ====================
public enum GameState
{
    MainMenu,
    Exploring,
    InCombat,
    GameOver,
    Victory
}

// ==================== GAME MANAGER (Singleton + Game Loop) ====================
public class GameManager
{
    private static GameManager _instance;
    public static GameManager Instance => _instance ??= new GameManager();

    public GameState CurrentState { get; private set; }
    public Player Player { get; private set; }
    public UIManager UI { get; private set; }
    public Enemy CurrentEnemy { get; private set; }
    
    private Random rand = new Random();
    private bool _running = true;
    private List<string> _messages = new List<string>();

    private GameManager()
    {
        UI = new UIManager();
        SubscribeToEvents();
    }

    private void SubscribeToEvents()
    {
        GameEvents.OnGameMessage += msg => _messages.Add(msg);
        GameEvents.OnPlayerDied += () => ChangeState(GameState.GameOver);
    }

    public void StartNewGame(string playerName)
    {
        Player = new Player(playerName);
        CurrentState = GameState.MainMenu;
        _messages.Clear();
        UI = new UIManager();
    }

    public void ChangeState(GameState newState)
    {
        CurrentState = newState;
    }

    public void RunGameLoop()
    {
        while (_running)
        {
            ProcessInput();
            Update();
            Render();
            
            if (CurrentState == GameState.GameOver || CurrentState == GameState.Victory)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey(true);
                ShowEndScreen();
                return;
            }
        }
    }

    private void ProcessInput()
    {
        if (CurrentState == GameState.MainMenu)
        {
            Console.WriteLine("\n1. Start Game | 2. Quit");
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.D1) ChangeState(GameState.Exploring);
            else if (key == ConsoleKey.D2) _running = false;
        }
        else if (CurrentState == GameState.Exploring)
        {
            Console.WriteLine("\n1. Explore | 2. Check Inventory | 3. Rest (+20 HP)");
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.D1) SpawnEnemy();
            else if (key == ConsoleKey.D2) 
            {
                UI.DrawInventory(Player);
                Console.ReadKey(true);
            }
            else if (key == ConsoleKey.D3)
            {
                Player.Heal(20);
                FlushMessages();
                Console.ReadKey(true);
            }
        }
        else if (CurrentState == GameState.InCombat)
        {
            UI.DrawBattleScreen(Player, CurrentEnemy);
            Console.WriteLine("\n1. Attack | 2. Use Item | 3. Flee");
            var key = Console.ReadKey(true).Key;
            
            if (key == ConsoleKey.D1)
            {
                Player.Attack(CurrentEnemy);
                
                if (CurrentEnemy.IsAlive)
                {
                    CurrentEnemy.Attack(Player);
                }
                else
                {
                    CurrentEnemy.OnDefeated(Player);
                    UI.RegisterKill(CurrentEnemy.EnemyType);
                    
                    if (rand.Next(100) < 30)
                    {
                        Player.AddItem(new Item("Health Potion", "Restores 30 HP", 15));
                    }
                    
                    ChangeState(GameState.Exploring);
                }
            }
            else if (key == ConsoleKey.D2)
            {
                UI.DrawInventory(Player);
                Console.Write("Select item index (or -1 to cancel): ");
                if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 0)
                {
                    if (Player.UseItem(idx))
                    {
                        CurrentEnemy.Attack(Player);
                    }
                }
            }
            else if (key == ConsoleKey.D3)
            {
                if (rand.Next(100) < 50)
                {
                    _messages.Add("🏃 You fled successfully!");
                    ChangeState(GameState.Exploring);
                }
                else
                {
                    _messages.Add("❌ Failed to flee!");
                    CurrentEnemy.Attack(Player);
                }
            }
            
            FlushMessages();
            if (CurrentState != GameState.GameOver && CurrentState != GameState.Victory)
            {
                Console.ReadKey(true);
            }
        }
    }

    private void Update()
    {
        if (UI.EnemiesDefeated >= 5)
        {
            ChangeState(GameState.Victory);
        }
    }

    private void Render()
    {
        if (CurrentState == GameState.InCombat) return;
        
        Console.Clear();
        UI.DrawBox($"DAY 90 - THE ARENA");
        
        const int MAX_MSG = 5;
        int start = Math.Max(0, _messages.Count - MAX_MSG);
        for (int i = start; i < _messages.Count; i++)
        {
            Console.WriteLine(_messages[i]);
        }
    }

    private void SpawnEnemy()
    {
        int roll = rand.Next(100);
        CurrentEnemy = roll switch
        {
            < 50 => new Goblin(),
            < 85 => new Orc(),
            _ => new Dragon()
        };
        
        _messages.Add($"⚠️ A wild {CurrentEnemy.Name} appears!");
        ChangeState(GameState.InCombat);
    }

    private void FlushMessages()
    {
        foreach (var msg in _messages)
        {
            UI.ShowMessage(msg);
        }
        _messages.Clear();
    }

    private void ShowEndScreen()
    {
        Console.Clear();
        if (CurrentState == GameState.Victory)
        {
            UI.DrawBox("🏆 VICTORY! YOU CONQUERED THE ARENA!");
        }
        else
        {
            UI.DrawBox("💀 GAME OVER");
        }
        
        UI.DrawStats(Player);
        Console.WriteLine($"\nTotal Enemies Defeated: {UI.EnemiesDefeated}");
        Console.WriteLine($"Final Score: {UI.Score}");
        Console.WriteLine($"High Score: {UI.HighScore}");
    }
}

// ==================== ENTRY POINT ====================
class Program
{
    static void Main()
    {
        Console.WriteLine("=== C# 90-DAY FINAL PROJECT ===");
        Console.WriteLine("🎮 The Arena - Turn-Based Combat");
        Console.WriteLine("==================================\n");
        
        Console.Write("Enter your hero's name: ");
        string name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name)) name = "Hero";
        
        var game = GameManager.Instance;
        game.StartNewGame(name);
        game.RunGameLoop();
        
        Console.WriteLine("\nThanks for playing! 🎮");
        Console.WriteLine("✅ 90 days of C# complete. You are Unity-ready!");
    }
}
