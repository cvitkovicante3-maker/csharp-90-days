# Day 81: Input Handling

## 📚 Concept
Read player input via legacy Input class or new Input System. GetKey for buttons, GetAxis for smooth movement, GetMouseButton for clicks.

## 💻 My Code
```csharp
using System;

class PlayerController
{
    private float _x, _y;
    private bool _isJumping;

    public void Update(string input)
    {
        switch (input)
        {
            case "W": _y += 1; break;
            case "S": _y -= 1; break;
            case "A": _x -= 1; break;
            case "D": _x += 1; break;
            case "Space": _isJumping = true; break;
            case "Q": Attack(); break;
        }
        ShowState();
    }

    private void Attack() =&gt; Console.WriteLine("ATTACK!");
    public void ShowState() { Console.WriteLine($"({_x}, {_y}) | Jump: {_isJumping}"); _isJumping = false; }
}
