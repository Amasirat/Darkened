using Darkened.Core.Entities;
using Darkened.Core.Interfaces;
using Darkened.Data;

namespace Darkened.Core.Systems;

public static class Renderer
{
    public static void Render(Tree<string> actionTree, string parent, List<ICombator> combators, Player player)
    {
        Console.Clear();
        var menuItems = new List<string>();
        if (parent == "")
        {
            menuItems = actionTree?.GetRootChildren();
        }
        else
        {
            menuItems = actionTree?.GetChildren(parent);
        }

        if (menuItems.Count == 0)
        {
            string emptyNotifyMessage = parent != "" ? $"No {parent}" : $"Nothing to show here...";
            Console.WriteLine(emptyNotifyMessage);
        }

        foreach (var item in menuItems)
        {
            Console.Write($"{item}\t");
        }
        Console.WriteLine("\n--------------------------------------------------------");
        Console.WriteLine("--------------------------------------------------------");
        
        Console.WriteLine($"Health: {player.Health}/{player.MaxHealth}");
        Console.WriteLine($"Stamina: {player.Stamina}/{player.MaxStamina}");
    }
}