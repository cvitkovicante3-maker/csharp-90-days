using System;

class Program
{
    static void Main()
    {
        int choice = 0;

        // Menu that shows at least once
        do
        {
            Console.WriteLine("=== GAME MENU ===");
            Console.WriteLine("1. Start Game");
            Console.WriteLine("2. Load Game");
            Console.WriteLine("3. Quit");
            Console.WriteLine("=================");

            // Simulate user picking "Quit" (3)
            choice = 3;
            Console.WriteLine("You selected: " + choice);
        }
        while (choice != 3);

        Console.WriteLine("Goodbye!");

        // Another example: roll a die until we get a 6
        Random random = new Random();
        int roll;
        
        do
        {
            roll = random.Next(1, 7); // 1 to 6
            Console.WriteLine("Rolled: " + roll);
        }
        while (roll != 6);

        Console.WriteLine("You rolled a 6! Lucky!");
    }
}
