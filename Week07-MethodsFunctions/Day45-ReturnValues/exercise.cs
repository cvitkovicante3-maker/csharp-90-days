using System;

class Program
{
    static void Main()
    {
        // Capture the returned value
        int total = AddNumbers(10, 20);
        Console.WriteLine("Total: " + total);

        // Use the return directly
        Console.WriteLine("Double damage: " + Multiply(15, 2));

        // Chain with other logic
        bool alive = IsAlive(25);
        if (alive)
        {
            Console.WriteLine("Player survives!");
        }
        else
        {
            Console.WriteLine("Game over.");
        }

        string title = GetRankName(3);
        Console.WriteLine("Rank: " + title);
    }

    static int AddNumbers(int a, int b)
    {
        return a + b;
    }

    static int Multiply(int a, int b)
    {
        return a * b;
    }

    static bool IsAlive(int health)
    {
        return health > 0;
    }

    static string GetRankName(int rank)
    {
        if (rank == 1) return "Bronze";
        if (rank == 2) return "Silver";
        if (rank == 3) return "Gold";
        return "Unknown";
    }
}
