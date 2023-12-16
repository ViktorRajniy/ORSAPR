namespace UnitTests
{
    public class ParametersTests
    {
        [Test(Description = "Позитивный тест метода InitHoleGrooveCount")]
        public void InitHoleGrooveCount_ValueCorrect()
        {
            // Setup:
            Parameters setup = new Parameters();

            int expectedHoleCount = 24;
            int expectedGrooveCount = 49;

            // Testing:
            setup.InitHoleGrooveCount();

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.That(setup.GetHoleCount(), Is.EqualTo(expectedHoleCount));
                    Assert.That(setup.GetGrooveCount(), Is.EqualTo(expectedGrooveCount));
                });
        }

        [Test(Description = "Позитивный тест метода UpdateBorders")]
        public void UpdateBorders_ValueCorrect()
        {
            // Setup:
            Parameters setup = new Parameters();

            setup.SetValue(ParameterType.BoxLength, 1500);
            setup.SetValue(ParameterType.BoxWidth, 400);
            setup.SetValue(ParameterType.BoxHeight, 450);
            setup.SetValue(ParameterType.BoxWallThickness, 6);
            setup.SetValue(ParameterType.LegHeight, 750);
            setup.SetValue(ParameterType.LegDiameter, 16);
            setup.SetValue(ParameterType.GrooveDiameter, 12);
            setup.SetValue(ParameterType.GrooveDistance, 22);
            setup.SetValue(ParameterType.HoleDiameter, 50);
            setup.SetValue(ParameterType.HoleHeight, 67);
            setup.SetValue(ParameterType.HoleDistance, 50);

            double expectedMinLegDiameter = 12;
            double expectedMaxLegDiameter = 200;

            double expectedMinGrooveDistance = 12;
            double expectedMaxGrooveDistance = 1476;

            double expectedMinHoleDiameter = 10;
            double expectedMaxHoleDiameter = 225;

            double expectedMinHoleHeight = 31;
            double expectedMaxHoleHeight = 206;

            double expectedMinHoleDistance = 50;
            double expectedMaxHoleDistance = 1438;

            // Testing:
            setup.UpdateBorders();

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.That(setup.GetParameter(ParameterType.LegDiameter).MinValue, Is.EqualTo(expectedMinLegDiameter));
                    Assert.That(setup.GetParameter(ParameterType.LegDiameter).MaxValue, Is.EqualTo(expectedMaxLegDiameter));

                    Assert.That(setup.GetParameter(ParameterType.GrooveDistance).MinValue, Is.EqualTo(expectedMinGrooveDistance));
                    Assert.That(setup.GetParameter(ParameterType.GrooveDistance).MaxValue, Is.EqualTo(expectedMaxGrooveDistance));

                    Assert.That(setup.GetParameter(ParameterType.HoleDiameter).MinValue, Is.EqualTo(expectedMinHoleDiameter));
                    Assert.That(setup.GetParameter(ParameterType.HoleDiameter).MaxValue, Is.EqualTo(expectedMaxHoleDiameter));

                    Assert.That(setup.GetParameter(ParameterType.HoleHeight).MinValue, Is.EqualTo(expectedMinHoleHeight));
                    Assert.That(setup.GetParameter(ParameterType.HoleHeight).MaxValue, Is.EqualTo(expectedMaxHoleHeight));

                    Assert.That(setup.GetParameter(ParameterType.HoleDistance).MinValue, Is.EqualTo(expectedMinHoleDistance));
                    Assert.That(setup.GetParameter(ParameterType.HoleDistance).MaxValue, Is.EqualTo(expectedMaxHoleDistance));
                });
        }
    }
}
