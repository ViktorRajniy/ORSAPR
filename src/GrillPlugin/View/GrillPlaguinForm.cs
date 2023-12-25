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
        /// Initializes a new instance of the <see cref="GrillPluginForm"/> class.
        /// </summary>
        public GrillPluginForm()
        {
            InitializeComponent();
            _errorString = string.Empty;
            Parameters = new Parameters();
            InitDictionarys();
            holeCircleRadioButton.Checked = true;
            grooveCircleRadioButton.Checked = true;
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
                { ParameterType.GrooveDiameter, grooveDiameterBorderLable },
                { ParameterType.GrooveDistance, grooveDistanceBorderLable },
                { ParameterType.HoleDistance, holeDistanceBorderLable },
                { ParameterType.HoleDiameter, holeDiameterBorderLable },
                { ParameterType.HoleHeight, holeHeightBorderLable },
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
                { ParameterType.GrooveDiameter, "Диаметр паза для шампура" },
                { ParameterType.GrooveDistance, "Расстояние между пазами для шампуров" },
                { ParameterType.HoleDistance, "Расстояние между отверстиями для поддува" },
                { ParameterType.HoleDiameter, "Диаметр отверстия для поддува" },
                { ParameterType.HoleHeight, "Высота отверстия для поддува" },
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
                { ParameterType.GrooveDiameter, grooveDiameterTextBox },
                { ParameterType.GrooveDistance, grooveDistanceTextBox },
                { ParameterType.HoleDistance, holeDistanceTextBox },
                { ParameterType.HoleDiameter, holeDiameterTextBox },
                { ParameterType.HoleHeight, holeHeightTextBox },
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

                if (currentParameter == ParameterType.BoxLength ||
                    currentParameter == ParameterType.BoxWidth ||
                    currentParameter == ParameterType.BoxWallThickness ||
                    currentParameter == ParameterType.BoxHeight ||
                    currentParameter == ParameterType.GrooveDiameter)
                {
                    _errorParameters[currentParameter] = string.Empty;
                    Parameters.SetValue(currentParameter, value);
                    Parameters.UpdateBorders();
                    CheckDependedTextBoxsCorrect();
                    CheckDependedTextBoxCorrect(ParameterType.HoleDiameter);
                    UpdateLablesBorders();
                }

                if (currentParameter == ParameterType.HoleDiameter)
                {
                    _errorParameters[currentParameter] = string.Empty;
                    Parameters.SetValue(currentParameter, value);
                    Parameters.UpdateBorders();
                    CheckDependedTextBoxsCorrect();
                    UpdateLablesBorders();
                }
                else
                {
                    _errorParameters[currentParameter] = string.Empty;
                    Parameters.SetValue(currentParameter, value);
                }
            }
            catch (ArgumentException exc)
            {
                TextBox currentTextBox = (TextBox)sender;
                ParameterType currentParameter = CheckTextBoxParameter(currentTextBox);
                _errorParameters[currentParameter] = _rusParameters[currentParameter]
                    + " " + exc.Message;
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
            CheckDependedTextBoxCorrect(ParameterType.LegDiameter);
            CheckDependedTextBoxCorrect(ParameterType.GrooveDistance);
            CheckDependedTextBoxCorrect(ParameterType.HoleHeight);
            CheckDependedTextBoxCorrect(ParameterType.HoleDistance);
        }

        /// <summary>
        /// Проверяет текст бокс зависимого параметра.
        /// Сначала обнуляет его и заполняет значением из Модел, чтобы запустить событие.
        /// </summary>
        private void CheckDependedTextBoxCorrect(ParameterType type)
        {
            _textBoxs[type].Text = string.Empty;
            _textBoxs[type].Text = Parameters.GetParameter(type).Value.ToString();
        }

        /// <summary>
        /// Метод обновляет граничные значения у всех граничных лейблов зависимых параметров.
        /// </summary>
        private void UpdateLablesBorders()
        {
            UpdateLableBorders(ParameterType.LegDiameter);
            UpdateLableBorders(ParameterType.GrooveDistance);
            UpdateLableBorders(ParameterType.HoleDiameter);
            UpdateLableBorders(ParameterType.HoleHeight);
            UpdateLableBorders(ParameterType.HoleDistance);
        }

        /// <summary>
        /// Обновляет граничные значения лейблов у одного текст бокса.
        /// </summary>
        private void UpdateLableBorders(ParameterType type)
        {
            _borderLabels[type].Text = Parameters.GetParameter(type).MinValue.ToString() + " - " +
                Parameters.GetParameter(type).MaxValue.ToString() + ", мм";
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
                AutoCadBuilder builder = new AutoCadBuilder(Parameters);
                builder.BuildGrill();
                Close();
            }
        }

        /// <summary>
        /// Событие, случающееся при выборе круглых отверстий для поддува.
        /// </summary>
        /// <param name="sender">Отправитель радио баттон.</param>
        /// <param name="e">Событие.</param>
        private void HoleCircleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            holeDiameterLable.Visible = true;
            holeHeightLable.Visible = true;
            holeDistanceLable.Visible = true;

            holeDiameterTextBox.Visible = true;
            holeHeightTextBox.Visible = true;
            holeDistanceTextBox.Visible = true;

            holeDiameterBorderLable.Visible = true;
            holeHeightBorderLable.Visible = true;
            holeDistanceBorderLable.Visible = true;

            solidHoleHieghtLabel.Visible = false;
            solidHoleHeightTextBox.Visible = false;
            solidHoleHeightBorderLabel.Visible = false;
        }

        /// <summary>
        /// Событие, случающееся при выборе сплошного отверстия для поддува.
        /// </summary>
        /// <param name="sender">Отправитель радио баттон.</param>
        /// <param name="e">Событие.</param>
        private void HoleSolidRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            holeDiameterLable.Visible = false;
            holeHeightLable.Visible = false;
            holeDistanceLable.Visible = false;

            holeDiameterTextBox.Visible = false;
            holeHeightTextBox.Visible = false;
            holeDistanceTextBox.Visible = false;

            holeDiameterBorderLable.Visible = false;
            holeHeightBorderLable.Visible = false;
            holeDistanceBorderLable.Visible = false;

            solidHoleHieghtLabel.Visible = true;
            solidHoleHeightTextBox.Visible = true;
            solidHoleHeightBorderLabel.Visible = true;
        }
    }
}
