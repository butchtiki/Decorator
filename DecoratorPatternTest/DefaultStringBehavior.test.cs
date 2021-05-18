using Microsoft.VisualStudio.TestTools.UnitTesting;
using DecoratorPattern;

namespace DecoratorPatternTest
{
    [TestClass]
    public class DefaultStringBehaviorTest
    {
        DefaultStringBehavior defaultStringBehavior;
        string input;

        [TestInitialize]
        public void SetUp()
        {
            defaultStringBehavior = new DefaultStringBehavior();
        }

        [TestMethod]
        public void Reverse_RandomStringInput_ReturnsReversedString()
        {
            input = "Chris";

            string output = defaultStringBehavior.Reverse(input);

            Assert.AreEqual<string>("sirhC", output);
        }

        [TestMethod]
        public void Reverse_NullStringInput_ReturnsNull()
        {
            input = null;

            string output = defaultStringBehavior.Reverse(input);

            Assert.AreEqual<string>(null, output);
        }
    }
}
