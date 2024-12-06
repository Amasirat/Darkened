namespace Darkened.Core.Interfaces;

public interface IFInputHandler
{
    public string CombatInputHandler(int actionTreeDepth);
    
    public Dictionary<string, string> InputMap { get; set; }
}