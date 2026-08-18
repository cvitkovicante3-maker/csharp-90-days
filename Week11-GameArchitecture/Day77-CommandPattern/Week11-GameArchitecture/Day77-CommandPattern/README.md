# Day 77: Command Pattern

## 📚 Concept
Turn actions into objects. Commands encapsulate a request, allowing queuing, undo, and replay. Separates what is done from who does it.

## 💻 My Code
```csharp
using System;
using System.Collections.Generic;

interface ICommand
{
    void Execute();
    void Undo();
}

class Player
{
    public int X { get; set; }
    public int Y { get; set; }
    public void Move(int dx, int dy) { X += dx; Y += dy; }
}

class MoveCommand : ICommand
{
    private Player _player;
    private int _dx, _dy;
    public MoveCommand(Player p, int dx, int dy) { _player = p; _dx = dx; _dy = dy; }
    public void Execute() =&gt; _player.Move(_dx, _dy);
    public void Undo() =&gt; _player.Move(-_dx, -_dy);
}

class InputHandler
{
    private Stack&lt;ICommand&gt; _history = new();
    public void ExecuteCommand(ICommand cmd) { cmd.Execute(); _history.Push(cmd); }
    public void UndoLast() { if (_history.Count &gt; 0) _history.Pop().Undo(); }
}
