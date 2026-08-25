# Day 83: Prefabs & Instantiation

## 📚 Concept
Prefabs are reusable templates. Instantiation creates copies at runtime. Object pooling reuses instances instead of constant create/destroy.

## 💻 My Code
```csharp
using System;
using System.Collections.Generic;

class GameObject
{
    public string Name { get; set; }
    public string Tag { get; set; }
    public float X { get; set; }
    public float Y { get; set; }

    public GameObject(string name) { Name = name; }
    public void SetPosition(float x, float y) { X = x; Y = y; }
    public void ShowInfo() =&gt; Console.WriteLine($"{Name} at ({X}, {Y})");

    public GameObject Clone()
    {
        return new GameObject(Name + "_Clone") { Tag = Tag, X = X, Y = Y };
    }
}

class PrefabManager
{
    private Dictionary&lt;string, GameObject&gt; _prefabs = new();

    public void RegisterPrefab(string key, GameObject prefab) =&gt; _prefabs[key] = prefab;

    public GameObject Instantiate(string key, float x, float y)
    {
        if (!_prefabs.ContainsKey(key)) return null;
        GameObject instance = _prefabs[key].Clone();
        instance.SetPosition(x, y);
        return instance;
    }
}
