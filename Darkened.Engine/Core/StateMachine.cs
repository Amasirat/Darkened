using Darkened.Engine.Core.Interfaces;

namespace Darkened.Engine.Core;

public class StateMachine : IStateMachine
{
    public StateMachine(IState startingState)
    {
        _stateStack = new Stack<IState>();
        PushState(startingState);
    }

    public void PushState(IState state)
    {
        _currentState.Exit();
        _stateStack.Push(state);
        _currentState = state;
    }

    public void PopState()
    {
        if (_stateStack.Count == 0) throw new Exception("State stack is empty");
        
        _currentState.Exit();
        _stateStack.Pop();
    }

    public void Run(float deltaTime)
    {
        _currentState.Draw();
        _currentState.Update(deltaTime);
    }

    public IState CurrentState()
    {
        return _currentState;
    }

    private Stack<IState> _stateStack;
    private IState _currentState;
}