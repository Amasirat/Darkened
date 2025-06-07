using Darkened.Data;
using SFML.Graphics;

namespace Darkened.Rendering.UI;

public class MenuItem
{
    public MenuItem(string itemString, Action? action)
    {
        ItemText = new Text(itemString, Globals.DefaultFont);
        ItemAction += action;
    }
    
    public MenuItem(string itemString) : this(itemString, () => {})
    {
    }

    public override bool Equals(object? obj)
    {
        if (obj is not MenuItem other)
            return false;
        
        return ItemText.DisplayedString == other.ItemText.DisplayedString;
    }

    public override int GetHashCode()
    {
        return ItemText.DisplayedString.GetHashCode();
    }

    public void AddAction(Action? action)
    {
        ItemAction += action;
    }
    public Text ItemText { get; }
    public Action? ItemAction { get; private set; }
}