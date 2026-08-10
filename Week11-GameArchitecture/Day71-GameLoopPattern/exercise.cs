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
        _frameCount = 0;

        Console.WriteLine("=== GAME STARTED ===");
        Console.WriteLine("Press 'd' to move right, 'q' to quit");

        // The game loop
        while (_running)
        {
            ProcessInput();
            Update();
            Render();

            // Cap at ~10 FPS for console demo
            Thread.Sleep(100);
            _frameCount++;
        }

        Console.WriteLine("=== GAME OVER ===");
        Console.WriteLine("Total frames: " + _frameCount);
    }

    private void ProcessInput()
    {
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.D:
                    _playerX++;
                    break;
                case ConsoleKey.A:
                    _playerX = Math.Max(0, _playerX - 1);
                    break;
                case ConsoleKey.Q:
                    _running = false;
                    break;
            }
        }
    }

    private void Update()
    {
        // Game logic goes here
        // Check collisions, update AI, apply physics
    }

    private void Render()
    {
        Console.Clear();
        Console.WriteLine("Frame: " + _frameCount);
        Console.WriteLine("Player position: " + _playerX);

        // Draw player as 'P' at position
        for (int i = 0; i < _playerX; i++)
            Console.Write(" ");
        Console.WriteLine("P");

        Console.WriteLine("\n[A] Left  [D] Right  [Q] Quit");
    }
}

class Program
{
    static void Main()
    {
        GameLoop game = new GameLoop();
        game.Start();
    }
}
