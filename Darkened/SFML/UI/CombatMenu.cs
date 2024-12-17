using Darkened.Core.Interfaces;
using Darkened.Data;
using SFML.Graphics;

namespace Darkened.SFML.UI;

public sealed class CombatMenu : UIMenu
{
    public CombatMenu(RenderWindow window, Tree<string> menuTree) : base(window, menuTree)
    {}

    public void TakeStateAndDrawMenu(Tree<string> combatorMenuTree, ICombator combator)
    {
        combatorName = combator.Name;
        combatorHealth = combator.Health;
        combatorStamina = combator.Stamina;
        combatorMaxHealth = combator.MaxHealth;
        combatorMaxStamina = combator.MaxStamina;
        
        UpdateItemsTree(combatorMenuTree);
        while (_window.IsOpen)
        {
            _window.DispatchEvents();
            Render();
            HandleInput();
            _window.Display();
        }
    }
    
    private string combatorName;
    private int combatorHealth;
    private int combatorStamina;
    private int combatorMaxHealth;
    private int combatorMaxStamina;
}