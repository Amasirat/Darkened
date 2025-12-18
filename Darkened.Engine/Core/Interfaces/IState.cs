namespace Darkened.Engine.Core.Interfaces;

public interface IState
{
    void Update(float deltaTime);
    void HandleInput();
    void Draw();
    void Exit();
}