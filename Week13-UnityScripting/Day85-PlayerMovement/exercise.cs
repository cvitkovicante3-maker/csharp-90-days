using System;

// Simulating Unity movement in console

class PlayerMovement
{
    public float X { get; private set; }
    public float Z { get; private set; }
    public float Speed { get; set; } = 5f;

    // Simulates Unity's Update with input
    public void Update(string input, float deltaTime)
    {
        float horizontal = 0f;
        float vertical = 0f;

        switch (input)
        {
            case "W": vertical = 1f; break;
            case "S": vertical = -1f; break;
            case "A": horizontal = -1f; break;
            case "D": horizontal = 1f; break;
        }

        // Frame-rate independent movement
        float moveX = horizontal * Speed * deltaTime;
        float moveZ = vertical * Speed * deltaTime;

        X += moveX;
        Z += moveZ;

        if (horizontal != 0 || vertical != 0)
        {
            Console.WriteLine($"Moved to ({X:F2}, {Z:F2}) | Input: {input} | Delta: {deltaTime:F4}");
        }
    }

    public void ShowPosition() => Console.WriteLine($"Final Position: ({X:F2}, {Z:F2})");
}

class Program
{
    static void Main()
    {
        PlayerMovement player = new PlayerMovement();

        Console.WriteLine("=== PLAYER MOVEMENT DEMO ===\n");
        Console.WriteLine("Simulating 60 FPS gameplay\n");

        // Simulate holding W for 1 second at 60 FPS
        string[] inputs = { "W", "W", "W", "W", "W", "W", "W", "W", "W", "W",
                            "W", "W", "W", "W", "W", "W", "W", "W", "W", "W",
                            "W", "W", "W", "W", "W", "W", "W", "W", "W", "W",
                            "W", "W", "W", "W", "W", "W", "W", "W", "W", "W",
                            "W", "W", "W", "W", "W", "W", "W", "W", "W", "W",
                            "W", "W", "W", "W", "W", "W", "W", "W", "W", "W" };

        float deltaTime = 1f / 60f; // 60 FPS

        foreach (string input in inputs)
        {
            player.Update(input, deltaTime);
        }

        player.ShowPosition();

        Console.WriteLine("\n--- Now with sprint (hold Shift) ---");
        player = new PlayerMovement { Speed = 10f }; // sprint speed

        foreach (string input in inputs)
        {
            player.Update(input, deltaTime);
        }

        player.ShowPosition();
    }
}
