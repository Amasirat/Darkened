public class Stat
{
// Master Constructor
    public Stat(StatType type, int max, int value) : this(type, max)
    {
        Value = value;
    }
    public Stat(StatType type, int max)
    {
        statName = type;
        Max = max;
        Value = max;
    }
// use negative values to decrease stat num
    public void ChangeMaxValue(int amount)
    {
        Max += amount;
    }
// use negative values to decrease stat num
    public void ChangeValue(int amount)
    {
        Value += amount;
    }

    public override string ToString()
    {
        switch(statName)
        {
            case StatType.HP:
                return "HP";
            case StatType.AP:
                return "AP";
            case StatType.ATT:
                return "Att";
            case StatType.DEF:
                return "DEF";
            case StatType.AGI:
                return "AGI";
            case StatType.LUCK:
                return "LUCK";
            default:
                return "";
        }   
    }

    public int Max
    {
        get { return maxValue; }
        set
        {
            maxValue = value;
            if(maxValue < 1)
            {
                maxValue = 1;   
            }
        }
    }

    public enum StatType
    {
        HP,
        AP,
        ATT,
        DEF,
        AGI,
        LUCK,
    }
    public int Value
    {
        get { return value; }
        set
        {
            this.value = value;

            if(this.value > Max)
            {
                this.value = Max;
            }
            
            if(this.value < 0)
            {
                this.value = 0;
            }
        }
    }

    private StatType statName;
    private int maxValue;
    private int value;
}