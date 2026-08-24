# Day 82: Physics & Collisions

## 📚 Concept
Rigidbody makes objects physical. Colliders define shape for collisions. Triggers detect overlap. Forces move objects. Collision methods respond to contacts.

## 💻 My Code
```csharp
using System;

class PhysicsObject
{
    public float Position { get; private set; }
    public float Velocity { get; private set; }
    private float _gravity = -20f;

    public PhysicsObject(float h) { Position = h; }
    public void Jump(float f) { if (IsGrounded()) Velocity = f; }
    public bool IsGrounded() =&gt; Position &lt;= 0.01f;

    public void FixedUpdate(float dt)
    {
        Velocity += _gravity * dt;
        Position += Velocity * dt;
        if (Position &lt; 0) { Position = 0; Velocity = 0; }
    }
}
