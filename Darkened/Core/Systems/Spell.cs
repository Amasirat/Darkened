using Darkened.Data.Interface;

namespace Darkened.Core.Systems;

public class Spell
{
    // Master Constructor
    public Spell(string spellName = "Calista", 
        string spellDescription = "A fundamental spell that can generate heat. " +
                                  "If you could see, you would behold the most beautiful rays of light " +
                                  "emanate from the spell caster. " +
                                  "The rays captivated many mages, therefore being called Calista." +
                                  "Needs a spell from Fuel type to work its wonders", 
        Type spellType = Type.Heat)
    {
        SpellName = spellName;
        SpellType = spellType;
        SpellDescription = spellDescription;
    }

    public Spell(IJson spellData, object primaryKey)
    {
    }
    public enum Type
    {
        Heat,
        Cold,
        Kinetic,
        Fuel,
        Mystic,
    }
    
    public string SpellName { get; private set; }
    public string SpellDescription { get; private set; }
    public Type SpellType { get; private set; }
}