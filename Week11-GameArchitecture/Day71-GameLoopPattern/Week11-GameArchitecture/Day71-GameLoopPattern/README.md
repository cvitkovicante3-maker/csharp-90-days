# Day 71: Game Loop Pattern

## 📚 Concept
The game loop continuously runs: ProcessInput → Update → Render. It is the heartbeat of every real-time game.

## 💻 My Code
```csharp
using System;
using System.Threading;

class GameLoop
{
    private bool _running;
    private int _playerX;
    private int _frameCount;

    public void Start()
    {
        _running = true;
        _playerX = 0;

        while (_running)
        {
            ProcessInput();
            Update();
            Render();
            Thread.Sleep(100);
            _frameCount++;
        }
    }

    private void ProcessInput()
    {
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.D) _playerX++;
            if (key == ConsoleKey.A) _playerX = Math.Max(0, _playerX - 1);
            if (key == ConsoleKey.Q) _running = false;
        }
    }

    private void Update() { /* game logic */ }

    private void Render()
    {
        Console.Clear();
        Console.WriteLine("Frame: " + _frameCount);
        for (int i = 0; i &lt; _playerX; i++) Console.Write(" ");
        Console.WriteLine("P");
    }
}
