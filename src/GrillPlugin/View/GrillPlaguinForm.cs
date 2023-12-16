namespace GrillPlugin
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using GrillPlugin.Model;
    using ModelAPI;

    /// <summary>
    /// Главная форма приложения.
    /// </summary>
    public partial class GrillPluginForm : Form
    {
        /// <summary>
        /// Параметры мангала.
        /// </summary>
        public Parameters parameters;

        /// <summary>
        /// Словарь ошибок.
        /// </summary>
        private readonly Dictionary<ParameterType, string> _errorParameters =
            new Dictionary<ParameterType, string>();

        /// <summary>
        /// Цвет текст бокса при ошибке.
        /// </summary>
        private readonly Color _errorColor = Color.Pink;

        /// <summary>
        /// Цвет текст бокса при ошибке.
        /// </summary>
        private readonly Color _defaultColor = Color.White;

        /// <summary>
        /// Строка ошибки.
        /// </summary>
        private string _errorString;

        /// <summary>
        /// Initializes a new instance of the <see cref="GrillPluginForm"/> class.
        /// </summary>
        public GrillPluginForm()
        {
            InitializeComponent();
            _errorString = string.Empty;
            parameters = new Parameters();
            UpdateFields();
            UpdateLablesBorders();
        }

        /// <summary>
        /// Событие изменения текста в TextBox.
        /// </summary>
        /// <param name="sender">Отправитель.</param>
        /// <param name="e">Событие.</param>
        private void TextBoxTextChange(object sender, EventArgs e)
        {
            try
            {
                TextBox currentTextBox = (TextBox)sender;

                DefaultTextBox(currentTextBox);

                ParameterType currentParameter = CheckTextBoxParameter(currentTextBox);

                double value = Convert.ToDouble(currentTextBox.Text);

                if (currentParameter == ParameterType.BoxLength ||
                    currentParameter == ParameterType.BoxWidth ||
                    currentParameter == ParameterType.BoxWallThickness ||
                    currentParameter == ParameterType.BoxHeight ||
                    currentParameter == ParameterType.GrooveDiameter)
                {
                    _errorParameters[currentParameter] = string.Empty;
                    parameters.SetValue(currentParameter, value);
                    parameters.UpdateBorders();
                    CheckDependedTextBoxsCorrect();
                    CheckDependedTextBoxCorrect(holeDiameterTextBox, ParameterType.HoleDiameter);
                    UpdateLablesBorders();
                }

                if (currentParameter == ParameterType.HoleDiameter)
                {
                    _errorParameters[currentParameter] = string.Empty;
                    parameters.SetValue(currentParameter, value);
                    parameters.UpdateBorders();
                    CheckDependedTextBoxsCorrect();
                    UpdateLablesBorders();
                }
                else
                {
                    _errorParameters[currentParameter] = string.Empty;
                    parameters.SetValue(currentParameter, value);
                }
            }
            catch (ArgumentException exc)
            {
                TextBox currentTextBox = (TextBox)sender;
                ParameterType currentParameter = CheckTextBoxParameter(currentTextBox);
                _errorParameters[currentParameter] = exc.Message;
                ErrorTextBox(currentTextBox);
            }
            catch (FormatException exc)
            {
                TextBox currentTextBox = (TextBox)sender;
                ParameterType currentParameter = CheckTextBoxParameter(currentTextBox);
                _errorParameters[currentParameter] = "не может быть пуст";
                ErrorTextBox(currentTextBox);
            }

            UpdateErrorLable();
        }

        /// <summary>
        /// Метод обновляет строку ошибки списком ошибок.
        /// </summary>
        private void UpdateErrorLable()
        {
            _errorString = string.Empty;
            foreach (ParameterType parameterType in _errorParameters.Keys)
            {
                if (_errorParameters[parameterType] != string.Empty)
                {
                    _errorString += "Параметр " + parameterType + " " +
                                    _errorParameters[parameterType].ToString() + "\n";
                }
            }

            if (_errorString != string.Empty)
            {
                ErrorLable.Text = _errorString;
                ErrorLable.BackColor = _errorColor;
            }
            else
            {
                ErrorLable.Text = _errorString;
                ErrorLable.BackColor = _defaultColor;
            }
        }

        /// <summary>
        /// Проверяет все текст боксы зависимых параметров.
        /// </summary>
        private void CheckDependedTextBoxsCorrect()
        {
            CheckDependedTextBoxCorrect(legDiameterTextBox, ParameterType.LegDiameter);
            CheckDependedTextBoxCorrect(grooveDistanceTextBox, ParameterType.GrooveDistance);
            CheckDependedTextBoxCorrect(holeHeightTextBox, ParameterType.HoleHeight);
            CheckDependedTextBoxCorrect(holeDistanceTextBox, ParameterType.HoleDistance);
        }

        /// <summary>
        /// Проверяет текст бокс зависимого параметра.
        /// Сначала обнуляет его и заполняет значением из Модел, чтобы запустить событие.
        /// </summary>
        private void CheckDependedTextBoxCorrect(TextBox textBox, ParameterType type)
        {
            textBox.Text = string.Empty;
            textBox.Text = parameters.GetParameter(type).Value.ToString();
        }

        /// <summary>
        /// Метод обновляет граничные значения у всех граничных лейблов зависимых параметров.
        /// </summary>
        private void UpdateLablesBorders()
        {
            UpdateLableBorders(legDiameterBorderLable, ParameterType.LegDiameter);
            UpdateLableBorders(grooveDistanceBorderLable, ParameterType.GrooveDistance);
            UpdateLableBorders(holeDiameterBorderLable, ParameterType.HoleDiameter);
            UpdateLableBorders(holeHeightBorderLable, ParameterType.HoleHeight);
            UpdateLableBorders(holeDistanceBorderLable, ParameterType.HoleDistance);
        }

        /// <summary>
        /// Обновляет граничные значения лейблов у одного текст бокса.
        /// </summary>
        private void UpdateLableBorders(Label label, ParameterType type)
        {
            label.Text = parameters.GetParameter(type).MinValue.ToString() + " - " +
                parameters.GetParameter(type).MaxValue.ToString() + ", мм";
        }

        /// <summary>
        /// Проверка на соответствие названия текст бокса, определённому параметру.
        /// </summary>
        /// <param name="textBox">Текст бокс, который нужно проверить на соответствие параметру.</param>
        /// <returns>Тип параметра мангала.</returns>
        private ParameterType CheckTextBoxParameter(TextBox textBox)
        {
            switch (textBox.Name)
            {
                case "boxLengthTextBox":
                {
                    return ParameterType.BoxLength;
                }

                case "boxWidthTextBox":
                {
                    return ParameterType.BoxWidth;
                }

                case "boxHeightTextBox":
                {
                    return ParameterType.BoxHeight;
                }

                case "wallThicknessTextBox":
                {
                    return ParameterType.BoxWallThickness;
                }

                case "legHeightTextBox":
                {
                    return ParameterType.LegHeight;
                }

                case "legDiameterTextBox":
                {
                    return ParameterType.LegDiameter;
                }

                case "grooveDiameterTextBox":
                {
                    return ParameterType.GrooveDiameter;
                }

                case "grooveDistanceTextBox":
                {
                    return ParameterType.GrooveDistance;
                }

                case "holeDiameterTextBox":
                {
                    return ParameterType.HoleDiameter;
                }

                case "holeHeightTextBox":
                {
                    return ParameterType.HoleHeight;
                }

                case "holeDistanceTextBox":
                {
                    return ParameterType.HoleDistance;
                }

                default:
                {
                    return ParameterType.HoleDistance;
                }
            }
        }

        /// <summary>
        /// Обновляет цвет текст бокса на цвет ошибки.
        /// </summary>
        /// <param name="textBox">Текст бокс, который нужно выделить.</param>
        private void ErrorTextBox(TextBox textBox)
        {
            textBox.BackColor = _errorColor;
        }

        /// <summary>
        /// Обновляет цвет текст бокса на стандартный цвет.
        /// </summary>
        /// <param name="textBox">Текст бокс, который нужно выделить.</param>
        private void DefaultTextBox(TextBox textBox)
        {
            textBox.BackColor = _defaultColor;
        }

        /// <summary>
        /// Обновляет текст боксы до начального состояния.
        /// </summary>
        private void UpdateFields()
        {
            boxLengthTextBox.BackColor = _defaultColor;
            boxLengthTextBox.Text = parameters.GetParameter(ParameterType.BoxLength).Value.ToString();

            boxHeightTextBox.BackColor = _defaultColor;
            boxHeightTextBox.Text = parameters.GetParameter(ParameterType.BoxHeight).Value.ToString();

            boxWidthTextBox.BackColor = _defaultColor;
            boxWidthTextBox.Text = parameters.GetParameter(ParameterType.BoxWidth).Value.ToString();

            wallThicknessTextBox.BackColor = _defaultColor;
            wallThicknessTextBox.Text = parameters.GetParameter(ParameterType.BoxWallThickness).Value.ToString();

            legDiameterTextBox.BackColor = _defaultColor;
            legDiameterTextBox.Text = parameters.GetParameter(ParameterType.LegDiameter).Value.ToString();

            legHeightTextBox.BackColor = _defaultColor;
            legHeightTextBox.Text = parameters.GetParameter(ParameterType.LegHeight).Value.ToString();

            grooveDiameterTextBox.BackColor = _defaultColor;
            grooveDiameterTextBox.Text = parameters.GetParameter(ParameterType.GrooveDiameter).Value.ToString();

            grooveDistanceTextBox.BackColor = _defaultColor;
            grooveDistanceTextBox.Text = parameters.GetParameter(ParameterType.GrooveDistance).Value.ToString();

            holeDiameterTextBox.BackColor = _defaultColor;
            holeDiameterTextBox.Text = parameters.GetParameter(ParameterType.HoleDiameter).Value.ToString();

            holeHeightTextBox.BackColor = _defaultColor;
            holeHeightTextBox.Text = parameters.GetParameter(ParameterType.HoleHeight).Value.ToString();

            holeDistanceTextBox.BackColor = _defaultColor;
            holeDistanceTextBox.Text = parameters.GetParameter(ParameterType.HoleDistance).Value.ToString();

            ErrorLable.BackColor = _defaultColor;
            ErrorLable.Text = "";
        }

        /// <summary>
        /// Событие, блокирующее ввод букв в текст боксы.
        /// </summary>
        /// <param name="sender">Отправитель.</param>
        /// <param name="e">Событие.</param>
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Кнопка постройки мангала.
        /// </summary>
        /// <param name="sender">Отправитель кнопка.</param>
        /// <param name="e">Событие.</param>
        private void BuildButton_Click(object sender, EventArgs e)
        {
            if (_errorString != string.Empty)
            {
                MessageBox.Show("Данные некорректны!");
            }
            else
            {
                parameters.InitHoleGrooveCount();
                AutoCadBuilder builder = new AutoCadBuilder(parameters);
                builder.BuildGrill();
                Close();
            }
        }
    }
}
