using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== UNITY INPUT HANDLING ===\n");

        Console.WriteLine("--- LEGACY INPUT (Input class) ---");
        Console.WriteLine("Input.GetKey(KeyCode.W)        - Is W held down?");
        Console.WriteLine("Input.GetKeyDown(KeyCode.Space) - Was Space just pressed this frame?");
        Console.WriteLine("Input.GetKeyUp(KeyCode.Escape)  - Was Escape just released?");
        Console.WriteLine("Input.GetAxis(\"Horizontal\")     - A/D or Left/Right stick (-1 to 1)");
        Console.WriteLine("Input.GetAxis(\"Vertical\")       - W/S or Up/Down stick (-1 to 1)");
        Console.WriteLine("Input.GetButtonDown(\"Fire1\")    - Left mouse or Ctrl button\n");

        Console.WriteLine("--- NEW INPUT SYSTEM ---");
        Console.WriteLine("1. Install: Window → Package Manager → Input System");
        Console.WriteLine("2. Create: Input Actions asset");
        Console.WriteLine("3. Generate C# class from asset");
        Console.WriteLine("4. Use generated class in scripts\n");

        Console.WriteLine("--- EXAMPLE: Legacy Movement ---");
        Console.WriteLine(@"
void Update()
{
    float horizontal = Input.GetAxis(""Horizontal"");
    float vertical = Input.GetAxis(""Vertical"");
    
    Vector3 movement = new Vector3(horizontal, 0, vertical);
    transform.Translate(movement * speed * Time.deltaTime);
    
    if (Input.GetKeyDown(KeyCode.Space))
    {
        Jump();
    }
    
    if (Input.GetMouseButtonDown(0))
    {
        Shoot();
    }
}
");

        Console.WriteLine("--- EXAMPLE: Mouse Position ---");
        Console.WriteLine(@"
void Update()
{
    // Screen position (pixels)
    Vector3 mouseScreen = Input.mousePosition;
    
    // World position (requires Camera)
    Ray ray = Camera.main.ScreenPointToRay(mouseScreen);
    if (Physics.Raycast(ray, out RaycastHit hit))
    {
        Vector3 worldPoint = hit.point;
    }
}
");

        // Simulate input reading
        SimulateInput();
    }

    static void SimulateInput()
    {
        Console.WriteLine("\n=== SIMULATED INPUT DEMO ===\n");

        string[] inputs = { "W", "A", "S", "D", "Space", "Space", "Mouse0" };
        
        foreach (string input in inputs)
        {
            ProcessInput(input);
        }
    }

    static void ProcessInput(string input)
    {
        switch (input)
        {
            case "W": Console.WriteLine("Moving forward"); break;
            case "A": Console.WriteLine("Moving left"); break;
            case "S": Console.WriteLine("Moving backward"); break;
            case "D": Console.WriteLine("Moving right"); break;
            case "Space": Console.WriteLine("Jump!"); break;
            case "Mouse0": Console.WriteLine("Shoot!"); break;
        }
    }
}
