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
        fileStream = new FileStream(LogOutPath, FileMode.OpenOrCreate, FileAccess.Write);
        fileStream.Close();
    }
    public static void Log(string message)
    {
        FileStream appendStream = new FileStream(LogOutPath, FileMode.Append);
    }

    public static Logger Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Logger();
            }

            return _instance;
        }
    }
    
    public static string LogOutPath { get; set; } = Path.Join(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        _dateTimeNow.ToString("yyyy-MM-dd HH:mm:ss") + ".log"
    );
    
    private static Logger _instance;
    private static DateTime _dateTimeNow = DateTime.Now;
    private FileStream fileStream;
}