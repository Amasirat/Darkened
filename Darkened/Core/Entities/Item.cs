namespace Darkened.Core.Entities;

public class Item
{
    public Item(string name = "World Map", string description = "A map", Type itemType = Type.Map)
    {
        Name = name;
        Description = description;
        ItemType = itemType;
    }

    public enum Type
    {
        Healing,
        Map,
        Throwable,
        Special,
    }
    // Properties
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Type ItemType { get; private set; }
}