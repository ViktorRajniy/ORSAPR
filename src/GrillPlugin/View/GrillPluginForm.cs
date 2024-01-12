namespace View
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using ModelAPI;
    using ModelData;

    /// <summary>
    /// Главная форма приложения.
    /// </summary>
    public partial class GrillPluginForm : Form
    {
        /// <summary>
        /// Параметры мангала.
        /// </summary>
        public Parameters Parameters;

        /// <summary>
        /// Цвет текст бокса при ошибке.
        /// </summary>
        private readonly Color _errorColor = Color.Pink;

        /// <summary>
        /// Цвет текст бокса при ошибке.
        /// </summary>
        private readonly Color _defaultColor = Color.White;

        /// <summary>
        /// Словарь ошибок.
        /// </summary>
        private readonly Dictionary<ParameterType, string> _errorParameters =
            new Dictionary<ParameterType, string>();

        /// <summary>
        /// Словарь текст боксов.
        /// </summary>
        private Dictionary<ParameterType, TextBox> _textBoxs;

        /// <summary>
        /// Словарь граничных параметров.
        /// </summary>
        private Dictionary<ParameterType, Label> _borderLabels;

        /// <summary>
        /// Словарь граничных параметров.
        /// </summary>
        private Dictionary<ParameterType, string> _rusParameters;

        /// <summary>
        /// Строка ошибки.
        /// </summary>
        private string _errorString;

        /// <summary>
        /// Флаг, означающий, выбран ли метод построения круглых отверстий для поддува.
        /// </summary>
        private bool _isCircleHolesSelected = true;

        /// <summary>
        /// Флаг, означающий, выбран ли метод построения круглых пазов для шампуров.
        /// </summary>
        private bool _isCircleGrooveSelected = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="GrillPluginForm"/> class.
        /// </summary>
        public GrillPluginForm()
        {
            InitializeComponent();
            _errorString = string.Empty;
            Parameters = new Parameters();
            InitDictionarys();
            holeCircleRadioButton.Checked = _isCircleHolesSelected;
            grooveCircleRadioButton.Checked = _isCircleGrooveSelected;
            UpdateFields();
            UpdateLablesBorders();
        }

        /// <summary>
        /// Инициализирует словари для работы с формой приложения.
        /// </summary>
        private void InitDictionarys()
        {
            InitRusDictionary();
            InitLabelDictionary();
            InitTextBoxDictionary();
        }

        /// <summary>
        /// Инициализирует словарь Тип параметра - лейбл.
        /// </summary>
        private void InitLabelDictionary()
        {
            _borderLabels = new Dictionary<ParameterType, Label>()
            {
                { ParameterType.BoxLength, lengthBorderLable },
                { ParameterType.BoxWidth, widthBorderLable },
                { ParameterType.BoxHeight, heightBorderLable },
                { ParameterType.BoxWallThickness, thicknessBorderLable },
                { ParameterType.LegDiameter, legDiameterBorderLable },
                { ParameterType.LegHeight, legHeightBorderLable },
                { ParameterType.CircleHoleDistance, holeDistanceBorderLable },
                { ParameterType.CircleHoleDiameter, holeDiameterBorderLable },
                { ParameterType.CircleHoleHeight, holeHeightBorderLable },
                { ParameterType.RectangleHoleHeight, solidHoleHeightBorderLabel },
                { ParameterType.CircleGrooveDiameter, grooveDiameterBorderLable },
                { ParameterType.CircleGrooveDistance, grooveDistanceBorderLable },
                { ParameterType.RectangleGrooveHeight, rectangleGrooveHeightBorderLabel },
                { ParameterType.RectangleGrooveDistance, rectangleGrooveDistanceBorderLabel },
                { ParameterType.RectangleGrooveWidth, rectangleGrooveWidthBorderLabel },
            };
        }

        /// <summary>
        /// Инициализирует словарь Тип параметра - русское название.
        /// </summary>
        private void InitRusDictionary()
        {
            _rusParameters = new Dictionary<ParameterType, string>()
            {
                { ParameterType.BoxLength, "Длина короба" },
                { ParameterType.BoxWidth, "Ширина короба" },
                { ParameterType.BoxHeight, "Высота короба" },
                { ParameterType.BoxWallThickness, "Толщина стен" },
                { ParameterType.LegDiameter, "Диаметр ножки" },
                { ParameterType.LegHeight, "Высота ножки" },
                { ParameterType.CircleGrooveDiameter, "Диаметр паза для шампура" },
                { ParameterType.CircleGrooveDistance, "Расстояние между пазами для шампуров" },
                { ParameterType.CircleHoleDistance, "Расстояние между отверстиями для поддува" },
                { ParameterType.CircleHoleDiameter, "Диаметр отверстия для поддува" },
                { ParameterType.CircleHoleHeight, "Высота отверстия для поддува" },
                { ParameterType.RectangleHoleHeight, "Высота выреза для поддува" },
                { ParameterType.RectangleGrooveHeight, "Глубина прямоугольных пазов" },
                { ParameterType.RectangleGrooveDistance, "Расстояние между прямоугольными пазами" },
                { ParameterType.RectangleGrooveWidth, "Ширина прямоугольных пазов" },
            };
        }

        /// <summary>
        /// Инициализирует словарь Тип параметра - текст бокс.
        /// </summary>
        private void InitTextBoxDictionary()
        {
            _textBoxs = new Dictionary<ParameterType, TextBox>()
            {
                { ParameterType.BoxLength, boxLengthTextBox },
                { ParameterType.BoxWidth, boxWidthTextBox },
                { ParameterType.BoxHeight, boxHeightTextBox },
                { ParameterType.BoxWallThickness, wallThicknessTextBox },
                { ParameterType.LegDiameter, legDiameterTextBox },
                { ParameterType.LegHeight, legHeightTextBox },
                { ParameterType.CircleHoleDistance, holeDistanceTextBox },
                { ParameterType.CircleHoleDiameter, holeDiameterTextBox },
                { ParameterType.CircleHoleHeight, holeHeightTextBox },
                { ParameterType.RectangleHoleHeight, solidHoleHeightTextBox },
                { ParameterType.CircleGrooveDiameter, circleGrooveDiameterTextBox },
                { ParameterType.CircleGrooveDistance, circleGrooveDistanceTextBox },
                { ParameterType.RectangleGrooveHeight, rectangleGrooveHeightTextBox },
                { ParameterType.RectangleGrooveDistance, rectangleGrooveDistanceTextBox},
                { ParameterType.RectangleGrooveWidth, rectangleGrooveWidthTextBox },
            };
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

                _errorParameters[currentParameter] = string.Empty;
                Parameters.SetValue(currentParameter, value);

                switch (currentParameter)
                {
                    case ParameterType.BoxLength:
                    {
                        Parameters.UpdateBorders();
                        CheckDependedTextBoxCorrect(ParameterType.CircleHoleDistance);
                        CheckDependedTextBoxCorrect(ParameterType.CircleHoleHeight);
                        CheckDependedTextBoxCorrect(ParameterType.CircleGrooveDistance);
                        CheckDependedTextBoxCorrect(ParameterType.RectangleGrooveDistance);
                        UpdateLablesBorders();
                        break;
                    }

                    case ParameterType.BoxWidth:
                    {
                        Parameters.UpdateBorders();
                        CheckDependedTextBoxCorrect(ParameterType.LegDiameter);
                        UpdateLablesBorders();
                        break;
                    }

                    case ParameterType.BoxHeight:
                    {
                        Parameters.UpdateBorders();
                        CheckDependedTextBoxCorrect(ParameterType.CircleHoleHeight);
                        CheckDependedTextBoxCorrect(ParameterType.RectangleHoleHeight);
                        CheckDependedTextBoxCorrect(ParameterType.RectangleGrooveHeight);
                        UpdateLablesBorders();
                        break;
                    }

                    case ParameterType.BoxWallThickness:
                    {
                        Parameters.UpdateBorders();
                        CheckDependedTextBoxCorrect(ParameterType.LegDiameter);
                        CheckDependedTextBoxCorrect(ParameterType.CircleHoleDistance);
                        CheckDependedTextBoxCorrect(ParameterType.CircleHoleHeight);
                        CheckDependedTextBoxCorrect(ParameterType.CircleGrooveDistance);
                        CheckDependedTextBoxCorrect(ParameterType.RectangleGrooveDistance);
                        UpdateLablesBorders();
                        break;
                    }

                    case ParameterType.CircleHoleDiameter:
                    {
                        Parameters.UpdateBorders();
                        CheckDependedTextBoxCorrect(ParameterType.CircleHoleDistance);
                        CheckDependedTextBoxCorrect(ParameterType.CircleHoleHeight);
                        UpdateLablesBorders();
                        break;
                    }

                    case ParameterType.CircleGrooveDiameter:
                    {
                        Parameters.UpdateBorders();
                        CheckDependedTextBoxCorrect(ParameterType.CircleGrooveDistance);
                        UpdateLablesBorders();
                        break;
                    }

                    case ParameterType.RectangleGrooveWidth:
                    {
                        Parameters.UpdateBorders();
                        CheckDependedTextBoxCorrect(ParameterType.RectangleGrooveDistance);
                        UpdateLablesBorders();
                        break;
                    }

                    default:
                    {
                        _errorParameters[currentParameter] = string.Empty;
                        Parameters.SetValue(currentParameter, value);
                        UpdateLablesBorders();
                        break;
                    }
                }
            }
            catch (ArgumentException argumentException)
            {
                TextBox currentTextBox = (TextBox)sender;
                ParameterType currentParameter = CheckTextBoxParameter(currentTextBox);
                _errorParameters[currentParameter] = _rusParameters[currentParameter]
                    + " " + argumentException.Message;
                ErrorTextBox(currentTextBox);
            }
            catch (FormatException exc)
            {
                TextBox currentTextBox = (TextBox)sender;
                ParameterType currentParameter = CheckTextBoxParameter(currentTextBox);
                _errorParameters[currentParameter] = _rusParameters[currentParameter]
                    + " " + "не может быть пуст";
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
                    _errorString += _errorParameters[parameterType].ToString() + "\n";
                }
            }

            ErrorLable.Text = _errorString;
            ErrorLable.BackColor = _errorString != string.Empty
                ? _errorColor
                : _defaultColor;
        }

        /// <summary>
        /// Проверяет текст бокс зависимого параметра.
        /// Сначала обнуляет его и заполняет значением из Модел, чтобы запустить событие.
        /// </summary>
        private void CheckDependedTextBoxCorrect(ParameterType type)
        {
            string temp = _textBoxs[type].Text;
            _textBoxs[type].Text = string.Empty;
            _textBoxs[type].Text = temp;
        }

        /// <summary>
        /// Метод обновляет граничные значения у всех граничных лейблов зависимых параметров.
        /// </summary>
        private void UpdateLablesBorders()
        {
            foreach (ParameterType type in _borderLabels.Keys)
            {
                UpdateLableBorders(type);
            }
        }

        /// <summary>
        /// Обновляет граничные значения лейблов у одного текст бокса.
        /// </summary>
        private void UpdateLableBorders(ParameterType type)
        {
            _borderLabels[type].Text =
                Parameters.GetParameter(type).MinValue + " - " +
                Parameters.GetParameter(type).MaxValue + ", мм";
        }

        /// <summary>
        /// Проверка на соответствие названия текст бокса, определённому параметру.
        /// </summary>
        /// <param name="textBox">Текст бокс, который нужно проверить на соответствие параметру.</param>
        /// <returns>Тип параметра мангала.</returns>
        private ParameterType CheckTextBoxParameter(TextBox textBox)
        {
            foreach (ParameterType type in _textBoxs.Keys)
            {
                if (_textBoxs[type] == textBox)
                {
                    return type;
                }
            }

            return ParameterType.BoxLength;
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
            foreach (ParameterType type in _textBoxs.Keys)
            {
                _textBoxs[type].BackColor = _defaultColor;
                _textBoxs[type].Text = Parameters.GetParameter(type).Value.ToString();
            }

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
                Parameters.InitHoleGrooveCount();
                AutoCadBuilder builder = new AutoCadBuilder(
                    Parameters,
                    _isCircleHolesSelected,
                    _isCircleGrooveSelected);
                builder.BuildGrill();
                Close();
            }
        }

        /// <summary>
        /// Метод, отвечающий за видимость текст бокса и лейблов круглых
        /// отверстий для поддува на форме.
        /// </summary>
        /// <param name="visible">Флаг видимости.</param>
        private void CircleHoleVisible(bool visible)
        {
            holeDiameterLable.Visible = visible;
            holeHeightLable.Visible = visible;
            holeDistanceLable.Visible = visible;

            holeDiameterTextBox.Visible = visible;
            holeHeightTextBox.Visible = visible;
            holeDistanceTextBox.Visible = visible;

            holeDiameterBorderLable.Visible = visible;
            holeHeightBorderLable.Visible = visible;
            holeDistanceBorderLable.Visible = visible;
        }

        /// <summary>
        /// Метод, отвечающий за видимость текст бокса и лейблов
        /// прямоугольного выреза для поддува на форме.
        /// </summary>
        /// <param name="visible">Флаг видимости.</param>
        private void SolidHoleVisible(bool visible)
        {
            solidHoleHieghtLabel.Visible = visible;
            solidHoleHeightTextBox.Visible = visible;
            solidHoleHeightBorderLabel.Visible = visible;
        }

        /// <summary>
        /// Метод, отвечающий за видимость текст бокса и лейблов
        /// прямоугольных пазов для шампуров на форме.
        /// </summary>
        /// <param name="visible">Флаг видимости.</param>
        private void RectangleGrooveVisible(bool visible)
        {
            rectangleGrooveDistanceTextBox.Visible = visible;
            rectangleGrooveHeightTextBox.Visible = visible;
            rectangleGrooveWidthTextBox.Visible = visible;

            rectangleGrooveDistanceBorderLabel.Visible = visible;
            rectangleGrooveHeightBorderLabel.Visible = visible;
            rectangleGrooveWidthBorderLabel.Visible = visible;

            rectangleGrooveDistanceLabel.Visible = visible;
            rectangleGrooveHeightLabel.Visible = visible;
            rectangleGrooveWidthLabel.Visible = visible;
        }

        /// <summary>
        /// Метод, отвечающий за видимость текст бокса и лейблов
        /// круглых пазов для шампуров на форме.
        /// </summary>
        /// <param name="visible">Флаг видимости.</param>
        private void CircleGrooveVisible(bool visible)
        {
            circleGrooveDiameterTextBox.Visible = visible;
            circleGrooveDistanceTextBox.Visible = visible;

            grooveDiameterBorderLable.Visible = visible;
            grooveDistanceBorderLable.Visible = visible;

            grooveDiameterLable.Visible = visible;
            grooveDistanceLable.Visible = visible;
        }

        /// <summary>
        /// Событие, случающееся при выборе круглых отверстий для поддува.
        /// </summary>
        /// <param name="sender">Отправитель радио баттон.</param>
        /// <param name="e">Событие.</param>
        private void HoleCircleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            _isCircleHolesSelected = true;

            CircleHoleVisible(true);
            SolidHoleVisible(false);

            _errorParameters[ParameterType.RectangleHoleHeight] = "";

            CheckDependedTextBoxCorrect(ParameterType.CircleHoleDiameter);
            CheckDependedTextBoxCorrect(ParameterType.CircleHoleHeight);
            CheckDependedTextBoxCorrect(ParameterType.CircleHoleDistance);

            UpdateErrorLable();
        }

        /// <summary>
        /// Событие, случающееся при выборе сплошного отверстия для поддува.
        /// </summary>
        /// <param name="sender">Отправитель радио баттон.</param>
        /// <param name="e">Событие.</param>
        private void HoleSolidRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            _isCircleHolesSelected = false;

            CircleHoleVisible(false);
            SolidHoleVisible(true);

            _errorParameters[ParameterType.CircleHoleDiameter] = "";
            _errorParameters[ParameterType.CircleHoleHeight] = "";
            _errorParameters[ParameterType.CircleHoleDistance] = "";

            CheckDependedTextBoxCorrect(ParameterType.RectangleHoleHeight);

            UpdateErrorLable();
        }

        /// <summary>
        /// Событие, случающееся при выборе круглого паза для шампура.
        /// </summary>
        /// <param name="sender">отправитель радио баттон.</param>
        /// <param name="e">Событие.</param>
        private void GrooveCircleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            _isCircleGrooveSelected = true;

            RectangleGrooveVisible(false);
            CircleGrooveVisible(true);

            _errorParameters[ParameterType.RectangleGrooveDistance] = "";
            _errorParameters[ParameterType.RectangleGrooveHeight] = "";
            _errorParameters[ParameterType.RectangleGrooveWidth] = "";

            CheckDependedTextBoxCorrect(ParameterType.CircleGrooveDiameter);
            CheckDependedTextBoxCorrect(ParameterType.CircleGrooveDistance);

            UpdateErrorLable();
        }

        /// <summary>
        /// Событие, случающееся при выборе прямоугольного паза для шампура.
        /// </summary>
        /// <param name="sender">Отправитель радио баттон.</param>
        /// <param name="e">Событие.</param>
        private void GrooveRectangleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            _isCircleGrooveSelected = false;

            RectangleGrooveVisible(true);
            CircleGrooveVisible(false);

            _errorParameters[ParameterType.CircleGrooveDiameter] = "";
            _errorParameters[ParameterType.CircleGrooveDistance] = "";

            CheckDependedTextBoxCorrect(ParameterType.RectangleGrooveDistance);
            CheckDependedTextBoxCorrect(ParameterType.RectangleGrooveWidth);
            CheckDependedTextBoxCorrect(ParameterType.RectangleGrooveHeight);

            UpdateErrorLable();
        }
    }
}
