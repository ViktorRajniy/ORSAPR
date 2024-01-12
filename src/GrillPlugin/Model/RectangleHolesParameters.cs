namespace ModelData
{
    using System.Collections.Generic;

    /// <summary>
    /// Параметры прямоугольного отверстия для поддува.
    /// </summary>
    public class RectangleHolesParameters
    {
        /// <summary>
        /// Минимальный диаметр паза для шампура мангала.
        /// </summary>
        private readonly double _minRectangleHeight = 20;

        /// <summary>
        /// Максимальный диаметр паза для шампура мангала.
        /// </summary>
        private readonly double _maxRectangleHeight = 249;

        /// <summary>
        /// Словарь Тип параметра - Значение параметра мангала.
        /// </summary>
        private readonly Dictionary<ParameterType, Parameter> _rectangleHolesParameters;

        /// <summary>
        /// Конструктор параметров прямоугольного выреза.
        /// </summary>
        public RectangleHolesParameters()
        {
            _rectangleHolesParameters = new Dictionary<ParameterType, Parameter>
            {
                {
                ParameterType.RectangleHoleHeight,
                new Parameter(
                    _minRectangleHeight,
                    _minRectangleHeight,
                    _maxRectangleHeight)
                },
            };
        }

        /// <summary>
        /// Метод, устанавливающий текущее значение параметра.
        /// </summary>
        /// <param name="type">Тип параметра, в который передаётся значение.</param>
        /// <param name="value">Новое значение параметра.</param>
        public void Set(ParameterType type, double value)
        {
            _rectangleHolesParameters[type].Value = value;
        }

        /// <summary>
        /// Возвращает параметр.
        /// </summary>
        /// <param name="type">Тип параметра.</param>
        /// <returns>Параметр.</returns>
        public Parameter GetParameter(ParameterType type)
        {
            return _rectangleHolesParameters[type];
        }

        /// <summary>
        /// Метод, задающий новые границы диаметра круглого отверстия.
        /// </summary>
        public void NewRectangleHoleHeightBorders(double height)
        {
            _rectangleHolesParameters[ParameterType.RectangleHoleHeight].MinValue =
                _minRectangleHeight;

            _rectangleHolesParameters[ParameterType.RectangleHoleHeight].MaxValue =
                height / 2;
        }
    }
}
