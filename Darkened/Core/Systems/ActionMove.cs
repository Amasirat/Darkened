using Darkened.Core.Interfaces;

namespace Darkened.Core.Systems;
public struct ActionMove
{
    public ActionMove(ActionHandler.Actions action, ICombator? combator = null)
    {
        Value = action;
        Target = combator;
    }
    public ActionHandler.Actions Value { get; set; }
    public ICombator? Target { get; set; }
}