using System.Data;
using Darkened.Core.Entities;
using Darkened.Core.Interfaces;
using Darkened.Data;

namespace Darkened.Core.Systems;

public class CombatEncounter
{
    public CombatEncounter(ICombator player, List<ICombator> enemies, bool playerStruckFirst)
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

        _actionTree = new Tree<string>();
        _actionTree.AddChild("Attack");
        _actionTree.AddChild("Defend");
        _actionTree.AddChild("Spells");
        _actionTree.AddChild("Items");
        
        player.Death += OnPlayerDeath;
        player.TakeAndUpdateActionMoves(_actionTree);
        
        _combators = new List<ICombator>();
        if (playerStruckFirst)
        {
            _combators.Add(player);
            foreach (var enemy in enemies)
            {
                _combators.Add(enemy);
                enemy.Death += OnEnemyDeath;
                // enemy.TakeAndUpdateActionMoves(_actionTree);
            }
        }
        else
        {
            foreach (var enemy in enemies)
            {
                enemy.Death += OnEnemyDeath;
                // enemy.TakeAndUpdateActionMoves(_actionTree);
                _combators.Add(enemy);
            }
            _combators.Add(player);
        }
    }
    public void StartEncounter()
    {

        int turnIncrementor = 0;
        _currentTurn = _combators[turnIncrementor];
        if(_currentTurn == null) 
            throw new NullReferenceException("Current Turn was discovered to be null. " +
                                             "Something may have gone wrong: " + 
                                             "CombatEncounter.StartEncounter()");
        while (true)
        {
        // by giving the above to TakeTurn, any combator can make moves on any other combator except itself.
            Move action = _currentTurn.TakeTurn(_combators);
            // CarryOutAction(_currentTurn, action);
            // turnIncrementor++;
            // _currentTurn = _combators[turnIncrementor % _combators.Count];
        }
    }

    private void CarryOutAction(ICombator offender, Move action)
    {
        switch (action.title)
        {
            case "Attack":
                action.target.TakeDamage(offender.CalculateDamageDealt());
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

    public event Action<Tree<string>, Player, List<Enemy>> Render;

    public enum ValidActions
    {
        Attack,
        Magic,
        Defend,
        UseItem
    }
    // fields
    private Player _player;
    private List<Enemy> _enemies;
    
    // The below ICombator list is for the encounter logic to use for easy turn management
    private List<ICombator> _combators;
    private ICombator _currentTurn;
    private Tree<string> _actionTree;
}