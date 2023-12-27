namespace UnitTests
{
    using Model;

    [TestFixture]
    public class BoxParametersTests
    {
        [Test(Description = "Позитивный тест конструктора BoxParameters")]
        public void BoxParameters_ValueIsConstructed()
        {
            // Setup:
            Parameter expectedLenght = new Parameter(500, 500, 2000);
            Parameter expectedWidth = new Parameter(300, 300, 500);
            Parameter expectedHeight = new Parameter(200, 200, 500);
            Parameter expectedThickness = new Parameter(2, 2, 8);

            // Testing:

            BoxParameters actual = new BoxParameters();

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.That(
                        actual.GetParameter(ParameterType.BoxLength).MinValue,
                        Is.EqualTo(expectedLenght.MinValue));
                    Assert.That(
                        actual.GetParameter(ParameterType.BoxLength).Value,
                        Is.EqualTo(expectedLenght.Value));
                    Assert.That(
                        actual.GetParameter(ParameterType.BoxLength).MaxValue,
                        Is.EqualTo(expectedLenght.MaxValue));
                    Assert.That(
                        actual.GetParameter(ParameterType.BoxWidth).MinValue,
                        Is.EqualTo(expectedWidth.MinValue));
                    Assert.That(
                        actual.GetParameter(ParameterType.BoxWidth).Value,
                        Is.EqualTo(expectedWidth.Value));
                    Assert.That(
                        actual.GetParameter(ParameterType.BoxWidth).MaxValue,
                        Is.EqualTo(expectedWidth.MaxValue));
                    Assert.That(
                        actual.GetParameter(ParameterType.BoxHeight).MinValue,
                        Is.EqualTo(expectedHeight.MinValue));
                    Assert.That(
                        actual.GetParameter(ParameterType.BoxHeight).Value,
                        Is.EqualTo(expectedHeight.Value));
                    Assert.That(
                        actual.GetParameter(ParameterType.BoxHeight).MaxValue,
                        Is.EqualTo(expectedHeight.MaxValue));
                    Assert.That(
                        actual.GetParameter(ParameterType.BoxWallThickness).MinValue,
                        Is.EqualTo(expectedThickness.MinValue));
                    Assert.That(
                        actual.GetParameter(ParameterType.BoxWallThickness).Value,
                        Is.EqualTo(expectedThickness.Value));
                    Assert.That(
                        actual.GetParameter(ParameterType.BoxWallThickness).MaxValue,
                        Is.EqualTo(expectedThickness.MaxValue));
                });
        }

        [Test(Description = "Позитивный тест сеттера Set")]
        public void BoxParameters_SetCorrectValue_ValueIsSetted()
        {
            // Setup:
            double expectedLenght = 750;
            double expectedWidth = 325;
            double expectedHeight = 400;
            double expectedThickness = 6;

            // Testing:
            BoxParameters actual = new BoxParameters();
            actual.Set(ParameterType.BoxLength, 750);
            actual.Set(ParameterType.BoxWidth, 325);
            actual.Set(ParameterType.BoxHeight, 400);
            actual.Set(ParameterType.BoxWallThickness, 6);

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.That(
                        actual.GetParameter(ParameterType.BoxLength).Value,
                        Is.EqualTo(expectedLenght));
                    Assert.That(
                        actual.GetParameter(ParameterType.BoxWidth).Value,
                        Is.EqualTo(expectedWidth));
                    Assert.That(
                        actual.GetParameter(ParameterType.BoxHeight).Value,
                        Is.EqualTo(expectedHeight));
                    Assert.That(
                        actual.GetParameter(ParameterType.BoxWallThickness).Value,
                        Is.EqualTo(expectedThickness));
                });
        }
    }
}
