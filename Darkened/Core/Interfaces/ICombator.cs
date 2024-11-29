using Darkened.Core.Entities;
using Darkened.Data;

namespace Darkened.Core.Interfaces;

// Interface for objects that are allowed to participate in Combat Encounters
public interface ICombator
{
    public void TakeDamage(int damage);

    public Move TakeTurn(List<ICombator> combators);

    public void TakeAndUpdateActionMoves(Tree<string> actionTree);

    public int CalculateDamageDealt();

    public void FlipGuarded();

    public Tree<string> GetActionTree();
        
    public bool IsGuarded { get; }
    public string Name { get; }
    public event Action<ICombator> Death;
}