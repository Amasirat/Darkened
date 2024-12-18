using System.Diagnostics.Tracing;
using System.Numerics;
using System.Text;
using System.Threading.Channels;
using Darkened.Core.Entities;
using Darkened.Core.Interfaces;
using Darkened.Core.Systems;
using Darkened.Data;
using Darkened.SFML;
using Darkened.SFML.UI;
using SFML.Audio;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace Darkened.Main;
// This class contains the entry point into the program and is responsible for managing the window
public static class Game
{
    public static void Main()
    {
        Logger.Instance.Log("Logged");
        // Initialize();
        // var player = new Player();
        // var enemy= new Enemy();
        //
        // List<ICombator> enemies =
        // [
        //     enemy
        // ];
        // var encounter = new CombatEncounter(player, enemies, true);
        //
        // var combatMenu = new CombatMenu(window, encounter.ActionTree);
        // combatMenu.AddActionToSelection(
        //     ActionHandler.ToString(
        //         ActionHandler.Actions.Attack), 
        //     () => combatMenu.GoNext(ActionHandler.ToString(ActionHandler.Actions.Attack)));
        // combatMenu.AddActionToSelection(ActionHandler.ToString(ActionHandler.Actions.Defend), () => ActionHandler.Defend(player));
        //
        // player.CombatRenderer += combatMenu.TakeStateAndDrawMenu;
        //
        // encounter.StartEncounter();
    }
    // Make all initialization code here
    private static void Initialize()
    {
        windowMode = new VideoMode(WindowWidth, WindowHeight);
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
    
    private static string gameTitle = Globals.ProjectName;
    private static RenderWindow window;
    private static VideoMode windowMode;

    public static uint WindowWidth { get; set; } = 1920;
    public static uint WindowHeight { get; set; } = 1080;
}