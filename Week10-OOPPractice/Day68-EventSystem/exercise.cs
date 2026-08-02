using System;

// Define what the event looks like
class PlayerDiedEventArgs : EventArgs
{
    public string PlayerName { get; set; }
    public int FinalScore { get; set; }
}

class Player
{
    public string Name { get; private set; }
    public int Health { get; private set; }

    // Declare the event
    public event EventHandler<PlayerDiedEventArgs> Died;

    public Player(string name, int health)
    {
        Name = name;
        Health = health;
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
        Console.WriteLine(Name + " took " + amount + " damage. HP: " + Health);

        if (Health <= 0)
        {
            // Raise the event
            OnDied();
        }
    }

    protected virtual void OnDied()
    {
        Died?.Invoke(this, new PlayerDiedEventArgs
        {
            PlayerName = Name,
            FinalScore = 100 // example score
        });
    }
}

// Objects that listen to events
class GameManager
{
    public void HandlePlayerDied(object sender, PlayerDiedEventArgs e)
    {
        Console.WriteLine("GAME MANAGER: " + e.PlayerName + " died. Final score: " + e.FinalScore);
        Console.WriteLine("GAME MANAGER: Showing game over screen.");
    }
}

class SaveSystem
{
    public void HandlePlayerDied(object sender, PlayerDiedEventArgs e)
    {
        Console.WriteLine("SAVE SYSTEM: Saving final score for " + e.PlayerName);
    }
}

class AchievementSystem
{
    public void HandlePlayerDied(object sender, PlayerDiedEventArgs e)
    {
        Console.WriteLine("ACHIEVEMENTS: Checking death-related achievements.");
    }
}

class Program
{
    static void Main()
    {
        Player hero = new Player("Zara", 30);
        GameManager gm = new GameManager();
        SaveSystem save = new SaveSystem();
        AchievementSystem achievements = new AchievementSystem();

        // Subscribe to the event
        hero.Died += gm.HandlePlayerDied;
        hero.Died += save.HandlePlayerDied;
        hero.Died += achievements.HandlePlayerDied;

        Console.WriteLine("Battle starts!");
        hero.TakeDamage(20);
        hero.TakeDamage(15); // This triggers the event
    }
}
