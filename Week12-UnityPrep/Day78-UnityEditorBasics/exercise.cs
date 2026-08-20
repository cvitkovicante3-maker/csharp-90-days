using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== UNITY EDITOR BASICS ===\n");

        // These are the core panels you'll use daily
        string[] panels = {
            "Scene View     - Build and edit your 3D/2D world",
            "Game View      - See what the player sees",
            "Hierarchy      - List of all objects in current scene",
            "Project        - All files: scripts, models, textures, sounds",
            "Inspector      - Properties of selected object",
            "Console        - Errors, warnings, Debug.Log messages",
            "Toolbar        - Play, pause, step buttons"
        };

        foreach (string panel in panels)
        {
            Console.WriteLine("• " + panel);
        }

        Console.WriteLine("\n=== KEY CONCEPTS ===\n");

        Console.WriteLine("GameObject  - Any object in the scene (player, enemy, light, camera)");
        Console.WriteLine("Component   - Behavior attached to GameObjects");
        Console.WriteLine("Transform   - Position, rotation, scale (every GameObject has one)");
        Console.WriteLine("Prefab      - Reusable GameObject template");
        Console.WriteLine("Scene       - A level or screen in your game");
        Console.WriteLine("Asset       - Any file in the Project panel");

        Console.WriteLine("\n=== UNITY C# BASICS ===\n");

        // Unity scripts extend MonoBehaviour
        Console.WriteLine("using UnityEngine;\n");
        Console.WriteLine("public class Player : MonoBehaviour");
        Console.WriteLine("{");
        Console.WriteLine("    void Start() { }  // Runs once when object spawns");
        Console.WriteLine("    void Update() { } // Runs every frame");
        Console.WriteLine("}");
    }
}
