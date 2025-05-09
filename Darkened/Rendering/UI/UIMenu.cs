using Darkened.Core.Entities;
using Darkened.Data;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Darkened.Rendering.UI;

public class UIMenu
{
    public UIMenu(RenderWindow window, Tree<string> menuTree)
    {
        _window = window;
        _itemsTree = (Tree<string>)menuTree.Clone();
        Initialize();
    }
    public void Render()
    {
        RenderMenuItems(_visibleItems);
    }

    private void RenderMenuItems(List<Text> menuItems)
    {
        // TODO: Row Direction does not layout properly
        float PositionX = 20.0f;
        float PositionY = 20.0f;
        foreach (var menuItem in menuItems)
        {
            menuItem.Position = new Vector2f(PositionX, PositionY);
            menuItem.FillColor = menuItem == SelectedItem ? Color.Red : Color.White;
            _window.Draw(menuItem);
            PositionX += Direction == MDirection.Row ? Spacing : 0.0f;
            PositionY += Direction == MDirection.Column ? Spacing : 0.0f;
        }
    }

    public void MoveSelectedItem(int direction)
    {
        if (_visibleItems.Count == 0) return;
        int currentIndex = _visibleItems.IndexOf(SelectedItem);
        int newIndex = (currentIndex + direction + _visibleItems.Count) % _visibleItems.Count;
        SelectedItem = _visibleItems[newIndex];
    }

    public virtual void HandleInput()
    {
        if (_clock.ElapsedTime.AsSeconds() < InputCoolDown)
            return;
        
        switch (Direction)
        {
            case MDirection.Column:
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                {
                    MoveSelectedItem(-1);
                    _clock.Restart();
                }

                if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
                {
                    MoveSelectedItem(1);
                    _clock.Restart();
                }
                break;
            }

            case MDirection.Row:
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
                {
                    _clock.Restart();
                    MoveSelectedItem(-1);
                }

                if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
                {
                    _clock.Restart();
                    MoveSelectedItem(1);
                }
                break;
            }
            default:
                throw new ArgumentException("UIMenu has corrupted value or invalid direction.");
        }
        
        if (Keyboard.IsKeyPressed(Keyboard.Key.Enter))
        {
            if(_actionMap.ContainsKey(SelectedItem.DisplayedString) && _actionMap[SelectedItem.DisplayedString] != null)
                _actionMap[SelectedItem.DisplayedString]?.Invoke();
            _clock.Restart();
        }

        if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
        {
            _clock.Restart();
            if (_currentParent?.Value != null)
            {
                GoPrevious();
            }
        }
    }

    public void AddActionToSelection(string selection, Action inputAction)
    {
        if(_actionMap.ContainsKey(selection))
            _actionMap[selection] += inputAction;
        else
        {
            _actionMap.Add(selection, inputAction);
        }
    }
    
    public void UpdateItemsTree(Tree<string> menuTree)
    {
        _itemsTree = menuTree;
    }
    
    public void GoNext(string selection)
    {
        _currentParent = _itemsTree.FindNode(selection);
        _selectionPath.AddLast(_currentParent);
        UpdateVisibleItems();
    }

    public void GoPrevious()
    {
        _selectionPath.RemoveLast();
        _currentParent = _selectionPath.Last();
        UpdateVisibleItems();
    }
    private void UpdateVisibleItems()
    {
        _visibleItems.Clear();
        foreach (var item in _currentParent?.Children)
        {
            _visibleItems.Add(new Text(item.Value, Globals.DefaultFont));
        }
    }
    
    private void Initialize()
    {
        _currentParent = _itemsTree.Root;
        _visibleItems = new List<Text>();
        foreach (var child in _currentParent?.Children)
        {
            _visibleItems.Add(new Text(child.Value, Globals.DefaultFont));
        }
        SelectedItem = _visibleItems.FirstOrDefault();
        _actionMap = new Dictionary<string, Action?>();

        foreach (var item in _visibleItems)
        {
            _actionMap.Add(item.DisplayedString, () => Console.WriteLine($"Selected: {item.DisplayedString}"));
            _actionMap[item.DisplayedString] += () => Logger.Instance.Log($"Selected: {item.DisplayedString}");
        }

        _selectionPath = new LinkedList<Tree<string>.Node?>();
        _selectionPath.AddLast(_currentParent);
    }

    public float Spacing { get; set; } = 100.0f;
    public float InputCoolDown { get; set; } = 0.2f;
    public MDirection Direction { get; set; } = MDirection.Column;

    public enum MDirection
    {
        Column,
        Row
    }
    
    private Text SelectedItem { get; set; }
    protected Tree<string> _itemsTree;
    protected Dictionary<string, Action?> _actionMap;
    private Tree<string>.Node? _currentParent;
    private LinkedList<Tree<string>.Node?> _selectionPath;
    private List<Text> _visibleItems;
    protected RenderWindow _window;
    private Clock _clock = new Clock();
}