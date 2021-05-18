using System;
using DecoratorPattern;


namespace MainProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            String inputString = Console.ReadLine();
            DefaultStringBehavior defaultStringBehavior = new DefaultStringBehavior();
            AppendingBehavior appendDecorator = new AppendingBehavior(defaultStringBehavior);
            LoggingBehavior loggingDecorator = new LoggingBehavior(defaultStringBehavior);

            String outputString = loggingDecorator.Reverse(inputString);
            Console.WriteLine(outputString);
        }
    }
}
