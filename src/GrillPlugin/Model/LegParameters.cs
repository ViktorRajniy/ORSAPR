namespace Model
{
    using GrillPlugin.Model;
    using System.Collections.Generic;

    /// <summary>
    /// Параметры ножек мангала.
    /// </summary>
    public class LegParameters
    {
        /// <summary>
        /// Минимальная высота ножек мангала.
        /// </summary>
        private readonly double _minLegHeight = 500;

        /// <summary>
        /// Максимальная высота ножек мангала.
        /// </summary>
        private readonly double _maxLegHeight = 1000;

        /// <summary>
        /// Минимальный диаметр ножек мангала.
        /// </summary>
        private readonly double _minLegDiameter = 4;

        /// <summary>
        /// Максимальный диаметр ножек мангала.
        /// </summary>
        private readonly double _maxLegDiameter = 150;

        /// <summary>
        /// Словарь Тип параметра - Значение параметра мангала.
        /// </summary>
        private readonly Dictionary<ParameterType, Parameter> _legParameters;

        /// <summary>
        /// Конструктор параметров ног.
        /// </summary>
        public LegParameters()
        {
            _legParameters = new Dictionary<ParameterType, Parameter>()
            {
                {
                ParameterType.LegHeight,
                new Parameter(
                    _minLegHeight,
                    _minLegHeight,
                    _maxLegHeight)
                },
                {
                ParameterType.LegDiameter,
                new Parameter(
                    _minLegDiameter,
                    _minLegDiameter,
                    _maxLegDiameter)
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
            _legParameters[type].Value = value;
        }

        /// <summary>
        /// Возвращает параметр.
        /// </summary>
        /// <param name="type">Тип параметра.</param>
        /// <returns>Параметр.</returns>
        public Parameter GetParameter(ParameterType type)
        {
            return _legParameters[type];
        }

        /// <summary>
        /// Метод, задающий новые границы диаметра ножки мангала.
        /// </summary>
        public void NewDiameterBorders(double width, double thickness)
        {
            _legParameters[ParameterType.LegDiameter].MinValue =
                2 * thickness;
            _legParameters[ParameterType.LegDiameter].MaxValue =
                width / 2;
        }
    }
}
