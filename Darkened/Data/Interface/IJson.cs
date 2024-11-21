namespace Darkened.Data.Interface;

public interface IJson
{
    public Dictionary<string, object> Parse(object primaryKey);
    public bool Store(Dictionary<string, object> data);
    
    public string JsonFilePath { get; set; }
}