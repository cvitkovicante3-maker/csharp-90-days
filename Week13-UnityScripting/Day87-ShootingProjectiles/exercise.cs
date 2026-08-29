using System;
using System.Collections.Generic;

// Simulating Unity projectile system

class Projectile
{
    public string Name { get; set; }
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }
    public float Speed { get; set; }
    public float Damage { get; set; }
    public float Lifetime { get; set; } = 2f;
    private float _age;

    public Projectile(string name, float speed, float damage)
    {
        Name = name;
        Speed = speed;
        Damage = damage;
    }

    public void Launch(float startX, float startY, float startZ, float directionX, float directionZ)
    {
        X = startX;
        Y = startY;
        Z = startZ;
        _age = 0;

        // Normalize direction
        float magnitude = MathF.Sqrt(directionX * directionX + directionZ * directionZ);
        DirectionX = directionX / magnitude;
        DirectionZ = directionZ / magnitude;

        Console.WriteLine($"Launched {Name} from ({X:F1}, {Z:F1}) toward ({DirectionX:F2}, {DirectionZ:F2})");
    }

    public float DirectionX { get; private set; }
    public float DirectionZ { get; private set; }

    public void Update(float deltaTime)
    {
        X += DirectionX * Speed * deltaTime;
        Z += DirectionZ * Speed * deltaTime;
        _age += deltaTime;
    }

    public bool IsExpired() => _age >= Lifetime;

    public void ShowPosition() => Console.WriteLine($"{Name}: ({X:F2}, {Z:F2}) Age: {_age:F2}");

    public float DistanceTo(float tx, float tz)
    {
        float dx = X - tx;
        float dz = Z - tz;
        return MathF.Sqrt(dx * dx + dz * dz);
    }
}

class Weapon
{
    public string Name { get; set; }
    public float FireRate { get; set; } // shots per second
    public float ProjectileSpeed { get; set; }
    public float Damage { get; set; }
    private float _cooldown;

    public Weapon(string name, float fireRate, float speed, float damage)
    {
        Name = name;
        FireRate = fireRate;
        ProjectileSpeed = speed;
        Damage = damage;
    }

    public bool CanFire() => _cooldown <= 0;

    public Projectile Fire(float fromX, float fromY, float fromZ, float aimX, float aimZ)
    {
        if (!CanFire()) return null;

        _cooldown = 1f / FireRate;
        Projectile p = new Projectile(Name + "_Projectile", ProjectileSpeed, Damage);
        p.Launch(fromX, fromY, fromZ, aimX, aimZ);
        return p;
    }

    public void Update(float deltaTime)
    {
        if (_cooldown > 0) _cooldown -= deltaTime;
    }
}

class Program
{
    static void Main()
    {
        Weapon gun = new Weapon("Pistol", 2f, 20f, 10f);
        List<Projectile> projectiles = new();

        float playerX = 0, playerZ = 0;
        float deltaTime = 1f / 60f;

        Console.WriteLine("=== SHOOTING DEMO ===\n");

        // Fire several shots
        for (int frame = 0; frame < 180; frame++)
        {
            gun.Update(deltaTime);

            // Fire on frame 0, 30, 60 (simulating clicks)
            if (frame == 0 || frame == 30 || frame == 60)
            {
                Projectile p = gun.Fire(playerX, 1f, playerZ, 1f, 0f); // aim right
                if (p != null) projectiles.Add(p);
            }

            // Update all projectiles
            for (int i = projectiles.Count - 1; i >= 0; i--)
            {
                projectiles[i].Update(deltaTime);
                if (projectiles[i].IsExpired())
                {
                    Console.WriteLine($"{projectiles[i].Name} expired.");
                    projectiles.RemoveAt(i);
                }
            }
        }

        Console.WriteLine($"\nRemaining projectiles: {projectiles.Count}");
    }
}
