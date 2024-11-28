using Darkened.Core.Entities;
using Darkened.Data;

namespace Darkened.Core.Interfaces;

// Interface for objects that are allowed to participate in Combat Encounters
public interface ICombator
{
    public void TakeDamage(int damage);

    public Move TakeTurn(List<ICombator> combators);

    public void TakeActionMoves(Tree<string> actionTree);

    public int DealDamage();

    public void FlipGuarded();

        
    public bool IsGuarded { get; }
    public event Action<ICombator> Death;
}