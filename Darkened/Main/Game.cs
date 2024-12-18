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
        Initialize();
        var player = new Player();
        
        List<ICombator> enemies =
        [
            new Enemy()
        ];
        var encounter = new CombatEncounter(player, enemies, true);
        encounter.CombatEnded += (bool playerWon) => Console.WriteLine(playerWon);
        
        string attackString = ActionHandler.ToString(ActionHandler.Actions.Attack);
        var playerCombatMenu = new CombatMenu(window, encounter.ActionTree);
        
        playerCombatMenu.AddActionToSelection( attackString, () => playerCombatMenu.GoNext(attackString));
        playerCombatMenu.AddActionToSelection(ActionHandler.ToString(ActionHandler.Actions.Defend), () => ActionHandler.Defend(player));
        playerCombatMenu.AddActionToSelection($"{attackString}-{player.Name}", () => ActionHandler.Attack(player, player));
        foreach (var enemy in enemies)
        {
            playerCombatMenu.AddActionToSelection($"{attackString}-{enemy.Name}", () => ActionHandler.Attack(player, enemy));
        }
        
        player.CombatRenderer += playerCombatMenu.TakeStateAndDrawMenu;
        
        encounter.StartEncounter();
    }
    // Make all initialization code here
    private static void Initialize()
    {
        Logger.Instance.Log("Initializing Game Window...");
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