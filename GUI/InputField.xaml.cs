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
	/// Interaction logic for InputField.xaml
	/// </summary>
	public partial class InputField : UserControl
	{
		public InputField(string inputType, string descName, string descText)
		{
			InitializeComponent();

			switch (inputType)
			{
				case "Text":
					descStack.Children.Add(new TextBlock { Name = descName, Text = descText, FontSize = 20, Foreground = Brushes.WhiteSmoke });
					inputStack.Children.Add(new TextBox { Name = "inputName", FontSize = 20, Foreground = Brushes.WhiteSmoke });
					break;
				case "Slider":
					descStack.Children.Add(new TextBlock { Name = descName, Text = descText, FontSize = 20, Foreground = Brushes.WhiteSmoke });
					inputStack.Children.Add(new Slider { Name = "inputName", Width = 200 });
					break;
				default:
					break;
			}
		}
	}
}
