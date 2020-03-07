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
		public bool MyNoError = true;
		public MediaProp MyMediaProp;
		

		public string MyInput
		{
			get
			{
				string s = "";
				if (MyMediaProp is MediaPropText || MyMediaProp is MediaPropDate)
				{
					s = textInput.Text.ToString();
				}
				else if (MyMediaProp is MediaPropInt)
				{
					s = sliderInput.Value.ToString();
				}
				else if (MyMediaProp is MediaPropBool)
				{
					s = checkInput.IsChecked.ToString();
				}
				return s;
			}
		}

		public InputField(MediaProp mediaProp)
		{
			InitializeComponent();
			ResetBorder();
			MyMediaProp = mediaProp;
			descTextBlock.Text = mediaProp.MyDescription;

			if (MyMediaProp is MediaPropText || MyMediaProp is MediaPropDate)
			{
				sliderStack.Visibility = Visibility.Collapsed;
				checkInput.Visibility = Visibility.Collapsed;
			}
			else if (MyMediaProp is MediaPropInt)
			{
				textInput.Visibility = Visibility.Collapsed;
				checkInput.Visibility = Visibility.Collapsed;
			}
			else if (MyMediaProp is MediaPropBool)
			{
				textInput.Visibility = Visibility.Collapsed;
				sliderStack.Visibility = Visibility.Collapsed;
			}			
		}

		private void ResetBorder()
		{
			highlightBox.Visibility = Visibility.Hidden;
		}

		private void TextInput_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (MyMediaProp is MediaPropText)
			{
				MyNoError = (MyMediaProp as MediaPropText).ValidateValue();
			}
			else if (MyMediaProp is MediaPropInt)
			{
				MyNoError = (MyMediaProp as MediaPropInt).ValidateValue();
			}
			else if (MyMediaProp is MediaPropBool)
			{
				MyNoError = (MyMediaProp as MediaPropBool).ValidateValue();
			}
			else if (MyMediaProp is MediaPropDate)
			{
				MyNoError = (MyMediaProp as MediaPropDate).ValidateValue(textInput.Text.ToString());
			}
		}

		private void SliderInput_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			sliderText.Text = sliderInput.Value.ToString();
		}
	}
}
