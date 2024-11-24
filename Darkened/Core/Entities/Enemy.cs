namespace Darkened.Core.Entities;

using Data.Interface;

public class Enemy
{
    // Events
    public event Action<Enemy> OnDeath;
    public Enemy()
    {}
}