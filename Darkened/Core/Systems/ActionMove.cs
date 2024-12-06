using Darkened.Core.Interfaces;

namespace Darkened.Core.Systems;
public struct ActionMove
{
    public ActionHandler.Actions Act { get; set; }
    public ICombator? Target { get; set; }
}