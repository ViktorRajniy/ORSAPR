using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GrillView.UserControls
{
	/// <summary>
	/// Логика взаимодействия для Parameter.xaml
	/// </summary>
	public partial class Parameter : UserControl
	{
		public Parameter()
		{
			InitializeComponent();
		}

		private string _parameterName;

		private string _parameterValue;

		private string _parameterBorder;

		public string ParameterName
		{
			get { return _parameterName; }
			set
			{
				_parameterName = value;
				parameterName.Content = _parameterName;
			}
		}

		public string ParameterValue
		{
			get { return _parameterValue; }
			set
			{
				_parameterValue = value;
				parameterTextBox.Text = _parameterValue;
			}
		}

		public string ParameterBorder
		{
			get { return _parameterBorder; }
			set
			{
				_parameterBorder = value;
				parameterBorder.Content = _parameterBorder;
			}
		}
	}
}
