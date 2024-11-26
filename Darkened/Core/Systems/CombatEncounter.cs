using System.Data;
using Darkened.Core.Entities;
using Darkened.Core.Interfaces;

namespace Darkened.Core.Systems;

public class CombatEncounter
{
    public CombatEncounter(ICombator player, ICombator[] enemies, bool playerStruckFirst)
    {
        _player = player;
        if (enemies.Length == 0)
        {
            throw new ConstraintException("No enemies were provided to CombatEncounter.");
        }
        _enemies = enemies;
        _currentTurn = playerStruckFirst ? player : _enemies[0];
    }

    public void Update()
    {
        while (true)
        {
            
        }
    }
    // events
    public event Action<bool> CombatEnded;
    // fields
    public ICombator _player;
    public ICombator[] _enemies;
    public ICombator _currentTurn;

    private Dictionary<string, string> _choices;
}