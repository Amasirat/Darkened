using Darkened.Data;

namespace UnitTests.Data;

public class TreeTests
{
    [SetUp]
    public void Setup()
    {
        testTree = new Tree<string>();
        
        testTree.AddChild("first");
        testTree.AddChild("second");
    }

    [Test]
    public void ChildAddedToNode()
    {
        // Do
        var child = testTree.AddChild("firstNodeAdded", "first");
        // Assert
        Tree<string>.Node? parent = testTree.FindNode("first");
        Assert.That(parent?.Children.Contains(child), Is.True);
    }
    
    [Test]
    public void NewNodeAddedToRoot()
    {
        testTree.AddChild("first");
        
        var node = testTree.FindNode("first");
        Assert.That(node, Is.Not.Null);
    }
    
    [Test]
    public void NewNodeAddedToFirst()
    {
        // do
        testTree.AddChild("first's child", "first");
        
        var addedNode = testTree.FindNode("first's child");
        Assert.That(addedNode, Is.Not.Null);
    }
    
    [Test]
    public void FindNodeFoundNode()
    {
        // Setup
        testTree.AddChild("nodeToFind", "first");
        // Do
        Tree<string>.Node? node = testTree.FindNode("nodeToFind");
        // Assert
        Assert.That(node, Is.Not.Null);
    }
    
    [Test]
    public void FindNodeNotFoundNode()
    {
        var node = testTree.FindNode("NonExistingNode");
        
        Assert.That(node, Is.Null);
    }

    [Test]
    public void CloneSuccessful()
    {
        var newTree = testTree.Clone();
        
        
    }
    private Tree<string> testTree;
}