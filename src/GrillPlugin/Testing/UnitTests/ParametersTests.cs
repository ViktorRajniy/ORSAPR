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
        public void Parameters_GetValue_ValueIsGetted(ParameterType type, double expectedvalue, double expectedMinValue, double expectedMaxValue)
        {
            // Setup:

            // Testing:
            Parameters actual = new Parameters();

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.AreEqual(expectedvalue, actual.GetParameter(type).Value);
                    Assert.AreEqual(expectedMinValue, actual.GetParameter(type).MinValue);
                    Assert.AreEqual(expectedMaxValue, actual.GetParameter(type).MaxValue);
                });
        }

        [Test(Description = "Позитивный тест сеттера GetParameter")]
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
                    Assert.AreEqual(expectedValue, actual.GetParameter(type).Value);
                });
        }

        [Test(Description = "Позитивный тест метода InitHoleGrooveCount")]
        public void Parameters_InitHoleGrooveCount_ValuesAreGetted()
        {
            // Setup:
            int expectedCircleHoleCount = 24;
            int expectedCircleGrooveCount = 49;
            int expectedRectangleGrooveCount = 19;

            // Testing:
            Parameters actual = new Parameters();

            actual.InitHoleGrooveCount();

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.AreEqual(expectedCircleHoleCount, actual.GetCircleHoleCount());
                    Assert.AreEqual(expectedCircleGrooveCount, actual.GetCircleGroovesCount());
                    Assert.AreEqual(expectedRectangleGrooveCount, actual.GetRectangleGroovesCount());
                });
        }

        [Test(Description = "Позитивный тест метода UpdateBorders")]
        public void Parameters_UpdateBorders_BordersAreUpdated()
        {
            // Setup:
            double expectedMinLegDiameter = 10;
            double expectedMaxLegDiameter = 225;

            double expectedMinCircleGrooveDistance = 12;
            double expectedMaxCircleGrooveDistance = 1178;

            double expectedMinRectangleGrooveDistance = 14;
            double expectedMaxRectangleGrooveDistance = 1176;

            double expectedMinRectangleGrooveHeight = 20;
            double expectedMaxRectangleGrooveHeight = 97.5;

            double expectedMinRectangleHoleHeight = 20;
            double expectedMaxRectangleHoleHeight = 195;

            double expectedMinCircleHoleDistance = 12;
            double expectedMaxCircleHoleDistance = 1178;

            double expectedMinCircleHoleHeight = 11;
            double expectedMaxCircleHoleHeight = 194;

            double expectedMinCircleHoleDiameter = 10;
            double expectedMaxCircleHoleDiameter = 195;

            // Testing:
            Parameters actual = new Parameters();

            actual.SetValue(ParameterType.BoxLength, 1200);
            actual.SetValue(ParameterType.BoxWidth, 450);
            actual.SetValue(ParameterType.BoxHeight, 390);
            actual.SetValue(ParameterType.BoxWallThickness, 5);
            actual.SetValue(ParameterType.CircleHoleDiameter, 12);
            actual.SetValue(ParameterType.CircleGrooveDiameter, 20);
            actual.SetValue(ParameterType.RectangleGrooveWidth, 14);

            actual.UpdateBorders();

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.AreEqual(expectedMinLegDiameter, actual.GetParameter(ParameterType.LegDiameter).MinValue);
                    Assert.AreEqual(expectedMaxLegDiameter, actual.GetParameter(ParameterType.LegDiameter).MaxValue);

                    Assert.AreEqual(expectedMinCircleGrooveDistance, actual.GetParameter(ParameterType.CircleHoleDistance).MinValue);
                    Assert.AreEqual(expectedMaxCircleGrooveDistance, actual.GetParameter(ParameterType.CircleHoleDistance).MaxValue);

                    Assert.AreEqual(expectedMinRectangleGrooveDistance, actual.GetParameter(ParameterType.RectangleGrooveDistance).MinValue);
                    Assert.AreEqual(expectedMaxRectangleGrooveDistance, actual.GetParameter(ParameterType.RectangleGrooveDistance).MaxValue);

                    Assert.AreEqual(expectedMinRectangleGrooveHeight, actual.GetParameter(ParameterType.RectangleGrooveHeight).MinValue);
                    Assert.AreEqual(expectedMaxRectangleGrooveHeight, actual.GetParameter(ParameterType.RectangleGrooveHeight).MaxValue);

                    Assert.AreEqual(expectedMinRectangleHoleHeight, actual.GetParameter(ParameterType.RectangleHoleHeight).MinValue);
                    Assert.AreEqual(expectedMaxRectangleHoleHeight, actual.GetParameter(ParameterType.RectangleHoleHeight).MaxValue);

                    Assert.AreEqual(expectedMinCircleHoleDistance, actual.GetParameter(ParameterType.CircleHoleDistance).MinValue);
                    Assert.AreEqual(expectedMaxCircleHoleDistance, actual.GetParameter(ParameterType.CircleHoleDistance).MaxValue);

                    Assert.AreEqual(expectedMinCircleHoleHeight, actual.GetParameter(ParameterType.CircleHoleHeight).MinValue);
                    Assert.AreEqual(expectedMaxCircleHoleHeight, actual.GetParameter(ParameterType.CircleHoleHeight).MaxValue);

                    Assert.AreEqual(expectedMinCircleHoleDiameter, actual.GetParameter(ParameterType.CircleHoleDiameter).MinValue);
                    Assert.AreEqual(expectedMaxCircleHoleDiameter, actual.GetParameter(ParameterType.CircleHoleDiameter).MaxValue);
                });
        }
    }
}
