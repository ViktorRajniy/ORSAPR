namespace Model
{
    using GrillPlugin.Model;
    using System.Collections.Generic;

    /// <summary>
    /// Параметры круглых пазов для шампуров.
    /// </summary>
    public class CircleGroovesParameters
    {
        /// <summary>
        /// Минимальный диаметр паза для шампура мангала.
        /// </summary>
        private readonly double _minGrooveDiameter = 5;

        /// <summary>
        /// Максимальный диаметр паза для шампура мангала.
        /// </summary>
        private readonly double _maxGrooveDiameter = 20;

        /// <summary>
        /// Минимальное расстояние между пазами для шампуров мангала.
        /// </summary>
        private readonly double _minGrooveDistance = 5;

        /// <summary>
        /// Максимальное расстояние между пазами для шампуров мангала.
        /// </summary>
        private readonly double _maxGrooveDistance = 490;

        /// <summary>
        /// Словарь Тип параметра - Значение параметра мангала.
        /// </summary>
        private readonly Dictionary<ParameterType, Parameter> _groovesParameters;

        /// <summary>
        /// Конструктор круглых пазов для шампуров.
        /// </summary>
        public CircleGroovesParameters()
        {
            _groovesParameters = new Dictionary<ParameterType, Parameter>
            {
                {
                ParameterType.CircleGrooveDiameter,
                new Parameter(
                    _minGrooveDiameter,
                    _minGrooveDiameter,
                    _maxGrooveDiameter)
                },
                {
                ParameterType.CircleGrooveDistance,
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
            _groovesParameters[type].Value = value;
        }

        /// <summary>
        /// Возвращает параметр.
        /// </summary>
        /// <param name="type">Тип параметра.</param>
        /// <returns>Параметр.</returns>
        public Parameter GetParameter(ParameterType type)
        {
            return _groovesParameters[type];
        }

        /// <summary>
        /// Метод, задающий новые границы расстояния между пазами.
        /// </summary>
        public void NewDistanceBorders(double length, double thickness)
        {
            _groovesParameters[ParameterType.CircleGrooveDistance].MinValue =
                _groovesParameters[ParameterType.CircleGrooveDiameter].Value;

            _groovesParameters[ParameterType.CircleGrooveDistance].MaxValue =
               length - ((2 * thickness) +
                 _groovesParameters[ParameterType.CircleGrooveDiameter].Value);
        }

        /// <summary>
        /// Высчитывает количество пазов для шампуров в мангале.
        /// </summary>
        public void CalculateGrooveCount(double length, double thickness)
        {
            double groovePlace =
                (length - (2 * thickness)
                - _groovesParameters[ParameterType.CircleGrooveDiameter].Value) /
                (_groovesParameters[ParameterType.CircleGrooveDiameter].Value +
                _groovesParameters[ParameterType.CircleGrooveDistance].Value);
            GrooveCount = (int)groovePlace;
        }
    }
}
