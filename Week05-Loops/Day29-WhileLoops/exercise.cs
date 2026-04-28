using System;

class Program
{
    static void Main()
    {
        int health = 30;

        // While health is below 100, regenerate 10 each tick
        while (health < 100)
        {
            health = health + 10;
            Console.WriteLine("Healing... Health is now: " + health);
        }

        Console.WriteLine("Health is full!");

        // Countdown example
        int countdown = 3;
        while (countdown > 0)
        {
            Console.WriteLine("Starting in: " + countdown);
            countdown = countdown - 1;
        }
        Console.WriteLine("Go!");
    }
}
