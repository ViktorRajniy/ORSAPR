namespace ModelData
{
    using GrillPlugin.Model;
    using System.Collections.Generic;

    /// <summary>
    /// Параметры массива круглых отверстий для поддува.
    /// </summary>
    public class CircleHolesParameters
    {
        /// <summary>
        /// Минимальный диаметр отверстия мангала.
        /// </summary>
        private readonly double _minHoleDiameter = 10;

        /// <summary>
        /// Максимальный диаметр отверстия мангала.
        /// </summary>
        private readonly double _maxHoleDiameter = 100;

        /// <summary>
        /// Минимальная высота центра отверстия мангала.
        /// </summary>
        private readonly double _minHoleHeight = 7;

        /// <summary>
        /// Максимальная высота центра отверстия мангала.
        /// </summary>
        private readonly double _maxHoleHeight = 97;

        /// <summary>
        /// Минимальное расстояние между отверстиями мангала.
        /// </summary>
        private readonly double _minHoleDistance = 10;

        /// <summary>
        /// Максимальное расстояние между отверстиями мангала.
        /// </summary>
        private readonly double _maxHoleDistance = 486;

        /// <summary>
        /// Словарь Тип параметра - Значение параметра мангала.
        /// </summary>
        private readonly Dictionary<ParameterType, Parameter> _circleHolesParameters;

        /// <summary>
        /// Параметры круглых отверстий для поддува.
        /// </summary>
        public CircleHolesParameters()
        {
            _circleHolesParameters = new Dictionary<ParameterType, Parameter>
            {
                {
                ParameterType.CircleHoleDiameter,
                new Parameter(
                    _minHoleDiameter,
                    _minHoleDiameter,
                    _maxHoleDiameter)
                },
                {
                ParameterType.CircleHoleHeight,
                new Parameter(
                    _minHoleHeight,
                    _minHoleHeight,
                    _maxHoleHeight)
                },
                {
                ParameterType.CircleHoleDistance,
                new Parameter(
                    _minHoleDistance,
                    _minHoleDistance,
                    _maxHoleDistance)
                }
            };
        }

        /// <summary>
        /// Количество отверстий для вентиляции мангала.
        /// </summary>
        public int HoleCount { get; set; }

        /// <summary>
        /// Метод, устанавливающий текущее значение параметра.
        /// </summary>
        /// <param name="type">Тип параметра, в который передаётся значение.</param>
        /// <param name="value">Новое значение параметра.</param>
        public void Set(ParameterType type, double value)
        {
            _circleHolesParameters[type].Value = value;
        }

        /// <summary>
        /// Возвращает параметр.
        /// </summary>
        /// <param name="type">Тип параметра.</param>
        /// <returns>Параметр.</returns>
        public Parameter GetParameter(ParameterType type)
        {
            return _circleHolesParameters[type];
        }

        /// <summary>
        /// Метод, задающий новые границы высоты центра отверстия.
        /// </summary>
        /// <param name="height">Высота короба мангала.</param>
        /// <param name="thickness">Толщина стен мангала.</param>
        public void NewCircleHoleHeightBorders(double height, double thickness)
        {
            _circleHolesParameters[ParameterType.CircleHoleHeight].MinValue =
                thickness +
                (_circleHolesParameters[ParameterType.CircleHoleDiameter].Value / 2);

            _circleHolesParameters[ParameterType.CircleHoleHeight].MaxValue =
                (height / 2) + thickness -
                (_circleHolesParameters[ParameterType.CircleHoleDiameter].Value / 2);
        }

        /// <summary>
        /// Метод, задающий новые границы диаметра круглого отверстия.
        /// </summary>
        /// <param name="height">Высота короба мангала.</param>
        public void NewCircleHoleDiameterBorders(double height)
        {
            _circleHolesParameters[ParameterType.CircleHoleDiameter].MinValue =
                _minHoleDiameter;

            _circleHolesParameters[ParameterType.CircleHoleDiameter].MaxValue =
                height / 2;
        }

        /// <summary>
        /// Метод, задающий новые границы расстояния между отверстиями.
        /// </summary>
        /// <param name="min">Минимальная граница расстояния между элементами.</param>
        /// <param name="max">Максимальная граница расстояния между элементами.</param>
        public void SetCircleHoleDistanceBorders(double min, double max)
        {
            _circleHolesParameters[ParameterType.CircleHoleDistance].MinValue = min;

            _circleHolesParameters[ParameterType.CircleHoleDistance].MaxValue = max;
        }
    }
}
