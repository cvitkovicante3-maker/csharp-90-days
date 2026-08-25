using System;
using System.Collections.Generic;

// Simulating Unity's prefab system in console

class GameObject
{
    public string Name { get; set; }
    public string Tag { get; set; }
    public float X { get; set; }
    public float Y { get; set; }

    public GameObject(string name)
    {
        Name = name;
        Tag = "Untagged";
    }

    public void SetPosition(float x, float y)
    {
        X = x;
        Y = y;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"{Name} [Tag: {Tag}] at ({X:F1}, {Y:F1})");
    }

    // Clone this object (like Instantiate in Unity)
    public GameObject Clone()
    {
        GameObject copy = new GameObject(Name + "_Clone");
        copy.Tag = Tag;
        copy.X = X;
        copy.Y = Y;
        return copy;
    }
}

// Prefab manager
class PrefabManager
{
    private Dictionary<string, GameObject> _prefabs = new();

    public void RegisterPrefab(string key, GameObject prefab)
    {
        _prefabs[key] = prefab;
        Console.WriteLine($"Registered prefab: {key}");
    }

    public GameObject Instantiate(string key, float x, float y)
    {
        if (!_prefabs.ContainsKey(key))
        {
            Console.WriteLine($"Prefab '{key}' not found!");
            return null;
        }

        GameObject instance = _prefabs[key].Clone();
        instance.SetPosition(x, y);
        Console.WriteLine($"Instantiated {key} at ({x}, {y})");
        return instance;
    }
}

class Program
{
    static void Main()
    {
        PrefabManager manager = new PrefabManager();

        // Create prefabs (like in Unity Editor)
        GameObject enemyPrefab = new GameObject("Enemy");
        enemyPrefab.Tag = "Enemy";
        enemyPrefab.SetPosition(0, 0);

        GameObject bulletPrefab = new GameObject("Bullet");
        bulletPrefab.Tag = "Projectile";
        bulletPrefab.SetPosition(0, 0);

        // Register them
        manager.RegisterPrefab("Enemy", enemyPrefab);
        manager.RegisterPrefab("Bullet", bulletPrefab);

        Console.WriteLine("\n=== SPAWNING ===\n");

        // Instantiate at runtime (like in game)
        List<GameObject> spawned = new();

        spawned.Add(manager.Instantiate("Enemy", 5, 0));
        spawned.Add(manager.Instantiate("Enemy", -3, 2));
        spawned.Add(manager.Instantiate("Bullet", 0, 1));
        spawned.Add(manager.Instantiate("Bullet", 0, 2));

        Console.WriteLine("\n=== SPAWNED OBJECTS ===\n");
        foreach (GameObject obj in spawned)
        {
            obj?.ShowInfo();
        }

        // Try invalid prefab
        Console.WriteLine("\n=== INVALID ===");
        manager.Instantiate("Dragon", 10, 10);
    }
}
