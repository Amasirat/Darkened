using Darkened.Core.Interfaces;

namespace Darkened.Core.Entities;


public interface IMove
{
    public ICombator target { get; set; }
}

public struct Move : IMove
{
    public string title { get; set; }
    public ICombator target { get; set; }
}
public struct Magic : IMove
{
    public List<string> spells { get; set; }
    public ICombator target { get; set; }
}