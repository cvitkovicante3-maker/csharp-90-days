# Day 27: Boolean Logic Review

## 📚 Concept
A recap of `&&` (AND), `||` (OR), and `!` (NOT). Combine multiple conditions into one decision.

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        bool hasWeapon = true;
        bool hasAmmo = true;
        bool isInvisible = false;
        int health = 20;

        bool canShoot = hasWeapon && hasAmmo;
        Console.WriteLine("Can shoot: " + canShoot);

        bool isVulnerable = !isInvisible || health &lt; 30;
        Console.WriteLine("Is vulnerable: " + isVulnerable);

        bool canFight = hasWeapon && hasAmmo && !isInvisible;
        Console.WriteLine("Can fight: " + canFight);

        bool hasKey = true;
        bool bossDefeated = false;
        bool canEnterBossRoom = hasKey && !bossDefeated && health &gt; 0;
        Console.WriteLine("Can enter boss room: " + canEnterBossRoom);
    }
}
