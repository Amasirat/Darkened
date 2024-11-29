using System.Reflection.Metadata;
using Darkened.Core.Interfaces;
using Darkened.Core.Systems;
using Darkened.Data;

namespace Darkened.Core.Entities;
using Data.Interface;

/*
 *  Player
 */
public class Player : ICombator
{
    // Events
    public event Action<ICombator> Death;

    public event Action<Tree<string>, List<ICombator>, int> CombatRenderer;

    // Constructors
    public Player(IStaticData playerDetails, IDatabase noteDatabase)
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
        Name = playerName;
        MaxHealth = maxHealth;
        MaxStamina = maxSt;
        // This is for when the field is not given
        Health = health == -1 ? maxHealth : health;
        Stamina = stamina == -1 ? maxSt : stamina;
        CombatRenderer += ConsoleRenderer;
        notes = noteDatabase;
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
    public void ConsoleRenderer(Tree<string> actionTree, List<ICombator> enemies, int depth)
    {
        var menuItems = new List<string>();
        switch (depth)
        {
            case 0:
            {
                menuItems = actionTree.GetRootChildren();
                int index = 0;
                foreach (string menuItem in menuItems)
                {
                    Console.Write($"{index}.{menuItem} ");
                    index++;
                }
                
                HandleInput(depth);
                break;
            }
        }
        // List<string> rootMenuItems = actionTree.GetRootChildren();
        //
        // int index = 0;
        // foreach (string menuItem in rootMenuItems)
        // {
        //     Console.Write($"{index}.{menuItem} ");
        //     index++;
        // }
        
        Console.WriteLine($"Health: {Health}/{MaxHealth}");
        Console.WriteLine($"Stamina: {Stamina}/{MaxStamina}");
    }
    public Move TakeTurn(List<ICombator> combators)
    {
        if (_actionTree == null)
            throw new Exception("Player has no action tree");

        foreach (var combator in combators)
        {
            _actionTree.AddChild(combator.Name, "Attack");
        }
        
        CombatRenderer(_actionTree, combators, 0);
        HandleInput();
        return new Move();
    }

    private string HandleInput(int depth = 0)
    {
        string action = "";

        switch (depth)
        {
            case 0:
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                    {
                        depth++;
                        
                        break;
                    }
                    case ConsoleKey.DownArrow:
                    {
                        break;
                    }
                    case ConsoleKey.LeftArrow:
                    {
                        break;
                    }
                    case ConsoleKey.RightArrow:
                    {
                        break;
                    }
                }
                break;
            }
            case 1:
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                    {
                        depth--;
                        break;
                    }
                }
                break;
            }
            case 2:
            {
                
                break;
            }
                
        }

        return action;
    }

    public void TakeAndUpdateActionMoves(Tree<string> actionTree)
    {
        _actionTree = (Tree<string>)actionTree.Clone();
        foreach (var spell in _spells)
        {
            actionTree.AddChild(spell.SpellName, "Spells");
        }

        foreach (var item in _items)
        {
            actionTree.AddChild(item.Name, "Items");
        }
    }

    public Tree<string> GetActionTree()
    {
        return _actionTree;
    }
    
    public int CalculateDamageDealt()
    {
        return _weaponSlot?.Attack ?? 1;
    }
    // Private Methods
    private int CalculateDamageTaken(int damage)
    {
        int armourDamage = _armour?.Defense ?? 1;
        int guardedDamage = IsGuarded ? damage / 2 : 0;
        
        return damage - (armourDamage + guardedDamage);
    }
    // Properties
    public string Name { get; private set; }
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
    
    private Weapon? _weaponSlot = null;
    private Armour? _armour = null;
    private List<Spell> _spells = [];
    private List<Item> _items = [];
    
    private IDatabase? notes;
    private Tree<string>? _actionTree;
}