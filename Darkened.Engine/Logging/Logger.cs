using System.Collections.Concurrent;
using Darkened.Engine.Logging.Interfaces;

namespace Darkened.Engine.Logging;

public class Logger : ILogger
{
    public event Action<LogMessage> OnLogOutput;
    
    public static Logger Instance
    {
        get
        {
            if(_instance != null) return _instance;
            lock (_threadLock)
            {
                _instance ??= new Logger();
            }
            
            return _instance;
        }
    }

    private Logger()
    {
        _logBuffer = new ConcurrentQueue<LogMessage>();
        _logEvent = new AutoResetEvent(false);
        _loggingThread = new Thread(ProcessLogBuffer);
        
        OnLogOutput += l => Console.WriteLine(l.Message);
        
        _loggingThread.IsBackground = true;
        _loggingThread.Start();
        IsRunning = true;
    }

    public void LogInformation(string message)
    {
        var logMessage = new LogMessage
        {
            Priority = 3,
            Message = message
        };
        _logBuffer.Enqueue(logMessage);
        _logEvent.Set();
    }

    public void LogWarning(string message)
    {
        var logMessage = new LogMessage
        {
            Priority = 2,
            Message = $"WARNING: {message}"
        };
        _logBuffer.Enqueue(logMessage);
        _logEvent.Set();
    }

    public void LogError(string message)
    {
        var logMessage = new LogMessage
        {
            Priority = 1,
            Message = $"ERROR: {message}"
        };
        _logBuffer.Enqueue(logMessage);
        _logEvent.Set();
    }

    private void ProcessLogBuffer()
    {
        while (IsRunning)
        {
            _logEvent.WaitOne();
            while (_logBuffer.TryDequeue(out var logMessage))
            {
                OnLogOutput?.Invoke(logMessage);
            }
        }
    }

    public void ShutDown()
    {
        IsRunning = false;
        _logEvent.Set();
        _loggingThread.Join();
    }

    private ConcurrentQueue<LogMessage> _logBuffer;
    private AutoResetEvent _logEvent;
    private static readonly Lock _threadLock = new();
    private readonly Thread _loggingThread;
    private static Logger? _instance;
    
    public bool IsRunning { get; private set; }

    public struct LogMessage
    {
        public byte Priority;
        public string Message;
    }
}