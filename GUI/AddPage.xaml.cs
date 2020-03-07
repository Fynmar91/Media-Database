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
			// Error Stuff
			foreach (var item in inputFields)
			{
				if (item.MyErrorState)
				{
					return;
				}
			}

			// Set Propperties
			Media m = new Media();
			m.MyType = MainWindow.MyMainwindow.MyActiveTypeString;

			foreach (var item in inputFields)
			{
				MethodInfo mi = MainWindow.MyMainwindow.MyMediaList.GetType().GetMethod(item.MyPropName);
				object[] obj = { MainWindow.MyMainwindow.MyActiveTypeString, item.MyInput };

				if (mi != null && (bool)mi.Invoke(MainWindow.MyMainwindow.MyMediaList, obj))
				{
					Type myType = typeof(Media);
					PropertyInfo myPropInfo = myType.GetProperty(item.MyPropName);
					myPropInfo.SetValue(m, item.MyInput, null);
				}
				else if (mi == null)
				{
					if (item.MyInputType == "Slider")
					{
						Type myType = typeof(Media);
						PropertyInfo myPropInfo = myType.GetProperty(item.MyPropName);
						myPropInfo.SetValue(m, Convert.ToInt16(item.MyInput), null);
					}
					else if (item.MyInputType == "Check")
					{
						Type myType = typeof(Media);
						PropertyInfo myPropInfo = myType.GetProperty(item.MyPropName);
						myPropInfo.SetValue(m, Convert.ToBoolean(item.MyInput), null);
					}
				}
			}

			// Download Image
			Downloader d = new Downloader();
			m.MyImageName = d.GetImage(MainWindow.MyMainwindow.MySettings.MyImageFolder, m.MyType, m.MyTitle, m.MyReleaseDate);

			MainWindow.MyMainwindow.MyMediaList.Add(m);
			Refresh();
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
				inputStack.Children.Add(item);
			}
		}

		private void SetInputBook()
		{
			inputFields.Add(new InputField("Text", "Buch", "MyTitle", "Titel:"));
			inputFields.Add(new InputField("Text", "Buch", "MyAuthor", "Autor:"));
			inputFields.Add(new InputField("Check", "Buch", "MyIsStarted", "Angefangen:"));
			inputFields.Add(new InputField("Check", "Buch", "MyIsFinished", "Beendet:"));
			inputFields.Add(new InputField("Slider", "Buch", "MyRating", "Bewertung:"));
			inputFields.Add(new InputField("Check", "Buch", "MyIsDropped", "Dropped:"));
			inputFields.Add(new InputField("Text", "Buch", "MyProgress", "Fortschritt:"));
			inputFields.Add(new InputField("Slider", "Buch", "MyProgressPercentage", "Fortschritt%:"));
			inputFields.Add(new InputField("Text", "Buch", "MyReleaseDate", "Erschienen:"));
			inputFields.Add(new InputField("Text", "Buch", "MyFirstWatchDate", "Angefangen:"));
		}

		private void SetInputWebNovel()
		{
			inputFields.Add(new InputField("Text", "Web-Novel", "MyTitle", "Titel:"));
			inputFields.Add(new InputField("Text", "Web-Novel", "MyAuthor", "Autor:"));
			inputFields.Add(new InputField("Check", "Web-Novel", "MyIsStarted", "Angefangen:"));
			inputFields.Add(new InputField("Check", "Web-Novel", "MyIsFinished", "Beendet:"));
			inputFields.Add(new InputField("Slider", "Web-Novel", "MyRating", "Bewertung:"));
			inputFields.Add(new InputField("Check", "Web-Novel", "MyIsDropped", "Dropped:"));
			inputFields.Add(new InputField("Text", "Web-Novel", "MyProgress", "Fortschritt:"));
			inputFields.Add(new InputField("Slider", "Web-Novel", "MyProgressPercentage", "Fortschritt%:"));
			inputFields.Add(new InputField("Text", "Web-Novel", "MyReleaseDate", "Erschienen:"));
			inputFields.Add(new InputField("Text", "Web-Novel", "MyFirstWatchDate", "Angefangen:"));
		}

		private void SetInputMovie()
		{
			inputFields.Add(new InputField("Text", "Film", "MyTitle", "Titel:"));
			inputFields.Add(new InputField("Check", "Film", "MyIsStarted", "Angefangen:"));
			inputFields.Add(new InputField("Check", "Film", "MyIsFinished", "Beendet:"));
			inputFields.Add(new InputField("Slider", "Film", "MyRating", "Bewertung:"));
			inputFields.Add(new InputField("Check", "Film", "MyIsDropped", "Dropped:"));
			inputFields.Add(new InputField("Text", "Film", "MyProgress", "Fortschritt:"));
			inputFields.Add(new InputField("Text", "Film", "MyReleaseDate", "Erschienen:"));
			inputFields.Add(new InputField("Text", "Film", "MyFirstWatchDate", "Angefangen:"));
		}

		private void SetInputShow()
		{
			inputFields.Add(new InputField("Text", "Serie", "MyTitle", "Titel:"));
			inputFields.Add(new InputField("Check", "Serie", "MyIsStarted", "Angefangen:"));
			inputFields.Add(new InputField("Check", "Serie", "MyIsFinished", "Beendet:"));
			inputFields.Add(new InputField("Slider", "Serie", "MyRating", "Bewertung:"));
			inputFields.Add(new InputField("Check", "Serie", "MyIsDropped", "Dropped:"));
			inputFields.Add(new InputField("Text", "Serie", "MyProgress", "Fortschritt:"));
			inputFields.Add(new InputField("Text", "Serie", "MyReleaseDate", "Erschienen:"));
			inputFields.Add(new InputField("Text", "Serie", "MyFirstWatchDate", "Angefangen:"));
		}

		private void SetInputAnime()
		{
			inputFields.Add(new InputField("Text", "Anime", "MyTitle", "Titel:"));
			inputFields.Add(new InputField("Text", "Anime", "MyStudio", "Studio:"));
			inputFields.Add(new InputField("Check", "Anime", "MyIsStarted", "Angefangen:"));
			inputFields.Add(new InputField("Check", "Anime", "MyIsFinished", "Beendet:"));
			inputFields.Add(new InputField("Slider", "Anime", "MyRating", "Bewertung:"));
			inputFields.Add(new InputField("Check", "Anime", "MyIsDropped", "Dropped:"));
			inputFields.Add(new InputField("Text", "Anime", "MyProgress", "Fortschritt:"));
			inputFields.Add(new InputField("Text", "Anime", "MyReleaseDate", "Erschienen:"));
			inputFields.Add(new InputField("Text", "Anime", "MyFirstWatchDate", "Angefangen:"));
		}

		private void SetInputAnimeMovie()
		{
			inputFields.Add(new InputField("Text", "Anime-Film", "MyTitle", "Titel:"));
			inputFields.Add(new InputField("Text", "Anime-Film", "MyStudio", "Studio:"));
			inputFields.Add(new InputField("Check", "Anime-Film", "MyIsStarted", "Angefangen:"));
			inputFields.Add(new InputField("Check", "Anime-Film", "MyIsFinished", "Beendet:"));
			inputFields.Add(new InputField("Slider", "Anime-Film", "MyRating", "Bewertung:"));
			inputFields.Add(new InputField("Check", "Anime-Film", "MyIsDropped", "Dropped:"));
			inputFields.Add(new InputField("Text", "Anime-Film", "MyProgress", "Fortschritt:"));
			inputFields.Add(new InputField("Text", "Anime-Film", "MyReleaseDate", "Erschienen:"));
			inputFields.Add(new InputField("Text", "Anime-Film", "MyFirstWatchDate", "Angefangen:"));
		}
	}
}
