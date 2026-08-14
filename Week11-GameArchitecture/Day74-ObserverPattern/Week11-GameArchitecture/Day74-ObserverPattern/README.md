# Day 74: Observer Pattern

## 📚 Concept
One-to-many dependency. When the subject changes, all observers are notified automatically. Built from scratch with interfaces.

## 💻 My Code
```csharp
using System;
using System.Collections.Generic;

interface IObserver
{
    void OnNotify(string eventType, object data);
}

class AchievementSystem
{
    private List&lt;IObserver&gt; _observers = new();

    public void Subscribe(IObserver o) =&gt; _observers.Add(o);
    public void Unsubscribe(IObserver o) =&gt; _observers.Remove(o);

    public void Notify(string eventType, object data)
    {
        foreach (var o in _observers) o.OnNotify(eventType, data);
    }

    public void PlayerKilledEnemy(string name) =&gt; Notify("ENEMY_KILLED", name);
    public void PlayerLeveledUp(int level) =&gt; Notify("LEVEL_UP", level);
}

class AchievementTracker : IObserver
{
    private int _killCount;
    public void OnNotify(string type, object data)
    {
        if (type == "ENEMY_KILLED") { _killCount++; Console.WriteLine($"Kills: {_killCount}"); }
    }
}
