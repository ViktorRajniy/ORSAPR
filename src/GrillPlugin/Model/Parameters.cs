namespace GrillPlugin.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// Описание.
    /// </summary>
    public class Parameters
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
        private readonly Dictionary<ParameterType, Parameter> _parametersValue;

        /// <summary>
        /// Количество отверстий для вентиляции мангала.
        /// </summary>
        private int _holeCount;

        /// <summary>
        /// Количество пазов для шампуров мангала.
        /// </summary>
        private int _grooveCount;

        /// <summary>
        /// Конструктор начальных значений.
        /// </summary>
        public Parameters()
        {
            _parametersValue = new Dictionary<ParameterType, Parameter>
            {
                {
                ParameterType.BoxLength,
                new Parameter(_minBoxLength, _minBoxLength, _maxBoxLength)
                },
                {
                ParameterType.BoxWidth,
                new Parameter(_minBoxWidth, _minBoxWidth, _maxBoxWidth)
                },
                {
                ParameterType.BoxWallThickness,
                new Parameter(_minBoxThickness, _minBoxThickness, _maxBoxThickness)
                },
                {
                ParameterType.BoxHeight,
                new Parameter(_minBoxHeight, _minBoxHeight, _maxBoxHeight)
                },
                {
                ParameterType.LegHeight,
                new Parameter(_minLegHeight, _minLegHeight, _maxLegHeight)
                },
                {
                ParameterType.LegDiameter,
                new Parameter(_minLegDiameter, _minLegDiameter, _maxLegDiameter)
                },
                {
                ParameterType.GrooveDiameter,
                new Parameter(_minGrooveDiameter, _minGrooveDiameter, _maxGrooveDiameter)
                },
                {
                ParameterType.GrooveDistance,
                new Parameter(_minGrooveDistance, _minGrooveDistance, _maxGrooveDistance)
                },
                {
                ParameterType.HoleDiameter,
                new Parameter(_minHoleDiameter, _minHoleDiameter, _maxHoleDiameter)
                },
                {
                ParameterType.HoleHeight,
                new Parameter(_minHoleHeight, _minHoleHeight, _maxHoleHeight)
                },
                {
                ParameterType.HoleDistance,
                new Parameter(_minHoleDistance, _minHoleDistance, _maxHoleDistance)
                }
            };
        }

        /// <summary>
        /// Возвращает значение количества пазов для шампуров мангала.
        /// </summary>
        /// <returns>Количество пазов для шампуров мангала.</returns>
        public int GetGrooveCount()
        {
            return _grooveCount;
        }

        /// <summary>
        /// Возвращает значение количества отверстий для вентиляции мангала.
        /// </summary>
        /// <returns>Количество отверстий для вентиляции.</returns>
        public int GetHoleCount()
        {
            return _holeCount;
        }

        /// <summary>
        /// Метод обновляет все границы параметров.
        /// </summary>
        public void UpdateBorders()
        {
            NewGrooveDistanceBorders();
            NewHoleDiameterBorders();
            NewHoleDistanceBorders();
            NewHoleHeightBorders();
            NewLegDiameterBorders();
        }

        /// <summary>
        /// Метод, устанавливающий текущее значение параметра.
        /// </summary>
        /// <param name="type">Тип параметра, в который передаётся значение.</param>
        /// <param name="value">Новое значение параметра.</param>
        public void SetValue(ParameterType type, double value)
        {
            _parametersValue[type].Value = value;
        }

        /// <summary>
        /// Возвращает параметр, запрошенного типа.
        /// </summary>
        /// <param name="type">Тип запрашиваемого параметра.</param>
        /// <returns>Параметр, запрашиваемого типа.</returns>
        public Parameter GetParameter(ParameterType type)
        {
            return _parametersValue[type];
        }

        /// <summary>
        /// Присваивает количеству отверстий и пазов новые значения.
        /// </summary>
        public void InitHoleGrooveCount()
        {
            CalculateGrooveCount();
            CalculateHoleCount();
        }

        /// <summary>
        /// Высчитывает количество отверстий для вентиляции в мангале.
        /// </summary>
        private void CalculateHoleCount()
        {
            double holePlace =
                (_parametersValue[ParameterType.BoxLength].Value -
                (2 * _parametersValue[ParameterType.BoxWallThickness].Value)
                - _parametersValue[ParameterType.HoleDiameter].Value) /
                (_parametersValue[ParameterType.HoleDiameter].Value +
                _parametersValue[ParameterType.HoleDistance].Value);
            _holeCount = (int)holePlace;
        }

        /// <summary>
        /// Высчитывает количество пазов для шампуров в мангале.
        /// </summary>
        private void CalculateGrooveCount()
        {
            double groovePlace =
                (_parametersValue[ParameterType.BoxLength].Value -
                (2 * _parametersValue[ParameterType.BoxWallThickness].Value)
                - _parametersValue[ParameterType.GrooveDiameter].Value) /
                (_parametersValue[ParameterType.GrooveDiameter].Value +
                _parametersValue[ParameterType.GrooveDistance].Value);
            _grooveCount = (int)groovePlace;
        }

        /// <summary>
        /// Метод, задающий новые границы расстояния между отверстиями.
        /// </summary>
        private void NewHoleDistanceBorders()
        {
            _parametersValue[ParameterType.HoleDistance].MinValue = _parametersValue[ParameterType.HoleDiameter].Value;
            _parametersValue[ParameterType.HoleDistance].MaxValue = _parametersValue[ParameterType.BoxLength].Value - ((2 * _parametersValue[ParameterType.BoxWallThickness].Value) + _parametersValue[ParameterType.HoleDiameter].Value);
        }

        /// <summary>
        /// Метод, задающий новые границы высоты центра отверстия.
        /// </summary>
        private void NewHoleHeightBorders()
        {
            _parametersValue[ParameterType.HoleHeight].MinValue = _parametersValue[ParameterType.BoxWallThickness].Value + (_parametersValue[ParameterType.HoleDiameter].Value / 2);
            _parametersValue[ParameterType.HoleHeight].MaxValue = (_parametersValue[ParameterType.BoxHeight].Value / 2) + _parametersValue[ParameterType.BoxWallThickness].Value - (_parametersValue[ParameterType.HoleDiameter].Value / 2);
        }

        /// <summary>
        /// Метод, задающий новые границы диаметра отверстия.
        /// </summary>
        private void NewHoleDiameterBorders()
        {
            _parametersValue[ParameterType.HoleDiameter].MinValue = _minHoleDiameter;
            _parametersValue[ParameterType.HoleDiameter].MaxValue = _parametersValue[ParameterType.BoxHeight].Value / 2;
        }

        /// <summary>
        /// Метод, задающий новые границы расстояния между пазами.
        /// </summary>
        private void NewGrooveDistanceBorders()
        {
            _parametersValue[ParameterType.GrooveDistance].MinValue = _parametersValue[ParameterType.GrooveDiameter].Value;
            _parametersValue[ParameterType.GrooveDistance].MaxValue = _parametersValue[ParameterType.BoxLength].Value - ((2 * _parametersValue[ParameterType.BoxWallThickness].Value) + _parametersValue[ParameterType.GrooveDiameter].Value);
        }

        /// <summary>
        /// Метод, задающий новые границы диаметра ножки мангала.
        /// </summary>
        private void NewLegDiameterBorders()
        {
            _parametersValue[ParameterType.LegDiameter].MinValue = 2 * _parametersValue[ParameterType.BoxWallThickness].Value;
            _parametersValue[ParameterType.LegDiameter].MaxValue = _parametersValue[ParameterType.BoxWidth].Value / 2;
        }
    }
}
