namespace UnitTests
{
    using ModelData;

    [TestFixture]
    public class ParameterTests
    {
        [Test(Description = "Позитивный тест сеттера Value")]
        public void ParameterValue_SetCorrectValue_ValueIsSetted()
        {
            // Setup:
            double expected = 10;

            Parameter actual = new Parameter(5, 1, 15);

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

            Parameter actual = new Parameter(5, 1, 15);

            // Testing:

            // Assert:
            Assert.That(actual.Value, Is.EqualTo(expected));
        }

        [Test(Description = "Позитивный тест сеттера MinValue")]
        public void ParameterMinValue_SetCorrectValue_ValueIsSetted()
        {
            // Setup:
            double expected = 10;

            Parameter actual = new Parameter(12, 1, 15);

            // Testing:
            actual.MinValue = expected;

            // Assert:
            Assert.AreEqual(expected, actual.MinValue);
        }

        [Test(Description = "Негативный тест сеттера MinValue")]
        public void ParameterMinValue_SetLessNullValue_ValueIsSetted()
        {
            // Setup:

            // Testing:

            // Assert:
            Assert.Throws<ArgumentException>(
                () =>
                {
                    Parameter setup = new Parameter(1, -5, 5);
                });
        }

        [Test(Description = "Негативный тест сеттера MinValue")]
        public void ParameterMinValue_NewValueSet_ValueIsNotSetted()
        {
            // Setup:
            double newMin = -4;

            // Testing:
            Parameter setup = new Parameter(3, 1, 5);

            // Assert:
            Assert.Throws<ArgumentException>(
                () =>
                {
                    setup.MinValue = newMin;
                });
        }

        [Test(Description = "Негативный тест сеттера MinValue")]
        public void ParameterMinValue_SetNullValue_ValueIsSetted()
        {
            // Setup:

            // Testing:

            // Assert:
            Assert.Throws<ArgumentException>(
                () =>
                {
                    Parameter setup = new Parameter(1, 0, 5);
                });
        }

        [Test(Description = "Позитивный тест геттера MinValue")]
        public void ParameterMinValue_GetCorrectValue_ValueIsGetted()
        {
            // Setup:
            double expected = 1;

            Parameter actual = new Parameter(12, 1, 15);

            // Testing:

            // Assert:
            Assert.That(actual.MinValue, Is.EqualTo(expected));
        }

        [Test(Description = "Позитивный тест сеттера MaxValue")]
        public void ParameterMaxValue_SetCorrectValue_ValueIsSetted()
        {
            // Setup:
            double expected = 10;

            Parameter actual = new Parameter(7, 1, 15);

            // Testing:
            actual.MaxValue = expected;

            // Assert:
            Assert.AreEqual(expected, actual.MaxValue);
        }

        [Test(Description = "Негативный тест сеттера MinValue")]
        public void ParameterMaxValue_SetIncorrectValue_ValueIsSetted()
        {
            // Setup:

            // Testing:

            // Assert:
            Assert.Throws<ArgumentException>(
                () =>
                {
                    Parameter setup = new Parameter(10, 10, 5);
                });
        }

        [Test(Description = "Негативный тест сеттера MaxValue")]
        public void ParameterMaxValue_NewValueSet_ValueIsNotSetted()
        {
            // Setup:
            double newMin = -4;

            // Testing:
            Parameter setup = new Parameter(3, 1, 5);

            // Assert:
            Assert.Throws<ArgumentException>(
                () =>
                {
                    setup.MaxValue = newMin;
                });
        }

        [Test(Description = "Позитивный тест геттера MaxValue")]
        public void ParameterMaxValue_GetCorrectValue_ValueIsGetted()
        {
            // Setup:
            double expected = 15;

            Parameter actual = new Parameter(12, 1, 15);

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
                    Assert.That(actual.Value, Is.EqualTo(expectedValue));
                    Assert.That(actual.MinValue, Is.EqualTo(expectedMinValue));
                    Assert.That(actual.MaxValue, Is.EqualTo(expectedMaxValue));
                });
        }

        [Test(Description = "Негативный тест метода MinMaxValidate")]
        [TestCase(2,10,5,1)]
        [TestCase(2, 10, 5, 11)]
        public void MinMaxValidate_GetNewIncorrectValue_TestNotPassed(
            double min, double max, double value, double newValue)
        {
            // Setup:

            // Testing:
            Parameter setup = new Parameter(value, min, max);

            // Assert:
            Assert.Throws<ArgumentException>(
                () =>
                {
                    setup.Value = newValue;
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
                    Parameter setup = new Parameter(5, 1, 10);
                });
        }
    }
}
