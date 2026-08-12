# Day 72: State Machines

## 📚 Concept
A state machine tracks what state something is in and controls valid transitions. Prevents invalid states and replaces messy boolean flags.

## 💻 My Code
```csharp
using System;

enum GameState { Menu, Playing, Paused, GameOver }

class GameStateMachine
{
    private GameState _currentState;

    public GameStateMachine() { _currentState = GameState.Menu; }

    public void StartGame()
    {
        if (_currentState == GameState.Menu)
            _currentState = GameState.Playing;
    }

    public void Pause()
    {
        if (_currentState == GameState.Playing)
            _currentState = GameState.Paused;
    }

    public void Resume()
    {
        if (_currentState == GameState.Paused)
            _currentState = GameState.Playing;
    }

    public void GameOver()
    {
        if (_currentState == GameState.Playing || _currentState == GameState.Paused)
            _currentState = GameState.GameOver;
    }
}
