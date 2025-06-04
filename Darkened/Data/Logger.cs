using System.Collections.Concurrent;
using System.Text;

namespace Darkened.Data;
public class Logger
{
    private Logger(IFile fileStream)
    {
        if (!Directory.Exists(Globals.LogDirectory))
        {
            Directory.CreateDirectory(Globals.LogDirectory);
        }
        logStream = fileStream;
        logStream.Write($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}: Log Stream Created\n");

        logThread = new Thread(ProcessLogQueue) { IsBackground = true };
        
        logThread.Start();
    }
    public void Log(string message)
    {
        string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}: {message}\n";
        logQueue.Enqueue(logEntry);
        logSignal.Set();
    }
    public void ShutDown()
    {
        isRunning = false;
        logSignal.Set();
        logThread.Join();
    }

    private void ProcessLogQueue()
    {
        while (isRunning)
        {
            logSignal.WaitOne();
            while (logQueue.TryDequeue(out string? logEntry))
            {
                logStream.Append(logEntry);
            }
        }
    }
    public static Logger? Instance
    {
        get
        {
            if (_instance != null) return _instance;
            lock (_lock)
            {
                _instance ??= new Logger(new File(
                    Path.Join(
                        Globals.LogDirectory, 
                        DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss") + ".log"))
                );
            }

            return _instance;
        }
    }
    private static Logger? _instance;
    private static readonly object _lock = new();
    private readonly ConcurrentQueue<string> logQueue = new();
    private readonly AutoResetEvent logSignal = new(false);
    private readonly Thread logThread;
    private bool isRunning = true;
    private static IFile logStream;
}