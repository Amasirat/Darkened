using System.Text;

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
        var writeFileStream = new FileStream(_logOutPath, FileMode.OpenOrCreate, FileAccess.Write);
        writeFileStream.Close();
        // creates a static appending log stream for Logger.
        // This should be the main log stream that is supposed to be used
        // and opening any new streams should be avoided
        LogStream = new FileStream(_logOutPath, FileMode.Append);
    }
    public void Log(string message)
    {
        string line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}: {message}\n";
        byte[] buffer = Encoding.UTF8.GetBytes(line);
        LogStream.Write(buffer, 0, buffer.Length);
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
    private static FileStream LogStream;
}