namespace UnitTests
{
    using Model;

    [TestFixture]
    public class CircleHolesParametersTests
    {
        [Test(Description = "Позитивный тест конструктора CircleHolesParameters")]
        public void CircleHolesParameters_ValueIsConstructed()
        {
            // Setup:
            Parameter expectedDiameter = new Parameter(10, 10, 100);
            Parameter expectedHeight = new Parameter(7, 7, 97);
            Parameter expectedDistanse = new Parameter(10, 10, 486);

            // Testing:
            CircleHolesParameters actual = new CircleHolesParameters();

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.That(
                        actual.GetParameter(ParameterType.CircleHoleDiameter).MinValue,
                        Is.EqualTo(expectedDiameter.MinValue));
                    Assert.That(
                        actual.GetParameter(ParameterType.CircleHoleDiameter).Value,
                        Is.EqualTo(expectedDiameter.Value));
                    Assert.That(
                        actual.GetParameter(ParameterType.CircleHoleDiameter).MaxValue,
                        Is.EqualTo(expectedDiameter.MaxValue));
                    Assert.That(
                        actual.GetParameter(ParameterType.CircleHoleHeight).MinValue,
                        Is.EqualTo(expectedHeight.MinValue));
                    Assert.That(
                        actual.GetParameter(ParameterType.CircleHoleHeight).Value,
                        Is.EqualTo(expectedHeight.Value));
                    Assert.That(
                        actual.GetParameter(ParameterType.CircleHoleHeight).MaxValue,
                        Is.EqualTo(expectedHeight.MaxValue));
                    Assert.That(
                        actual.GetParameter(ParameterType.CircleHoleDistance).MinValue,
                        Is.EqualTo(expectedDistanse.MinValue));
                    Assert.That(
                        actual.GetParameter(ParameterType.CircleHoleDistance).Value,
                        Is.EqualTo(expectedDistanse.Value));
                    Assert.That(
                        actual.GetParameter(ParameterType.CircleHoleDistance).MaxValue,
                        Is.EqualTo(expectedDistanse.MaxValue));
                });
        }

        [Test(Description = "Позитивный тест сеттера Set")]
        public void CircleHolesParameters_SetCorrectValue_ValueIsSetted()
        {
            // Setup:
            double expectedDiameter = 50;
            double expectedDistanse = 200;
            double expectedHeight = 56;

            // Testing:
            CircleHolesParameters actual = new CircleHolesParameters();

            actual.Set(ParameterType.CircleHoleDiameter, 50);
            actual.Set(ParameterType.CircleHoleDistance, 200);
            actual.Set(ParameterType.CircleHoleHeight, 56);

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.That(
                        actual.GetParameter(ParameterType.CircleHoleDiameter).Value,
                        Is.EqualTo(expectedDiameter));
                    Assert.That(
                        actual.GetParameter(ParameterType.CircleHoleDistance).Value,
                        Is.EqualTo(expectedDistanse));
                    Assert.That(
                        actual.GetParameter(ParameterType.CircleHoleHeight).Value,
                        Is.EqualTo(expectedHeight));
                });
        }

        [Test(Description = "Позитивный тест метода NewCircleHoleDiameterBorders")]
        public void CircleHolesParameters_NewCircleHoleDiameterBorders_NewBordersIsSetted()
        {
            // Setup:
            double expectedMinHeight = 10;
            double expectedMaxHeight = 100;

            // Testing:
            CircleHolesParameters actual = new CircleHolesParameters();

            actual.Set(ParameterType.CircleHoleDiameter, 25);

            actual.NewCircleHoleDiameterBorders(200);

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.That(
                        actual.GetParameter(ParameterType.CircleHoleDiameter).MinValue,
                        Is.EqualTo(expectedMinHeight));
                    Assert.That(
                        actual.GetParameter(ParameterType.CircleHoleDiameter).MaxValue,
                        Is.EqualTo(expectedMaxHeight));
                });
        }

        [Test(Description = "Позитивный тест метода NewCircleHoleDistanceBorders")]
        public void CircleHolesParameters_NewCircleHoleDistanceBorders_NewBordersIsSetted()
        {
            // Setup:
            double expectedMinHeight = 25;
            double expectedMaxHeight = 155;

            // Testing:
            CircleHolesParameters actual = new CircleHolesParameters();

            actual.Set(ParameterType.CircleHoleDiameter, 25);

            actual.Set(ParameterType.CircleHoleDistance, 25);

            actual.NewCircleHoleDistanceBorders(200, 10);

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.That(
                        actual.GetParameter(ParameterType.CircleHoleDistance).MinValue,
                        Is.EqualTo(expectedMinHeight));
                    Assert.That(
                        actual.GetParameter(ParameterType.CircleHoleDistance).MaxValue,
                        Is.EqualTo(expectedMaxHeight));
                });
        }

        [Test(Description = "Позитивный тест метода NewCircleHoleHeightBorders")]
        public void CircleHolesParameters_NewCircleHoleHeightBorders_NewBordersIsSetted()
        {
            // Setup:
            double expectedMinHeight = 25;
            double expectedMaxHeight = 195;

            // Testing:
            CircleHolesParameters actual = new CircleHolesParameters();

            actual.Set(ParameterType.CircleHoleDiameter, 30);

            actual.Set(ParameterType.CircleHoleHeight, 25);

            actual.NewCircleHoleHeightBorders(400, 10);

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.That(
                        actual.GetParameter(ParameterType.CircleHoleHeight).MinValue,
                        Is.EqualTo(expectedMinHeight));
                    Assert.That(
                        actual.GetParameter(ParameterType.CircleHoleHeight).MaxValue,
                        Is.EqualTo(expectedMaxHeight));
                });
        }

        [Test(Description = "Позитивный тест метода CalculateHoleCount")]
        public void CircleHolesParameters_CalculateHoleCount_CountCorrect()
        {
            // Setup:
            double expectedCount = 18;

            // Testing:
            CircleHolesParameters actual = new CircleHolesParameters();

            actual.CalculateHoleCount(400, 10);

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.That(
                        actual.HoleCount,
                        Is.EqualTo(expectedCount));
                });
        }
    }
}
