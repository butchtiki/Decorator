using System;
using System.Diagnostics;

namespace DecoratorPattern
{
    public class DebugLogger : ILogger
    {
        public void Log(string message)
        {
            Debug.WriteLine(message);
        }

    }
}
