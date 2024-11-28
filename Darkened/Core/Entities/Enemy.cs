using Darkened.Core.Interfaces;
using Darkened.Data;

namespace Darkened.Core.Entities;

public class Enemy : ICombator
{
    // Events
    public event Action<ICombator> Death;

    public Enemy(string name = "Crow")
    {
        Name = name;
    }

    public void TakeDamage(int damage)
    {
        throw new NotImplementedException();
    }

    public Move TakeTurn(List<ICombator> combators)
    {
        throw new NotImplementedException();
    }

    public void TakeActionMoves(Tree<string> actionTree)
    {
        throw new NotImplementedException();
    }

    public int DealDamage()
    {
        throw new NotImplementedException();
    }

    public void FlipGuarded()
    {
        IsGuarded = !IsGuarded;
    }
    
    public string Name { get; set; }
    
    public bool IsGuarded { get; private set; }
}