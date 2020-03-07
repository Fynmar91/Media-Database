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
	/// Interaktionslogik für DisplayPage.xaml
	/// </summary>
	public partial class DisplayPage : Page, PageInterface
	{
		private List<DisplayField> displayFields = new List<DisplayField>();
		private Media MyMedia;
		private string path = "";

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
			displayFields.Add(new DisplayField(MyMedia.MyTitle, "Titel", "MyTitle", this));
			displayFields.Add(new DisplayField(MyMedia.MyAuthor, "Autor", "MyAuthor", this));
			displayFields.Add(new DisplayField(MyMedia.MyIsStarted, "Angefangen", "MyIsStarted", this));
			displayFields.Add(new DisplayField(MyMedia.MyIsFinished, "Beendet", "MyIsFinished", this));
			displayFields.Add(new DisplayField(MyMedia.MyRating, "Bewertung", "MyRating", this));
			displayFields.Add(new DisplayField(MyMedia.MyIsDropped, "Dropped", "MyIsDropped", this));
			displayFields.Add(new DisplayField(MyMedia.MyProgress, "Fortschritt", "MyProgress", this));
			displayFields.Add(new DisplayField(MyMedia.MyProgressPercentage, "Fortschritt%", "MyProgressPercentage", this));
			displayFields.Add(new DisplayField(MyMedia.MyImageName, "Bild:", "MyImageName", this));
			displayFields.Add(new DisplayField(MyMedia.MyReleaseDate, "Erschienen:", "MyReleaseDate", this));
			displayFields.Add(new DisplayField(MyMedia.MyFirstWatchDate, "Angefangen:", "MyFirstWatchDate", this));

			displayStack.Children.Clear();
			foreach (var item in displayFields)
			{
				displayStack.Children.Add(item);
			}
		}

		public void EnableInput(string propName, string descText)
		{
			InputField inputField;

			Type myType = typeof(Media);
			PropertyInfo myPropInfo = myType.GetProperty(propName);
			TypeCode typeCode = Type.GetTypeCode(myPropInfo.PropertyType)

;			switch (typeCode)
			{
				case TypeCode.String:
					inputField = new InputField("Text", myPropInfo.GetValue(MyMedia).ToString(), propName, descText);
					break;
				case TypeCode.Int32:

					break;
				case TypeCode.Boolean:

					break;				
				default:
					break;
			}

			

		}
	}
}
