namespace Darkened.Data;

public class File : IFile
{
    public File(string path)
    {
        Path = path;
        // if directory does not previously exist create it
        Console.WriteLine(Directory.GetParent(path));
        Directory.GetParent(Path)?.Create();
        if (!PathExists())
        {
            // Create a new file and dispose of the resource that did so
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