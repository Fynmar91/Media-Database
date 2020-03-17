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
		
		public int MyProp { get; set; }
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

		public AttributeField(int state, int prop, MediaProp mediaProp, IPage page)
		{
			InitializeComponent();
			MyState = state;
			MyProp = prop;
			MyMediaProp = mediaProp;
			MyPage = page;
		}

		public void Refresh()
		{
			Reset();

			switch (MyProp)
			{
				case 0:
					Title();
					break;
				case 1:
					Season();
					break;
				case 2:
					Text();
					break;
				case 3:
					Progress();
					break;
				case 4:
					Check();
					break;
				default:
					break;
			}			
		}

		public void Reset()
		{
			titleGrid.Visibility = Visibility.Collapsed;
			titleDisplay.Visibility = Visibility.Collapsed;
			titleInput.Visibility = Visibility.Collapsed;

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
		}

		public void Title()
		{
			titleGrid.Visibility = Visibility.Visible;

			switch (MyState)
			{
				case 0:	
					titleDisplay.Visibility = Visibility.Visible;
					break;
				case 1:
					titleInput.Visibility = Visibility.Visible;
					break;
				default:
					break;
			}
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
				default:
					break;
			}
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
				default:
					break;
			}
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
				default:
					break;
			}
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
				default:
					break;
			}
		}
		private void ResetBorder()
		{
			highlightBox.Visibility = Visibility.Hidden;
		}

		private void TextDisplay_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			MyPage.EnableInput(MyMediaProp, MyIndex);
		}

		private void ProgressDisplay_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			MyPage.EnableInput(MyMediaProp, MyIndex);
		}

		private void CheckDisplay_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			MyPage.EnableInput(MyMediaProp, MyIndex);
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
