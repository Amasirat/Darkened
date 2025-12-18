namespace Darkened.Engine.Core.Interfaces;

public interface IStateMachine
{
    void PushState(IState state);
    void PopState();
}