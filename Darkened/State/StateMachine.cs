namespace Darkened.State;

public class StateMachine
{
    public void ChangeMode(GameMode newMode)
    {
        Mode = newMode;
    }
    public GameMode Mode { get; private set; }
}