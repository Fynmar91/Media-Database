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
	/// Interaction logic for AddPage.xaml
	/// </summary>
	public partial class AddPage : Page, PageInterface
	{
		private List<InputField> inputFields = new List<InputField>();

		public AddPage()
		{
			InitializeComponent();
			comboBox_MediaChoice.ItemsSource = MainWindow.MyMainwindow.MyTypeString;
			Refresh();
		}

		public void Refresh()
		{
			comboBox_MediaChoice.SelectedIndex = MainWindow.MyMainwindow.MySelectedTypeIndex;

			ResetInput();

			switch (comboBox_MediaChoice.SelectedIndex)
			{
				case 1:
					SetInputBook();
					break;
				case 2:
					SetInputWebNovel();
					break;
				case 3:
					SetInputMovie();
					break;
				case 4:
					SetInputShow();
					break;
				case 5:
					SetInputAnime();
					break;
				case 6:
					SetInputAnimeMovie();
					break;
				default:
					break;
			}
			BuildUI();
		}

		//
		// Application Stuff
		//
		private void ComboBox_MediaChoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			MainWindow.MyMainwindow.SelectMediaType(comboBox_MediaChoice.SelectedIndex);
		}

		private void Button_Add_Click(object sender, RoutedEventArgs e)
		{
			AddMedia();
		}

		private void AddMedia()
		{
			foreach (var item in inputFields)
			{
				
			}
		}

		//
		// Media Type Selection Stuff
		//
		private void ResetInput()
		{
			inputStack.Children.Clear();
			inputFields.Clear();
		}

		private void BuildUI()
		{
			foreach (var item in inputFields)
			{
				item.Margin = new Thickness(0, 0, 0, 10);
				inputStack.Children.Add(item);
			}			
		}

		private void SetInputBook()
		{
			inputFields.Add(new InputField("Text", "a"));
		}

		private void SetInputWebNovel()
		{

		}

		private void SetInputMovie()
		{

		}

		private void SetInputShow()
		{

		}

		private void SetInputAnime()
		{

		}

		private void SetInputAnimeMovie()
		{

		}
	}
}
