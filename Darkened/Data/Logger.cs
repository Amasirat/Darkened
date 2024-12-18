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
        var fileStream = new FileStream(_logOutPath, FileMode.OpenOrCreate, FileAccess.Write);
        fileStream.Close();
    }
    public void Log(string message)
    {
        var fileStream = new FileStream(_logOutPath, FileMode.Append);
        
        string line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}: {message}\n";
        byte[] buffer = Encoding.UTF8.GetBytes(line);
        fileStream.Write(buffer, 0, buffer.Length);
        
        fileStream.Close();
    }
    public static Logger? Instance
    {
        get
        {
            if (_instance != null) return _instance;
            lock (_lock)
            {
                _instance ??= new Logger();
            }

            return _instance;
        }
    }

    private static string _logOutPath;
    private static Logger? _instance;
    private static readonly object _lock = new();
}