using System;

class Program
{
    static void Main()
    {
        int score = 75;
        
        if (score >= 90)
        {
            Console.WriteLine("Rank: S");
        }
        else if (score >= 70)
        {
            Console.WriteLine("Rank: A");
        }
        else if (score >= 50)
        {
            Console.WriteLine("Rank: B");
        }
        else
        {
            Console.WriteLine("Rank: C");
        }
    }
}
