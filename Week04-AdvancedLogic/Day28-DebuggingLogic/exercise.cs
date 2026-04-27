using System;

class Program
{
    static void Main()
    {
        int playerLevel = 5;
        bool hasQuestItem = true;

        // BUG 1: Should let player enter at level 5 or higher
        // Fix: change > to >=
        if (playerLevel > 5)
        {
            Console.WriteLine("Entering dungeon...");
        }
        else
        {
            Console.WriteLine("Level too low.");
        }

        // DEBUG: Print values to see what's happening
        Console.WriteLine("DEBUG - playerLevel: " + playerLevel);
        Console.WriteLine("DEBUG - hasQuestItem: " + hasQuestItem);

        // BUG 2: Should enter if level >= 5 AND has quest item
        // Fix: change || to &&
        if (playerLevel >= 5 || hasQuestItem)
        {
            Console.WriteLine("Quest accepted.");
        }
        else
        {
            Console.WriteLine("Cannot start quest.");
        }

        // BUG 3: Should be "Ready" when health is above 0
        int health = 0;
        string status = health > 0 ? "Ready" : "Dead";
        Console.WriteLine("Status: " + status);
        // Fix: check if this matches what you expect
    }
}
