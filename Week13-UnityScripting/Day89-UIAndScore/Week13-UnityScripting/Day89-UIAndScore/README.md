# Day 89: UI & Score

## 📚 Concept
Track score, kills, high score, and health. Display as formatted text and progress bars. Events notify UI of changes. Combo system rewards rapid kills.

## 💻 My Code
```csharp
using System;

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
        if (Score &gt; HighScore) { HighScore = Score; OnHighScoreChanged?.Invoke(); }
    }

    public void RegisterKill(string enemyName)
    {
        KillCount++;
        int points = enemyName switch { "Goblin" =&gt; 100, "Orc" =&gt; 250, "Dragon" =&gt; 1000, _ =&gt; 50 };
        AddScore(points);
    }

    public void DrawHealthBar(int width = 20)
    {
        int filled = (int)(width * HealthPercent);
        Console.WriteLine($"[{new string('█', filled).PadRight(width, '░')}] {HealthPercent * 100:F0}%");
    }

    public void DrawScore() =&gt; Console.WriteLine($"Score: {Score} | Kills: {KillCount} | High: {HighScore}");
}
