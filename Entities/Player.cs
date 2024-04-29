namespace Entities;

public class Player
{
    public Player(string name = "user")
    {

    }

//properties
    public string Name
    {
        get { return name; }
        set
        {
            if(value.Length > 512)
            {
                throw new InvalidDataException("Size of name is too much!");
            }
            name = value;
        }
    }

    private string name;
    private int level;
}
