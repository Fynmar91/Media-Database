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
	/// Interaction logic for AddPage.xaml
	/// </summary>
	public partial class AddPage : Page, PageInterface
	{

		public int MyTypeChoice
		{
			get { return comboBox_MediaChoice.SelectedIndex; }
			set { comboBox_MediaChoice.SelectedIndex = value; }
		}


		public AddPage()
		{
			InitializeComponent();
			comboBox_MediaChoice.ItemsSource = MainWindow.MyMainwindow.typeString;
			comboBox_MediaChoice.SelectedIndex = MainWindow.MyMainwindow.MyTypeIndex;
			Refresh();
		}

		public void Refresh()
		{
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
					SetInputAll();
					break;
			}
		}

		private void AddMedia()
		{
			Media media = new Media();

			media.MyType = comboBox_MediaChoice.SelectedValue.ToString();

			media.MyTitle = myTitle_in.Text;

			media.MyIsStarted = myIsStarted_in.IsChecked.Value;
			media.MyIsFinished = myIsFinished_in.IsChecked.Value;

			media.MyAuthor = myAuthor_in.Text;

			media.MyStudio = myStudio_in.Text;

			if (rating_switch.IsChecked == true)
			{
				media.MyRating = Convert.ToInt16(myRating_in.Value);
			}
			else
			{
				media.MyRating = -1;
			}

			media.MyProgressPercentage = Convert.ToInt16(myPercentageRead_in.Value);
			media.MyProgress = myProgress_in.Text;

			media.MyIsDropped = myIsDropped_in.IsChecked.Value;

			MainWindow.MyMainwindow.mediaList.Add(media);
		}

		private bool CheckMedia()
		{
			
		}

		private void Button_Add_Click(object sender, RoutedEventArgs e)
		{
			
		}

		private void Button_Check_Click(object sender, RoutedEventArgs e)
		{

		}

		private void ResetInput()
		{
			title_txt.Visibility = Visibility.Visible;
			myTitle_in.Visibility = Visibility.Visible;
			myTitle_in.Text = "";

			isFinished_txt.Visibility = Visibility.Visible;
			status_stack_in.Visibility = Visibility.Visible;
			myIsStarted_in.IsChecked = false;
			myIsFinished_in.IsChecked = false;

			author_txt.Visibility = Visibility.Collapsed;
			myAuthor_in.Visibility = Visibility.Collapsed;
			myAuthor_in.Text = "";

			studio_txt.Visibility = Visibility.Collapsed;
			myStudio_in.Visibility = Visibility.Collapsed;
			myStudio_in.Text = "";

			rating_stack.Visibility = Visibility.Visible;
			rating_stack_in.Visibility = Visibility.Visible;
			myRating_in.Visibility = Visibility.Hidden;
			rating_value.Visibility = Visibility.Hidden;
			myRating_in.Value = 0;
			rating_value.Text = "0";
			rating_switch.IsChecked = false;

			progress_stack.Visibility = Visibility.Collapsed;
			percentage_stack_in.Visibility = Visibility.Collapsed;
			myProgress_in.Visibility = Visibility.Collapsed;
			percentage_switch.IsChecked = false;
			percentage_value.Text = "0";
			myPercentageRead_in.Value = 0;
			myProgress_in.Text = "";

			dropped_txt.Visibility = Visibility.Visible;
			myIsDropped_in.Visibility = Visibility.Visible;
			myIsDropped_in.IsChecked = false;
		}

		private void SetInputAll()
		{
			title_txt.Visibility = Visibility.Collapsed;
			myTitle_in.Visibility = Visibility.Collapsed;

			isFinished_txt.Visibility = Visibility.Collapsed;
			status_stack_in.Visibility = Visibility.Collapsed;

			rating_stack.Visibility = Visibility.Collapsed;
			rating_stack_in.Visibility = Visibility.Collapsed;

			dropped_txt.Visibility = Visibility.Collapsed;
			myIsDropped_in.Visibility = Visibility.Collapsed;
		}

		private void SetInputBook()
		{
			author_txt.Visibility = Visibility.Visible;
			myAuthor_in.Visibility = Visibility.Visible;

			progress_stack.Visibility = Visibility.Visible;
			percentage_stack_in.Visibility = Visibility.Collapsed;
			myProgress_in.Visibility = Visibility.Visible;
		}

		private void SetInputWebNovel()
		{
			author_txt.Visibility = Visibility.Visible;
			myAuthor_in.Visibility = Visibility.Visible;

			progress_stack.Visibility = Visibility.Visible;
			percentage_stack_in.Visibility = Visibility.Collapsed;
			myProgress_in.Visibility = Visibility.Visible;
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

		private void Percentage_switch_Checked(object sender, RoutedEventArgs e)
		{
			if (progress_stack.Visibility == Visibility.Visible)
			{
				percentage_stack_in.Visibility = Visibility.Visible;
				myProgress_in.Visibility = Visibility.Collapsed;
			}
		}

		private void Percentage_switch_Unchecked(object sender, RoutedEventArgs e)
		{
			if (progress_stack.Visibility == Visibility.Visible)
			{
				percentage_stack_in.Visibility = Visibility.Collapsed;
				myProgress_in.Visibility = Visibility.Visible;
			}
		}

		private void MyIsFinished_in_Checked(object sender, RoutedEventArgs e)
		{
			if (status_stack_in.Visibility == Visibility.Visible)
			{
				myIsStarted_in.IsChecked = true;
			}
		}

		private void MyRating_in_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			rating_value.Text = myRating_in.Value.ToString();
		}

		private void MyPercentageRead_in_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			percentage_value.Text = myPercentageRead_in.Value.ToString();
		}

		private void Rating_switch_Checked(object sender, RoutedEventArgs e)
		{
			myRating_in.Visibility = Visibility.Visible;
			rating_value.Visibility = Visibility.Visible;
		}

		private void Rating_switch_Unchecked(object sender, RoutedEventArgs e)
		{
			myRating_in.Visibility = Visibility.Hidden;
			rating_value.Visibility = Visibility.Hidden;
		}

		private void ComboBox_MediaChoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			MainWindow.MyMainwindow.MyTypeIndex = comboBox_MediaChoice.SelectedIndex;
			Refresh();
		}
	}
}
