using System;

// Simulating Unity UI system in console

class UISystem
{
    public int Score { get; private set; }
    public int HighScore { get; private set; }
    public int KillCount { get; private set; }
    public float HealthPercent { get; set; } = 1f;

    public event Action OnScoreChanged;
    public event Action OnHighScoreChanged;

    public void AddScore(int points)
    {
        Score += points;
        OnScoreChanged?.Invoke();

        if (Score > HighScore)
        {
            HighScore = Score;
            OnHighScoreChanged?.Invoke();
        }
    }

    public void RegisterKill(string enemyName)
    {
        KillCount++;
        int points = enemyName switch
        {
            "Goblin" => 100,
            "Orc" => 250,
            "Dragon" => 1000,
            _ => 50
        };

        AddScore(points);
        Console.WriteLine($"Killed {enemyName}! +{points} points");
    }

    public void Reset()
    {
        Score = 0;
        KillCount = 0;
        HealthPercent = 1f;
        OnScoreChanged?.Invoke();
    }

    public void DrawHealthBar(int width = 20)
    {
        int filled = (int)(width * HealthPercent);
        string bar = new string('█', filled).PadRight(width, '░');
        Console.WriteLine($"HP [{bar}] {HealthPercent * 100:F0}%");
    }

    public void DrawScore()
    {
        Console.WriteLine($"Score: {Score} | Kills: {KillCount} | High: {HighScore}");
    }

    public void DrawUI()
    {
        Console.WriteLine("\n╔══════════════════════╗");
        Console.WriteLine("║       HUD            ║");
        DrawHealthBar();
        DrawScore();
        Console.WriteLine("╚══════════════════════╝\n");
    }
}

class Program
{
    static void Main()
    {
        UISystem ui = new UISystem();

        // Subscribe to events
        ui.OnScoreChanged += () => Console.WriteLine("[EVENT] Score updated!");
        ui.OnHighScoreChanged += () => Console.WriteLine("[EVENT] New high score!");

        Console.WriteLine("=== UI & SCORE DEMO ===\n");

        ui.DrawUI();

        // Simulate gameplay
        ui.HealthPercent = 0.75f;
        ui.RegisterKill("Goblin");
        ui.DrawUI();

        ui.HealthPercent = 0.45f;
        ui.RegisterKill("Orc");
        ui.RegisterKill("Goblin");
        ui.DrawUI();

        ui.HealthPercent = 0.2f;
        ui.RegisterKill("Dragon");
        ui.DrawUI();

        // Take damage
        ui.HealthPercent = 0f;
        Console.WriteLine("PLAYER DIED!");
        ui.DrawUI();

        // Restart
        Console.WriteLine("\n--- RESTART ---\n");
        ui.Reset();
        ui.DrawUI();
    }
}
