using System.Text.Json;
namespace Darkened.Data;
using Interfaces;

public class JsonParser<T>(IFile file, JsonSerializerOptions? options)
{
    public void Store(T data)
    {
        if(!File.PathExists())
            throw new FileNotFoundException("File not found", File.Path);
        string jsonString = JsonSerializer.Serialize(data, Options);
        File.Write(jsonString);
    }
    public T Load()
    {
        if(!File.PathExists())
            throw new FileNotFoundException("File not found", File.Path);
        string jsonString = File.Read();
        T data = JsonSerializer.Deserialize<T>(jsonString, Options) ?? throw new Exception("Invalid file format");
        return data;
    }
    private IFile File { get; set; } = file;
    private JsonSerializerOptions Options { get; set; } = options ?? new JsonSerializerOptions { WriteIndented = true };
}