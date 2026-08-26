using System;
using System.Collections.Generic;

// Simulating Unity's scene system in console

class Scene
{
    public string Name { get; }
    public List<string> Objects { get; private set; }

    public Scene(string name)
    {
        Name = name;
        Objects = new List<string>();
    }

    public void AddObject(string obj) => Objects.Add(obj);

    public void Load()
    {
        Console.WriteLine($"\n=== LOADING SCENE: {Name} ===");
        Console.WriteLine($"Objects in scene: {Objects.Count}");
        foreach (string obj in Objects)
        {
            Console.WriteLine($"  - {obj}");
        }
        Console.WriteLine($"=== {Name} LOADED ===\n");
    }

    public void Unload()
    {
        Console.WriteLine($"Unloading scene: {Name}");
        Objects.Clear();
    }
}

class SceneManager
{
    private Dictionary<string, Scene> _scenes = new();
    private Scene _currentScene;

    public void RegisterScene(string name, Scene scene)
    {
        _scenes[name] = scene;
    }

    public void LoadScene(string name)
    {
        if (_currentScene != null)
        {
            _currentScene.Unload();
        }

        if (_scenes.ContainsKey(name))
        {
            _currentScene = _scenes[name];
            _currentScene.Load();
        }
        else
        {
            Console.WriteLine($"Scene '{name}' not found!");
        }
    }

    public void LoadSceneAsync(string name)
    {
        Console.WriteLine($"Starting async load of '{name}'...");
        
        // Simulate loading steps
        for (int progress = 0; progress <= 100; progress += 25)
        {
            Console.WriteLine($"Loading... {progress}%");
        }

        LoadScene(name);
        Console.WriteLine("Async load complete!\n");
    }

    public string CurrentScene => _currentScene?.Name;
}

class Program
{
    static void Main()
    {
        SceneManager manager = new SceneManager();

        // Build scenes
        Scene menu = new Scene("MainMenu");
        menu.AddObject("Background");
        menu.AddObject("PlayButton");
        menu.AddObject("SettingsButton");

        Scene level1 = new Scene("Level1");
        level1.AddObject("Player");
        level1.AddObject("Enemy_Goblin");
        level1.AddObject("Enemy_Orc");
        level1.AddObject("Terrain");

        Scene gameOver = new Scene("GameOver");
        gameOver.AddObject("Background");
        gameOver.AddObject("RestartButton");
        gameOver.AddObject("ScoreText");

        // Register
        manager.RegisterScene("MainMenu", menu);
        manager.RegisterScene("Level1", level1);
        manager.RegisterScene("GameOver", gameOver);

        // Simulate game flow
        manager.LoadScene("MainMenu");
        Console.WriteLine("Player clicks Play...\n");

        manager.LoadSceneAsync("Level1");
        Console.WriteLine("Player dies...\n");

        manager.LoadScene("GameOver");
        Console.WriteLine("Player clicks Restart...\n");

        manager.LoadScene("Level1");
    }
}
