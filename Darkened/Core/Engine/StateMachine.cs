using Darkened.Data;

namespace Darkened.Core.Engine;

public class StateMachine
{
    public StateMachine(IState startingState)
    {
        stateStack = new Stack<IState>();
        stateStack.Push(startingState);
        Logger.Instance?.Log($"StateMachine initialized...");
    }

    public void PushState(IState state)
    {
        if (stateStack.Count == 0)
        {
            throw new Exception("State stack is empty");
        }
        
        CurrentState()?.Exit();
        stateStack.Push(state);
    }

    public void PopState()
    {
        if (stateStack.Count == 0)
        {
            throw new Exception("StateStack is empty");
        }
        
        CurrentState()?.Exit();
        stateStack.Pop();
    }

    public IState? CurrentState()
    {
        return !IsRunning() ? null : stateStack.Peek();
    }

    public void Run(float deltaTime)
    {
        CurrentState()?.Draw();
        CurrentState()?.Update(deltaTime);
    }

    public bool IsRunning()
    {
        return stateStack.Count > 0;
    }
    
    private Stack<IState> stateStack;
}