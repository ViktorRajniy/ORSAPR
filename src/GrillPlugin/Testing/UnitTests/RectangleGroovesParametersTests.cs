namespace UnitTests
{
    using ModelData;

    [TestFixture]
    public class RectangleGroovesParametersTests
    {
        [Test(Description = "Позитивный тест конструктора RectangleGroovesParameters")]
        [TestCase(ParameterType.RectangleGrooveHeight, 20, 20, 100)]
        [TestCase(ParameterType.RectangleGrooveWidth, 5, 5, 20)]
        [TestCase(ParameterType.RectangleGrooveDistance, 20, 20, 490)]
        public void RectangleGroovesParameters_ValueIsConstructed(ParameterType type,
            double expectedValue, double expectedMinValue, double expectedMaxValue)
        {
            // Setup:

            // Testing:
            RectangleGroovesParameters actual = new RectangleGroovesParameters();

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
        [TestCase(ParameterType.RectangleGrooveHeight, 80, 80)]
        [TestCase(ParameterType.RectangleGrooveWidth, 11, 11)]
        [TestCase(ParameterType.RectangleGrooveDistance, 200, 200)]
        public void RectangleGroovesParameters_SetCorrectValue_ValueIsSetted(ParameterType type,
            double value, double expectedValue)
        {
            // Setup:

            // Testing:
            RectangleGroovesParameters actual = new RectangleGroovesParameters();

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

        [Test(Description = "Позитивный тест метода NewHeightBorders")]
        [TestCase(20, 250, 1000)]
        public void RectangleGroovesParameters_NewHeightBorders_NewBordersIsSetted(
            double expectedMin, double expectedMax, double height)
        {
            // Setup:

            // Testing:
            RectangleGroovesParameters actual = new RectangleGroovesParameters();

            actual.NewHeightBorders(height);

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.That(
                        actual.GetParameter(ParameterType.RectangleGrooveHeight).MinValue,
                        Is.EqualTo(expectedMin));
                    Assert.That(
                        actual.GetParameter(ParameterType.RectangleGrooveHeight).MaxValue,
                        Is.EqualTo(expectedMax));
                });
        }

        [Test(Description = "Позитивный тест метода SetDistanceBorders")]
        [TestCase(20, 960, 20, 960)]
        public void RectangleGroovesParameters_SetDistanceBorders_NewBordersIsSetted(
            double minValue, double maxValue, double expectedMin, double expectedMax)
        {
            // Setup:
            RectangleGroovesParameters actual = new RectangleGroovesParameters();

            // Testing:
            actual.Set(ParameterType.RectangleGrooveWidth, 20);

            actual.SetDistanceBorders(minValue, maxValue);

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.That(
                        actual.GetParameter(ParameterType.RectangleGrooveDistance).MinValue,
                        Is.EqualTo(expectedMin));
                    Assert.That(
                        actual.GetParameter(ParameterType.RectangleGrooveDistance).MaxValue,
                        Is.EqualTo(expectedMax));
                });
        }

        [Test(Description = "Позитивный тест сеттера GroovesCount")]
        [TestCase(10, 10)]
        public void RectangleGroovesParameters_SetCorrectValue_ValueIsSetted(
            double value, double expectedValue)
        {
            // Setup:
            RectangleGroovesParameters actual = new RectangleGroovesParameters();

            // Testing:
            actual.GrooveCount = 10;

            // Assert:
            Assert.AreEqual(expectedValue, actual.GrooveCount);
        }
    }
}
