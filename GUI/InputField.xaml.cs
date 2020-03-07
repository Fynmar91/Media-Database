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
		private bool myNoError = true;
		public MediaProp MyMediaProp;
		private AddPage MyAddPage;

		public bool MyNoError
		{
			get => myNoError;
			set
			{
				myNoError = value;
				if (myNoError)
				{
					highlightBox.Visibility = Visibility.Collapsed;
				}
				else
				{
					highlightBox.Visibility = Visibility.Visible;
				}
			}
		}

		public string[] MyInput
		{
			get
			{
				string[] s = { "", "" };
				if (MyMediaProp is MediaPropTitle)
				{
					s[0] = titleInput.Text.ToString();
					s[1] = seasonInput.Text.ToString();

				}
				else if (MyMediaProp is MediaPropText)
				{
					s[0] = textInput.Text.ToString();
				}
				else if (MyMediaProp is MediaPropInt)
				{
					s[0] = sliderInput.Value.ToString();
				}
				else if (MyMediaProp is MediaPropBool)
				{
					s[0] = checkInput.IsChecked.ToString();
				}
				else if (MyMediaProp is MediaPropDate)
				{
					s[0] = textInput.Text.ToString();
				}
				return s;
			}
		}



		public InputField(MediaProp mediaProp, AddPage addPage)
		{
			InitializeComponent();
			MyMediaProp = mediaProp;
			MyAddPage = addPage;
			descTextBlock.Text = mediaProp.MyDescription;
			SetUp();
		}

		private void SetUp()
		{
			ResetBorder();

			if (MyMediaProp is MediaPropTitle)
			{
				textInput.Visibility = Visibility.Collapsed;
				sliderStack.Visibility = Visibility.Collapsed;
				checkInput.Visibility = Visibility.Collapsed;

				if ((MyMediaProp as MediaPropTitle).MyHasSeasons == false)
				{
					seasonInput.Visibility = Visibility.Collapsed;
				}
			}
			else if (MyMediaProp is MediaPropText)
			{
				titleGrid.Visibility = Visibility.Collapsed;
				sliderStack.Visibility = Visibility.Collapsed;
				checkInput.Visibility = Visibility.Collapsed;
			}
			else if (MyMediaProp is MediaPropInt)
			{
				titleGrid.Visibility = Visibility.Collapsed;
				textInput.Visibility = Visibility.Collapsed;
				checkInput.Visibility = Visibility.Collapsed;
			}
			else if (MyMediaProp is MediaPropBool)
			{
				titleGrid.Visibility = Visibility.Collapsed;
				textInput.Visibility = Visibility.Collapsed;
				sliderStack.Visibility = Visibility.Collapsed;
			}
			else if (MyMediaProp is MediaPropDate)
			{
				titleGrid.Visibility = Visibility.Collapsed;
				sliderStack.Visibility = Visibility.Collapsed;
				checkInput.Visibility = Visibility.Collapsed;
			}
		}

		private void ResetBorder()
		{
			highlightBox.Visibility = Visibility.Hidden;
		}

		private void TextInput_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (MyMediaProp is MediaPropTitle)
			{
				MyNoError = MainWindow.MyMainwindow.MyMediaList.IsUnique(MainWindow.MyMainwindow.MyActiveTypeString, titleInput.Text.ToString(), (MyMediaProp as MediaPropTitle).MyHasSeasons, int.TryParse(seasonInput.Text, out int num) ? int.Parse(seasonInput.Text) : 0);
			}
			else if (MyMediaProp is MediaPropText)
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
