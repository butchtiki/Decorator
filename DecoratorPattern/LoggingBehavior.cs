using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorPattern
{
    public class LoggingBehavior : Decorator
    {
        private ILogger debugLogger;

        public LoggingBehavior(ILogger logger)
        {
            this.debugLogger = logger;
        }

        public override string Reverse(string input)
        {
            string resultString;

            resultString = base.Reverse(input);
            if(resultString != null)
            {
                this.debugLogger.Log(resultString + "LoggingBehavior");
            }
            
            return resultString;

        }


    }
}
