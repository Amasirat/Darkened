namespace Darkened.Data;

public class JsonParser
{
    public JsonParser(string filePath)
    {
        FilePath = filePath;
        if(!File.Exists(FilePath))
            throw new FileNotFoundException("File not found", FilePath);
    }
    
    public Dictionary<string, object> Parse(object primaryKey)
    {
        Dictionary<string, object> result = new();

        switch (primaryKey)
        {
            case int intPrimaryKey:
                break;
        }
        
        return result;
    }

    public void Store(Dictionary<string, object> data)
    {
        
    }
    
    public string FilePath { get; set; }
}