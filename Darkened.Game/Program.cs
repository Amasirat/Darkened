using Darkened.Engine.Logging;

namespace Darkened.Game;

public class Program
{
    public static void Main()
    {
        Logger.Instance.LogInformation("Darkened Game");
        Logger.Instance.LogWarning("Darkened Game");
        Logger.Instance.LogError("Darkened Game");
        
        Logger.Instance.LogError("Darkened Game");
        
        Logger.Instance.ShutDown();
    }
}