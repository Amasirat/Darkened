namespace Darkened.Core.Entities;

public class Weapon
{
    // Event
    public event Action<Weapon> OnBroken;
    // Constructor
    public Weapon(string name = "", string description = "", Type weaponType = Type.Slash, 
        int attack = 10, float breakScore = 10)
    {
        Name = name;
        Description = description;
        WeaponType = weaponType;
        Attack = attack;
        BreakScore = breakScore;
    }
    public enum Type
    {
        Slash,
        Pierce,
        Strike
    }

    public void ApplyBreak(float damage)
    {
        float appliedDamage = damage < 0 ? float.Abs(damage) : damage;
        BreakScore -= appliedDamage;
    }
    // Method for updating Weapon's IsBroken status
    public void CheckBroken()
    {
        IsBroken = _breakScore <= 0;
    }
    // Properties
    public string Name { get; set; }
    public string Description { get; set; }
    public Type WeaponType { get; set; }
    public int Attack { get => _attack; set => _attack = value > 0 ? value : 0; }
    public float BreakScore { get => _breakScore; set => _breakScore = value > 0 ? value : 0; }
    public bool IsBroken { get; set; }
    // fields
    private int _attack;
    private float _breakScore;
}