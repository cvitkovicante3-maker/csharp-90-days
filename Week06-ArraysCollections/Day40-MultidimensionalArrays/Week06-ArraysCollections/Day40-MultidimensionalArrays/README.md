# Day 40: Multidimensional Arrays

## 📚 Concept
A 2D array uses two indexes: `[row, column]`. Perfect for grids, boards, and tile maps.

## 💻 My Code
```csharp
using System;

class Program
{
    static void Main()
    {
        int[,] board = new int[3, 3];
        board[0, 0] = 1;
        board[1, 1] = 1;
        board[2, 2] = 2;

        Console.WriteLine("Game board:");
        for (int row = 0; row &lt; board.GetLength(0); row++)
        {
            for (int col = 0; col &lt; board.GetLength(1); col++)
            {
                Console.Write(board[row, col] + " ");
            }
            Console.WriteLine();
        }

        string[,] map = {
            { "Grass", "Water" },
            { "Tree", "Stone" }
        };
        Console.WriteLine("Map tile at [0,1]: " + map[0, 1]);
    }
}
