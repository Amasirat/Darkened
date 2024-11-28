namespace Darkened.Data;

public class Tree<T>
{
    public Tree()
    {
        _root = new Node();
    }

    public Tree(Tree<T> tree)
    {
        _root = tree._root;
    }
    
    // Adds a child to root
    public Node AddChild(T child)
    {
        var childNode = new Node(child);
        
        _root.Children.Add(childNode);
        return childNode;
    }
    // Overflow of above that adds a node to another non-root node
    public Node AddChild(T child, T parentValue)
    {
        Node? parent = FindNode(parentValue);
        Node childNode = new Node(child);
        parent?.Children.Add(childNode);

        return childNode;
    }
    
    // Add children to root
    public void AddChildren(T[] children)
    {
        foreach (var child in children)
        {
            AddChild(child);
        }
    }
    // Overflow of above, adding children to a specific node
    // Complexity is most likely O(m*b^d) m being number of children
    // and branching factor which is likely really variable. and d is max depth.
    // Candidate for optimization if having trouble with performance
    public void AddChildren(T[] children, T parentValue)
    {
        foreach (var child in children)
        {
            AddChild(child, parentValue);
        }
    }
    
    // Finds node by using a BFS algorithm
    public Node? FindNode(T parentValue)
    {
        Queue<Node> queue = new Queue<Node>();

        foreach (var child in _root.Children)
        {
            queue.Enqueue(child);
        }

        if (queue.Count == 0) throw new Exception("Tree has no children");

        while (queue.Count != 0)
        {
            var child = queue.Dequeue();
            if (child.Value.Equals(parentValue))
            {
                return child;
            }
            
            foreach (var childItems in child.Children)
            {
                queue.Enqueue(childItems);
            }
        }
        return null;
    }

    public List<T> GetRootChildren()
    {
        List<T> rootChildren = new List<T>();

        foreach (var child in _root.Children)
        {
            rootChildren.Add(child.Value);
        }
        
        return rootChildren;
    }
    public List<T> GetChildren(T nodeValue)
    {
        Node? node = FindNode(nodeValue);
        
        if(node == null) throw new Exception("The desired node was not found: Tree<T>.GetChildren()");
        
        List<T> childValues = new List<T>();

        foreach (var child in node?.Children)
        {
            childValues.Add(child.Value);
        }
        return childValues;
    }
    public struct Node
    {
        public Node()
        {
            Children = new List<Node>();
        }
        
        public Node(T? value)
        {
            Children = new List<Node>();
            Value = value;
        }
        public T? Value { get; set; }
        public List<Node> Children { get; set; }
    }

    private Node _root;
}