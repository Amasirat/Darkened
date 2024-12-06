using Darkened.Core.Interfaces;
using Darkened.Core.Systems;
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

    public ActionMove TakeTurn(List<ICombator> combators)
    {
        throw new NotImplementedException();
    }

    public void TakeAndUpdateActionMoves(Tree<string> actionTree)
    {
        throw new NotImplementedException();
    }

    public Tree<string> GetActionTree()
    {
        return _actionTree;
    }

    public int CalculateDamageDealt()
    {
        throw new NotImplementedException();
    }

    public void FlipGuarded()
    {
        IsGuarded = !IsGuarded;
    }
    
    public string Name { get; set; }
    
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int Stamina { get; set; }
    public int MaxStamina { get; set; }
    public bool IsGuarded { get; private set; }
    

    private Tree<string> _actionTree;
}