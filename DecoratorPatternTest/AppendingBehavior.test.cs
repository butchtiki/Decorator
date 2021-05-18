using Microsoft.VisualStudio.TestTools.UnitTesting;
using DecoratorPattern;
using Moq;
using System.Diagnostics;
using System;

namespace DecoratorPatternTest
{
    [TestClass]
    public class AppendingBehaviorTest
    {
        AppendingBehavior appendingBehavior;
        string input;
        Mock<IStringBehavior> loggingBehavior;

        [TestInitialize]
        public void SetUp()
        {
            loggingBehavior = new Mock<IStringBehavior>();
            appendingBehavior = new AppendingBehavior();
        }


        [TestMethod]
        public void Reverse_RandomStringInput_AppendedName()
        {
            input = "Hello World";
            string output = appendingBehavior.Reverse(input);

            Assert.AreEqual<string>("Hello WorldChristopher Henry Davila", output);
        }

        [TestMethod]
        public void Reverse_NullInput_NullOutput()
        {
            input = null;
            string output = appendingBehavior.Reverse(input);

            Assert.AreEqual<string>(null, output);
        }

        [TestMethod]
        public void Reverse_NotNullStringBehaviorANDNotNullInput_NullOutput()
        {
            input = "HelloWorld";
            
            appendingBehavior.SetStringBehavior(loggingBehavior.Object);
            loggingBehavior.Setup(loggingBehavior => loggingBehavior.Reverse(input)).Returns("HelloWorld");
            string output = appendingBehavior.Reverse(input);
            Console.WriteLine(output);
            Assert.AreEqual<string>("HelloWorldChristopher Henry Davila", output);
        }

        [TestMethod]
        public void Reverse_NullStringBehaviorANDNotNullInput_AppendedName()
        {
            input = "HelloWorld";
            appendingBehavior.SetStringBehavior(null);
            string output = appendingBehavior.Reverse(input);

            Assert.AreEqual<string>("HelloWorldChristopher Henry Davila",output);
        }
    }
}