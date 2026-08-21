# Day 79: MonoBehaviour Lifecycle

## 📚 Concept
MonoBehaviour methods run at specific times: Awake (load), Start (first frame), Update (every frame), FixedUpdate (physics), LateUpdate (after Update), OnDestroy (cleanup).

## 💻 My Code
```csharp
using System;

class FakeMonoBehaviour
{
    private int _awakeCalls, _startCalls, _updateCalls, _fixedUpdateCalls;

    public void Awake() { _awakeCalls++; Console.WriteLine($"Awake ({_awakeCalls}x)"); }
    public void Start() { _startCalls++; Console.WriteLine($"Start ({_startCalls}x)"); }
    public void Update() { _updateCalls++; }
    public void FixedUpdate() { _fixedUpdateCalls++; }

    public void ShowStats()
    {
        Console.WriteLine($"Awake={_awakeCalls}, Start={_startCalls}, Update={_updateCalls}, FixedUpdate={_fixedUpdateCalls}");
    }
}
