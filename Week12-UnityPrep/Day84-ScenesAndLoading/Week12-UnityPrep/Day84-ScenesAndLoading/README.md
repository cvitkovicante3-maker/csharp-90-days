# Day 84: Scenes & Loading

## 📚 Concept
Scenes are self-contained levels or screens. SceneManager loads, unloads, and transitions between them. Async loading prevents freezing.

## 💻 My Code
```csharp
using System;
using System.Collections.Generic;

class Scene
{
    public string Name { get; }
    public List&lt;string&gt; Objects { get; private set; }
    public Scene(string name) { Name = name; Objects = new List&lt;string&gt;(); }
    public void AddObject(string obj) =&gt; Objects.Add(obj);
    public void Load() { Console.WriteLine($"Loading {Name} with {Objects.Count} objects"); }
    public void Unload() { Objects.Clear(); }
}

class SceneManager
{
    private Dictionary&lt;string, Scene&gt; _scenes = new();
    private Scene _current;

    public void RegisterScene(string name, Scene scene) =&gt; _scenes[name] = scene;

    public void LoadScene(string name)
    {
        _current?.Unload();
        if (_scenes.ContainsKey(name)) { _current = _scenes[name]; _current.Load(); }
    }

    public void LoadSceneAsync(string name)
    {
        Console.WriteLine($"Async loading {name}...");
        for (int p = 0; p &lt;= 100; p += 25) Console.WriteLine($"{p}%");
        LoadScene(name);
    }
}
