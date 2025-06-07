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
        currentParent = itemsTree.Root;
        GiveActionToNodes();
        visibleItems = [];
        UpdateVisibleItems();
        SelectedItem = visibleItems.FirstOrDefault() ?? 
                       throw new Exception(
                           "ERROR: There is no initial selection item selected. " +
                           "(Either itemTree given to UIMenu is invalid or has no children");
        selectionPath = [];
        selectionPath.AddLast(currentParent);
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
        // -1 moves the selection by one in the visibleItems list
        // (lower index means going up, towards the first item)
        MoveSelectedItem(-1);
    }

    public void MoveDownSelectedItem()
    {
        // -1 moves down the selection by one in the visibleItems list
        // (higher index means going down)
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
        if (IsOnRoot()) return;
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
    // All internal nodes that are not leaves can be given the GoNext() action
    // That way the caller does not need to know how UIMenu handles updating visible items
    private void GiveActionToNodes()
    {
        var bfsQueue = new Queue<Tree<MenuItem>.Node>();
        bfsQueue.Enqueue(itemsTree.Root);

        while (bfsQueue.Count > 0)
        {
            var current = bfsQueue.Dequeue();
            foreach (var child in current.Children)
            {
                if (child.Children.Count != 0)
                {
                    child.Value?.AddAction(() => GoNext(child.Value));
                    bfsQueue.Enqueue(child);
                }
            }
        }
    }
    
// When selectionPath has only one node, it means the UIMenu is on the root list of items
    private bool IsOnRoot()
    { 
        return selectionPath.Count <= 1;
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