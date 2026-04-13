using System;

class Program
{
    static void Main()
    {
        int score = 100;
        int highScore = 100;
        
        bool isEqual = (score == highScore);
        Console.WriteLine($"Tied record? {isEqual}");
    }
}
