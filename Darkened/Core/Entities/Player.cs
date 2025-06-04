using Darkened.Core.Systems;
using Darkened.Data;
using Darkened.Rendering.UI;

namespace Darkened.Core.Entities;
using Systems.Combat;

/*
 *  Player
 */
public class Player : ICombator
{
    // Events
    public event Action<ICombator> Death;

    public event Action<Tree<string>, ICombator> CombatRenderer;

    // Constructors
    // public Player(IStaticData playerDetails, IDatabase noteDatabase)
    // {}
    public Player (
        string playerName = "Ruoxi", 
        int maxHealth = 20, 
        int maxSt = 20, 
        int health = -1, 
        int stamina = -1
    )
    {
        Name = playerName;
        MaxHealth = maxHealth;
        MaxStamina = maxSt;
        // This is for when the field is not given
        Health = health < 0 ? maxHealth : health;
        Stamina = stamina < 0 ? maxSt : stamina;
        
        items = new Dictionary<Item, uint>();
        items.Add(new Item(), 1);
    }
    public void FlipGuarded()
    {
        IsGuarded = !IsGuarded;
    }
    public void TakeDamage(int damage)
    {
        Health -= CalculateDamageTaken(damage);
        if (Health <= 0)
        {
            Death?.Invoke(this);
        }
    }

    public void TakeTurn(List<ICombator> combators)
    {
        Logger.Instance?.Log("Player starts turn");
        IsGuarded = false;
        // CombatRenderer?.Invoke(_actionTree, this);
    }
    
    public int CalculateDamageDealt()
    {
        return weaponSlot?.Attack ?? 1;
    }
    // Private Methods
    private int CalculateDamageTaken(int damage)
    {
        // int armourResistence = _armour?.Defense ?? 1;
        int guardedDamage = IsGuarded ? damage / 2 : 0;
        
        return damage - (guardedDamage);
    }
    // Properties
    public string Name { get; private set; }
    public int Health { get => _health; set => _health = Math.Clamp(value, 0, MaxHealth); }
    public int MaxHealth { get => _maxHealth; set => _maxHealth = value <= 0 ? 1 : value; }
    public int Stamina { get => _st; set => _st = Math.Clamp(value, 0, MaxStamina); }
    public int MaxStamina { get => _maxSt; set => _maxSt = value < 0 ? 1 : value; }
    // This boolean dictates how much damage player takes
    public bool IsGuarded { get; private set; }
    // public CombatMenu? CombatMenu { get; set; }
    
    // fields
    private int _health;
    private int _maxHealth;
    private int _st;
    private int _maxSt;
    
    private Weapon? weaponSlot = null;
    private Armour? armour = null;
    private List<Spell> spells = [];
    private Dictionary<Item, uint> items;
}