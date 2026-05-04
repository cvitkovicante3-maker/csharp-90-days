using System;

class Program
{
    static void Main()
    {
        // Draw a 3x3 grid of asterisks
        for (int row = 1; row <= 3; row++)
        {
            for (int col = 1; col <= 3; col++)
            {
                Console.Write("* ");
            }
            Console.WriteLine(); // new line after each row
        }

        Console.WriteLine("---");

        // Number grid: rows and columns numbered
        for (int row = 1; row <= 3; row++)
        {
            for (int col = 1; col <= 3; col++)
            {
                Console.Write("(" + row + "," + col + ") ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("---");

        // Multiplication table 1-3
        for (int i = 1; i <= 3; i++)
        {
            for (int j = 1; j <= 3; j++)
            {
                Console.Write(i * j + "\t");
            }
            Console.WriteLine();
        }
    }
}
