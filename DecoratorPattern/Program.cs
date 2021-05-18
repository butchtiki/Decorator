using System;
using DecoratorPattern;


namespace MainProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter string you want to reverse");
            String inputString = Console.ReadLine();
            DefaultStringBehavior defaultStringBehavior = new DefaultStringBehavior();

            DebugLogger debugLogger = new DebugLogger();
            LoggingBehavior loggingDecorator = new LoggingBehavior(debugLogger);
            loggingDecorator.SetStringBehavior(defaultStringBehavior);
            MoreAppendBehavior moreAppendDecorator = new MoreAppendBehavior();
            moreAppendDecorator.SetStringBehavior(loggingDecorator);
            AppendingBehavior appendBehavior = new AppendingBehavior();
            appendBehavior.SetStringBehavior(moreAppendDecorator);
            
            String outputString2 = appendBehavior.Reverse(inputString);
            Console.WriteLine(outputString2);
        }
    }
}
