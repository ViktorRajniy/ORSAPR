namespace UnitTests
{
    [TestFixture]
    public class ParametersTests
    {
        [Test(Description = "Позитивный тест геттера GetParameter")]
        [TestCase(ParameterType.BoxLength, 500, 500, 2000)]
        [TestCase(ParameterType.BoxWidth, 300, 300, 500)]
        [TestCase(ParameterType.BoxHeight, 200, 200, 500)]
        [TestCase(ParameterType.BoxWallThickness, 2, 2, 8)]
        [TestCase(ParameterType.LegHeight, 500, 500, 1000)]
        [TestCase(ParameterType.LegDiameter, 4, 4, 150)]
        [TestCase(ParameterType.CircleHoleDiameter, 10, 10, 100)]
        [TestCase(ParameterType.CircleHoleHeight, 7, 7, 97)]
        [TestCase(ParameterType.CircleHoleDistance, 10, 10, 486)]
        [TestCase(ParameterType.RectangleHoleHeight, 20, 20, 249)]
        [TestCase(ParameterType.CircleGrooveDiameter, 5, 5, 20)]
        [TestCase(ParameterType.CircleGrooveDistance, 5, 5, 490)]
        [TestCase(ParameterType.RectangleGrooveHeight, 20, 20, 100)]
        [TestCase(ParameterType.RectangleGrooveWidth, 5, 5, 20)]
        [TestCase(ParameterType.RectangleGrooveDistance, 20, 20, 490)]
        public void Parameters_GetValue_ValueIsGetted(ParameterType type,
            double expectedvalue, double expectedMinValue, double expectedMaxValue)
        {
            // Setup:

            // Testing:
            Parameters actual = new Parameters();

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.That(actual.GetParameter(type).Value, Is.EqualTo(expectedvalue));
                    Assert.That(actual.GetParameter(type).MinValue, Is.EqualTo(expectedMinValue));
                    Assert.That(actual.GetParameter(type).MaxValue, Is.EqualTo(expectedMaxValue));
                });
        }

        [Test(Description = "Позитивный тест сеттера SetParameter")]
        [TestCase(ParameterType.BoxLength, 1000, 1000)]
        [TestCase(ParameterType.BoxWidth, 350, 350)]
        [TestCase(ParameterType.BoxHeight, 250, 250)]
        [TestCase(ParameterType.BoxWallThickness, 6, 6)]
        [TestCase(ParameterType.LegHeight, 750, 750)]
        [TestCase(ParameterType.LegDiameter, 50, 50)]
        [TestCase(ParameterType.CircleHoleDiameter, 30, 30)]
        [TestCase(ParameterType.CircleHoleHeight, 40, 40)]
        [TestCase(ParameterType.CircleHoleDistance, 35, 35)]
        [TestCase(ParameterType.RectangleHoleHeight, 45, 45)]
        [TestCase(ParameterType.CircleGrooveDiameter, 10, 10)]
        [TestCase(ParameterType.CircleGrooveDistance, 15, 15)]
        [TestCase(ParameterType.RectangleGrooveHeight, 30, 30)]
        [TestCase(ParameterType.RectangleGrooveWidth, 10, 10)]
        [TestCase(ParameterType.RectangleGrooveDistance, 25, 25)]
        public void Parameters_SetCorrectValue_ValueIsSetted(ParameterType type, double value, double expectedValue)
        {
            // Setup:
            Parameters actual = new Parameters();

            // Testing:
            actual.SetValue(type, value);

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.That(actual.GetParameter(type).Value, Is.EqualTo(expectedValue));
                });
        }

        [Test(Description = "Позитивный тест метода UpdateBorders")]
        [TestCase(ParameterType.BoxWidth, 450,
            ParameterType.LegDiameter, 4, 225)]
        [TestCase(ParameterType.BoxLength, 1200,
            ParameterType.CircleGrooveDistance, 5, 1191)]
        [TestCase(ParameterType.BoxLength, 1200,
            ParameterType.RectangleGrooveDistance, 5, 1191)]
        [TestCase(ParameterType.BoxWallThickness, 5,
            ParameterType.CircleGrooveDistance, 5, 485)]
        [TestCase(ParameterType.BoxWallThickness, 5,
            ParameterType.RectangleGrooveDistance, 5, 485)]
        [TestCase(ParameterType.CircleGrooveDiameter, 20,
            ParameterType.CircleGrooveDistance, 5, 491)]
        [TestCase(ParameterType.RectangleGrooveWidth, 14,
            ParameterType.RectangleGrooveDistance, 14, 482)]
        [TestCase(ParameterType.BoxHeight, 390,
            ParameterType.RectangleHoleHeight, 20, 195)]
        [TestCase(ParameterType.BoxHeight, 390,
            ParameterType.CircleHoleHeight, 7, 192)]
        public void Parameters_UpdateBorders_BordersAreUpdated(
            ParameterType variableParameterType, double variableParam,
            ParameterType checkedParameter, double expectedMin, double expectedMax)
        {
            // Setup:

            // Testing:
            Parameters actual = new Parameters();
            actual.SetValue(variableParameterType, variableParam);

            actual.UpdateBorders();

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.That(actual.GetParameter(checkedParameter).MinValue, Is.EqualTo(expectedMin));
                    Assert.That(actual.GetParameter(checkedParameter).MaxValue, Is.EqualTo(expectedMax));
                });
        }

        [Test(Description = "Позитивный тест метода CalculateCount")]
        [TestCase(500,2,20,25,10)]
        public void Parameters_CalculateCount_ValueIsCorrect(
            double length, double thickness,
            double width, double distance, int expectedCount)
        {

            Parameters actual = new Parameters();
            actual.SetValue(ParameterType.BoxLength, length);
            actual.SetValue(ParameterType.BoxWallThickness, thickness);

            Assert.That(actual.CalculateCount(width, distance),
                Is.EqualTo(expectedCount));
        }

        [Test(Description = "Позитивный тест метода InitHoleGrooveCount")]
        [TestCase(24,49,19)]
        public void Parameters_InitHoleGrooveCount_ValuesAreGetted(
            int expectedCircleHoleCount, int expectedCircleGrooveCount,
            int expectedRectangleGrooveCount)
        {
            // Setup:

            // Testing:
            Parameters actual = new Parameters();

            actual.InitHoleGrooveCount();

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.That(actual.GetCircleHoleCount(), Is.EqualTo(expectedCircleHoleCount));
                    Assert.That(actual.GetCircleGroovesCount(), Is.EqualTo(expectedCircleGrooveCount));
                    Assert.That(actual.GetRectangleGroovesCount(), Is.EqualTo(expectedRectangleGrooveCount));
                });
        }
    }
}
