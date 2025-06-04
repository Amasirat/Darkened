using Darkened.Data;
using SFML.Window;
using SFML.Graphics;
using Darkened.Core.Engine;
using Darkened.Core.Systems;
using Darkened.Core.Systems.Combat;
using Darkened.Rendering.UI;
using SFML.System;


namespace Darkened.Main;
// This class contains the entry point into the program and is responsible for managing the window
public class Game
{
    // Make all initialization code here
    private void Initialize()
    {
        Logger.Instance?.Log("Initializing Game Window...");
        window = new RenderWindow(new VideoMode(WindowWidth, WindowHeight), GameTitle);
        window.Closed += OnClose;
        gameClock = new Clock();
        stateMachine = new StateMachine(
            window, 
            new MenuState(window, new InputHandler(), GetDefaultStartMenuTree())
        );
    }
    private Tree<MenuItem> GetDefaultStartMenuTree()
    {
        var startMenuTree = new Tree<MenuItem>();
        startMenuTree.AddChildren([
            new MenuItem("Start", () => stateMachine.PushState(new CombatState())),
            new MenuItem("Settings"),
            new MenuItem("Exit", () => stateMachine.PopState() ),
        ]);
        
        startMenuTree.AddChildren([
            new MenuItem("FullScreen"),
            new MenuItem("Keyboard"),
            new MenuItem("Check", () => {Console.WriteLine("Hit");}),
        ], new MenuItem("Settings"));
        
        return startMenuTree;
    }
    public Game()
    {
        Initialize();
    }
    public void Run()
    {
        while (window.IsOpen && stateMachine.IsRunning())
        {
            float deltaTime = gameClock.Restart().AsSeconds();
            window.Clear(Color.Black);
            window.DispatchEvents();
            
            stateMachine.Run(deltaTime);
            
            window.Display();
        }
    }
    // Window calls this method whenever it wants to close
    // put anything that needs to be done before closing here
    private static void OnClose(object? sender, EventArgs e)
    {
        var renderWindow = (RenderWindow)sender;
        renderWindow?.Close();
        Logger.Instance?.Log("Game Window Closed");
    }
    public static uint WindowWidth { get; set; } = 1920;
    public static uint WindowHeight { get; set; } = 1080;
    public string GameTitle { get; } = Globals.ProjectName;
    
    
    private RenderWindow window;
    private StateMachine stateMachine;
    private Clock gameClock;
}