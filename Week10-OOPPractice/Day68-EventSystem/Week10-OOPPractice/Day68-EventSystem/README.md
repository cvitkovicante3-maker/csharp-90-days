# Day 68: Event System

## 📚 Concept
Events let objects communicate without direct connections. One object raises an event, others subscribe and respond. Loose coupling = flexible code.

## 💻 My Code
```csharp
using System;

class PlayerDiedEventArgs : EventArgs
{
    public string PlayerName { get; set; }
    public int FinalScore { get; set; }
}

class Player
{
    public string Name { get; private set; }
    public int Health { get; private set; }
    public event EventHandler&lt;PlayerDiedEventArgs&gt; Died;

    public Player(string n, int h) { Name = n; Health = h; }

    public void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health &lt;= 0) OnDied();
    }

    protected virtual void OnDied()
    {
        Died?.Invoke(this, new PlayerDiedEventArgs { PlayerName = Name, FinalScore = 100 });
    }
}

class GameManager
{
    public void HandlePlayerDied(object sender, PlayerDiedEventArgs e)
    {
        Console.WriteLine("GAME OVER: " + e.PlayerName + " died.");
    }
}
