using NUnit.Framework;
using CalcLibrary;

namespace CalcTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Init()
        {
            _calculator = new Calculator();
        }

        [TearDown]
        public void Cleanup()
        {
            // Clean up if necessary (not needed here)
        }

        [Test]
        public void Add_TwoPositiveNumbers_ReturnsCorrectSum()
        {
            int result = _calculator.Add(3, 4);
            Assert.That(result, Is.EqualTo(7));
        }

        [TestCase(1, 2, 3)]
        [TestCase(-1, -1, -2)]
        [TestCase(100, 200, 300)]
        [TestCase(0, 0, 0)]
        public void Add_WithTestCases_ReturnsExpectedResult(int a, int b, int expected)
        {
            int result = _calculator.Add(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test, Ignore("Example of Ignore usage")]
        public void ThisTestWillBeSkipped()
        {
            Assert.That(1, Is.EqualTo(2)); // Won’t run
        }
    }
}
