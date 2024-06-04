using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAdditiveApp
{
    public class MyLoggerProvider : ILoggerProvider
    {
        class MyFileLogger : ILogger, IDisposable
        {
            public IDisposable? BeginScope<TState>(TState state) where TState : notnull
            {
                return this;
            }

            public void Dispose(){}

            public bool IsEnabled(LogLevel logLevel) { return true; }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
            {
                File.AppendAllText("log.dat", formatter(state, exception));
            }
        }

        class MyConsoleLogger : ILogger, IDisposable
        {
            public IDisposable? BeginScope<TState>(TState state) where TState : notnull
            {
                return this;
            }

            public void Dispose()
            {

            }

            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
            {
                Console.WriteLine(formatter(state, exception));
            }
        }


        public ILogger CreateLogger(string categoryName)
        {
            return new MyFileLogger();
            //switch (categoryName)
            //{
            //    case "console": return new MyConsoleLogger();
            //    case "file": return new MyFileLogger();
            //    default: return null;
            //}
        }

        public void Dispose() {}
    }
}
