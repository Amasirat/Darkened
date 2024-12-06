namespace Darkened.Core.Systems;

public static class ActionHandler
{
    public static string ToString(Actions action)
    {
        return action switch
        {
            Actions.Attack => "Attack",
            Actions.Magic => "Magic",
            Actions.Defend => "Defend",
            Actions.UseItem => "Items",
            _ => ""
        };
    }

    public static Actions ToEnum(string action)
    {
        return action switch
        {
            "Attack" => Actions.Attack,
            "Magic" => Actions.Magic,
            "Defend" => Actions.Defend,
            "Items" => Actions.UseItem,
            _ => throw new Exception("Invalid action")
        };
    }

    public static ActionMove HandleActionPath(LinkedList<string> actionPath, List<string> turnEndingActions)
    {
        throw new NotImplementedException();
    }
    public enum Actions
    {
        Attack,
        Magic,
        Defend,
        UseItem
    }
}