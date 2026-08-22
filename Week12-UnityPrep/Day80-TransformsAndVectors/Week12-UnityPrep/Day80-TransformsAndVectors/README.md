# Day 80: Transforms & Vectors

## 📚 Concept
Transform stores position, rotation, scale. Vector3 represents 3D points and directions. Use them to move, rotate, and measure in 3D space.

## 💻 My Code
```csharp
using System;

struct Vector3
{
    public float x, y, z;
    public Vector3(float x, float y, float z) { this.x = x; this.y = y; this.z = z; }
    public static Vector3 operator +(Vector3 a, Vector3 b) =&gt; new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
    public static Vector3 operator *(Vector3 v, float s) =&gt; new Vector3(v.x * s, v.y * s, v.z * s);
    public float Magnitude() =&gt; MathF.Sqrt(x * x + y * y + z * z);
    public override string ToString() =&gt; $"({x}, {y}, {z})";
}

class Transform
{
    public Vector3 position, rotation, scale;
    public Transform() { position = new Vector3(0, 0, 0); scale = new Vector3(1, 1, 1); }
    public void Translate(Vector3 d) { position = position + d; }
    public float DistanceTo(Transform other) { /* calculate distance */ return 0; }
}
