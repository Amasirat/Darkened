using Darkened.Core.Engine;
using Darkened.Rendering.UI;
using Darkened.Data;
using SFML.Graphics;
using SFML.System;

namespace Darkened.Core.Systems;

public class MenuState : IState
{
    public MenuState(RenderWindow window, InputHandler input, Tree<MenuItem> actionTree)
    {
        MenuDirection = MDirection.Column;
        this.input = input;
        uiMenu = new UIMenu(window, actionTree)
        {
            Direction = MenuDirection
        };
        clock = new Clock();
        Logger.Instance?.Log($"{Mode} state pushed on stack");
    }
    
    public void HandleInput()
    {
        if (clock.ElapsedTime.AsSeconds() < inputCooldown) return;

        switch (MenuDirection)
        {
            case MDirection.Column:
            {
                if (input.IsActionPressed(ActionMove.MoveUp))
                {
                    clock.Restart();
                    uiMenu.MoveUpSelectedItem();
                }

                if (input.IsActionPressed(ActionMove.MoveDown))
                {
                    clock.Restart();
                    uiMenu.MoveDownSelectedItem();
                }
                break;
            }
            default:
                throw new ArgumentException("UIMenu has corrupted value or invalid direction.");
        }
        
        if (input.IsActionPressed(ActionMove.Interact))
        {
            uiMenu.SelectedItem.ItemAction?.Invoke();
            Logger.Instance?.Log($"{uiMenu.SelectedItem.ItemText.DisplayedString} Pressed");
            clock.Restart();
        }

        if (input.IsActionPressed(ActionMove.Back))
        {
            Logger.Instance?.Log($"Pressed back");
            uiMenu.GoPrevious();
            clock.Restart();
        }
    }
    public void Update(float deltaTime)
    {
        HandleInput();
    }
    public void Draw()
    {
        uiMenu.Render();
    }
    public void Exit()
    {
        Logger.Instance?.Log($"{Mode} state popped off stack");
    }
    public GameMode Mode { get; } = GameMode.Menu;
    public MDirection MenuDirection { get; set; }

    private InputHandler input;
    private UIMenu uiMenu;
    private float inputCooldown = 0.2f;
    private Clock clock;
}