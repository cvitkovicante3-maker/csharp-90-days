using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== MONOBEHAVIOUR LIFECYCLE ===\n");

        Console.WriteLine("1. AWAKE()");
        Console.WriteLine("   - Runs once when script loads");
        Console.WriteLine("   - Use for: internal setup, caching references");
        Console.WriteLine("   - Runs even if script is disabled\n");

        Console.WriteLine("2. START()");
        Console.WriteLine("   - Runs once before first frame");
        Console.WriteLine("   - Use for: initialization that needs other objects ready");
        Console.WriteLine("   - Only runs if script is enabled\n");

        Console.WriteLine("3. UPDATE()");
        Console.WriteLine("   - Runs EVERY FRAME");
        Console.WriteLine("   - Use for: input, movement, visual updates");
        Console.WriteLine("   - 60 FPS = 60 calls per second\n");

        Console.WriteLine("4. FIXEDUPDATE()");
        Console.WriteLine("   - Runs at fixed time interval (default 0.02s = 50Hz)");
        Console.WriteLine("   - Use for: physics, Rigidbody movement");
        Console.WriteLine("   - Consistent timing, not tied to frame rate\n");

        Console.WriteLine("5. LATEUPDATE()");
        Console.WriteLine("   - Runs after all Update() calls");
        Console.WriteLine("   - Use for: camera follow (after player moved)\n");

        Console.WriteLine("6. ONENABLE() / ONDISABLE()");
        Console.WriteLine("   - When object/script is toggled on/off");
        Console.WriteLine("   - Use for: pausing, pooling, event subscriptions\n");

        Console.WriteLine("7. ONDESTROY()");
        Console.WriteLine("   - When object is destroyed");
        Console.WriteLine("   - Use for: cleanup, saving, unsubscribing events\n");

        Console.WriteLine("\n=== ORDER SUMMARY ===");
        Console.WriteLine("Awake → OnEnable → Start → FixedUpdate → Update → LateUpdate → OnDisable → OnDestroy");
    }
}
