namespace UnitTests
{
    using Model;

    [TestFixture]
    public class CircleGroovesParametersTests
    {
        [Test(Description = "Позитивный тест конструктора CircleGroovesParameters")]
        public void CircleGroovesParameters_ValueIsConstructed()
        {
            // Setup:
            Parameter expectedDiameter = new Parameter(5, 5, 20);
            Parameter expectedDistanse = new Parameter(5, 5, 490);

            // Testing:
            CircleGroovesParameters actual = new CircleGroovesParameters();

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.That(
                        actual.GetParameter(ParameterType.CircleGrooveDiameter).MinValue,
                        Is.EqualTo(expectedDiameter.MinValue));
                    Assert.That(
                        actual.GetParameter(ParameterType.CircleGrooveDiameter).Value,
                        Is.EqualTo(expectedDiameter.Value));
                    Assert.That(
                        actual.GetParameter(ParameterType.CircleGrooveDiameter).MaxValue,
                        Is.EqualTo(expectedDiameter.MaxValue));
                    Assert.That(
                        actual.GetParameter(ParameterType.CircleGrooveDistance).MinValue,
                        Is.EqualTo(expectedDistanse.MinValue));
                    Assert.That(
                        actual.GetParameter(ParameterType.CircleGrooveDistance).Value,
                        Is.EqualTo(expectedDistanse.Value));
                    Assert.That(
                        actual.GetParameter(ParameterType.CircleGrooveDistance).MaxValue,
                        Is.EqualTo(expectedDistanse.MaxValue));
                });
        }

        [Test(Description = "Позитивный тест сеттера Set")]
        public void CircleGroovesParameters_SetCorrectValue_ValueIsSetted()
        {
            // Setup:
            double expectedDiameter = 15;
            double expectedDistanse = 200;

            // Testing:
            CircleGroovesParameters actual = new CircleGroovesParameters();

            actual.Set(ParameterType.CircleGrooveDiameter, 15);
            actual.Set(ParameterType.CircleGrooveDistance, 200);

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.That(
                        actual.GetParameter(ParameterType.CircleGrooveDiameter).Value,
                        Is.EqualTo(expectedDiameter));
                    Assert.That(
                        actual.GetParameter(ParameterType.CircleGrooveDistance).Value,
                        Is.EqualTo(expectedDistanse));
                });
        }

        [Test(Description = "Позитивный тест метода NewDistanceBorders")]
        public void CircleGroovesParameters_NewDistanceBorders_NewBordersIsSetted()
        {
            // Setup:
            double expectedMinDistance = 20;
            double expectedMaxDistance = 960;

            // Testing:
            CircleGroovesParameters actual = new CircleGroovesParameters();

            actual.Set(ParameterType.CircleGrooveDiameter, 20);

            actual.NewDistanceBorders(1000, 10);

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.That(
                        actual.GetParameter(ParameterType.CircleGrooveDistance).MinValue,
                        Is.EqualTo(expectedMinDistance));
                    Assert.That(
                        actual.GetParameter(ParameterType.CircleGrooveDistance).MaxValue,
                        Is.EqualTo(expectedMaxDistance));
                });
        }

        [Test(Description = "Позитивный тест метода CalculateGrooveCount")]
        public void CircleGroovesParameters_CalculateGrooveCount_CountCorrect()
        {
            // Setup:
            double expectedCount = 37;

            // Testing:
            CircleGroovesParameters actual = new CircleGroovesParameters();

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
