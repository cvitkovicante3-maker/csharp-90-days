using System;

// Simulating Unity health system

class HealthSystem
{
    public float Current { get; private set; }
    public float Max { get; private set; }
    public bool IsAlive => Current > 0;
    public bool IsInvulnerable { get; private set; }

    private float _invulnerableTimer;

    public event Action OnDamaged;
    public event Action OnHealed;
    public event Action OnDied;

    public HealthSystem(float maxHealth)
    {
        Max = maxHealth;
        Current = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        if (IsInvulnerable || !IsAlive) return;

        Current = Math.Max(0, Current - amount);
        OnDamaged?.Invoke();

        Console.WriteLine($"Took {amount} damage. HP: {Current}/{Max}");

        if (!IsAlive)
        {
            OnDied?.Invoke();
            Console.WriteLine("DIED!");
        }
        else
        {
            SetInvulnerable(0.5f); // i-frames after hit
        }
    }

    public void Heal(float amount)
    {
        if (!IsAlive) return;

        float oldHealth = Current;
        Current = Math.Min(Max, Current + amount);
        float healed = Current - oldHealth;

        if (healed > 0)
        {
            OnHealed?.Invoke();
            Console.WriteLine($"Healed {healed}. HP: {Current}/{Max}");
        }
    }

    public void SetInvulnerable(float duration)
    {
        IsInvulnerable = true;
        _invulnerableTimer = duration;
        Console.WriteLine($"Invulnerable for {duration}s");
    }

    public void Update(float deltaTime)
    {
        if (_invulnerableTimer > 0)
        {
            _invulnerableTimer -= deltaTime;
            if (_invulnerableTimer <= 0)
            {
                IsInvulnerable = false;
                Console.WriteLine("Vulnerable again");
            }
        }
    }

    public float GetPercent() => Current / Max;
}

class DamageSource
{
    public string Name { get; set; }
    public float BaseDamage { get; set; }
    public bool CanCrit { get; set; }
    public float CritMultiplier { get; set; } = 2f;

    private Random _random = new Random();

    public float CalculateDamage()
    {
        float damage = BaseDamage;
        if (CanCrit && _random.NextDouble() < 0.2) // 20% crit chance
        {
            damage *= CritMultiplier;
            Console.WriteLine($"CRITICAL! {damage} damage!");
        }
        return damage;
    }
}

class Program
{
    static void Main()
    {
        HealthSystem playerHealth = new HealthSystem(100);
        DamageSource sword = new DamageSource { Name = "Sword", BaseDamage = 15, CanCrit = true };
        DamageSource fire = new DamageSource { Name = "Fire", BaseDamage = 5, CanCrit = false };

        Console.WriteLine("=== HEALTH & DAMAGE DEMO ===\n");

        // Subscribe to events
        playerHealth.OnDamaged += () => Console.WriteLine("[EVENT] Damaged!");
        playerHealth.OnDied += () => Console.WriteLine("[EVENT] Died!");

        float deltaTime = 1f / 60f;

        // Take damage over time
        for (int i = 0; i < 300; i++)
        {
            playerHealth.Update(deltaTime);

            // Hit every 60 frames
            if (i % 60 == 0 && playerHealth.IsAlive)
            {
                float damage = sword.CalculateDamage();
                playerHealth.TakeDamage(damage);
            }

            // Fire damage every 30 frames
            if (i % 30 == 0 && playerHealth.IsAlive && i > 0)
            {
                playerHealth.TakeDamage(fire.CalculateDamage());
            }

            // Heal at frame 150
            if (i == 150 && playerHealth.IsAlive)
            {
                playerHealth.Heal(25);
            }
        }

        Console.WriteLine($"\nFinal: {playerHealth.Current}/{playerHealth.Max} ({playerHealth.GetPercent():P0})");
    }
}
