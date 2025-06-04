using Darkened.Core.Engine;

namespace Darkened.Core.Systems.Combat;

public class CombatState : IState
{
    public CombatState()
    {
    }

    public void Update(float deltaTime)
    {
        
    }

    public void Draw()
    {
        Console.WriteLine("In Combat State");
    }

    public void Exit()
    {
        
    }

    public void HandleInput()
    {
        
    }

    private CombatEncounter combatEncounter;
}