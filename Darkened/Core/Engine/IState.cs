using SFML.Graphics;

namespace Darkened.Core.Engine;

public interface IState
{
    public void Update(float deltaTime);
    public void HandleInput();
    public void Draw();
    public void Exit();
}