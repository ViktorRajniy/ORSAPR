namespace UnitTests
{
    using ModelData;

    [TestFixture]
    public class CircleGroovesParametersTests
    {
        [Test(Description = "Позитивный тест конструктора CircleGroovesParameters")]
        [TestCase(ParameterType.CircleGrooveDistance, 5, 5, 490)]
        [TestCase(ParameterType.CircleGrooveDiameter, 5, 5, 20)]
        public void CircleGroovesParameters_ValueIsConstructed(ParameterType type,
            double expectedValue, double expectedMinValue, double expectedMaxValue)
        {
            // Setup:

            // Testing:
            CircleGroovesParameters actual = new CircleGroovesParameters();

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.That(
                        actual.GetParameter(type).MinValue,
                        Is.EqualTo(expectedMinValue));
                    Assert.That(
                        actual.GetParameter(type).Value,
                        Is.EqualTo(expectedValue));
                    Assert.That(
                        actual.GetParameter(type).MaxValue,
                        Is.EqualTo(expectedMaxValue));
                });
        }

        [Test(Description = "Позитивный тест сеттера Set")]
        [TestCase(ParameterType.CircleGrooveDiameter, 15, 15)]
        [TestCase(ParameterType.CircleGrooveDistance, 200, 200)]
        public void CircleGroovesParameters_SetCorrectValue_ValueIsSetted(ParameterType type,
            double value, double expectedValue)
        {
            // Setup:
            CircleGroovesParameters actual = new CircleGroovesParameters();

            // Testing:

            actual.Set(type, value);

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.That(
                        actual.GetParameter(type).Value,
                        Is.EqualTo(expectedValue));
                });
        }

        [Test(Description = "Позитивный тест метода SetDistanceBorders")]
        [TestCase(20, 960, 20, 960)]
        public void CircleGroovesParameters_SetDistanceBorders_NewBordersIsSetted(
            double minValue, double maxValue, double expectedMin, double expectedMax)
        {
            // Setup:
            CircleGroovesParameters actual = new CircleGroovesParameters();

            // Testing:
            actual.Set(ParameterType.CircleGrooveDiameter, 20);

            actual.SetDistanceBorders(minValue, maxValue);

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.That(
                        actual.GetParameter(ParameterType.CircleGrooveDistance).MinValue,
                        Is.EqualTo(expectedMin));
                    Assert.That(
                        actual.GetParameter(ParameterType.CircleGrooveDistance).MaxValue,
                        Is.EqualTo(expectedMax));
                });
        }

        [Test(Description = "Позитивный тест сеттера GroovesCount")]
        [TestCase(10, 10)]
        public void CircleGroovesParameters_SetCorrectValue_ValueIsSetted(
            double value, double expectedValue)
        {
            // Setup:
            CircleGroovesParameters actual = new CircleGroovesParameters();

            // Testing:
            actual.GrooveCount = 10;

            // Assert:
            Assert.AreEqual(expectedValue, actual.GrooveCount);
        }
    }
}
