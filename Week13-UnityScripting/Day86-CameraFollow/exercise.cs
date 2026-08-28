using System;

// Simulating Unity camera follow in console

class Camera
{
    public float X { get; private set; }
    public float Y { get; private set; }
    public float Z { get; private set; }

    // Offset from target
    public float OffsetX { get; set; } = 0f;
    public float OffsetY { get; set; } = 5f;
    public float OffsetZ { get; set; } = -10f;

    // Smoothing (0 = instant, 1 = no movement)
    public float SmoothSpeed { get; set; } = 0.1f;

    public void SnapToTarget(float targetX, float targetY, float targetZ)
    {
        X = targetX + OffsetX;
        Y = targetY + OffsetY;
        Z = targetZ + OffsetZ;
    }

    public void SmoothFollow(float targetX, float targetY, float targetZ)
    {
        float desiredX = targetX + OffsetX;
        float desiredY = targetY + OffsetY;
        float desiredZ = targetZ + OffsetZ;

        // Lerp = linear interpolation
        X += (desiredX - X) * SmoothSpeed;
        Y += (desiredY - Y) * SmoothSpeed;
        Z += (desiredZ - Z) * SmoothSpeed;
    }

    public void ShowPosition() => Console.WriteLine($"Camera: ({X:F2}, {Y:F2}, {Z:F2})");
}

class Player
{
    public float X { get; set; }
    public float Y { get; set; } = 0f;
    public float Z { get; set; }

    public void Move(float dx, float dz)
    {
        X += dx;
        Z += dz;
    }

    public void ShowPosition() => Console.WriteLine($"Player: ({X:F2}, {Y:F2}, {Z:F2})");
}

class Program
{
    static void Main()
    {
        Player player = new Player();
        Camera snapCam = new Camera();
        Camera smoothCam = new Camera { SmoothSpeed = 0.1f };

        Console.WriteLine("=== CAMERA FOLLOW DEMO ===\n");

        // Initial position
        player.Move(5, 5);
        snapCam.SnapToTarget(player.X, player.Y, player.Z);
        smoothCam.SnapToTarget(player.X, player.Y, player.Z); // start at same spot

        Console.WriteLine("Initial:");
        player.ShowPosition();
        snapCam.ShowPosition();
        smoothCam.ShowPosition();

        // Player moves, cameras follow differently
        Console.WriteLine("\n--- Player moves to (20, 0, 20) ---\n");

        for (int step = 0; step < 10; step++)
        {
            player.Move(1.5f, 1.5f);

            snapCam.SnapToTarget(player.X, player.Y, player.Z);
            smoothCam.SmoothFollow(player.X, player.Y, player.Z);

            Console.WriteLine($"Step {step + 1}:");
            player.ShowPosition();
            snapCam.ShowPosition();
            smoothCam.ShowPosition();
            Console.WriteLine();
        }
    }
}
