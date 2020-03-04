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
		private bool[] errors = { false, false };

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
					SetInputAll();
					break;
			}

			title_txt.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xBA, 0xBA, 0xBA));
			author_txt.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xBA, 0xBA, 0xBA));
			studio_txt.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xBA, 0xBA, 0xBA));
			rating_txt.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xBA, 0xBA, 0xBA));
			progress_txt.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xBA, 0xBA, 0xBA));
			percentage_value.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xBA, 0xBA, 0xBA));
			firstWatch_txt.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xBA, 0xBA, 0xBA));
		}

		private void Button_Add_Click(object sender, RoutedEventArgs e)
		{
			AddMedia();
		}

		private void AddMedia()
		{
			if (!errors[0] && !errors[1])
			{
				Media media = new Media();

				media.MyType = comboBox_MediaChoice.SelectedValue.ToString();

				media.MyTitle = myTitle_in.Text;
				media.MyAuthor = myAuthor_in.Text;
				media.MyStudio = myStudio_in.Text;
				media.MyIsStarted = myIsStarted_in.IsChecked.Value;
				media.MyIsFinished = myIsFinished_in.IsChecked.Value;
				if (rating_switch.IsChecked == true)
				{
					media.MyRating = Convert.ToInt16(myRating_in.Value);
				}
				media.MyProgress = myProgress_in.Text;
				media.MyProgressPercentage = Convert.ToInt16(myPercentageRead_in.Value);
				media.MyIsDropped = myIsDropped_in.IsChecked.Value;
				if (myIsStarted_in.IsChecked.Value != false)
				{
					media.MyFirstWatchDate = myFirstWatch_in.Text.ToString();
				}				

				MainWindow.MyMainwindow.MyMediaList.Add(media);
				Refresh();
			}			
		}

		//
		// Media Type Selection Stuff
		//
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

			firstWatch_txt.Visibility = Visibility.Visible;
			myFirstWatch_in.Visibility = Visibility.Visible;
			myFirstWatch_in.Text = "";
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

			firstWatch_txt.Visibility = Visibility.Collapsed;
			myFirstWatch_in.Visibility = Visibility.Collapsed;
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
		
		//
		// Realtime Check Stuff
		//
		private void MyTitle_in_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (MainWindow.MyMainwindow.MyMediaList.TestTitle(MainWindow.MyMainwindow.MyActiveTypeString, myTitle_in.Text.ToString()))
			{
				title_txt.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xBA, 0xBA, 0xBA));
				errors[0] = false;
			}
			else
			{
				title_txt.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x00, 0x00));
				errors[0] = true;
			}
		}
		private void MyFirstWatch_in_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (myIsStarted_in.IsChecked.Value == true)
			{
				if (MainWindow.MyMainwindow.MyMediaList.TestFirstDate(myFirstWatch_in.Text.ToString()))
				{
					firstWatch_txt.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xBA, 0xBA, 0xBA));
					errors[1] = false;
				}
				else
				{
					firstWatch_txt.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x00, 0x00));
					errors[1] = true;
				}
			}
		}

		//
		//
		//
		private void ComboBox_MediaChoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			MainWindow.MyMainwindow.SelectMediaType(comboBox_MediaChoice.SelectedIndex);
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

		private void MyIsStarted_in_Checked(object sender, RoutedEventArgs e)
		{
			myFirstWatch_in.Text = DateTime.Today.ToString("yyyy-MM-dd");
		}
		private void MyIsStarted_in_Unchecked(object sender, RoutedEventArgs e)
		{
			myFirstWatch_in.Text = "";
			myIsStarted_in.IsChecked = false;
		}
		private void MyIsFinished_in_Checked(object sender, RoutedEventArgs e)
		{
			if (status_stack_in.Visibility == Visibility.Visible)
			{
				myIsStarted_in.IsChecked = true;
			}
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
	}
}
