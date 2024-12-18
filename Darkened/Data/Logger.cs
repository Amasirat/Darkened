using System.Text;
using SFML.System;

namespace Darkened.Data;
public class Logger
{
    private Logger()
    {
        Initialize();
    }

    private void Initialize()
    {
        if (!Directory.Exists(Globals.LogDirectory))
        {
            Directory.CreateDirectory(Globals.LogDirectory);
        }
        _logOutPath = Path.Join(Globals.LogDirectory, DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss") + ".log");
        Console.WriteLine(_logOutPath);
        fileStream = new FileStream(_logOutPath, FileMode.OpenOrCreate, FileAccess.Write);
        fileStream.Close();
    }
    public void Log(string message)
    {
        fileStream = new FileStream(_logOutPath, FileMode.Append);
        
        string Line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}: {message}";
        byte[] buffer = Encoding.UTF8.GetBytes(Line);
        fileStream.Write(buffer, 0, buffer.Length);
        
        fileStream.Close();
    }
    public static Logger Instance
    {
        get
        {
            if (_instance == null)
                lock (_lock)
                {
                    _instance ??= new Logger();
                }
            
            return _instance;
        }
    }

    private static string _logOutPath;
    private static Logger _instance;
    private static readonly object _lock = new();
    private FileStream fileStream;
}