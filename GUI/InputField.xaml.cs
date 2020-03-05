using MediaClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace GUI
{
	/// <summary>
	/// Interaction logic for InputField.xaml
	/// </summary>
	public partial class InputField : UserControl
	{
		public bool MyErrorState = false;
		public string MyPropName;
		public string MyInputType;
		private string mediaType;

		public string MyInput
		{
			get
			{
				string s = "";
				switch (MyInputType)
				{
					case "Text":
						s = textInput.Text.ToString();
						break;
					case "Slider":
						s = sliderInput.Value.ToString();
						break;
					case "Check":
						s = checkInput.IsChecked.ToString();
						break;
					default:
						break;
				}
				return s;
			}
		}

		public InputField(string inputType, string mediaType, string name, string descText)
		{
			InitializeComponent();
			ResetBorder();
			MyPropName = name;
			descTextBlock.Text = descText;
			this.mediaType = mediaType;
			this.MyInputType = inputType;

			switch (inputType)
			{
				case "Text":
					sliderStack.Visibility = Visibility.Collapsed;
					checkInput.Visibility = Visibility.Collapsed;
					break;
				case "Slider":
					textInput.Visibility = Visibility.Collapsed;
					checkInput.Visibility = Visibility.Collapsed;
					break;
				case "Check":
					textInput.Visibility = Visibility.Collapsed;
					sliderStack.Visibility = Visibility.Collapsed;
					break;
				default:
					break;
			}
		}

		private void ResetBorder()
		{
			highlightBox.Visibility = Visibility.Hidden;
		}

		private void TextInput_TextChanged(object sender, TextChangedEventArgs e)
		{
			MethodInfo mi = MainWindow.MyMainwindow.MyMediaList.GetType().GetMethod(MyPropName);
			object[] obj = { mediaType, textInput.Text.ToString() };

			if (!(bool)mi.Invoke(MainWindow.MyMainwindow.MyMediaList, obj))
			{
				highlightBox.Visibility = Visibility.Visible;
				MyErrorState = true;
			}
			else
			{
				ResetBorder();
				MyErrorState = false;
			}

		}

		private void SliderInput_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			sliderText.Text = sliderInput.Value.ToString();
		}
	}
}
