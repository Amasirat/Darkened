namespace Darkened.Core.Entities;
using Data.Interface;

/*
 *  Player:                     Events:  OnDeath, 
 *      Health
 *      Stamina
 *      Spells
 *      Items
 *      Weapons
 *      Armour
 *      bool IsGuarded
 */
public class Player
{
    // Events
    public event Action<Player> OnDeath;
    // Constructors
    public Player(IJson playerDetails, IDatabase noteDatabase)
    {}
    public Player (
        string playerName = "Cleo", 
        int maxHealth = 20, 
        int maxSt = 20, 
        int health = -1, 
        int stamina = -1, 
        IDatabase? noteDatabase = null
    )
    {
        // setting field parameters
        Name = playerName;
        _maxHealth = maxHealth;
        _maxSt = maxSt;
        _health = health == -1 ? maxHealth : health;
        _st = stamina == -1 ? maxSt : stamina;
        notes = noteDatabase;
    }
    public void FlipGuarded()
    {
        IsGuarded = !IsGuarded;
    }
    public void TakeDamage(int damage)
    {
        Health -= CalculateDamage(damage);
        if (Health <= 0)
        {
            OnDeath(this);
        }
        
    }
    // Private Methods
    private int CalculateDamage(int damage)
    {
        int armourDamage = _armour?.Defense ?? 1;
        int guardedDamage = IsGuarded ? damage / 2 : 0;
        
        return damage - (armourDamage + guardedDamage);
    }
    // Properties
    public string Name { get; set; }
    public int Health { get => _health; set => _health = Math.Clamp(value, 0, MaxHealth); }
    public int MaxHealth { get => _maxHealth; set => _maxHealth = value <= 0 ? 1 : value; }
    public int Stamina { get => _st; set => _st = Math.Clamp(value, 0, MaxStamina); }
    public int MaxStamina { get => _maxSt; set => _maxSt = value < 0 ? 1 : value; }
    // This boolean dictates how much damage player takes
    public bool IsGuarded { get; private set; }
    
    // fields
    private int _health;
    private int _maxHealth;
    private int _st;
    private int _maxSt;
    
    private Weapon? _weaponSlot1 = null;
    private Weapon? _weaponSlot2 = null;
    private Armour? _armour = null;
    
    private IDatabase? notes;
}