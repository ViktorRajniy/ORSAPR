namespace UnitTests
{
    using ModelData;

    [TestFixture]
    public class LegParametersTests
    {
        [Test(Description = "Позитивный тест конструктора LegParameters")]
        [TestCase(ParameterType.LegDiameter, 4, 4, 150)]
        [TestCase(ParameterType.LegHeight, 500, 500, 1000)]
        public void LegParameters_ValueIsConstructed(ParameterType type,
            double expectedValue, double expectedMinValue, double expectedMaxValue)
        {
            // Setup:

            // Testing:
            LegParameters actual = new LegParameters();

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
        [TestCase(ParameterType.LegDiameter, 50, 50)]
        [TestCase(ParameterType.LegHeight, 700, 700)]
        public void LegParameters_SetCorrectValue_ValueIsSetted(ParameterType type,
            double value, double expectedValue)
        {
            // Setup:
            LegParameters actual = new LegParameters();

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

        [Test(Description = "Позитивный тест метода NewDiameterBorders")]
        [TestCase(20, 250, 20, 250)]
        public void LegParameters_NewDiameterBorders_NewBordersIsSetted(
            double minValue, double maxValue, double expectedMin, double expectedMax)
        {
            // Setup:
            LegParameters actual = new LegParameters();

            // Testing:
            actual.Set(ParameterType.LegDiameter, 50);

            actual.NewDiameterBorders(500, 10);

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.That(
                        actual.GetParameter(ParameterType.LegDiameter).MinValue,
                        Is.EqualTo(expectedMin));
                    Assert.That(
                        actual.GetParameter(ParameterType.LegDiameter).MaxValue,
                        Is.EqualTo(expectedMax));
                });
        }
    }
}
