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
	public partial class DisplayField : UserControl
	{
		private DisplayPage MyDisplayPage;
		public MediaProp MyMediaProp;

		public DisplayField(MediaProp mediaProp, DisplayPage displayPage)
		{
			InitializeComponent();
			MyDisplayPage = displayPage;
			MyMediaProp = mediaProp;

			descTextBlock.Text = MyMediaProp.MyDescription;

			if (MyMediaProp is MediaPropText)
			{
				progressStack.Visibility = Visibility.Collapsed;
				checkDisplay.Visibility = Visibility.Collapsed;
				textDisplay.Text = (MyMediaProp as MediaPropText).MyValue;
			}
			else if (MyMediaProp is MediaPropInt)
			{
				textDisplay.Visibility = Visibility.Collapsed;
				checkDisplay.Visibility = Visibility.Collapsed;
				progressDisplay.Value = (MyMediaProp as MediaPropInt).MyValue;
			}
			else if (MyMediaProp is MediaPropBool)
			{
				textDisplay.Visibility = Visibility.Collapsed;
				progressStack.Visibility = Visibility.Collapsed;
				checkDisplay.IsChecked = (MyMediaProp as MediaPropBool).MyValue;
			}
			else if (MyMediaProp is MediaPropDate)
			{
				progressStack.Visibility = Visibility.Collapsed;
				checkDisplay.Visibility = Visibility.Collapsed;
				textDisplay.Text = (MyMediaProp as MediaPropDate).MyValue;
			}
		}

		private void TextDisplay_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			MyDisplayPage.EnableInput(MyMediaProp);
		}

		private void ProgressDisplay_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			MyDisplayPage.EnableInput(MyMediaProp);
		}

		private void CheckDisplay_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			MyDisplayPage.EnableInput(MyMediaProp);
		}
	}
}
