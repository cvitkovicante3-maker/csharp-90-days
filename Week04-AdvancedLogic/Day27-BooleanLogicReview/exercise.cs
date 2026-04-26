using System;

class Program
{
    static void Main()
    {
        bool hasWeapon = true;
        bool hasAmmo = true;
        bool isInvisible = false;
        int health = 20;

        // AND: both must be true
        bool canShoot = hasWeapon && hasAmmo;
        Console.WriteLine("Can shoot: " + canShoot);

        // OR: at least one is true
        bool isVulnerable = !isInvisible || health < 30;
        Console.WriteLine("Is vulnerable: " + isVulnerable);

        // Combine all three
        bool canFight = hasWeapon && hasAmmo && !isInvisible;
        Console.WriteLine("Can fight: " + canFight);

        // Complex: can enter boss room?
        bool hasKey = true;
        bool bossDefeated = false;
        bool canEnterBossRoom = hasKey && !bossDefeated && health > 0;
        Console.WriteLine("Can enter boss room: " + canEnterBossRoom);
    }
}
