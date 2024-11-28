using Darkened.Core.Entities;
using Darkened.Core.Interfaces;
using Darkened.Core.Systems;
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
        var tree = new Tree<string>();

        tree.AddChildren(["Attack", "Spells", "Items"]);

        List<string> children = tree.GetRootChildren();
        foreach (var child in children)
        {
            Console.WriteLine(child);
        }

        tree.AddChild("Calista", "Spells");
        
        List<string> spells = tree.GetChildren("Spells");
        foreach (var spell in spells)
        {
            Console.WriteLine(spell);   
        }
    }

    // Make all initialization code here
    private static void Initialize()
    {
        windowMode = new VideoMode(800, 600);
        window = new RenderWindow(windowMode, gameTitle);
        window.Closed += OnClose;
    }

    // Window calls this method whenever it wants to close
    // put anything that needs to be done before closing here
    private static void OnClose(object? sender, EventArgs e)
    {
        RenderWindow renderWindow = (RenderWindow)sender;
        renderWindow?.Close();
    }
    
    // private fields
    private static string gameTitle = "Darkened";
    private static RenderWindow window;
    private static VideoMode windowMode;
}