using System;

class Program
{
    static void Main()
    {
        bool hasKey = false;
        bool hasLockpick = true;
        
        if (hasKey || hasLockpick)
        {
            Console.WriteLine("Door unlocked!");
        }
    }
}
