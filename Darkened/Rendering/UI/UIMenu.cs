using Darkened.Core.Entities;
using Darkened.Data;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Darkened.Rendering.UI;

public class UIMenu
{
    public UIMenu(RenderWindow window, Tree<MenuItem> menuTree)
    {
        this.window = window;
        itemsTree = (Tree<MenuItem>)menuTree.Clone();
        Initialize();
    }
    public void Render()
    {
        RenderMenuItems(visibleItems);
    }

    private void RenderMenuItems(List<MenuItem> menuItems)
    {
        // TODO: Row Direction does not layout properly
        float positionX = 20.0f;
        float positionY = 20.0f;
        foreach (var menuItem in menuItems)
        {
            menuItem.ItemText.Position = new Vector2f(positionX, positionY);
            menuItem.ItemText.FillColor = menuItem.Equals(SelectedItem) ? Color.Red : Color.White;
            window.Draw(menuItem.ItemText);
            positionX += Direction == MDirection.Row ? Spacing : 0.0f;
            positionY += Direction == MDirection.Column ? Spacing : 0.0f;
        }
    }

    private void MoveSelectedItem(int direction)
    {
        if (visibleItems.Count == 0) return;
        int currentIndex = visibleItems.IndexOf(SelectedItem);
        int newIndex = (currentIndex + direction + visibleItems.Count) % visibleItems.Count;
        SelectedItem = visibleItems[newIndex];
    }
    public void MoveUpSelectedItem()
    {
        MoveSelectedItem(-1);
    }

    public void MoveDownSelectedItem()
    {
        MoveSelectedItem(1);
    }
    
    public void UpdateItemsTree(Tree<MenuItem> newMenuTree)
    {
        itemsTree = newMenuTree;
    }
    
    public void GoNext(MenuItem selection)
    {
        currentParent = itemsTree.FindNode(selection);
        selectionPath.AddLast(currentParent);
        UpdateVisibleItems();
    }

    public void GoPrevious()
    {
        selectionPath.RemoveLast();
        currentParent = selectionPath.Last();
        UpdateVisibleItems();
    }
    private void UpdateVisibleItems()
    {
        visibleItems.Clear();
        foreach (var item in currentParent?.Children)
        {
            visibleItems.Add(item.Value);
        }
    }
    
    private void Initialize()
    {
        currentParent = itemsTree.Root;
        visibleItems = [];

        UpdateVisibleItems();
        SelectedItem = visibleItems.FirstOrDefault();

        selectionPath = [];
        selectionPath.AddLast(currentParent);
    }

    public float Spacing { get; set; } = 100.0f;
    public MDirection Direction { get; set; } = MDirection.Column;
    
    public MenuItem SelectedItem;
    protected Tree<MenuItem> itemsTree;
    private Tree<MenuItem>.Node? currentParent;
    private LinkedList<Tree<MenuItem>.Node?> selectionPath;
    private List<MenuItem> visibleItems;
    protected RenderWindow window;
}