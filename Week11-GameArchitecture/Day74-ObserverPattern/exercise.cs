using System;
using System.Collections.Generic;

// --- OBSERVER INTERFACE ---
interface IObserver
{
    void OnNotify(string eventType, object data);
}

// --- SUBJECT (the thing being observed) ---
class AchievementSystem
{
    private List<IObserver> _observers = new();

    public void Subscribe(IObserver observer)
    {
        _observers.Add(observer);
        Console.WriteLine("Observer subscribed.");
    }

    public void Unsubscribe(IObserver observer)
    {
        _observers.Remove(observer);
        Console.WriteLine("Observer unsubscribed.");
    }

    public void Notify(string eventType, object data)
    {
        foreach (var observer in _observers)
        {
            observer.OnNotify(eventType, data);
        }
    }

    // Game logic that triggers notifications
    public void PlayerKilledEnemy(string enemyName)
    {
        Console.WriteLine("\n--- EVENT: Enemy Killed ---");
        Notify("ENEMY_KILLED", enemyName);
    }

    public void PlayerLeveledUp(int newLevel)
    {
        Console.WriteLine("\n--- EVENT: Level Up ---");
        Notify("LEVEL_UP", newLevel);
    }
}

// --- CONCRETE OBSERVERS ---

class AchievementTracker : IObserver
{
    private int _killCount;

    public void OnNotify(string eventType, object data)
    {
        if (eventType == "ENEMY_KILLED")
        {
            _killCount++;
            Console.WriteLine($"[ACHIEVEMENT] Kill count: {_killCount}");
            if (_killCount >= 10)
                Console.WriteLine("[ACHIEVEMENT UNLOCKED] Slayer!");
        }
        else if (eventType == "LEVEL_UP")
        {
            Console.WriteLine($"[ACHIEVEMENT] Reached level {(int)data}!");
        }
    }
}

class SoundManager : IObserver
{
    public void OnNotify(string eventType, object data)
    {
        switch (eventType)
        {
            case "ENEMY_KILLED":
                Console.WriteLine("[SOUND] Playing victory fanfare!");
                break;
            case "LEVEL_UP":
                Console.WriteLine("[SOUND] Playing level up jingle!");
                break;
        }
    }
}

class UIManager : IObserver
{
    public void OnNotify(string eventType, object data)
    {
        switch (eventType)
        {
            case "ENEMY_KILLED":
                Console.WriteLine($"[UI] Show +XP popup for killing {(string)data}");
                break;
            case "LEVEL_UP":
                Console.WriteLine($"[UI] Show level {(int)data} banner!");
                break;
        }
    }
}

class Program
{
    static void Main()
    {
        AchievementSystem gameEvents = new AchievementSystem();

        // Create observers
        AchievementTracker achievements = new AchievementTracker();
        SoundManager sounds = new SoundManager();
        UIManager ui = new UIManager();

        // Subscribe all
        gameEvents.Subscribe(achievements);
        gameEvents.Subscribe(sounds);
        gameEvents.Subscribe(ui);

        // Trigger events
        gameEvents.PlayerKilledEnemy("Goblin");
        gameEvents.PlayerKilledEnemy("Orc");
        gameEvents.PlayerLeveledUp(5);

        // Unsubscribe one
        Console.WriteLine("\n--- Unsubscribing UI ---");
        gameEvents.Unsubscribe(ui);

        gameEvents.PlayerKilledEnemy("Dragon");
    }
}
