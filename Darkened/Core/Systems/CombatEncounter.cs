using System.Data;
using Darkened.Core.Entities;
using Darkened.Core.Interfaces;
using Darkened.Data;

namespace Darkened.Core.Systems;

public class CombatEncounter
{
    public CombatEncounter(ICombator player, List<ICombator> enemies, bool playerStruckFirst)
    { 
        if (enemies.Count == 0)
        {
            throw new ConstraintException("No enemies were provided to CombatEncounter.");
        }
        
        player.Death += OnPlayerDeath;
        player.TakeActionMoves(_actionTree);
        
        _combators = new List<ICombator>();
        if (playerStruckFirst)
        {
            _combators.Add(player);
            foreach (var enemy in enemies)
            {
                _combators.Add(enemy);
                enemy.Death += OnEnemyDeath;
                enemy.TakeActionMoves(_actionTree);
            }
        }
        else
        {
            foreach (var enemy in enemies)
            {
                enemy.Death += OnEnemyDeath;
                enemy.TakeActionMoves(_actionTree);
                _combators.Add(enemy);
            }
            _combators.Add(player);
        }
    }
    
    public void StartEncounter()
    {
        if(_currentTurn == null) 
            throw new NullReferenceException("Current Turn was discovered to be null. " +
                                             "Something may have gone wrong: " + 
                                             "CombatEncounter.StartEncounter()");

        int turnIncrementor = 0;
        _currentTurn = _combators[turnIncrementor];
        while (true)
        {
            var combators = _combators.Where(combator => combator != _currentTurn).ToList();
        // by giving the above to TakeTurn, any combator can make moves on any other combator except itself. 
            Move action = _currentTurn.TakeTurn(combators);
            CarryOutAction(_currentTurn, action);
            _currentTurn = _combators[turnIncrementor % _combators.Count];
        }
    }

    private void CarryOutAction(ICombator offender, Move action)
    {
        switch (action.title)
        {
            case "Attack":
                action.target.TakeDamage(offender.DealDamage());
                break;
            case "Defend":
                offender.FlipGuarded();
                break;
        }
    }

    private void OnPlayerDeath(ICombator obj)
    {
        throw new NotImplementedException();
    }
    
    private void OnEnemyDeath(ICombator obj)
    {
        throw new NotImplementedException();
    }
    
    public event Action<bool> CombatEnded;
    // fields
    private List<ICombator> _combators;
    private ICombator _currentTurn;
    private Tree<string> _actionTree;
}