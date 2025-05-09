namespace Darkened.Data;

public interface IFile
{
    public void Write(string content);

    public string Read();

    public void Append(string content);
    
    public bool FileExists(string filePath);
    
    public string Path { get; }
}