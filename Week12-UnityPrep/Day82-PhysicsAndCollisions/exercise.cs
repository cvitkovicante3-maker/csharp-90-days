using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== UNITY PHYSICS & COLLISIONS ===\n");

        Console.WriteLine("--- RIGIDBODY ---");
        Console.WriteLine("Component that makes object respond to physics");
        Console.WriteLine("UseGravity     - Falls down");
        Console.WriteLine("Mass           - Heavier = harder to push");
        Console.WriteLine("Drag           - Air resistance");
        Console.WriteLine("AngularDrag    - Rotation resistance");
        Console.WriteLine("IsKinematic    - Not affected by physics (good for platforms)");
        Console.WriteLine("Constraints    - Freeze position/rotation axes\n");

        Console.WriteLine("--- COLLIDERS ---");
        Console.WriteLine("BoxCollider      - Rectangular shape");
        Console.WriteLine("SphereCollider   - Round shape");
        Console.WriteLine("CapsuleCollider  - Pill shape (good for characters)");
        Console.WriteLine("MeshCollider     - Exact mesh shape (expensive)");
        Console.WriteLine("IsTrigger        - Detects overlap without collision response\n");

        Console.WriteLine("--- COLLISION METHODS ---");
        Console.WriteLine("OnCollisionEnter(Collision other)  - First contact");
        Console.WriteLine("OnCollisionStay(Collision other)   - Still touching");
        Console.WriteLine("OnCollisionExit(Collision other)   - Stopped touching");
        Console.WriteLine("OnTriggerEnter(Collider other)     - Entered trigger zone");
        Console.WriteLine("OnTriggerStay(Collider other)      - Inside trigger zone");
        Console.WriteLine("OnTriggerExit(Collider other)      - Left trigger zone\n");

        Console.WriteLine("--- APPLYING FORCES ---");
        Console.WriteLine("rb.AddForce(Vector3.up * 10)           - Push in direction");
        Console.WriteLine("rb.AddForce(Vector3.up, ForceMode.Impulse) - Instant impulse");
        Console.WriteLine("rb.velocity = new Vector3(0, 5, 0)     - Set velocity directly");
        Console.WriteLine("rb.MovePosition(targetPos)             - Kinematic movement\n");

        // Simulate physics concepts
        SimulatePhysics();
    }

    static void SimulatePhysics()
    {
        Console.WriteLine("=== PHYSICS SIMULATION ===\n");

        // Simulate a ball drop
        float position = 10f;  // height
        float velocity = 0f;   // starting speed
        float gravity = -9.81f;
        float bounce = 0.7f;   // energy retained after bounce

        for (int frame = 0; frame < 20; frame++)
        {
            velocity += gravity * 0.02f;  // apply gravity
            position += velocity * 0.02f; // move

            // Bounce off ground
            if (position <= 0)
            {
                position = 0;
                velocity = -velocity * bounce;
                Console.WriteLine($"Frame {frame}: BOUNCE! Height: {position:F2}, Velocity: {velocity:F2}");
            }
            else
            {
                Console.WriteLine($"Frame {frame}: Height: {position:F2}, Velocity: {velocity:F2}");
            }

            // Stop if barely moving
            if (position <= 0.01f && MathF.Abs(velocity) < 0.5f)
            {
                Console.WriteLine("Ball came to rest.");
                break;
            }
        }
    }
}
