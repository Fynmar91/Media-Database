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

			// Set Propperties
			//foreach (var item in AttributeFields)
			//{
			//	foreach (var prop in media.MyProperties)
			//	{
			//		if (item.MyMediaProp.MyDescription == prop.MyDescription)
			//		{
			//			if (prop is MediaPropTitle)
			//			{
			//				(prop as MediaPropTitle).MyValue = item.MyInput[0];
			//				(prop as MediaPropTitle).MySeason = int.Parse(item.MyInput[1]);
			//				break;
			//			}
			//			else if (prop is MediaPropText)
			//			{
			//				(prop as MediaPropText).MyValue = item.MyInput[0];
			//				break;
			//			}
			//			else if (prop is MediaPropInt)
			//			{
			//				(prop as MediaPropInt).MyValue = int.Parse(item.MyInput[0]);
			//				break;
			//			}
			//			else if (prop is MediaPropBool)
			//			{
			//				(prop as MediaPropBool).MyValue = bool.Parse(item.MyInput[0]);
			//				break;
			//			}
			//			else if (prop is MediaPropDate)
			//			{
			//				(prop as MediaPropDate).MyValue = item.MyInput[0];
			//				break;
			//			}
			//		}
			//	}				
			//}

			// Download Image
			Downloader d = new Downloader();
			MyMedia.MyImageName.MyValue = d.GetImage(MainWindow.MyMainwindow.MySettings.MyImageFolder, MyMedia);

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
			Media media = new Media();
			AttributeFields.Add(new AttributeField(1, media.MyTitle, this));
			AttributeFields.Add(new AttributeField(1, media.MyAuthor, this));
			AttributeFields.Add(new AttributeField(1, media.MyIsStarted, this));
			AttributeFields.Add(new AttributeField(1, media.MyIsFinished, this));
			AttributeFields.Add(new AttributeField(1, media.MyRating, this));
			AttributeFields.Add(new AttributeField(1, media.MyIsDropped, this));
			AttributeFields.Add(new AttributeField(1, media.MyProgress, this));
			AttributeFields.Add(new AttributeField(1, media.MyProgressPercentage, this));
			AttributeFields.Add(new AttributeField(1, media.MyReleaseDate, this));
			AttributeFields.Add(new AttributeField(1, media.MyFirstWatchDate, this));
		}											  
													  
		private void SetInputWebNovel()				  
		{											  
			Media media = new Media();				  
			AttributeFields.Add(new AttributeField(1, media.MyTitle, this));
			AttributeFields.Add(new AttributeField(1, media.MyAuthor, this));
			AttributeFields.Add(new AttributeField(1, media.MyIsStarted, this));
			AttributeFields.Add(new AttributeField(1, media.MyIsFinished, this));
			AttributeFields.Add(new AttributeField(1, media.MyRating, this));
			AttributeFields.Add(new AttributeField(1, media.MyIsDropped, this));
			AttributeFields.Add(new AttributeField(1, media.MyProgress, this));
			AttributeFields.Add(new AttributeField(1, media.MyProgressPercentage, this));
			AttributeFields.Add(new AttributeField(1, media.MyReleaseDate, this));
			AttributeFields.Add(new AttributeField(1, media.MyFirstWatchDate, this));
		}											  
													  
		private void SetInputMovie()				  
		{											  
			Media media = new Media();				  
			AttributeFields.Add(new AttributeField(1, media.MyTitle, this));
			AttributeFields.Add(new AttributeField(1, media.MyIsStarted, this));
			AttributeFields.Add(new AttributeField(1, media.MyIsFinished, this));
			AttributeFields.Add(new AttributeField(1, media.MyRating, this));
			AttributeFields.Add(new AttributeField(1, media.MyIsDropped, this));
			AttributeFields.Add(new AttributeField(1, media.MyProgress, this));
			AttributeFields.Add(new AttributeField(1, media.MyReleaseDate, this));
			AttributeFields.Add(new AttributeField(1, media.MyFirstWatchDate, this));
		}											  
													  
		private void SetInputShow()					  
		{											  
			Media media = new Media();				  
			media.MyTitle.MyHasSeasons = true;		  
			AttributeFields.Add(new AttributeField(1, media.MyTitle, this));
			AttributeFields.Add(new AttributeField(1, media.MyIsStarted, this));
			AttributeFields.Add(new AttributeField(1, media.MyIsFinished, this));
			AttributeFields.Add(new AttributeField(1, media.MyRating, this));
			AttributeFields.Add(new AttributeField(1, media.MyIsDropped, this));
			AttributeFields.Add(new AttributeField(1, media.MyProgress, this));
			AttributeFields.Add(new AttributeField(1, media.MyReleaseDate, this));
			AttributeFields.Add(new AttributeField(1, media.MyFirstWatchDate, this));
		}											  
													  
		private void SetInputAnime()				  
		{											  
			Media media = new Media();				  
			media.MyTitle.MyHasSeasons = true;		  
			AttributeFields.Add(new AttributeField(1, media.MyTitle, this));
			AttributeFields.Add(new AttributeField(1, media.MyStudio, this));
			AttributeFields.Add(new AttributeField(1, media.MyIsStarted, this));
			AttributeFields.Add(new AttributeField(1, media.MyIsFinished, this));
			AttributeFields.Add(new AttributeField(1, media.MyRating, this));
			AttributeFields.Add(new AttributeField(1, media.MyIsDropped, this));
			AttributeFields.Add(new AttributeField(1, media.MyProgress, this));
			AttributeFields.Add(new AttributeField(1, media.MyReleaseDate, this));
			AttributeFields.Add(new AttributeField(1, media.MyFirstWatchDate, this));
		}											  
													  
		private void SetInputAnimeMovie()			  
		{											  
			Media media = new Media();				  
			AttributeFields.Add(new AttributeField(1, media.MyTitle, this));
			AttributeFields.Add(new AttributeField(1, media.MyStudio, this));
			AttributeFields.Add(new AttributeField(1, media.MyIsStarted, this));
			AttributeFields.Add(new AttributeField(1, media.MyIsFinished, this));
			AttributeFields.Add(new AttributeField(1, media.MyRating, this));
			AttributeFields.Add(new AttributeField(1, media.MyIsDropped, this));
			AttributeFields.Add(new AttributeField(1, media.MyProgress, this));
			AttributeFields.Add(new AttributeField(1, media.MyReleaseDate, this));
			AttributeFields.Add(new AttributeField(1, media.MyFirstWatchDate, this));
		}
	}
}
