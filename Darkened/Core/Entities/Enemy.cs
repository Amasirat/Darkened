namespace Darkened.Core.Entities;

using Systems;
using Systems.Combat;
using Data;
public class Enemy : ICombator
{
    // Events
    public event Action<ICombator> Death;

    public Enemy(string name = "Crow")
    {
        Name = name;
        Health = 20;
        Stamina = 20;
        MaxHealth = 20;
        MaxStamina = 20;
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
        IsGuarded = false;
        
        Console.WriteLine("Turn Ended");
    }
    
    public void FlipGuarded()
    {
        IsGuarded = !IsGuarded;
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
        return _weapon?.Attack ?? 1;
    }
    
    private int CalculateDamageTaken(int damage)
    {
        int damageTaken = damage;

        damageTaken = IsGuarded ? damageTaken / 2 : damageTaken;
        
        return damageTaken;
    }

    public void AddCombatorsToActionTree(List<ICombator> combators)
    {
        foreach (var combator in combators)
        {
            _actionTree.AddChild(combator.Name,
                ActionHandler.ToString(ActionHandler.Actions.Attack));
        }
    }

    private void RemoveCombatorsFromActionTree(List<ICombator> combators)
    {
        for (int i = 0; i < combators.Count; i++) 
        {
            _actionTree.RemoveChild(
                combators[i].Name,
                ActionHandler.ToString(ActionHandler.Actions.Attack)
            );
        }
    }
    
    public string Name { get; set; }
    
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int Stamina { get; set; }
    public int MaxStamina { get; set; }
    public bool IsGuarded { get; private set; }
    
    private Weapon? _weapon = null;
    private List<Item> _items = new();
    private List<Spell> _spells = new();
    private Tree<string> _actionTree;
}