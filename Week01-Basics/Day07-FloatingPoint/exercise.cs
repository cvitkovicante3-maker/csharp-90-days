using System;

class Program
{
    static void Main()
    {
        float health = 100.0f;
        float damage = 23.5f;
        
        health = health - damage;
        Console.WriteLine("Health: " + health);
    }
}
