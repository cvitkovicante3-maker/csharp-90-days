# Day 86: Camera Follow

## 📚 Concept
Keep camera positioned relative to player. Snap for instant, SmoothFollow with lerp for gradual movement. Offset maintains viewing angle.

## 💻 My Code
```csharp
using System;

class Camera
{
    public float X, Y, Z;
    public float OffsetX, OffsetY = 5f, OffsetZ = -10f;
    public float SmoothSpeed = 0.1f;

    public void SnapToTarget(float tx, float ty, float tz)
    {
        X = tx + OffsetX;
        Y = ty + OffsetY;
        Z = tz + OffsetZ;
    }

    public void SmoothFollow(float tx, float ty, float tz)
    {
        X += ((tx + OffsetX) - X) * SmoothSpeed;
        Y += ((ty + OffsetY) - Y) * SmoothSpeed;
        Z += ((tz + OffsetZ) - Z) * SmoothSpeed;
    }
}
