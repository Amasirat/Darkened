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

    public event Action<Tree<string>, string, List<ICombator>, Player> CombatRenderer;

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

    private void RenderMenu(string parent)
    {
        Console.Clear();
        var menuItems = new List<string>();
        if (parent == "")
        {
            menuItems = _actionTree?.GetRootChildren();
        }
        else
        {
            menuItems = _actionTree?.GetChildren(parent);
        }

        if (menuItems.Count == 0)
        {
            string emptyNotifyMessage = parent != "" ? $"No {parent}" : $"Nothing to show here...";
            Console.WriteLine(emptyNotifyMessage);
        }

        foreach (var item in menuItems)
        {
            Console.Write($"{item}\t");
        }
        Console.WriteLine("\n--------------------------------------------------------");
        Console.WriteLine("--------------------------------------------------------");
        
        Console.WriteLine($"Health: {Health}/{MaxHealth}");
        Console.WriteLine($"Stamina: {Stamina}/{MaxStamina}");
    }

    public ActionMove TakeTurn(List<ICombator> combators)
    {
        if (_actionTree == null)
            throw new Exception("Player has no action tree");

        foreach (var combator in combators)
        {
            _actionTree.AddChild(
                combator.Name, 
                ActionHandler.ToString(ActionHandler.Actions.Attack
                ));
        }
        
        ActionMove actionMove = new ActionMove();
        CombatRenderer += Renderer.Render;
        int depth = 0;       
        // A list of action choices that end the turn and need to be applied
        List<string> turnEndingActions = [
            ActionHandler.
                ToString(
                    ActionHandler.Actions.Defend)
        ];
        // Once a name of an enemy is called, turn ends. Whether it be an attack
        // or a check
        foreach (var combator in combators)
        {
            turnEndingActions.Add(combator.Name);
        }
        var pathTrace = new LinkedList<string>();
        pathTrace.AddLast("");
        while (true)
        {
            CombatRenderer?.Invoke(_actionTree, pathTrace.Last.Value, combators, this);
            HandleInput(ref depth, ref pathTrace);
            if (turnEndingActions.Contains(pathTrace.Last.Value))
            {
                break;
            }
        }

        return actionMove;
    }

    private void HandleInput(ref int depth, ref LinkedList<string> pathTrace)
    {
        switch (depth)
        {
            case 0:
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                    {
                        depth++;
                        pathTrace.AddLast(ActionHandler.ToString(ActionHandler.Actions.Attack));
                        break;
                    }
                    case ConsoleKey.DownArrow:
                    {
                        pathTrace.AddLast(ActionHandler.ToString(ActionHandler.Actions.Magic));
                        depth++;
                        break;
                    }
                    case ConsoleKey.LeftArrow:
                    {
                        pathTrace.AddLast(ActionHandler.ToString(ActionHandler.Actions.Defend));
                        break;
                    }
                    case ConsoleKey.RightArrow:
                    {
                        depth++;
                        pathTrace.AddLast(ActionHandler.ToString(ActionHandler.Actions.UseItem));
                        break;
                    }
                }
                break;
            }
            case 1:
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.A:
                    {
                        depth--;
                        pathTrace.RemoveLast();
                        break;
                    }
                }
                break;
            }
        }
    }

    public void TakeAndUpdateActionMoves(Tree<string> actionTree)
    {
        _actionTree = (Tree<string>)actionTree.Clone();
        foreach (var spell in _spells)
        {
            actionTree.AddChild(spell.SpellName, 
                ActionHandler.
                    ToString(ActionHandler.Actions.Magic));
        }

        foreach (var item in _items)
        {
            actionTree.AddChild(item.Name, 
                ActionHandler.
                    ToString(ActionHandler.Actions.UseItem));
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