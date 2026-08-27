# Day 85: Player Movement

## 📚 Concept
Combine input, transform, and deltaTime for smooth frame-rate independent movement. Add jump with gravity for platformer feel.

## 💻 My Code
```csharp
using System;

class PlayerMovement
{
    public float X { get; private set; }
    public float Z { get; private set; }
    public float Speed { get; set; } = 5f;

    public void Update(string input, float deltaTime)
    {
        float horizontal = input == "A" ? -1f : input == "D" ? 1f : 0f;
        float vertical = input == "W" ? 1f : input == "S" ? -1f : 0f;

        X += horizontal * Speed * deltaTime;
        Z += vertical * Speed * deltaTime;
    }
}
