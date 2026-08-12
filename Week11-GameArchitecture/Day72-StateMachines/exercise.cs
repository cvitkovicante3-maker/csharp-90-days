using System;

// Define possible states
enum GameState
{
    Menu,
    Playing,
    Paused,
    GameOver
}

class GameStateMachine
{
    private GameState _currentState;

    public GameStateMachine()
    {
        _currentState = GameState.Menu;
        ShowState();
    }

    public void StartGame()
    {
        if (_currentState == GameState.Menu)
        {
            _currentState = GameState.Playing;
            Console.WriteLine("Game started!");
        }
        else
        {
            Console.WriteLine("Can't start from " + _currentState);
        }
        ShowState();
    }

    public void Pause()
    {
        if (_currentState == GameState.Playing)
        {
            _currentState = GameState.Paused;
            Console.WriteLine("Game paused.");
        }
        else
        {
            Console.WriteLine("Can't pause from " + _currentState);
        }
        ShowState();
    }

    public void Resume()
    {
        if (_currentState == GameState.Paused)
        {
            _currentState = GameState.Playing;
            Console.WriteLine("Game resumed.");
        }
        else
        {
            Console.WriteLine("Can't resume from " + _currentState);
        }
        ShowState();
    }

    public void GameOver()
    {
        if (_currentState == GameState.Playing || _currentState == GameState.Paused)
        {
            _currentState = GameState.GameOver;
            Console.WriteLine("Game over!");
        }
        else
        {
            Console.WriteLine("Can't end from " + _currentState);
        }
        ShowState();
    }

    public void ReturnToMenu()
    {
        if (_currentState == GameState.GameOver)
        {
            _currentState = GameState.Menu;
            Console.WriteLine("Returned to menu.");
        }
        else
        {
            Console.WriteLine("Can't return to menu from " + _currentState);
        }
        ShowState();
    }

    private void ShowState()
    {
        Console.WriteLine("[Current State: " + _currentState + "]\n");
    }
}

class Program
{
    static void Main()
    {
        GameStateMachine game = new GameStateMachine();

        game.StartGame();      // Menu → Playing
        game.Pause();          // Playing → Paused
        game.Resume();         // Paused → Playing
        game.GameOver();       // Playing → GameOver
        game.ReturnToMenu();   // GameOver → Menu

        Console.WriteLine("--- Invalid transitions ---");
        game.Pause();          // Can't pause from Menu
        game.Resume();         // Can't resume from Menu
    }
}
