using SFML.Graphics;

namespace Darkened.Core.Engine;

public class StateMachine
{
    public StateMachine(RenderWindow mainWindow, IState startingState)
    {
        window = mainWindow;
        stateStack = new Stack<IState>();
        stateStack.Push(startingState);
    }

    public void PushState(IState state)
    {
        if (stateStack.Count == 0)
        {
            throw new Exception("State stack is empty");
        }
        
        CurrentState().Exit();
        stateStack.Push(state);
    }

    public void PopState()
    {
        if (stateStack.Count == 0)
        {
            throw new Exception("StateStack is empty");
        }
        
        CurrentState().Exit();
        stateStack.Pop();
    }

    public IState CurrentState()
    {
        return stateStack.Peek();
    }

    public void Run(float deltaTime)
    {
        var currentState = CurrentState();
        currentState.Draw();
        currentState.Update(deltaTime);
    }

    public bool IsRunning()
    {
        return stateStack.Count > 0;
    }
    
    private Stack<IState> stateStack;
    private RenderWindow window;
}