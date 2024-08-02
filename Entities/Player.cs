namespace Entities;

public class Player
{
// Master Constructor
    public Player(string name = "user", int level = 1)
    {
        Name = name;
        this.level = level;
    }

// Properties
    public string Name
    {
        get { if (name == null) return ""; else return name; }
        set
        {
            if(value.Length > 512)
            {
                throw new InvalidDataException("The name given is too long!");
            }
            name = value;
        }
    }

    public int Level { get{return level;} }

    private string? name;
    private int hp;
    private int level;
    private int exp;
    private int exp_required;
}
