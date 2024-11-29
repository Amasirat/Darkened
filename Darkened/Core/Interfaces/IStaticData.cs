namespace Darkened.Data.Interface;

public interface IStaticData
{
    public Dictionary<string, object> Parse(object primaryKey);
    public void Store(Dictionary<string, object> data);
    
    public string FilePath { get; set; }
}