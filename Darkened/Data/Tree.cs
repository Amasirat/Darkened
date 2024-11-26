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

    public void AddChild(T child, T parentValue)
    {
        Node parent = FindNode(parentValue);
        parent.Children?.Append(new Node(child, []));
    }

    public void AddChildren(T[] children, T parentValue)
    {
        foreach (var child in children)
        {
            AddChild(child, parentValue);
        }
    }
    
    // Finds node by using the BFS algorithm
    private Node FindNode(T parentValue)
    {
        Queue<Node> queue = new Queue<Node>();

        foreach (var child in _root.Children)
        {
            queue.Enqueue(child);
        }

        if (queue.Count == 0) throw new Exception("Tree has no children");

        foreach (var child in queue)
        {
            if (child.Value.Equals(parentValue))
            {
                return child;
            }

            queue.Dequeue();
            foreach (var childItems in child.Children)
            {
                queue.Enqueue(childItems);
            }
        }
        // Still not sure how to handle non-existing node,
        // this is a temp thing to have it compile
        return new Node();
    }
    
    public T[] GetChildren(Node node)
    {
        if(node.Children == null) throw new NullReferenceException();
        
        int length = node.Children?.Length ?? 0;
        T[] values = new T[length];

        foreach (var child in node.Children)
        {
            values.Append(child.Value);
        }

        return values;
    }
    public struct Node(T? value, Node[] children)
    {
        public T? Value { get; set; } = value;
        public Node[] Children { get; set; } = children;
    }

    private Node _root;
}