using HelperClasses;
using MediaClass;
using System;
using System.Collections.Generic;
using System.IO;
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
	/// Interaktionslogik für DisplayPage.xaml
	/// </summary>
	public partial class DisplayPage : Page, PageInterface
	{
		private List<DisplayField> displayFields = new List<DisplayField>();
		Media MyMedia;
		string path = "";

		public DisplayPage(Media media)
		{
			InitializeComponent();
			MyMedia = media;

			if (MyMedia.MyImageName != null && MyMedia.MyImageName != "")
			{
				path = System.IO.Path.Combine(MainWindow.MyMainwindow.MySettings.MyImageFolder, MyMedia.MyImageName);
			}
			if (!File.Exists(path))
			{
				Downloader d = new Downloader();
				MyMedia.MyImageName = d.GetImage(MainWindow.MyMainwindow.MySettings.MyImageFolder, MyMedia.MyType, MyMedia.MyTitle, MyMedia.MyReleaseDate);
			}
			Refresh();
		}

		public void Refresh()
		{
			var uri = new Uri(path);
			var bitmap = new BitmapImage(uri);
			image.Source = bitmap;


			displayFields.Clear();
			displayFields.Add(new DisplayField(MyMedia.MyTitle, "Titel"));
			displayFields.Add(new DisplayField(MyMedia.MyAuthor, "Autor"));
			displayFields.Add(new DisplayField(MyMedia.MyIsStarted, "Angefangen"));
			displayFields.Add(new DisplayField(MyMedia.MyIsFinished, "Beendet"));
			displayFields.Add(new DisplayField(MyMedia.MyRating, "Bewertung"));
			displayFields.Add(new DisplayField(MyMedia.MyIsDropped, "Dropped"));
			displayFields.Add(new DisplayField(MyMedia.MyProgress, "Fortschritt"));
			displayFields.Add(new DisplayField(MyMedia.MyProgressPercentage, "Fortschritt%"));
			displayFields.Add(new DisplayField(MyMedia.MyImageName, "Bild:"));
			displayFields.Add(new DisplayField(MyMedia.MyReleaseDate, "Erschienen:"));
			displayFields.Add(new DisplayField(MyMedia.MyFirstWatchDate, "Angefangen:"));

			displayStack.Children.Clear();
			foreach (var item in displayFields)
			{
				displayStack.Children.Add(item);
			}
		}
	}
}
