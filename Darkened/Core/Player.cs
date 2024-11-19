namespace Darkened.Core;

public class Player
{
    // Constructors
    // Master Constructor
    public Player()
    {}
    
    
    // Properties
    public string Name { get; set; }
    
    public int Health
    {
        get => health;
        set => health = Math.Clamp(value, 0, MaxHealth);
    }
    public int MaxHealth
    {
        get => maxHealth;
        set => maxHealth = value < 0 ? 1 : value;
    }
    public int Mana
    {
        get => mana;
        set => mana = Math.Clamp(value, 0, MaxMana);
    }
    public int MaxMana
    {
        get => maxMana;
        set => maxMana = value < 0 ? 1 : value;
    }

    private int health;
    private int maxHealth;
    private int mana;
    private int maxMana;
}