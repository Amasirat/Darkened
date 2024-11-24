namespace Darkened.Core.Entities;

public class Armour
{
    // Event
    public event Action<Armour> OnBroken;
    // Constructor
    public Armour()
    {
    }

    public void TakeDamage(int damage)
    {
        BreakScore = CalculateDamage(damage);
    }

    private int CalculateDamage(int damage)
    {
        return damage - Resilience;
    }
    // Properties
    public string Name { get; set; }
    public string Description { get; set; }
    public int Defense { get => _defense; set => _defense = value > 0 ? value : 0; }
    public int BreakScore { get => _breakScore; set => _breakScore = value > 0 ? value : 0; }
    public int Resilience { get => _resilience; set => _resilience = value > 0 ? value : 0; }
    // fields
    private int _defense;
    private int _breakScore;
    private int _resilience;
}