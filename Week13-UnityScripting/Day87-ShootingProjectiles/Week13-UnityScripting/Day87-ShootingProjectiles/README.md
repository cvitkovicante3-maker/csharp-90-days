# Day 87: Shooting Projectiles

## 📚 Concept
Create projectile objects with velocity, update their position each frame, detect hits, and clean up expired projectiles. Use fire rate cooldowns and object pooling for performance.

## 💻 My Code
```csharp
using System;
using System.Collections.Generic;

class Projectile
{
    public string Name { get; set; }
    public float X, Y, Z;
    public float Speed { get; set; }
    public float Damage { get; set; }
    public float Lifetime { get; set; } = 2f;
    private float _age;
    public float DirectionX { get; private set; }
    public float DirectionZ { get; private set; }

    public void Launch(float sx, float sy, float sz, float dx, float dz)
    {
        X = sx; Y = sy; Z = sz; _age = 0;
        float mag = MathF.Sqrt(dx * dx + dz * dz);
        DirectionX = dx / mag; DirectionZ = dz / mag;
    }

    public void Update(float deltaTime)
    {
        X += DirectionX * Speed * deltaTime;
        Z += DirectionZ * Speed * deltaTime;
        _age += deltaTime;
    }

    public bool IsExpired() =&gt; _age &gt;= Lifetime;
    public float DistanceTo(float tx, float tz) { /* calculate */ return 0; }
}

class Weapon
{
    public string Name { get; set; }
    public float FireRate { get; set; }
    public float ProjectileSpeed { get; set; }
    public float Damage { get; set; }
    private float _cooldown;

    public bool CanFire() =&gt; _cooldown &lt;= 0;
    public void Update(float dt) { if (_cooldown &gt; 0) _cooldown -= dt; }

    public Projectile Fire(float fx, float fy, float fz, float ax, float az)
    {
        if (!CanFire()) return null;
        _cooldown = 1f / FireRate;
        Projectile p = new Projectile { Name = Name + "_Projectile", Speed = ProjectileSpeed, Damage = Damage };
        p.Launch(fx, fy, fz, ax, az);
        return p;
    }
}
