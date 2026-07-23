# Day 67: Game Manager Class

## 📚 Concept
A central singleton class that controls game flow: starts the game, manages turns, checks win/lose, and coordinates all game objects.

## 💻 My Code
```csharp
using System;
using System.Collections.Generic;

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

    private Player _player;
    private List&lt;Enemy&gt; _enemies;
    private bool _gameOver;

    private GameManager() { _enemies = new List&lt;Enemy&gt;(); }

    public void StartGame()
    {
        _player = new Player("Hero", 100);
        _enemies.Add(new Goblin("Skitter"));
        _enemies.Add(new Orc("Gruk"));
    }

    public void PlayerAttack(int enemyIndex)
    {
        if (_gameOver) return;
        Enemy target = _enemies[enemyIndex];
        target.TakeDamage(20);
        if (!target.IsAlive()) _enemies.RemoveAt(enemyIndex);
        CheckWinCondition();
        if (!_gameOver) EnemyTurn();
    }

    private void EnemyTurn()
    {
        foreach (Enemy e in _enemies)
        {
            e.Attack();
            _player.TakeDamage(e.damage);
        }
        CheckLoseCondition();
    }

    private void CheckWinCondition()
    {
        if (_enemies.Count == 0) _gameOver = true;
    }

    private void CheckLoseCondition()
    {
        if (_player.Health &lt;= 0) _gameOver = true;
    }

    public bool IsGameOver() { return _gameOver; }
}
