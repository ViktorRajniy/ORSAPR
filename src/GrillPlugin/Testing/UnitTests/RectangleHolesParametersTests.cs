namespace UnitTests
{
    using Model;

    [TestFixture]
    public class RectangleHolesParametersTests
    {
        [Test(Description = "Позитивный тест конструктора RectangleHolesParameters")]
        public void RectangleHolesParameters_ValueIsConstructed()
        {
            // Setup:
            Parameter expectedHeight = new Parameter(20, 20, 249);

            // Testing:
            RectangleHolesParameters actual = new RectangleHolesParameters();

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.That(
                        actual.GetParameter(ParameterType.RectangleHoleHeight).MinValue,
                        Is.EqualTo(expectedHeight.MinValue));
                    Assert.That(
                        actual.GetParameter(ParameterType.RectangleHoleHeight).Value,
                        Is.EqualTo(expectedHeight.Value));
                    Assert.That(
                        actual.GetParameter(ParameterType.RectangleHoleHeight).MaxValue,
                        Is.EqualTo(expectedHeight.MaxValue));
                });
        }

        [Test(Description = "Позитивный тест сеттера Set")]
        public void RectangleHolesParameters_SetCorrectValue_ValueIsSetted()
        {
            // Setup:
            double expectedHeight = 100;

            // Testing:
            RectangleHolesParameters actual = new RectangleHolesParameters();
            actual.Set(ParameterType.RectangleHoleHeight, 100);

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.That(
                        actual.GetParameter(ParameterType.RectangleHoleHeight).Value,
                        Is.EqualTo(expectedHeight));
                });
        }

        [Test(Description = "Позитивный тест метода NewRectangleHoleHeightBorders")]
        public void RectangleHolesParameters_NewRectangleHoleHeightBorders_NewBordersIsSetted()
        {
            // Setup:
            double expectedMinHeight = 20;
            double expectedMaxHeight = 100;

            // Testing:
            RectangleHolesParameters actual = new RectangleHolesParameters();

            actual.Set(ParameterType.RectangleHoleHeight, 25);

            actual.NewRectangleHoleHeightBorders(200);

            // Assert:
            Assert.Multiple(
                () =>
                {
                    Assert.That(
                        actual.GetParameter(ParameterType.RectangleHoleHeight).MinValue,
                        Is.EqualTo(expectedMinHeight));
                    Assert.That(
                        actual.GetParameter(ParameterType.RectangleHoleHeight).MaxValue,
                        Is.EqualTo(expectedMaxHeight));
                });
        }
    }
}
