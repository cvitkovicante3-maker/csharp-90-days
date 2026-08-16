# Day 75: Singleton Pattern

## 📚 Concept
Ensure only one instance of a class exists. Provide global access through a static property. Private constructor blocks external creation.

## 💻 My Code
```csharp
using System;

class GameManager
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null) _instance = new GameManager();
            return _instance;
        }
    }

    private GameManager() { Score = 0; Level = 1; }

    public int Score { get; private set; }
    public int Level { get; private set; }

    public void AddScore(int points) { Score += points; }
    public void NextLevel() { Level++; }
}
