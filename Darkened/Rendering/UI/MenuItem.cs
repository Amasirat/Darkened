using Darkened.Data;
using SFML.Graphics;

namespace Darkened.Rendering.UI;

public class MenuItem
{
    public MenuItem(string itemString, Action? action)
    {
        this.itemString = itemString;
        ItemText = new Text(itemString, Globals.DefaultFont);
        ItemAction += action;
    }
    
    public MenuItem(string itemString) : this(itemString, () => {})
    {
    }
    public bool Equals(MenuItem other)
    {
        return itemString == other.itemString;
    }

    public void AddAction(Action? action)
    {
        ItemAction += action;
    }
    public Text ItemText { get; }
    public Action? ItemAction { get; private set; }
    // The string behind this MenuItem, used for checking equality
    private string itemString;
}