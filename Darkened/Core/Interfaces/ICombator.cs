namespace Darkened.Core.Interfaces;

// Interface for objects that are allowed to participate in Combat Encounters
public interface ICombator
{
    public void TakeDamage(int damage);

    public void TakeTurn(string[] choices);
    
}