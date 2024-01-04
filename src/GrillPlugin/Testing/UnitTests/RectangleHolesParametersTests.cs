namespace UnitTests
{
    using ModelData;

    [TestFixture]
    public class RectangleHolesParametersTests
    {
        [Test(Description = "Позитивный тест конструктора RectangleHolesParameters")]
        [TestCase(ParameterType.RectangleHoleHeight, 20, 20, 249)]
        public void RectangleHolesParameters_ValueIsConstructed(ParameterType type,
            double expectedValue, double expectedMinValue, double expectedMaxValue)
        {
            // Setup:

            // Testing:
            RectangleHolesParameters actual = new RectangleHolesParameters();

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
        [TestCase(ParameterType.RectangleHoleHeight, 100, 100)]
        public void RectangleHolesParameters_SetCorrectValue_ValueIsSetted(ParameterType type,
            double value, double expectedValue)
        {
            // Setup:

            // Testing:
            RectangleHolesParameters actual = new RectangleHolesParameters();

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

        [Test(Description = "Позитивный тест метода NewRectangleHoleHeightBorders")]
        [TestCase(25, 200, 20, 100)]
        public void RectangleHolesParameters_NewRectangleHoleHeightBorders_NewBordersIsSetted(
            double holeHeight, double height, double expectedMin, double expectedMax)
        {
            // Setup:

            // Testing:
            RectangleHolesParameters actual = new RectangleHolesParameters();

            actual.Set(ParameterType.RectangleHoleHeight, holeHeight);

            actual.NewRectangleHoleHeightBorders(height);

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.That(
                        actual.GetParameter(ParameterType.RectangleHoleHeight).MinValue,
                        Is.EqualTo(expectedMin));
                    Assert.That(
                        actual.GetParameter(ParameterType.RectangleHoleHeight).MaxValue,
                        Is.EqualTo(expectedMax));
                });
        }
    }
}
