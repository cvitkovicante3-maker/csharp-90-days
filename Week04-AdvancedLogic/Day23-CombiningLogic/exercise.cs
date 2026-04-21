using System;

class Program
{
    static void Main()
    {
        bool isRaining = true;
        bool hasUmbrella = false;
        bool isIndoor = true;
        
        if ((isRaining && hasUmbrella) || isIndoor)
        {
            Console.WriteLine("You stay dry");
        }
    }
}
