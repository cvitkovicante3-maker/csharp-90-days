using System;

class GameManager
{
    // The single instance
    private static GameManager _instance;

    // Public access point
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameManager();
                Console.WriteLine("GameManager created.");
            }
            return _instance;
        }
    }

    // Private constructor prevents external creation
    private GameManager()
    {
        Score = 0;
        Level = 1;
    }

    // Game data
    public int Score { get; private set; }
    public int Level { get; private set; }

    public void AddScore(int points)
    {
        Score += points;
        Console.WriteLine($"Score: {Score}");
    }

    public void NextLevel()
    {
        Level++;
        Console.WriteLine($"Level: {Level}");
    }

    public void ShowStatus()
    {
        Console.WriteLine($"=== Game Status ===");
        Console.WriteLine($"Score: {Score}");
        Console.WriteLine($"Level: {Level}");
        Console.WriteLine($"===================");
    }
}

class Program
{
    static void Main()
    {
        // Both lines return the SAME instance
        GameManager gm1 = GameManager.Instance;
        gm1.AddScore(100);
        gm1.NextLevel();

        GameManager gm2 = GameManager.Instance;
        gm2.AddScore(50);

        // Prove they're the same object
        Console.WriteLine($"\nSame object? {ReferenceEquals(gm1, gm2)}");

        gm1.ShowStatus();
    }
}
