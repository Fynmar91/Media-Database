using MediaClass;
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

namespace GUI
{
	/// <summary>
	/// Interaction logic for AttributeField.xaml
	/// </summary>
	public partial class AttributeField : UserControl
	{
		private int myState;
		private bool myNoError = true;

		public int MyState
		{
			get { return myState; }
			set { myState = value; Refresh(); }
		}
		
		public MediaProp MyMediaProp { get; set; }
		public IPage MyPage { get; set; }

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

		public AttributeField(int state, MediaProp mediaProp, IPage page)
		{
			InitializeComponent();
			MyMediaProp = mediaProp;
			MyPage = page;
			MyState = state;
		}

		public void WriteProp()
		{
			if (MyNoError)
			{
				if (MyMediaProp is MediaPropTitle)
				{
					(MyMediaProp as MediaPropTitle).MyValue = titleInput.Text.ToString();
					if ((MyMediaProp as MediaPropTitle).MyHasSeasons)
					{
						(MyMediaProp as MediaPropTitle).MySeason.MyValue = Convert.ToInt32(seasonInput);
					}
				}
				else if (MyMediaProp is MediaPropText)
				{
					(MyMediaProp as MediaPropText).MyValue = textInput.Text.ToString();
				}
				else if (MyMediaProp is MediaPropInt)
				{
					(MyMediaProp as MediaPropInt).MyValue = Convert.ToInt32(sliderInput.Value);
				}
				else if (MyMediaProp is MediaPropBool)
				{
					(MyMediaProp as MediaPropBool).MyValue = checkInput.IsChecked == true;
				}
				else if (MyMediaProp is MediaPropDate)
				{
					(MyMediaProp as MediaPropDate).MyValue = textInput.Text.ToString();
				}

				if (MyState == 2)
				{
					MyState = 0;
				}
			}
		}

		public void Refresh()
		{
			Reset();
			MyNoError = MyNoError;

			if (MyMediaProp is MediaPropTitle)
			{
				Title();
				if ((MyMediaProp as MediaPropTitle).MyHasSeasons)
				{
					Season();
				}
			}
			else if (MyMediaProp is MediaPropText)
			{
				Text();
			}
			else if (MyMediaProp is MediaPropInt)
			{
				Progress();
			}
			else if (MyMediaProp is MediaPropBool)
			{
				Check();
			}
			else if (MyMediaProp is MediaPropDate)
			{
				Date();
			}
		}

		public void Reset()
		{
			titleDisplayGrid.Visibility = Visibility.Collapsed;
			titleInputGrid.Visibility = Visibility.Collapsed;

			seasonDisplay.Visibility = Visibility.Collapsed;
			seasonInput.Visibility = Visibility.Collapsed;

			textDisplay.Visibility = Visibility.Collapsed;
			textInput.Visibility = Visibility.Collapsed;

			progressStack.Visibility = Visibility.Collapsed;
			progressDisplay.Visibility = Visibility.Collapsed;
			progressText.Visibility = Visibility.Collapsed;
			sliderStack.Visibility = Visibility.Collapsed;
			sliderInput.Visibility = Visibility.Collapsed;
			sliderText.Visibility = Visibility.Collapsed;

			checkDisplay.Visibility = Visibility.Collapsed;
			checkInput.Visibility = Visibility.Collapsed;

			updateButton.Visibility = Visibility.Collapsed;
			reverseButton.Visibility = Visibility.Collapsed;
		}

		public void Title()
		{
			switch (MyState)
			{
				case 0:
					titleDisplayGrid.Visibility = Visibility.Visible;
					break;
				case 1:
					titleInputGrid.Visibility = Visibility.Visible;
					break;
				case 2:
					titleInputGrid.Visibility = Visibility.Visible;
					updateButton.Visibility = Visibility.Visible;
					reverseButton.Visibility = Visibility.Visible;
					break;
				default:
					break;
			}

			descTextBlock.Text = (MyMediaProp as MediaPropTitle).MyDescription;
			titleDisplay.Text = (MyMediaProp as MediaPropTitle).MyValue;
		}

		public void Season()
		{
			switch (MyState)
			{
				case 0:
					seasonDisplay.Visibility = Visibility.Visible;
					break;
				case 1:
					seasonInput.Visibility = Visibility.Visible;
					break;
				case 2:
					seasonInput.Visibility = Visibility.Visible;
					updateButton.Visibility = Visibility.Visible;
					reverseButton.Visibility = Visibility.Visible;
					break;
				default:
					break;
			}

			descTextBlock.Text = (MyMediaProp as MediaPropTitle).MySeason.MyDescription;
			seasonDisplay.Text = (MyMediaProp as MediaPropTitle).MySeason.MyValue.ToString();
		}

		public void Text()
		{
			switch (MyState)
			{
				case 0:
					textDisplay.Visibility = Visibility.Visible;
					break;
				case 1:
					textInput.Visibility = Visibility.Visible;
					break;
				case 2:
					textInput.Visibility = Visibility.Visible;
					updateButton.Visibility = Visibility.Visible;
					reverseButton.Visibility = Visibility.Visible;
					break;
				default:
					break;
			}

			descTextBlock.Text = (MyMediaProp as MediaPropText).MyDescription;
			textDisplay.Text = (MyMediaProp as MediaPropText).MyValue;
		}

		public void Progress()
		{
			switch (MyState)
			{
				case 0:
					progressStack.Visibility = Visibility.Visible;
					progressDisplay.Visibility = Visibility.Visible;
					progressText.Visibility = Visibility.Visible;
					break;
				case 1:
					sliderStack.Visibility = Visibility.Visible;
					sliderInput.Visibility = Visibility.Visible;
					sliderText.Visibility = Visibility.Visible;
					break;
				case 2:
					sliderStack.Visibility = Visibility.Visible;
					sliderInput.Visibility = Visibility.Visible;
					sliderText.Visibility = Visibility.Visible;
					updateButton.Visibility = Visibility.Visible;
					reverseButton.Visibility = Visibility.Visible;
					break;
				default:
					break;
			}

			descTextBlock.Text = (MyMediaProp as MediaPropInt).MyDescription;
			progressDisplay.Value = (MyMediaProp as MediaPropInt).MyValue;
		}

		public void Check()
		{
			switch (MyState)
			{
				case 0:
					checkDisplay.Visibility = Visibility.Visible;
					break;
				case 1:
					checkInput.Visibility = Visibility.Visible;
					break;
				case 2:
					checkInput.Visibility = Visibility.Visible;
					updateButton.Visibility = Visibility.Visible;
					reverseButton.Visibility = Visibility.Visible;
					break;
				default:
					break;
			}

			descTextBlock.Text = (MyMediaProp as MediaPropBool).MyDescription;
			checkDisplay.IsChecked = (MyMediaProp as MediaPropBool).MyValue;
		}
		public void Date()
		{
			switch (MyState)
			{
				case 0:
					textDisplay.Visibility = Visibility.Visible;
					break;
				case 1:
					textInput.Visibility = Visibility.Visible;
					break;
				case 2:
					textInput.Visibility = Visibility.Visible;
					updateButton.Visibility = Visibility.Visible;
					reverseButton.Visibility = Visibility.Visible;
					break;
				default:
					break;
			}

			descTextBlock.Text = (MyMediaProp as MediaPropDate).MyDescription;
			textDisplay.Text = (MyMediaProp as MediaPropDate).MyValue;
		}

		private void UpdateButton_Click(object sender, RoutedEventArgs e)
		{
			WriteProp();
		}

		private void ReverseButton_Click(object sender, RoutedEventArgs e)
		{
			MyState = 0;
		}

		private void TextInput_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (MyMediaProp is MediaPropTitle)
			{
				MyNoError = MainWindow.MyMainwindow.MyMediaList.IsUnique((MyMediaProp as MediaPropTitle).MyType.MyValue, titleInput.Text.ToString(), (MyMediaProp as MediaPropTitle).MyHasSeasons, int.TryParse(seasonInput.Text, out int num) ? int.Parse(seasonInput.Text) : 0);
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

		private void ResetBorder()
		{
			highlightBox.Visibility = Visibility.Hidden;
		}

		private void TitleDisplay_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			MyState = 2;
		}

		private void TextDisplay_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			MyState = 2;
		}

		private void ProgressDisplay_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			MyState = 2;
		}

		private void CheckDisplay_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			MyState = 2;
		}

		private void CheckDisplay_Click(object sender, RoutedEventArgs e)
		{
			checkDisplay.IsChecked = (MyMediaProp as MediaPropBool).MyValue;
		}	
	}
}
