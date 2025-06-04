using System.Data;
using Darkened.Core.Entities;
using Darkened.Data;
using Darkened.Rendering.UI;

namespace Darkened.Core.Systems.Combat;

public class CombatEncounter
{
    public CombatEncounter(ICombator player, List<ICombator> enemies, bool playerStruckFirst)
    {
        Initialize(player, enemies, playerStruckFirst);
    }
    private void Initialize(ICombator player, List<ICombator> enemies, bool playerStruckFirst)
    {
        ActionTree = new Tree<string>();
        PopulateActionTree();
        player.Death += OnPlayerDeath;
        // player.TakeAndUpdateActionMoves(ActionTree);
        _combators = new List<ICombator>();
        if (playerStruckFirst)
        {
            _combators.Add(player);
            foreach (var enemy in enemies)
            {
                _combators.Add(enemy);
                enemy.Death += OnEnemyDeath;
                // enemy.TakeAndUpdateActionMoves(ActionTree);
            }
        }
        else
        {
            foreach (var enemy in enemies)
            {
                enemy.Death += OnEnemyDeath;
                // enemy.TakeAndUpdateActionMoves(ActionTree);
                _combators.Add(enemy);
            }
            _combators.Add(player);
        }
        // This is for letting the combators add the initial combators to their action trees
        foreach (var combator in _combators)
        {
            // combator.AddCombatorsToActionTree(_combators);
        }
    }
// Method to give proper functionality to combator
    // public void HandleCombatMenuInitialization(
    //     ICombator combator, 
    //     List<ICombator> targets)
    // {
    //     combator.AddCombatorsToActionTree(_combators);
    //     combator.TakeAndUpdateActionMoves(ActionTree);
    //     
    // }
    public void StartEncounter()
    {
        Logger.Instance?.Log("Starting CombatEncounter");
        int turnIncrementor = 0;
        _currentTurn = _combators[turnIncrementor];
        if(_currentTurn == null) 
            throw new NullReferenceException("Current Turn was discovered to be null. " +
                                             "Something may have gone wrong: " + 
                                             "CombatEncounter.StartEncounter()");
        while (true)
        {
            _currentTurn.TakeTurn(_combators);
            if (_combators.Count == 1 || playerDied)
            {
                CombatEnded?.Invoke(!playerDied);
                break;
            }
            turnIncrementor++;
            _currentTurn = _combators[turnIncrementor % _combators.Count];
        }
    }

    private void OnPlayerDeath(ICombator obj)
    {
        Logger.Instance?.Log($"CombatEncounter.OnPlayerDeath: {obj.Name}");
        Console.WriteLine("PlayerDeath");
        playerDied = true;
        CombatEnded?.Invoke(!playerDied);
    }
    
    private void OnEnemyDeath(ICombator obj)
    {
        _combators.Remove(obj);
    }

    private void PopulateActionTree()
    {
        foreach (var action in ActionHandler.GetActionHashMap())
        {
            ActionTree.AddChild(action.Value);
        }
    }
    // gives a boolean informing the delegate if player won or lost
    public event Action<bool> CombatEnded;
    // The below ICombator list is for the encounter logic to use for easy turn management
    private List<ICombator> _combators;
    private ICombator _currentTurn;
    private List<ActionHandler.Actions> _validActions;
    private bool playerDied;
    public Tree<string> ActionTree;
}