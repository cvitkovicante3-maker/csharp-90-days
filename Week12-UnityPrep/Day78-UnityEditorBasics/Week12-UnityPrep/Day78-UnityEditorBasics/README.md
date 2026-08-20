# Day 78: Unity Editor Basics

## 📚 Concept
Learn the Unity Editor layout and core concepts: GameObjects, Components, Scenes, Prefabs, and the main panels.

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== UNITY EDITOR PANELS ===");
        Console.WriteLine("Scene View     - Build and edit your world");
        Console.WriteLine("Game View      - See what the player sees");
        Console.WriteLine("Hierarchy      - All objects in current scene");
        Console.WriteLine("Project        - All files and assets");
        Console.WriteLine("Inspector      - Properties of selected object");
        Console.WriteLine("Console        - Debug messages and errors");
        Console.WriteLine("Toolbar        - Play, pause, step buttons");

        Console.WriteLine("\n=== KEY CONCEPTS ===");
        Console.WriteLine("GameObject  - Any object in the scene");
        Console.WriteLine("Component   - Behavior attached to GameObjects");
        Console.WriteLine("Transform   - Position, rotation, scale");
        Console.WriteLine("Prefab      - Reusable GameObject template");
        Console.WriteLine("Scene       - A level or screen");
        Console.WriteLine("Asset       - Any file in the Project panel");
    }
}
