using SFML.Graphics;

namespace Darkened.Data;

public static class Globals
{
    public static bool IsDebug { get; set; } = true;
    public const string ProjectName = "Darkened";
    public static readonly string LogDirectory = !IsDebug ? 
        Path.Join(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), 
            Path.Join(ProjectName, "Logs")) : 
        
        Path.Join(
            Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.FullName, 
            "obj", "Debug", "Logs");
    
    public static readonly string ProjectDirectory = Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.FullName 
                                                     ?? throw new DirectoryNotFoundException();
    public static readonly Font DefaultFont = new Font(Path.Join(ProjectDirectory, "Assets/Fonts/Poppins-Light.ttf"));
}