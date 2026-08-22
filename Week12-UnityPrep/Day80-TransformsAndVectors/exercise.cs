using System;

// Simulating Unity's Vector3 and Transform in console
struct Vector3
{
    public float x;
    public float y;
    public float z;

    public Vector3(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    // Vector addition
    public static Vector3 operator +(Vector3 a, Vector3 b)
    {
        return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
    }

    // Scalar multiplication
    public static Vector3 operator *(Vector3 v, float scalar)
    {
        return new Vector3(v.x * scalar, v.y * scalar, v.z * scalar);
    }

    public float Magnitude()
    {
        return MathF.Sqrt(x * x + y * y + z * z);
    }

    public override string ToString()
    {
        return $"({x}, {y}, {z})";
    }
}

class Transform
{
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;

    public Transform()
    {
        position = new Vector3(0, 0, 0);
        rotation = new Vector3(0, 0, 0);
        scale = new Vector3(1, 1, 1);
    }

    public void Translate(Vector3 direction)
    {
        position = position + direction;
    }

    public float DistanceTo(Transform other)
    {
        float dx = position.x - other.position.x;
        float dy = position.y - other.position.y;
        float dz = position.z - other.position.z;
        return MathF.Sqrt(dx * dx + dy * dy + dz * dz);
    }

    public void Show()
    {
        Console.WriteLine($"Position: {position}");
        Console.WriteLine($"Rotation: {rotation}");
        Console.WriteLine($"Scale: {scale}");
    }
}

class Program
{
    static void Main()
    {
        Transform player = new Transform();
        Transform enemy = new Transform();

        Console.WriteLine("=== INITIAL ===");
        player.Show();

        Console.WriteLine("\n=== MOVE PLAYER ===");
        player.Translate(new Vector3(5, 0, 3));
        player.Show();

        Console.WriteLine("\n=== MOVE ENEMY ===");
        enemy.Translate(new Vector3(10, 0, 0));
        enemy.Show();

        Console.WriteLine("\n=== DISTANCE ===");
        Console.WriteLine($"Distance: {player.DistanceTo(enemy)}");

        Console.WriteLine("\n=== DIRECTION VECTOR ===");
        Vector3 direction = new Vector3(1, 0, 0); // right
        Vector3 movement = direction * 2f; // move 2 units right
        Console.WriteLine($"Direction: {direction}");
        Console.WriteLine($"Movement: {movement}");
        Console.WriteLine($"Magnitude: {movement.Magnitude()}");
    }
}
