namespace Darkened.Data;

public class File : IFile
{
    public File(string path)
    {
        Path = path;
        if (!PathExists())
        {
            System.IO.File.CreateText(Path).Dispose();
        }
    }
    public void Write(string content)
    {
        System.IO.File.WriteAllText(Path, content);
    }

    public string Read()
    {
        return System.IO.File.ReadAllText(Path);
    }

    public void Append(string content)
    {
        System.IO.File.AppendAllText(Path, content);
    }

    public bool PathExists()
    {
        return System.IO.File.Exists(Path);
    }
    
    public string Path { get; private set; }
}