using System.Data;
using Darkened.Core.Entities;
using Darkened.Core.Interfaces;
using Darkened.Data;
using Darkened.Data.Interface;
using Darkened.SFML.UI;

namespace Darkened.Core.Systems;

public class CombatEncounter
{
    public CombatEncounter(ICombator player, List<ICombator> enemies, bool playerStruckFirst)
    {
        Initialize(player, enemies, playerStruckFirst);
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
            _currentTurn.TakeTurn(_combators);
            // CarryOutAction(_currentTurn, actionMove);
            if (_combators.Count == 1)
            {
                CombatEnded?.Invoke(false);
            }

            turnIncrementor++;
            _currentTurn = _combators[turnIncrementor % _combators.Count];
        }
    }

    private void CarryOutAction(ICombator offender, ActionMove actionMove)
    {
        switch (actionMove.Value)
        {
            case ActionHandler.Actions.Attack:
                actionMove.Target?.TakeDamage(offender.CalculateDamageDealt());
                break;
            case ActionHandler.Actions.Defend:
                offender.FlipGuarded();
                break;
            case ActionHandler.Actions.Magic:
                break;
            case ActionHandler.Actions.UseItem:
                break;
        }
    }

    private void OnPlayerDeath(ICombator obj)
    {
        CombatEnded?.Invoke(true);
    }
    
    private void OnEnemyDeath(ICombator obj)
    {
        throw new NotImplementedException();
    }

    private void PopulateActionTree()
    {
        foreach (var action in ActionHandler.GetActionHashMap())
        {
            ActionTree.AddChild(action.Value);
        }
    }
    private void Initialize(ICombator player, List<ICombator> enemies, bool playerStruckFirst)
    {
        // The explicit types of these combators is required for passing them into the render event
        // Should throw a cast exception if explicit cast fails
        _player = (Player)player;
        
        if (enemies.Count == 0)
        {
            throw new ConstraintException("No enemies were provided to CombatEncounter.");
        }
        _enemies = [];
        foreach (var enemy in enemies)
        {
            _enemies.Add((Enemy)enemy);
        }

        ActionTree = new Tree<string>();
        PopulateActionTree();
        player.Death += OnPlayerDeath;
        player.TakeAndUpdateActionMoves(ActionTree);
        
        _combators = new List<ICombator>();
        if (playerStruckFirst)
        {
            _combators.Add(player);
            foreach (var enemy in enemies)
            {
                _combators.Add(enemy);
                enemy.Death += OnEnemyDeath;
                enemy.TakeAndUpdateActionMoves(ActionTree);
            }
        }
        else
        {
            foreach (var enemy in enemies)
            {
                enemy.Death += OnEnemyDeath;
                enemy.TakeAndUpdateActionMoves(ActionTree);
                _combators.Add(enemy);
            }
            _combators.Add(player);
        }
    }
    public event Action<bool> CombatEnded;
    
    // fields
    private Player _player;
    private List<Enemy> _enemies;
    
    // The below ICombator list is for the encounter logic to use for easy turn management
    private List<ICombator> _combators;
    private ICombator _currentTurn;
    private List<ActionHandler.Actions> _validActions;
    public Tree<string> ActionTree;
}