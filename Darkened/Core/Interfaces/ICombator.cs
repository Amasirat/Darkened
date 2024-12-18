using Darkened.Core.Entities;
using Darkened.Core.Systems;
using Darkened.Data;

namespace Darkened.Core.Interfaces;

// Interface for objects that are allowed to participate in Combat Encounters
public interface ICombator
{
    public void TakeDamage(int damage);

    public void TakeTurn(List<ICombator> combators);

    public void TakeAndUpdateActionMoves(Tree<string> actionTree);

    public void AddCombatorsToActionTree(List<ICombator> combators);

    public int CalculateDamageDealt();

    public void FlipGuarded();

    public Tree<string> GetActionTree();
        
    public bool IsGuarded { get; }
    public string Name { get; }
    public int Health { get; }
    public int MaxHealth { get; }
    public int Stamina { get; }
    public int MaxStamina { get; }
    public event Action<ICombator> Death;
}