using Darkened.Data;
using SFML.Graphics;
using SFML.System;

namespace Darkened.Rendering.UI;

public class CheckMenuItem : MenuItem
{
    // Primary Constructor
    public CheckMenuItem(string itemString, bool isChecked, Action? action) : base(
        itemString, 
        action
    )
    {
        AddAction(OnCheck);
        IsChecked = isChecked;
        ItemText = new Text(itemString, Globals.DefaultFont);
    }

    public CheckMenuItem(string itemString, bool isChecked) : this(itemString, isChecked, null)
    {}
    
    public CheckMenuItem(string itemString, Action? action) : this(itemString, false, action)
    {}

    public override void Render(RenderWindow window, Vector2f position, bool isSelected)
    {
        base.Render(window, position, isSelected);
        string CheckString = IsChecked ? checkBoxUnicode["Checked"] : checkBoxUnicode["Unchecked"];
        var checkText = new Text(CheckString, Globals.DefaultFont);
        checkText.Position = new Vector2f(position.X + 170f, position.Y);
        checkText.FillColor = isSelected ? Color.Red : Color.White;
        window.Draw(checkText);
    }
    private void OnCheck()
    {
        IsChecked = !IsChecked;
        Console.WriteLine($"IsChecked: {IsChecked}");
    }

    public bool IsChecked { get; private set; }
    
    private Dictionary<string, string> checkBoxUnicode = new Dictionary<string, string>()
    {
        ["Checked"] = "\u2705",
        ["Unchecked"] = "\u274e"
    };
}