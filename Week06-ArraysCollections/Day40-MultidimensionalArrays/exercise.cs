using System;

class Program
{
    static void Main()
    {
        // Create a 3x3 game board
        // Rows = 3, Columns = 3
        int[,] board = new int[3, 3];

        // Place some values
        board[0, 0] = 1; // top-left
        board[1, 1] = 1; // center
        board[2, 2] = 2; // bottom-right

        // Print the board using nested loops
        Console.WriteLine("Game board:");
        for (int row = 0; row < board.GetLength(0); row++)
        {
            for (int col = 0; col < board.GetLength(1); col++)
            {
                Console.Write(board[row, col] + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("---");

        // Create and fill a 2x2 grid directly
        string[,] map = {
            { "Grass", "Water" },
            { "Tree", "Stone" }
        };

        Console.WriteLine("Map tile at [0,1]: " + map[0, 1]);
        Console.WriteLine("Map tile at [1,0]: " + map[1, 0]);
    }
}
