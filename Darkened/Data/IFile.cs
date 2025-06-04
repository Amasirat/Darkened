namespace Darkened.Data;

public interface IFile
{
    public void Write(string content);

    public string Read();

    public void Append(string content);
    
    public bool PathExists();
    
    public string Path { get; }
}