using MediaClass;
using System;
using System.IO;
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
using Downloaders;

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
				if (item.MyErrorState)
				{
					return;
				}
			}

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

			if (m.MyType == "Film")
			{
				string invalid = new string(System.IO.Path.GetInvalidFileNameChars()) + new string(System.IO.Path.GetInvalidPathChars());
				string searchTerm = m.MyTitle + " " + "(" + m.MyReleaseDate + ")";
				foreach (char c in invalid)
				{
					searchTerm = searchTerm.Replace(c.ToString(), "");
				}

				Downloader d = new Downloader();
				d.DownloadImageIMDB(searchTerm, MainWindow.MyMainwindow.MySettings.MyImageFolder + searchTerm + ".jpg");
				m.MyImageName = searchTerm + ".jpg";
			}

			MainWindow.MyMainwindow.MyMediaList.Add(m);
			ResetInput();
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
			inputFields.Add(new InputField("Text", "Buch", "MyTitle", "Titel"));
			inputFields.Add(new InputField("Text", "Buch", "MyAuthor", "Autor"));
			inputFields.Add(new InputField("Check", "Buch", "MyIsStarted", "Angefangen"));
			inputFields.Add(new InputField("Check", "Buch", "MyIsFinished", "Beendet"));
			inputFields.Add(new InputField("Slider", "Buch", "MyRating", "Bewertung"));
			inputFields.Add(new InputField("Check", "Buch", "MyIsDropped", "Dropped"));
			inputFields.Add(new InputField("Text", "Buch", "MyProgress", "Fortschritt"));
			inputFields.Add(new InputField("Slider", "Buch", "MyProgressPercentage", "Fortschritt%"));
			inputFields.Add(new InputField("Text", "Buch", "MyReleaseDate", "Erschienen:"));
			inputFields.Add(new InputField("Text", "Buch", "MyFirstWatchDate", "Angefangen:"));
		}

		private void SetInputWebNovel()
		{

		}

		private void SetInputMovie()
		{
			inputFields.Add(new InputField("Text", "Buch", "MyTitle", "Titel"));
			inputFields.Add(new InputField("Check", "Buch", "MyIsStarted", "Angefangen"));
			inputFields.Add(new InputField("Check", "Buch", "MyIsFinished", "Beendet"));
			inputFields.Add(new InputField("Slider", "Buch", "MyRating", "Bewertung"));
			inputFields.Add(new InputField("Check", "Buch", "MyIsDropped", "Dropped"));
			inputFields.Add(new InputField("Text", "Buch", "MyProgress", "Fortschritt"));
			inputFields.Add(new InputField("Text", "Buch", "MyReleaseDate", "Erschienen:"));
			inputFields.Add(new InputField("Text", "Buch", "MyFirstWatchDate", "Angefangen:"));
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
