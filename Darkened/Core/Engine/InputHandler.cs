using SFML.Window;

namespace Darkened.Core.Engine;

public class InputHandler
{
    public InputHandler()
    {
        ActionMap = DefaultActionMap();
    }

    public bool IsActionPressed(ActionMove actionMove)
    {
        bool isPressed = false;
        foreach (var enumKey in ActionMap[actionMove])
        {
            if (Keyboard.IsKeyPressed(enumKey))
            {
                isPressed = true;
                break;
            }
        }
        return isPressed;
    }

    public Dictionary<ActionMove, List<Keyboard.Key>> DefaultActionMap()
    {
        return new Dictionary<ActionMove, List<Keyboard.Key>>()
        {
            [ActionMove.MoveUp] = [Keyboard.Key.W, Keyboard.Key.Up],
            [ActionMove.MoveDown] = [Keyboard.Key.S, Keyboard.Key.Down],
            [ActionMove.MoveLeft] = [Keyboard.Key.A, Keyboard.Key.Left],
            [ActionMove.MoveRight] = [Keyboard.Key.D, Keyboard.Key.Right],
            [ActionMove.Back] = [Keyboard.Key.Backspace],
            [ActionMove.Pause] = [Keyboard.Key.Escape],
            [ActionMove.Interact] = [Keyboard.Key.E, Keyboard.Key.Enter],
        };
    }
    
    public Dictionary<ActionMove, List<Keyboard.Key>> ActionMap;
}