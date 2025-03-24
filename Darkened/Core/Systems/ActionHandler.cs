using System.Data;
using Darkened.Core.Entities;
using Darkened.Core.Interfaces;

namespace Darkened.Core.Systems;

public static class ActionHandler
{

    public static event Action ActionTaken;
    public static string ToString(Actions action)
    {
        return action switch
        {
            Actions.Attack => "Attack",
            Actions.Magic => "Magic",
            Actions.Defend => "Defend",
            Actions.UseItem => "Items",
            _ => ""
        };
    }

    public static Actions ToEnum(string action)
    {
        return action switch
        {
            "Attack" => Actions.Attack,
            "Magic" => Actions.Magic,
            "Defend" => Actions.Defend,
            "Items" => Actions.UseItem,
            _ => throw new Exception("Invalid action")
        };
    }

    public static Dictionary<Actions, string> GetActionHashMap()
    {
        var allActionStrings = new Dictionary<Actions, string>
        {
            { Actions.Attack, ToString(Actions.Attack)},
            { Actions.Defend, ToString(Actions.Defend)},
            { Actions.UseItem, ToString(Actions.UseItem) },
            { Actions.Magic, ToString(Actions.Magic) }
        };

        return allActionStrings;
    }

    public static void Attack(ICombator offender, ICombator target)
    {
        Console.WriteLine("Reached Attack method");
        ActionTaken?.Invoke();
        target.TakeDamage(offender.CalculateDamageDealt());
        Console.WriteLine($"{target.Name} Health: {target.Health} / {target.MaxHealth}");
    }
    public static void Defend(ICombator caster)
    {
        ActionTaken?.Invoke();
        caster.FlipGuarded();
    }

    public static void Magic(ICombator caster, List<Spell> spells, ICombator target)
    {
        
    }

    public static void UseItem(ICombator caster, Item item, ICombator target)
    {
        
    }
    public enum Actions
    {
        Attack,
        Magic,
        Defend,
        UseItem
    }
}