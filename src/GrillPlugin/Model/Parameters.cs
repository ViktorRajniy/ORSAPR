namespace GrillPlugin.Model
{
    using global::ModelData;

    /// <summary>
    /// Описание.
    /// </summary>
    public class Parameters
    {
        /// <summary>
        /// Параметры короба мангала.
        /// </summary>
        private readonly BoxParameters _boxParameters;

        /// <summary>
        /// Параметры ножек мангала.
        /// </summary>
        private readonly LegParameters _legParameters;

        /// <summary>
        /// Параметры круглых отверстий мангала.
        /// </summary>
        private readonly CircleHolesParameters _circleHolesParameters;

        /// <summary>
        /// Параметры прямоугольного отверстия мангала.
        /// </summary>
        private readonly RectangleHolesParameters _rectangleHolesParameters;

        /// <summary>
        /// Параметры круглых пазов мангала.
        /// </summary>
        private readonly CircleGroovesParameters _circleGroovesParameters;

        /// <summary>
        /// Параметры прямоугольных пазов мангала.
        /// </summary>
        private readonly RectangleGroovesParameters _rectangleGroovesParameters;

        /// <summary>
        /// Конструктор начальных значений.
        /// </summary>
        public Parameters()
        {
            _boxParameters = new BoxParameters();
            _legParameters = new LegParameters();
            _circleHolesParameters = new CircleHolesParameters();
            _rectangleHolesParameters = new RectangleHolesParameters();
            _circleGroovesParameters = new CircleGroovesParameters();
            _rectangleGroovesParameters = new RectangleGroovesParameters();
        }

        /// <summary>
        /// Возвращает значение параметра.
        /// </summary>
        /// <param name="type">Тип параметра.</param>
        /// <returns>Значение параметра.</returns>
        public Parameter GetParameter(ParameterType type)
        {
            if (type == ParameterType.BoxLength
                || type == ParameterType.BoxWidth
                || type == ParameterType.BoxHeight
                || type == ParameterType.BoxWallThickness)
            {
                return _boxParameters.GetParameter(type);
            }

            if (type == ParameterType.LegHeight
                || type == ParameterType.LegDiameter)
            {
                return _legParameters.GetParameter(type);
            }

            if (type == ParameterType.CircleHoleHeight
                || type == ParameterType.CircleHoleDiameter
                || type == ParameterType.CircleHoleDistance
                || type == ParameterType.BoxWallThickness)
            {
                return _circleHolesParameters.GetParameter(type);
            }

            if (type == ParameterType.RectangleHoleHeight)
            {
                return _rectangleHolesParameters.GetParameter(type);
            }

            if (type == ParameterType.CircleGrooveDiameter
                || type == ParameterType.CircleGrooveDistance)
            {
                return _circleGroovesParameters.GetParameter(type);
            }

            return _rectangleGroovesParameters.GetParameter(type);
        }

        /// <summary>
        /// Задаёт новое значение параметра.
        /// </summary>
        /// <param name="type">Тип задаваемого параметра.</param>
        /// <param name="value">Новое значение задаваемого параметра.</param>
        public void SetValue(ParameterType type, double value)
        {
            switch (type)
            {
                case ParameterType.BoxLength:
                case ParameterType.BoxWidth:
                case ParameterType.BoxHeight:
                case ParameterType.BoxWallThickness:
                {
                    _boxParameters.Set(type, value);
                    break;
                }

                case ParameterType.LegDiameter:
                case ParameterType.LegHeight:
                {
                    _legParameters.Set(type, value);
                    break;
                }

                case ParameterType.CircleHoleHeight:
                case ParameterType.CircleHoleDiameter:
                case ParameterType.CircleHoleDistance:
                {
                    _circleHolesParameters.Set(type, value);
                    break;
                }

                case ParameterType.RectangleHoleHeight:
                {
                    _rectangleHolesParameters.Set(type, value);
                    break;
                }

                case ParameterType.CircleGrooveDiameter:
                case ParameterType.CircleGrooveDistance:
                {
                    _circleGroovesParameters.Set(type, value);
                    break;
                }

                case ParameterType.RectangleGrooveDistance:
                case ParameterType.RectangleGrooveHeight:
                case ParameterType.RectangleGrooveWidth:
                {
                    _rectangleGroovesParameters.Set(type, value);
                    break;
                }
            }
        }

        /// <summary>
        /// Инициализирует количество отверстий и пазов для шампуров мангала.
        /// </summary>
        public void InitHoleGrooveCount()
        {
            _circleHolesParameters.HoleCount = CalculateCount(
                _circleHolesParameters.GetParameter(
                    ParameterType.CircleHoleDiameter).Value,
                _circleHolesParameters.GetParameter(
                    ParameterType.CircleHoleDistance).Value);

            _circleGroovesParameters.GrooveCount = CalculateCount(
                _circleGroovesParameters.GetParameter(
                    ParameterType.CircleGrooveDiameter).Value,
                _circleGroovesParameters.GetParameter(
                    ParameterType.CircleGrooveDistance).Value);

            _rectangleGroovesParameters.GrooveCount = CalculateCount(
                _rectangleGroovesParameters.GetParameter(
                    ParameterType.RectangleGrooveWidth).Value,
                _rectangleGroovesParameters.GetParameter(
                    ParameterType.RectangleGrooveDistance).Value);
        }

        /// <summary>
        /// Высчитывает количество элементов в ряду.
        /// </summary>
        /// <param name="width">Ширина элемента.</param>
        /// <param name="distance">Расстояние между элементами.</param>
        public int CalculateCount(double width, double distance)
        {
            double place =
                (_boxParameters.GetParameter(ParameterType.BoxLength).Value -
                 (2 * _boxParameters.GetParameter(ParameterType.BoxWallThickness).Value)
                        - width) / (width + distance);
            return (int)place;
        }

        /// <summary>
        /// Возвращает количество круглых отверстий для поддува.
        /// </summary>
        /// <returns>Количество круглых отверстий для поддува.</returns>
        public int GetCircleHoleCount()
        {
            return _circleHolesParameters.HoleCount;
        }

        /// <summary>
        /// Возвращает количество круглых пазов для шампуров.
        /// </summary>
        /// <returns>Количество круглых пазов для шампуров.</returns>
        public int GetCircleGroovesCount()
        {
            return _circleGroovesParameters.GrooveCount;
        }

        /// <summary>
        /// Возвращает количество прямоугольных пазов для шампуров.
        /// </summary>
        /// <returns>Количество круглых пазов для шампуров.</returns>
        public int GetRectangleGroovesCount()
        {
            return _rectangleGroovesParameters.GrooveCount;
        }

        /// <summary>
        /// Метод обновляет все границы параметров.
        /// </summary>
        public void UpdateBorders()
        {
            NewRectangleHoleBorders();
            NewCircleHoleBorders();
            NewRectangleGrooveBorders();
            NewCircleGrooveBorders();
            NewLegBorders();
        }

        /// <summary>
        /// Метод, задающий новые границы круглых отверстий.
        /// </summary>
        private void NewRectangleHoleBorders()
        {
            _rectangleHolesParameters.NewRectangleHoleHeightBorders(
                _boxParameters.GetParameter(ParameterType.BoxHeight).Value);
        }

        /// <summary>
        /// Метод, задающий новые границы круглых отверстий.
        /// </summary>
        private void NewCircleHoleBorders()
        {
            Parameter borderParameter = NewDistanceBorders(
                _circleHolesParameters.GetParameter(
                    ParameterType.CircleHoleDistance).Value);

            _circleHolesParameters.SetCircleHoleDistanceBorders(
                borderParameter.MinValue, borderParameter.MaxValue);

            _circleHolesParameters.NewCircleHoleDiameterBorders(
                _boxParameters.GetParameter(ParameterType.BoxHeight).Value);

            _circleHolesParameters.NewCircleHoleHeightBorders(
                _boxParameters.GetParameter(ParameterType.BoxHeight).Value,
                _boxParameters.GetParameter(
                    ParameterType.BoxWallThickness).Value);
        }

        /// <summary>
        /// Метод, задающий новые границы расстояния между прямоугольными пазами.
        /// </summary>
        private void NewRectangleGrooveBorders()
        {
            Parameter borderParameter = NewDistanceBorders(
                _rectangleGroovesParameters.GetParameter(
                    ParameterType.RectangleGrooveWidth).Value);

            _rectangleGroovesParameters.SetDistanceBorders(
                borderParameter.MinValue, borderParameter.MaxValue);
        }

        /// <summary>
        /// Метод, задающий новые границы расстояния между круглыми пазами.
        /// </summary>
        private void NewCircleGrooveBorders()
        {
            Parameter borderParameter = NewDistanceBorders(
                _circleGroovesParameters.GetParameter(
                    ParameterType.CircleGrooveDistance).Value);

            _circleGroovesParameters.SetDistanceBorders(
                borderParameter.MinValue, borderParameter.MaxValue);
        }

        /// <summary>
        /// Метод определяющий новые границы расстояния между элементами.
        /// </summary>
        /// <param name="width">Ширина элемента.</param>
        /// <returns>Параметр с новыми граничными значениями.</returns>
        private Parameter NewDistanceBorders(double width)
        {
            Parameter borderParameter = new Parameter(1, 1, 1);

            borderParameter.MaxValue =
                _boxParameters.GetParameter(ParameterType.BoxLength).Value -
                ((2 * _boxParameters.GetParameter(
                    ParameterType.BoxWallThickness).Value) + width);
            borderParameter.Value = width;
            borderParameter.MinValue = width;

            return borderParameter;
        }

        /// <summary>
        /// Метод, задающий новые границы ножек мангала.
        /// </summary>
        private void NewLegBorders()
        {
            _legParameters.NewDiameterBorders(
                _boxParameters.GetParameter(
                    ParameterType.BoxWidth).Value,
                _boxParameters.GetParameter(
                    ParameterType.BoxWallThickness).Value);
        }
    }
}
