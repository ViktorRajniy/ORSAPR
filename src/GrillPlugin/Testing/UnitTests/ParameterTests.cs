namespace UnitTests
{
    [TestFixture]
    public class ParameterTests
    {
        [Test(Description = "Позитивный тест сеттера Value")]
        public void ParameterValue_SetCorrectValue_ValueIsSetted()
        {
            // Setup:
            double expected = 10;

            Parameter actual = new Parameter(5, 0, 15);

            // Testing:
            actual.Value = expected;

            // Assert:
            Assert.AreEqual(expected, actual.Value);
        }

        [Test(Description = "Позитивный тест геттера Value")]
        public void ParameterValue_GetCorrectValue_ValueIsGetted()
        {
            // Setup:
            double expected = 5;

            Parameter actual = new Parameter(5, 0, 15);

            // Testing:

            // Assert:
            Assert.That(actual.Value, Is.EqualTo(expected));
        }

        [Test(Description = "Позитивный тест сеттера MinValue")]
        public void ParameterMinValue_SetCorrectValue_ValueIsSetted()
        {
            // Setup:
            double expected = 10;

            Parameter actual = new Parameter(12, 0, 15);

            // Testing:
            actual.MinValue = expected;

            // Assert:
            Assert.AreEqual(expected, actual.MinValue);
        }

        [Test(Description = "Позитивный тест геттера MinValue")]
        public void ParameterMinValue_GetCorrectValue_ValueIsGetted()
        {
            // Setup:
            double expected = 0;

            Parameter actual = new Parameter(12, 0, 15);

            // Testing:

            // Assert:
            Assert.That(actual.MinValue, Is.EqualTo(expected));
        }

        [Test(Description = "Позитивный тест сеттера MaxValue")]
        public void ParameterMaxValue_SetCorrectValue_ValueIsSetted()
        {
            // Setup:
            double expected = 10;

            Parameter actual = new Parameter(7, 0, 15);

            // Testing:
            actual.MaxValue = expected;

            // Assert:
            Assert.AreEqual(expected, actual.MaxValue);
        }

        [Test(Description = "Позитивный тест геттера MaxValue")]
        public void ParameterMaxValue_GetCorrectValue_ValueIsGetted()
        {
            // Setup:
            double expected = 15;

            Parameter actual = new Parameter(12, 0, 15);

            // Testing:

            // Assert:
            Assert.That(actual.MaxValue, Is.EqualTo(expected));
        }

        [Test(Description = "Позитивный тест конструктора Parameter")]
        public void Parameter_ValueIsSetted()
        {
            // Setup:
            double expectedValue = 10;
            double expectedMinValue = 5;
            double expectedMaxValue = 15;

            Parameter actual = new Parameter(10, 5, 15);

            // Testing:

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.AreEqual(expectedValue, actual.Value);
                    Assert.AreEqual(expectedMinValue, actual.MinValue);
                    Assert.AreEqual(expectedMaxValue, actual.MaxValue);
                });
        }

        [Test(Description = "Негативный тест метода MinMaxValidate")]
        public void MinMaxValidate_GetIncorrectBigValue_TestNotPassed()
        {
            // Setup:

            // Testing:

            // Assert:
            Assert.Throws<ArgumentException>(
                () =>
                {
                    Parameter setup = new Parameter(10, 0, 5);
                });
        }

        [Test(Description = "Негативный тест метода MinMaxValidate")]
        public void MinMaxValidate_GetIncorrectLittleValue_TestNotPassed()
        {
            // Setup:

            // Testing:

            // Assert:
            Assert.Throws<ArgumentException>(
                () =>
                {
                    Parameter setup = new Parameter(2, 5, 10);
                });
        }

        [Test(Description = "Позитивный тест метода MinMaxValidate")]
        public void MinMaxValidate_GetCorrectValue_TestPassed()
        {
            // Setup:

            // Testing:

            // Assert:
            Assert.DoesNotThrow(
                () =>
                {
                    Parameter setup = new Parameter(5, 0, 10);
                });
        }
    }
}
