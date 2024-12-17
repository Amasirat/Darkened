using Darkened.Core.Interfaces;
using Darkened.Core.Systems;
using Darkened.Data;
using SFML.Graphics;

namespace Darkened.SFML.UI;

public sealed class CombatMenu : UIMenu
{
    public CombatMenu(RenderWindow window, Tree<string> menuTree) : base(window, menuTree)
    {
        ActionHandler.ActionTaken += OnTurnEnded;
    }

    public void TakeStateAndDrawMenu(Tree<string> combatorMenuTree, ICombator combator)
    {
        combatorName = combator.Name;
        combatorHealth = combator.Health;
        combatorStamina = combator.Stamina;
        combatorMaxHealth = combator.MaxHealth;
        combatorMaxStamina = combator.MaxStamina;
        
        UpdateItemsTree(combatorMenuTree);
        turnEnded = false;
        
        while (_window.IsOpen && !turnEnded)
        {
            _window.DispatchEvents();
            _window.Clear();
            Render();
            HandleInput();
            _window.Display();
        }
    }

    public void OnTurnEnded()
    {
        turnEnded = true;
    }
    
    private string combatorName;
    private int combatorHealth;
    private int combatorStamina;
    private int combatorMaxHealth;
    private int combatorMaxStamina;
    private bool turnEnded;
}