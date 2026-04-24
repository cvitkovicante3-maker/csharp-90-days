using System;

class Program
{
    static void Main()
    {
        bool hasKey = true;
        bool doorIsLocked = true;

        if (hasKey)
        {
            Console.WriteLine("You have a key.");

            if (doorIsLocked)
            {
                Console.WriteLine("Door unlocked!");
            }
            else
            {
                Console.WriteLine("Door is already open.");
            }
        }
        else
        {
            Console.WriteLine("You need a key to proceed.");
        }
    }
}
