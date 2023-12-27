namespace GrillPlugin.Model
{
    using System;

    /// <summary>
    /// Параметр предмета. Включает минимальное и максимальное значение.
    /// </summary>
    public class Parameter
    {
        /// <summary>
        /// Значение параметра.
        /// </summary>
        private double _value;

        /// <summary>
        /// Минимальное значение параметра.
        /// </summary>
        private double _min;

        /// <summary>
        /// Максимальное значение параметра.
        /// </summary>
        private double _max;

        /// <summary>
        /// Конструктор параметра.
        /// </summary>
        /// <param name="value">Значение параметра.</param>
        /// <param name="min">Минимальное значение параметра.</param>
        /// <param name="max">Максимальное значение параметра.</param>
        public Parameter(double value, double min, double max)
        {
            MinValue = min;
            MaxValue = max;
            Value = value;
        }

        /// <summary>
        /// Значение параметра.
        /// </summary>
        public double Value
        {
            get => _value;
            set
            {
                if (MinMaxValidate(value))
                {
                    _value = value;
                }
            }
        }

        /// <summary>
        /// Минимальное значение параметра.
        /// </summary>
        public double MinValue
        {
            get => _min;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("минимальное значение меньше нуля");
                }

                _min = value;
            }
        }

        /// <summary>
        /// Максимальное значение параметра.
        /// </summary>
        public double MaxValue
        {
            get => _max;
            set
            {
                if (value < _min)
                {
                    throw new ArgumentException("максимальное значение меньше минимального");
                }

                _max = value;
            }
        }

        /// <summary>
        /// Метод проверяет, входит ли значение в заданный диапазон.
        /// </summary>
        /// <returns>
        /// Возвращает true, если проходит проверку, иначе ArgumentException.
        /// </returns>
        public bool MinMaxValidate(double value)
        {
            if (value > MaxValue)
            {
                throw new ArgumentException("больше границы максимума");
            }

            if (value < MinValue)
            {
                throw new ArgumentException("меньше границы минимума");
            }

            return true;
        }
    }
}
