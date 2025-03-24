using Darkened.Data;
using SFML.Window;
using SFML.Graphics;

namespace Darkened.Main;
// This class contains the entry point into the program and is responsible for managing the window
public static class Game
{
    public static void Main()
    {
        Initialize();
    }
    // Make all initialization code here
    private static void Initialize()
    {
        // Logger.Instance.Log("Initializing Game Window...");
        windowMode = new VideoMode(WindowWidth, WindowHeight);
        window = new RenderWindow(windowMode, gameTitle);
        window.Closed += OnClose;
    }

    // Window calls this method whenever it wants to close
    // put anything that needs to be done before closing here
    private static void OnClose(object? sender, EventArgs e)
    {
        Logger.Instance.Log("Game Window Closed");
        RenderWindow renderWindow = (RenderWindow)sender;
        renderWindow?.Close();
    }
    
    private static string gameTitle = Globals.ProjectName;
    private static RenderWindow window;
    private static VideoMode windowMode;

    public static uint WindowWidth { get; set; } = 1920;
    public static uint WindowHeight { get; set; } = 1080;
}