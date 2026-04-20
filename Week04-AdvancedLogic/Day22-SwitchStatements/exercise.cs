using System;

class Program
{
    static void Main()
    {
        int direction = 2; // 1=North, 2=South, 3=East, 4=West
        
        switch (direction)
        {
            case 1:
                Console.WriteLine("Going North");
                break;
            case 2:
                Console.WriteLine("Going South");
                break;
            case 3:
                Console.WriteLine("Going East");
                break;
            case 4:
                Console.WriteLine("Going West");
                break;
            default:
                Console.WriteLine("Unknown direction");
                break;
        }
    }
}
