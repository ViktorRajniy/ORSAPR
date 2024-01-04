namespace ModelData
{
    using GrillPlugin.Model;
    using System.Collections.Generic;

    /// <summary>
    /// Параметры прямоугольных пазов для шампуров.
    /// </summary>
    public class RectangleGroovesParameters
    {
        /// <summary>
        /// Минимальный диаметр паза для шампура мангала.
        /// </summary>
        private readonly double _minRectangleHeight = 20;

        /// <summary>
        /// Максимальный диаметр паза для шампура мангала.
        /// </summary>
        private readonly double _maxRectangleHeight = 100;

        /// <summary>
        /// Минимальный диаметр паза для шампура мангала.
        /// </summary>
        private readonly double _minRectangleWidth = 5;

        /// <summary>
        /// Максимальный диаметр паза для шампура мангала.
        /// </summary>
        private readonly double _maxRectangleWidth = 20;

        /// <summary>
        /// Минимальное расстояние между пазами для шампуров мангала.
        /// </summary>
        private readonly double _minGrooveDistance = 20;

        /// <summary>
        /// Максимальное расстояние между пазами для шампуров мангала.
        /// </summary>
        private readonly double _maxGrooveDistance = 490;

        /// <summary>
        /// Словарь Тип параметра - Значение параметра мангала.
        /// </summary>
        private readonly Dictionary<ParameterType, Parameter> _rectangleGroovesParameters;

        /// <summary>
        /// Конструктор параметров прямоугольного выреза.
        /// </summary>
        public RectangleGroovesParameters()
        {
            _rectangleGroovesParameters = new Dictionary<ParameterType, Parameter>
            {
                {
                ParameterType.RectangleGrooveHeight,
                new Parameter(
                    _minRectangleHeight,
                    _minRectangleHeight,
                    _maxRectangleHeight)
                },
                {
                ParameterType.RectangleGrooveWidth,
                new Parameter(
                    _minRectangleWidth,
                    _minRectangleWidth,
                    _maxRectangleWidth)
                },
                {
                ParameterType.RectangleGrooveDistance,
                new Parameter(
                    _minGrooveDistance,
                    _minGrooveDistance,
                    _maxGrooveDistance)
                },
            };
        }

        /// <summary>
        /// Количество пазов для шампуров мангала.
        /// </summary>
        public int GrooveCount { get; set; }

        /// <summary>
        /// Метод, устанавливающий текущее значение параметра.
        /// </summary>
        /// <param name="type">Тип параметра, в который передаётся значение.</param>
        /// <param name="value">Новое значение параметра.</param>
        public void Set(ParameterType type, double value)
        {
            _rectangleGroovesParameters[type].Value = value;
        }

        /// <summary>
        /// Возвращает параметр.
        /// </summary>
        /// <param name="type">Тип параметра.</param>
        /// <returns>Параметр.</returns>
        public Parameter GetParameter(ParameterType type)
        {
            return _rectangleGroovesParameters[type];
        }

        /// <summary>
        /// Метод, задающий новые границы расстояния между пазами.
        /// </summary>
        /// <param name="min">Минимальная граница расстояния между элементами.</param>
        /// <param name="max">Максимальная граница расстояния между элементами.</param>
        public void SetDistanceBorders(double min, double max)
        {
            _rectangleGroovesParameters[
                ParameterType.RectangleGrooveDistance].MinValue = min;

            _rectangleGroovesParameters[
                ParameterType.RectangleGrooveDistance].MaxValue = max;
        }

        /// <summary>
        /// Метод, задающий новые границы высоты пазов.
        /// </summary>
        /// <param name="height">Высота короба мангала.</param>
        public void NewHeightBorders(double height)
        {
            _rectangleGroovesParameters[ParameterType.RectangleGrooveHeight].MaxValue =
                height / 4;
        }
    }
}
