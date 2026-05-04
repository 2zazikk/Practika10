using System;

// ================== COMPONENT ==================
public interface ILogger
{
    string Log(string message);
}

// ================== CONCRETE COMPONENT ==================
public class BasicLogger : ILogger
{
    public string Log(string message)
    {
        return message;
    }
}

// ================== BASE DECORATOR ==================
public abstract class LoggerDecorator : ILogger
{
    protected ILogger _logger;

    public LoggerDecorator(ILogger logger)
    {
        _logger = logger;
    }

    public virtual string Log(string message)
    {
        return _logger.Log(message);
    }
}

// ================== CONCRETE DECORATORS ==================

// Добавляет время
public class TimestampDecorator : LoggerDecorator
{
    public TimestampDecorator(ILogger logger) : base(logger) { }

    public override string Log(string message)
    {
        string baseLog = base.Log(message);
        string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        return $"[{time}] {baseLog}";
    }
}

// Добавляет уровень важности
public class SeverityDecorator : LoggerDecorator
{
    private string _severity;

    public SeverityDecorator(ILogger logger, string severity)
        : base(logger)
    {
        _severity = severity;
    }

    public override string Log(string message)
    {
        string baseLog = base.Log(message);
        return $"[{_severity}] {baseLog}";
    }
}

// Добавляет пользователя
public class UserDecorator : LoggerDecorator
{
    private string _user;

    public UserDecorator(ILogger logger, string user)
        : base(logger)
    {
        _user = user;
    }

    public override string Log(string message)
    {
        string baseLog = base.Log(message);
        return $"[User: {_user}] {baseLog}";
    }
}

// ================== CLIENT ==================
class Program
{
    static void Main()
    {
        // базовый логгер
        ILogger logger = new BasicLogger();

        // добавляем пользователя
        logger = new UserDecorator(logger, "Alex");

        // добавляем уровень важности
        logger = new SeverityDecorator(logger, "ERROR");

        // добавляем время
        logger = new TimestampDecorator(logger);

        string result = logger.Log("System crashed");

        Console.WriteLine(result);
    }
}