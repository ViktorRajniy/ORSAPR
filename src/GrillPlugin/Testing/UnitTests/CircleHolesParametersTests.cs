namespace UnitTests
{
    using ModelData;

    [TestFixture]
    public class CircleHolesParametersTests
    {
        [Test(Description = "Позитивный тест конструктора CircleHolesParameters")]
        [TestCase(ParameterType.CircleHoleDiameter, 10, 10, 100)]
        [TestCase(ParameterType.CircleHoleHeight, 7, 7, 97)]
        [TestCase(ParameterType.CircleHoleDistance, 10, 10, 486)]
        public void CircleHolesParameters_ValueIsConstructed(ParameterType type,
            double expectedValue, double expectedMinValue, double expectedMaxValue)
        {
            // Setup:

            // Testing:
            CircleHolesParameters actual = new CircleHolesParameters();

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
        [TestCase(ParameterType.CircleHoleDiameter, 50, 50)]
        [TestCase(ParameterType.CircleHoleDistance, 200, 200)]
        [TestCase(ParameterType.CircleHoleHeight, 56, 56)]
        public void CircleHolesParameters_SetCorrectValue_ValueIsSetted(ParameterType type,
            double expectedValue, double value)
        {
            // Setup:

            // Testing:
            CircleHolesParameters actual = new CircleHolesParameters();

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

        [Test(Description = "Позитивный тест метода NewCircleHoleDiameterBorders")]
        [TestCase(10, 100, 25, 200)]
        public void CircleHolesParameters_NewCircleHoleDiameterBorders_NewBordersIsSetted(
            double expectedMin, double expectedMax, double diameter, double height)
        {
            // Setup:

            // Testing:
            CircleHolesParameters actual = new CircleHolesParameters();

            actual.Set(ParameterType.CircleHoleDiameter, diameter);

            actual.NewCircleHoleDiameterBorders(height);

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.That(
                        actual.GetParameter(ParameterType.CircleHoleDiameter).MinValue,
                        Is.EqualTo(expectedMin));
                    Assert.That(
                        actual.GetParameter(ParameterType.CircleHoleDiameter).MaxValue,
                        Is.EqualTo(expectedMax));
                });
        }

        [Test(Description = "Позитивный тест метода SetDistanceBorders")]
        [TestCase(20, 960, 20, 960)]
        public void CircleHolesParameters_SetDistanceBorders_NewBordersIsSetted(
            double minValue, double maxValue, double expectedMin, double expectedMax)
        {
            // Setup:
            CircleHolesParameters actual = new CircleHolesParameters();

            // Testing:
            actual.Set(ParameterType.CircleHoleDiameter, 20);

            actual.SetCircleHoleDistanceBorders(minValue, maxValue);

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.That(
                        actual.GetParameter(ParameterType.CircleHoleDistance).MinValue,
                        Is.EqualTo(expectedMin));
                    Assert.That(
                        actual.GetParameter(ParameterType.CircleHoleDistance).MaxValue,
                        Is.EqualTo(expectedMax));
                });
        }

        [Test(Description = "Позитивный тест метода NewCircleHoleHeightBorders")]
        [TestCase(25, 195, 30, 25, 400, 10)]
        public void CircleHolesParameters_NewCircleHoleHeightBorders_NewBordersIsSetted(
            double expectedMin, double expectedMax, double diameter, double holeHeight, 
            double height, double thickness)
        {
            // Setup:
            double expectedMinHeight = 25;
            double expectedMaxHeight = 195;

            // Testing:
            CircleHolesParameters actual = new CircleHolesParameters();

            actual.Set(ParameterType.CircleHoleDiameter, diameter);

            actual.Set(ParameterType.CircleHoleHeight, holeHeight);

            actual.NewCircleHoleHeightBorders(height, thickness);

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.That(
                        actual.GetParameter(ParameterType.CircleHoleHeight).MinValue,
                        Is.EqualTo(expectedMin));
                    Assert.That(
                        actual.GetParameter(ParameterType.CircleHoleHeight).MaxValue,
                        Is.EqualTo(expectedMax));
                });
        }

        [Test(Description = "Позитивный тест сеттера HolesCount")]
        [TestCase(10, 10)]
        public void ParameterValue_SetCorrectValue_ValueIsSetted(
            double value, double expectedValue)
        {
            // Setup:
            CircleHolesParameters actual = new CircleHolesParameters();

            // Testing:
            actual.HoleCount = 10;

            // Assert:
            Assert.AreEqual(expectedValue, actual.HoleCount);
        }
    }
}
