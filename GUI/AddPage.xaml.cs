using HelperClasses;
using MediaClass;
using System;
using System.Collections.Generic;
using System.IO;
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
	public partial class AddPage : Page, IPage
	{
		public Media MyMedia { get; set; }

		private List<AttributeField> AttributeFields = new List<AttributeField>(); 

		public AddPage()
		{
			InitializeComponent();
			comboBox_MediaChoice.ItemsSource = MainWindow.MyMainwindow.MyTypeString;
			Refresh();
		}

		public void Refresh()
		{
			MyMedia = new Media();
			MyMedia.MyTitle.MyType.MyValue = MainWindow.MyMainwindow.MyActiveTypeString;
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
			// Error Stuff
			foreach (var item in AttributeFields)
			{
				if (!item.MyNoError)
				{
					return;
				}
			}

			foreach (var item in AttributeFields)
			{
				item.WriteProp();
			}

			Downloader d = new Downloader();
			string image = d.GetImage(MainWindow.MyMainwindow.MySettings.MyImageFolder, MyMedia);
			if (image != null)
			{
				MyMedia.MyImageName.MyValue = image;
			}			

			MainWindow.MyMainwindow.MyMediaList.Add(MyMedia);
			Refresh();
		}		

		//
		// Media Type Selection Stuff
		//
		private void ResetInput()
		{
			inputStack.Children.Clear();
			AttributeFields.Clear();
		}

		private void BuildUI()
		{
			foreach (var item in AttributeFields)
			{
				inputStack.Children.Add(item);
			}
		}

		private void SetInputBook()
		{
			AttributeFields.Add(new AttributeField(1, MyMedia.MyTitle, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyAuthor, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyIsStarted, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyIsFinished, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyRating, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyIsDropped, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyProgress, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyProgressPercentage, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyReleaseDate, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyFirstWatchDate, this));
		}											  
													  
		private void SetInputWebNovel()				  
		{			  
			AttributeFields.Add(new AttributeField(1, MyMedia.MyTitle, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyAuthor, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyIsStarted, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyIsFinished, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyRating, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyIsDropped, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyProgress, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyProgressPercentage, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyReleaseDate, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyFirstWatchDate, this));
		}											  
													  
		private void SetInputMovie()				  
		{			  
			AttributeFields.Add(new AttributeField(1, MyMedia.MyTitle, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyIsStarted, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyIsFinished, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyRating, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyIsDropped, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyProgress, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyReleaseDate, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyFirstWatchDate, this));
		}											  
													  
		private void SetInputShow()					  
		{			  
			MyMedia.MyTitle.MyHasSeasons = true;		  
			AttributeFields.Add(new AttributeField(1, MyMedia.MyTitle, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyIsStarted, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyIsFinished, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyRating, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyIsDropped, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyProgress, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyReleaseDate, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyFirstWatchDate, this));
		}											  
													  
		private void SetInputAnime()				  
		{				  
			MyMedia.MyTitle.MyHasSeasons = true;		  
			AttributeFields.Add(new AttributeField(1, MyMedia.MyTitle, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyStudio, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyIsStarted, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyIsFinished, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyRating, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyIsDropped, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyProgress, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyReleaseDate, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyFirstWatchDate, this));
		}											  
													  
		private void SetInputAnimeMovie()			  
		{			  
			AttributeFields.Add(new AttributeField(1, MyMedia.MyTitle, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyStudio, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyIsStarted, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyIsFinished, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyRating, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyIsDropped, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyProgress, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyReleaseDate, this));
			AttributeFields.Add(new AttributeField(1, MyMedia.MyFirstWatchDate, this));
		}
	}
}
