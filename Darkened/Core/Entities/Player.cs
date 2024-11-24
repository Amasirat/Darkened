namespace Darkened.Core.Entities;
using Darkened.Data.Interface;
public class Player
{
    // Constructors
    public Player(IJson playerDetails, IDatabase noteDatabase)
    {}
    public Player (
        string playerName, 
        int maxHealth = 20, 
        int maxMana = 20, 
        int health = -1, 
        int mana = -1, 
        IDatabase? noteDatabase = null
    )
    {
        Name = playerName;
        this.maxHealth = maxHealth;
        this.maxMana = maxMana;
        if(health == -1)
            this.health = maxHealth;
        if (mana == -1)
            this.mana = maxMana;
        notes = noteDatabase;
    }
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
        set => maxHealth = value <= 0 ? 1 : value;
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
    // This boolean dictates how much damage player takes
    public bool Guarded { get; set; }

    private int health;
    private int maxHealth;
    private int mana;
    private int maxMana;

    private IDatabase? notes;
}