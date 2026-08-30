# Day 88: Health & Damage

## 📚 Concept
HealthSystem tracks current/max health, handles damage with invulnerability frames, healing, events, and death. DamageSource calculates damage with crits and types.

## 💻 My Code
```csharp
using System;

class HealthSystem
{
    public float Current { get; private set; }
    public float Max { get; private set; }
    public bool IsAlive =&gt; Current &gt; 0;
    public bool IsInvulnerable { get; private set; }

    public event Action OnDamaged;
    public event Action OnHealed;
    public event Action OnDied;

    public HealthSystem(float max) { Max = max; Current = max; }

    public void TakeDamage(float amount)
    {
        if (IsInvulnerable || !IsAlive) return;
        Current = Math.Max(0, Current - amount);
        OnDamaged?.Invoke();
        if (!IsAlive) OnDied?.Invoke();
        else SetInvulnerable(0.5f);
    }

    public void Heal(float amount)
    {
        if (!IsAlive) return;
        Current = Math.Min(Max, Current + amount);
        OnHealed?.Invoke();
    }

    public void Update(float dt)
    {
        // invulnerability timer logic
    }
}
