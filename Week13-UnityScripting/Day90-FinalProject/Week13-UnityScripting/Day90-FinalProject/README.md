📚 Concept
using System;

// Game Loop + State Machine pattern
enum GameState { MainMenu, Exploring, InCombat, GameOver, Victory }

class GameManager
{
    public GameState CurrentState;
    
    public void ChangeState(GameState newState)
    {
        CurrentState = newState;
    }
}
💻 My Code
Day 90: Final Project — The Arena
🎯 Exercise I Completed
Task: Added Slime enemy with split mechanic.
My Solution:
csharp
public class Slime : Enemy
{
    public bool HasSplit { get; private set; }
    public Slime() : base("Slime", 60, 5, 40, 15, "Slime") { }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        if (!IsAlive && !HasSplit)
        {
            HasSplit = true;
            GameEvents.PublishMessage("💧 Slime splits in two!");
        }
    }
}
🤔 What I Learned
Game Loop = Update() + Render() running every frame
State Machine prevents code chaos — only one state is active at a time
Singleton GameManager ensures one source of truth for game state
Observer Pattern (events) decouples UI from game logic
Factory method (SpawnEnemy) makes adding new enemies trivial
Inheritance + Polymorphism = unique enemy behaviors without duplicate code
LateUpdate() in Unity = camera/UI updates after gameplay logic
Component-Based Design in Unity = attach scripts to GameObjects instead of one giant class
✅ Checklist
[x] Typed code by hand
[x] Modified and experimented (changed win condition, enemy stats, added Slime)
[x] Completed exercise
[x] Understood before moving on
