namespace UnitTests
{
    using Model;

    [TestFixture]
    public class LegParametersTests
    {
        [Test(Description = "Позитивный тест конструктора LegParameters")]
        public void LegParameters_ValueIsConstructed()
        {
            // Setup:
            Parameter expectedHeight = new Parameter(500, 500, 1000);
            Parameter expectedDiameter = new Parameter(4, 4, 150);

            // Testing:
            LegParameters actual = new LegParameters();

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.That(
                        actual.GetParameter(ParameterType.LegHeight).MinValue,
                        Is.EqualTo(expectedHeight.MinValue));
                    Assert.That(
                        actual.GetParameter(ParameterType.LegHeight).Value,
                        Is.EqualTo(expectedHeight.Value));
                    Assert.That(
                        actual.GetParameter(ParameterType.LegHeight).MaxValue,
                        Is.EqualTo(expectedHeight.MaxValue));
                    Assert.That(
                        actual.GetParameter(ParameterType.LegDiameter).MinValue,
                        Is.EqualTo(expectedDiameter.MinValue));
                    Assert.That(
                        actual.GetParameter(ParameterType.LegDiameter).Value,
                        Is.EqualTo(expectedDiameter.Value));
                    Assert.That(
                        actual.GetParameter(ParameterType.LegDiameter).MaxValue,
                        Is.EqualTo(expectedDiameter.MaxValue));
                });
        }

        [Test(Description = "Позитивный тест сеттера Set")]
        public void LegParameters_SetCorrectValue_ValueIsSetted()
        {
            // Setup:
            double expectedHeight = 700;
            double expectedDiameter = 50;

            // Testing:
            LegParameters actual = new LegParameters();
            actual.Set(ParameterType.LegHeight, 700);
            actual.Set(ParameterType.LegDiameter, 50);

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.That(
                        actual.GetParameter(ParameterType.LegHeight).Value,
                        Is.EqualTo(expectedHeight));
                    Assert.That(
                        actual.GetParameter(ParameterType.LegDiameter).Value,
                        Is.EqualTo(expectedDiameter));
                });
        }

        [Test(Description = "Позитивный тест метода NewDiameterBorders")]
        public void LegParameters_NewDiameterBorders_NewBordersIsSetted()
        {
            // Setup:
            double expectedMinDiameter = 20;
            double expectedMaxDiameter = 250;

            // Testing:
            LegParameters actual = new LegParameters();

            actual.Set(ParameterType.LegDiameter, 50);

            actual.NewDiameterBorders(500, 10);

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.That(
                        actual.GetParameter(ParameterType.LegDiameter).MinValue,
                        Is.EqualTo(expectedMinDiameter));
                    Assert.That(
                        actual.GetParameter(ParameterType.LegDiameter).MaxValue,
                        Is.EqualTo(expectedMaxDiameter));
                });
        }
    }
}
