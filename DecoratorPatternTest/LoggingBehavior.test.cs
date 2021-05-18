using Microsoft.VisualStudio.TestTools.UnitTesting;
using DecoratorPattern;
using Moq;

namespace DecoratorPatternTest
{
    [TestClass]
    public class LoggingBehaviorTest
    {
        LoggingBehavior loggingBehavior;
        string input;
        Mock<ILogger> debugLogger;
        Mock<IStringBehavior> appendingBehavior;

        [TestInitialize]
        public void SetUp()
        {
            this.debugLogger = new Mock<ILogger>();
            this.loggingBehavior = new LoggingBehavior(this.debugLogger.Object);
            
            this.appendingBehavior = new Mock<IStringBehavior>();
        }

        [TestMethod]
        public void Reverse_RandomStringInputANDNullStringBehavior_InputSameOutput()
        {
            this.loggingBehavior.SetStringBehavior(null);
            input = "Chris";
            debugLogger.Setup(debugLogger => debugLogger.Log("ChrisLoggingBehavior"));
            string output = this.loggingBehavior.Reverse(input);
            debugLogger.Verify(debugLogger => debugLogger.Log("ChrisLoggingBehavior"));
            Assert.AreEqual<string>("Chris", output);
        }

        [TestMethod]
        public void Reverse_RandomStringInputANDNotNullStringBehavior_AppendedInput()
        {
            this.input = "HelloWorld";
            this.appendingBehavior.Setup(appendingBehavior => appendingBehavior.Reverse(input))
                .Returns("HelloWorldChristopher Henry Davila");
            this.loggingBehavior.SetStringBehavior(this.appendingBehavior.Object);
            this.debugLogger.Setup(debugLogger => debugLogger.Log("HelloWorldChristopher Henry DavilaLoggingBehavior"));
           
            string output = loggingBehavior.Reverse(input);
            this.debugLogger.Verify(debugLogger => debugLogger.Log("HelloWorldChristopher Henry DavilaLoggingBehavior"));
            Assert.AreEqual<string>("HelloWorldChristopher Henry Davila", output);
        }

        [TestMethod]
        public void Reverse_NullStringInputANDNullStringBehavior_NullOutput()
        {
            loggingBehavior.SetStringBehavior(null);
            input = null;
            string output = loggingBehavior.Reverse(input);
            this.debugLogger.Verify(debugLogger => debugLogger.Log(null), Times.Never);
            Assert.AreEqual<string>(null, output);
        }

        [TestMethod]
        public void Reverse_NullStringInputANDNotNullStringBehavior_NullOutput()
        {
            input = null;

            this.appendingBehavior.Setup(appendingBehavior => appendingBehavior.Reverse(input))
                .Returns((string)null);
            loggingBehavior.SetStringBehavior(this.appendingBehavior.Object);
            
            string output = loggingBehavior.Reverse(input);
            this.debugLogger.Verify(debugLogger => debugLogger.Log(null), Times.Never);

            Assert.AreEqual<string>(null, output);
        }
    }
}

