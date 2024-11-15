using SFML.Window;
using SFML.Graphics;

namespace Darkened.Main;
public static class Game
{
    public static void Main()
    {
        Initialize();
        
        while (window.IsOpen)
        {
            window.Clear();
            window.DispatchEvents();
            
            window.Display();
        }
    }

    private static void Initialize()
    {
        windowMode = new VideoMode(800, 600);
        window = new RenderWindow(windowMode, gameTitle);
        window.Closed += OnClose;
    }

    private static void OnClose(object? sender, EventArgs e)
    {
        RenderWindow renderWindow = (RenderWindow)sender;
        renderWindow?.Close();
    }
    
    private static string gameTitle = "Darkened";
    private static RenderWindow window;
    private static VideoMode windowMode;
}