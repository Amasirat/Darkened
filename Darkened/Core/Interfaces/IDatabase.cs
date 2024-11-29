namespace Darkened.Data.Interface;

public interface IDatabase
{
    public bool Store(Dictionary<string, object> data);
    public Dictionary<string, object> Retrieve(object primaryKey);
    
    public string Database { get; set; }
    public string TableName { get; set; }
}