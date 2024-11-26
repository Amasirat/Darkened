using Darkened.Core.Interfaces;

namespace Darkened.Core.Entities;

using Data.Interface;

public class Enemy : ICombator
{
    // Events
    public event Action<Enemy> OnDeath;

    public Enemy(string name = "Crow")
    {
        Name = name;
    }

    public void TakeDamage(int damage)
    {
        throw new NotImplementedException();
    }

    public void TakeTurn(string[] choices)
    {
        throw new NotImplementedException();
    }
    
    public string Name { get; set; }
}