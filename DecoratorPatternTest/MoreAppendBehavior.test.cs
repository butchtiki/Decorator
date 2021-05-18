using Microsoft.VisualStudio.TestTools.UnitTesting;
using DecoratorPattern;
using Moq;

namespace DecoratorPatternTest
{
    [TestClass]
    public class MoreAppendBehaviorTest
    {
        MoreAppendBehavior moreAppendBehavior;
        Mock<IStringBehavior> appendingBehavior;
        string input;


        [TestInitialize]
        public void SetUp()
        {
            appendingBehavior = new Mock<IStringBehavior>();
            moreAppendBehavior = new MoreAppendBehavior();
        }

        [TestMethod]
        public void Reverse_RandomStringInput_AppendedString()
        {
            input = "Hello World";
            string output = moreAppendBehavior.Reverse(input);

            Assert.AreEqual<string>("Hello WorldWelcome", output);
        }

        [TestMethod]
        public void Reverse_NullInput_NullOutput()
        {
            input = null;
            string output = moreAppendBehavior.Reverse(input);

            Assert.AreEqual<string>(null, output);
        }

        [TestMethod]
        public void Reverse_NotNullStringBehaviorANDNotNullInput_NullOutput()
        {
            input = "HelloWorld";
            moreAppendBehavior.SetStringBehavior(appendingBehavior.Object);
            appendingBehavior.Setup(appendingBehavior => appendingBehavior.Reverse(input))
                .Returns("HelloWorldChristopher Henry Davila");
            
            string output = moreAppendBehavior.Reverse(input);

            Assert.AreEqual<string>("HelloWorldChristopher Henry DavilaWelcome", output);
        }

        [TestMethod]
        public void Reverse_NullStringBehaviorANDNotNullInput_AppendedName()
        {
            input = "HelloWorld";
            moreAppendBehavior.SetStringBehavior(null);
            string output = moreAppendBehavior.Reverse(input);

            Assert.AreEqual<string>("HelloWorldWelcome", output);
        }



    }
}