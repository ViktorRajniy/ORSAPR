namespace UnitTests
{
    using ModelData;

    [TestFixture]
    public class BoxParametersTests
    {
        [Test(Description = "Позитивный тест конструктора BoxParameters")]
        [TestCase(ParameterType.BoxLength, 500, 500, 2000)]
        [TestCase(ParameterType.BoxWidth, 300, 300, 500)]
        [TestCase(ParameterType.BoxHeight, 200, 200, 500)]
        [TestCase(ParameterType.BoxWallThickness, 2, 2, 8)]
        public void BoxParameters_ValueIsConstructed(ParameterType type,
            double expectedValue, double expectedMinValue, double expectedMaxValue)
        {
            // Setup:

            // Testing:
            BoxParameters actual = new BoxParameters();

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.That(
                        actual.GetParameter(type).Value, Is.EqualTo(expectedValue));
                    Assert.That(
                        actual.GetParameter(type).MinValue, Is.EqualTo(expectedMinValue));
                    Assert.That(
                        actual.GetParameter(type).MaxValue, Is.EqualTo(expectedMaxValue));
                });
        }

        [Test(Description = "Позитивный тест сеттера Set")]
        [TestCase(ParameterType.BoxLength, 750, 750)]
        [TestCase(ParameterType.BoxWidth, 325, 325)]
        [TestCase(ParameterType.BoxHeight, 400, 400)]
        [TestCase(ParameterType.BoxWallThickness, 6, 6)]
        public void BoxParameters_SetCorrectValue_ValueIsSetted(ParameterType type,
            double value, double expectedValue)
        {
            // Setup:

            // Testing:
            BoxParameters actual = new BoxParameters();
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
    }
}
