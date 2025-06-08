using Darkened.Data;
using SFML.Graphics;
using SFML.System;

namespace Darkened.Rendering.UI;

public class MenuItem
{
    public MenuItem(string itemString, Action? action)
    {
        ItemText = new Text(itemString, Globals.DefaultFont);
        ItemAction += action;
        itemColors = GetDefaultColors();
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
    
    public virtual void Render(RenderWindow window, Vector2f position, bool isSelected)
    {
        ItemText.Position = new Vector2f(position.X, position.Y);
        ItemText.FillColor = isSelected ? itemColors["SelectedColor"] : itemColors["NormalColor"];
        window.Draw(ItemText);
    }

    public void AddAction(Action? action)
    {
        ItemAction += action;
    }

    private Dictionary<string, Color> GetDefaultColors()
    {
        return new Dictionary<string, Color>()
        {
            ["SelectedColor"] = Color.Red,
            ["NormalColor"] = Color.White
        };
    }
    public Text ItemText { get; protected set; }
    public Action? ItemAction { get; private set; }
    
    private Dictionary<string, Color> itemColors;
}