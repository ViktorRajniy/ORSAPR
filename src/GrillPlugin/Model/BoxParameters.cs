namespace Model
{
    using GrillPlugin.Model;
    using System.Collections.Generic;

    /// <summary>
    /// Параметры короба мангала.
    /// </summary>
    public class BoxParameters
    {
        /// <summary>
        /// Минимальная длина короба мангала.
        /// </summary>
        private readonly double _minBoxLength = 500;

        /// <summary>
        /// Максимальная длина короба мангала.
        /// </summary>
        private readonly double _maxBoxLength = 2000;

        /// <summary>
        /// Минимальная ширина короба мангала.
        /// </summary>
        private readonly double _minBoxWidth = 300;

        /// <summary>
        /// Максимальная ширина короба мангала.
        /// </summary>
        private readonly double _maxBoxWidth = 500;

        /// <summary>
        /// Минимальная толщина стен короба мангала.
        /// </summary>
        private readonly double _minBoxThickness = 2;

        /// <summary>
        /// Максимальная толщина стен короба мангала.
        /// </summary>
        private readonly double _maxBoxThickness = 8;

        /// <summary>
        /// Минимальная высота короба мангала.
        /// </summary>
        private readonly double _minBoxHeight = 200;

        /// <summary>
        /// Максимальная высота короба мангала.
        /// </summary>
        private readonly double _maxBoxHeight = 500;

        /// <summary>
        /// Словарь Тип параметра - Значение параметра мангала.
        /// </summary>
        private readonly Dictionary<ParameterType, Parameter> _boxParameters;

        /// <summary>
        /// Конструктор параметров короба мангала.
        /// </summary>
        public BoxParameters()
        {
            _boxParameters = new Dictionary<ParameterType, Parameter>
            {
            {
                ParameterType.BoxLength,
                new Parameter(
                    _minBoxLength,
                    _minBoxLength,
                    _maxBoxLength)
            },
            {
                ParameterType.BoxWidth,
                new Parameter(
                    _minBoxWidth,
                    _minBoxWidth,
                    _maxBoxWidth)
            },
            {
                ParameterType.BoxWallThickness,
                new Parameter(
                    _minBoxThickness,
                    _minBoxThickness,
                    _maxBoxThickness)
            },
            {
                ParameterType.BoxHeight,
                new Parameter(
                    _minBoxHeight,
                    _minBoxHeight,
                    _maxBoxHeight)
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
            _boxParameters[type].Value = value;
        }

        /// <summary>
        /// Возвращает параметр.
        /// </summary>
        /// <param name="type">Тип параметра.</param>
        /// <returns>Параметр.</returns>
        public Parameter GetParameter(ParameterType type)
        {
            return _boxParameters[type];
        }
    }
}
