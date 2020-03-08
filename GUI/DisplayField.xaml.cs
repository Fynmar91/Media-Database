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
	/// Interaction logic for DisplayField.xaml
	/// </summary>
	public partial class DisplayField : UserControl, FieldInterface
	{
		private DisplayPage MyDisplayPage;
		public MediaProp MyMediaProp;
		private int MyIndex;

		public DisplayField(MediaProp mediaProp, DisplayPage displayPage, int index)
		{
			InitializeComponent();
			MyDisplayPage = displayPage;
			MyMediaProp = mediaProp;
			MyIndex = index;

			descTextBlock.Text = MyMediaProp.MyDescription;

			if (MyMediaProp is MediaPropTitle)
			{
				textDisplay.Visibility = Visibility.Collapsed;
				progressStack.Visibility = Visibility.Collapsed;
				checkDisplay.Visibility = Visibility.Collapsed;
				titleDisplay.Text = (MyMediaProp as MediaPropTitle).MyValue;
				seasonDisplay.Text = (MyMediaProp as MediaPropTitle).MySeason.ToString();
			}
			else if (MyMediaProp is MediaPropText)
			{
				titleGrid.Visibility = Visibility.Collapsed;
				progressStack.Visibility = Visibility.Collapsed;
				checkDisplay.Visibility = Visibility.Collapsed;
				textDisplay.Text = (MyMediaProp as MediaPropText).MyValue;
			}
			else if (MyMediaProp is MediaPropInt)
			{
				titleGrid.Visibility = Visibility.Collapsed;
				textDisplay.Visibility = Visibility.Collapsed;
				checkDisplay.Visibility = Visibility.Collapsed;
				progressDisplay.Value = (MyMediaProp as MediaPropInt).MyValue;
			}
			else if (MyMediaProp is MediaPropBool)
			{
				titleGrid.Visibility = Visibility.Collapsed;
				textDisplay.Visibility = Visibility.Collapsed;
				progressStack.Visibility = Visibility.Collapsed;
				checkDisplay.IsChecked = (MyMediaProp as MediaPropBool).MyValue;
			}
			else if (MyMediaProp is MediaPropDate)
			{
				titleGrid.Visibility = Visibility.Collapsed;
				progressStack.Visibility = Visibility.Collapsed;
				checkDisplay.Visibility = Visibility.Collapsed;
				textDisplay.Text = (MyMediaProp as MediaPropDate).MyValue;
			}
		}

		private void TextDisplay_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			MyDisplayPage.EnableInput(MyMediaProp, MyIndex);
		}

		private void ProgressDisplay_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			MyDisplayPage.EnableInput(MyMediaProp, MyIndex);
		}

		private void CheckDisplay_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			MyDisplayPage.EnableInput(MyMediaProp, MyIndex);
		}
	}
}
