using System;
using System.Collections.Generic;

// --- COMMAND INTERFACE ---
interface ICommand
{
    void Execute();
    void Undo();
}

// --- RECEIVER (the thing being controlled) ---
class Player
{
    public int X { get; set; }
    public int Y { get; set; }

    public void Move(int dx, int dy)
    {
        X += dx;
        Y += dy;
        Console.WriteLine($"Player moved to ({X}, {Y})");
    }

    public void ShowPosition() => Console.WriteLine($"Position: ({X}, {Y})");
}

// --- CONCRETE COMMANDS ---
class MoveCommand : ICommand
{
    private Player _player;
    private int _dx;
    private int _dy;

    public MoveCommand(Player player, int dx, int dy)
    {
        _player = player;
        _dx = dx;
        _dy = dy;
    }

    public void Execute()
    {
        _player.Move(_dx, _dy);
    }

    public void Undo()
    {
        _player.Move(-_dx, -_dy);
        Console.WriteLine("Move undone!");
    }
}

class AttackCommand : ICommand
{
    private string _target;

    public AttackCommand(string target)
    {
        _target = target;
    }

    public void Execute()
    {
        Console.WriteLine($"Attacking {_target}!");
    }

    public void Undo()
    {
        Console.WriteLine($"Healed {_target} (attack undone)!");
    }
}

// --- INVOKER (the thing that triggers commands) ---
class InputHandler
{
    private Stack<ICommand> _history = new();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _history.Push(command);
    }

    public void UndoLast()
    {
        if (_history.Count > 0)
        {
            ICommand last = _history.Pop();
            last.Undo();
        }
        else
        {
            Console.WriteLine("Nothing to undo.");
        }
    }

    public void ShowHistory() => Console.WriteLine($"Commands in history: {_history.Count}");
}

class Program
{
    static void Main()
    {
        Player player = new Player();
        InputHandler input = new InputHandler();

        Console.WriteLine("=== COMMAND PATTERN DEMO ===\n");

        // Execute commands
        input.ExecuteCommand(new MoveCommand(player, 5, 0));
        input.ExecuteCommand(new MoveCommand(player, 0, 3));
        input.ExecuteCommand(new AttackCommand("Goblin"));

        Console.WriteLine("\n--- Undoing ---");
        input.UndoLast(); // Undo attack
        input.UndoLast(); // Undo move up
        input.UndoLast(); // Undo move right
        input.UndoLast(); // Nothing to undo

        player.ShowPosition();
    }
}
