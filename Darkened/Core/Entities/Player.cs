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
        string playerName = "Cleo", 
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
        
        _items = new Dictionary<Item, uint>();
        _items.Add(new Item(), 1);
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
        if (_actionTree == null)
        {
            string message = "ERROR: Player has no action tree";
            Logger.Instance?.Log(message);
            throw new Exception(message);
        }
        CombatRenderer?.Invoke(_actionTree, this);
    }
    
    public void TakeAndUpdateActionMoves(Tree<string> actionTree)
    {
        if (!_readyToUpdateActionTree) return;
        
        _actionTree = actionTree;
        foreach (var spell in _spells)
        {
            actionTree.AddChild(spell.SpellName, 
                ActionHandler.
                    ToString(ActionHandler.Actions.Magic));
        }

        foreach (var item in _items.Keys)
        {
            actionTree.AddChild(item.Name, 
                ActionHandler.
                    ToString(ActionHandler.Actions.UseItem));
        }
        Logger.Instance?.Log("Player updates ActionTree");
        _readyToUpdateActionTree = false;
    }

    public Tree<string> GetActionTree()
    {
        return _actionTree;
    }

    public void AddCombatorsToActionTree(List<ICombator> combators)
    {
        if (_actionTree == null)
        {
            Logger.Instance?.Log("ERROR: Player has no action tree(TakeCombatorsAndUpdateActionTree)");
            throw new NullReferenceException("ERROR: Player has no action tree(TakeCombatorsAndUpdateActionTree)");
        }

        if (combators.Count == 0) return;

        string attackString = ActionHandler.ToString(ActionHandler.Actions.Attack);
        string itemString = ActionHandler.ToString(ActionHandler.Actions.UseItem);

        var itemNode = _actionTree.FindNode(itemString);
        
        foreach (var combator in combators)
        {
            _actionTree.AddChild($"{attackString} {combator.Name}", attackString);
            foreach(var item in itemNode?.Children)
                _actionTree.AddChild($"{itemString} {combator.Name}", item.Value);
        }
    }
    public int CalculateDamageDealt()
    {
        return _weaponSlot?.Attack ?? 1;
    }

    public void TakeUIMenu(UIMenu uiMenu)
    {
        _uiMenu = uiMenu;
    }

    public void TakeCombatMenu(CombatMenu combatMenu)
    {
        CombatMenu = combatMenu;
    }
    // Private Methods
    private int CalculateDamageTaken(int damage)
    {
        // int armourResistence = _armour?.Defense ?? 1;
        int guardedDamage = IsGuarded ? damage / 2 : 0;
        
        return damage - (guardedDamage);
    }

    private void AddSelectionsToCombatMenu()
    {
        
    }
    // Properties
    public string Name { get; private set; }
    public int Health { get => _health; set => _health = Math.Clamp(value, 0, MaxHealth); }
    public int MaxHealth { get => _maxHealth; set => _maxHealth = value <= 0 ? 1 : value; }
    public int Stamina { get => _st; set => _st = Math.Clamp(value, 0, MaxStamina); }
    public int MaxStamina { get => _maxSt; set => _maxSt = value < 0 ? 1 : value; }
    // This boolean dictates how much damage player takes
    public bool IsGuarded { get; private set; }
    public CombatMenu? CombatMenu { get; set; }
    
    // fields
    private int _health;
    private int _maxHealth;
    private int _st;
    private int _maxSt;
    // This is for making sure TakeAndUpdateActionTree does not get duplicate values
    private bool _readyToUpdateActionTree = true;
    
    private Weapon? _weaponSlot = null;
    private Armour? _armour = null;
    private List<Spell> _spells = [];
    private Dictionary<Item, uint> _items;

    private Tree<string>? _actionTree;
    private UIMenu? _uiMenu;
}