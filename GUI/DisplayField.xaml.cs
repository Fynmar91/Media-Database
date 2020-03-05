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

		public DisplayField(string value, string descText)
		{
			InitializeComponent();

			progressStack.Visibility = Visibility.Collapsed;
			checkDisplay.Visibility = Visibility.Collapsed;

			descTextBlock.Text = descText;
			textDisplay.Text = value;
		}


		public DisplayField(double value, string descText)
		{
			InitializeComponent();

			textDisplay.Visibility = Visibility.Collapsed;
			checkDisplay.Visibility = Visibility.Collapsed;

			descTextBlock.Text = descText;
			progressDisplay.Value = value;
			progressText.Text = value.ToString();
		}

		public DisplayField(bool value, string descText)
		{
			InitializeComponent();

			textDisplay.Visibility = Visibility.Collapsed;
			progressStack.Visibility = Visibility.Collapsed;

			descTextBlock.Text = descText;
			checkDisplay.IsChecked = value;
		}
	}
}
