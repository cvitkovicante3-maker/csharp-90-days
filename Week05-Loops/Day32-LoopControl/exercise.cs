using System;

class Program
{
    static void Main()
    {
        // break: stop early when target is found
        for (int room = 1; room <= 10; room++)
        {
            Console.WriteLine("Searching room " + room);

            if (room == 4)
            {
                Console.WriteLine("Key found! Stopping search.");
                break; // exits the loop immediately
            }
        }

        Console.WriteLine("---");

        // continue: skip even-numbered waves
        for (int wave = 1; wave <= 5; wave++)
        {
            if (wave == 2 || wave == 4)
            {
                Console.WriteLine("Wave " + wave + " skipped (recharging)");
                continue; // jumps to next wave
            }

            Console.WriteLine("Fighting wave " + wave);
        }
    }
}
