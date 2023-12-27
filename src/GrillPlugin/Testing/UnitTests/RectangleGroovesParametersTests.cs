namespace UnitTests
{
    using Model;

    [TestFixture]
    public class RectangleGroovesParametersTests
    {
        [Test(Description = "Позитивный тест конструктора RectangleGroovesParameters")]
        public void RectangleGroovesParameters_ValueIsConstructed()
        {
            // Setup:
            Parameter expectedHeight = new Parameter(20, 20, 100);
            Parameter expectedWidth = new Parameter(5, 5, 20);
            Parameter expectedDistanse = new Parameter(20, 20, 490);

            // Testing:
            RectangleGroovesParameters actual = new RectangleGroovesParameters();

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.That(
                        actual.GetParameter(ParameterType.RectangleGrooveHeight).MinValue,
                        Is.EqualTo(expectedHeight.MinValue));
                    Assert.That(
                        actual.GetParameter(ParameterType.RectangleGrooveHeight).Value,
                        Is.EqualTo(expectedHeight.Value));
                    Assert.That(
                        actual.GetParameter(ParameterType.RectangleGrooveHeight).MaxValue,
                        Is.EqualTo(expectedHeight.MaxValue));
                    Assert.That(
                        actual.GetParameter(ParameterType.RectangleGrooveWidth).MinValue,
                        Is.EqualTo(expectedWidth.MinValue));
                    Assert.That(
                        actual.GetParameter(ParameterType.RectangleGrooveWidth).Value,
                        Is.EqualTo(expectedWidth.Value));
                    Assert.That(
                        actual.GetParameter(ParameterType.RectangleGrooveWidth).MaxValue,
                        Is.EqualTo(expectedWidth.MaxValue));
                    Assert.That(
                        actual.GetParameter(ParameterType.RectangleGrooveDistance).MinValue,
                        Is.EqualTo(expectedDistanse.MinValue));
                    Assert.That(
                        actual.GetParameter(ParameterType.RectangleGrooveDistance).Value,
                        Is.EqualTo(expectedDistanse.Value));
                    Assert.That(
                        actual.GetParameter(ParameterType.RectangleGrooveDistance).MaxValue,
                        Is.EqualTo(expectedDistanse.MaxValue));
                });
        }

        [Test(Description = "Позитивный тест сеттера Set")]
        public void RectangleGroovesParameters_SetCorrectValue_ValueIsSetted()
        {
            // Setup:
            double expectedHeight = 80;
            double expectedWidth = 11;
            double expectedDistanse = 200;

            // Testing:
            RectangleGroovesParameters actual = new RectangleGroovesParameters();

            actual.Set(ParameterType.RectangleGrooveHeight, 80);
            actual.Set(ParameterType.RectangleGrooveWidth, 11);
            actual.Set(ParameterType.RectangleGrooveDistance, 200);

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.That(
                        actual.GetParameter(ParameterType.RectangleGrooveHeight).Value,
                        Is.EqualTo(expectedHeight));
                    Assert.That(
                        actual.GetParameter(ParameterType.RectangleGrooveWidth).Value,
                        Is.EqualTo(expectedWidth));
                    Assert.That(
                        actual.GetParameter(ParameterType.RectangleGrooveDistance).Value,
                        Is.EqualTo(expectedDistanse));
                });
        }

        [Test(Description = "Позитивный тест метода NewHeightBorders")]
        public void RectangleGroovesParameters_NewHeightBorders_NewBordersIsSetted()
        {
            // Setup:
            double expectedMinHeight = 20;
            double expectedMaxHeight = 250;

            // Testing:
            RectangleGroovesParameters actual = new RectangleGroovesParameters();

            actual.NewHeightBorders(1000);

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.That(
                        actual.GetParameter(ParameterType.RectangleGrooveHeight).MinValue,
                        Is.EqualTo(expectedMinHeight));
                    Assert.That(
                        actual.GetParameter(ParameterType.RectangleGrooveHeight).MaxValue,
                        Is.EqualTo(expectedMaxHeight));
                });
        }

        [Test(Description = "Позитивный тест метода NewDistanceBorders")]
        public void RectangleGroovesParameters_NewDistanceBorders_NewBordersIsSetted()
        {
            // Setup:
            double expectedMinHeight = 5;
            double expectedMaxHeight = 975;

            // Testing:
            RectangleGroovesParameters actual = new RectangleGroovesParameters();

            actual.NewDistanceBorders(1000, 10);

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.That(
                        actual.GetParameter(ParameterType.RectangleGrooveDistance).MinValue,
                        Is.EqualTo(expectedMinHeight));
                    Assert.That(
                        actual.GetParameter(ParameterType.RectangleGrooveDistance).MaxValue,
                        Is.EqualTo(expectedMaxHeight));
                });
        }

        [Test(Description = "Позитивный тест метода CalculateGrooveCount")]
        public void RectangleGroovesParameters_CalculateGrooveCount_CountCorrect()
        {
            // Setup:
            double expectedCount = 15;

            // Testing:
            RectangleGroovesParameters actual = new RectangleGroovesParameters();

            actual.CalculateGrooveCount(400, 10);

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.That(
                        actual.GrooveCount,
                        Is.EqualTo(expectedCount));
                });
        }
    }
}
