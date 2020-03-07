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

			if (MyMedia.MyImageName != null && MyMedia.MyImageName.MyValue != "")
			{
				path = System.IO.Path.Combine(MainWindow.MyMainwindow.MySettings.MyImageFolder, MyMedia.MyImageName.MyValue);
			}
			if (!File.Exists(path))
			{
				Downloader d = new Downloader();
				MyMedia.MyImageName.MyValue = d.GetImage(MainWindow.MyMainwindow.MySettings.MyImageFolder, MyMedia);
			}
			Refresh();
		}

		public void Refresh()
		{
			var uri = new Uri(path);
			var bitmap = new BitmapImage(uri);
			image.Source = bitmap;

			displayFields.Clear();
			displayFields.Add(new DisplayField(MyMedia.MyTitle, this));
			displayFields.Add(new DisplayField(MyMedia.MyAuthor, this));
			displayFields.Add(new DisplayField(MyMedia.MyIsStarted, this));
			displayFields.Add(new DisplayField(MyMedia.MyIsFinished, this));
			displayFields.Add(new DisplayField(MyMedia.MyRating, this));
			displayFields.Add(new DisplayField(MyMedia.MyIsDropped, this));
			displayFields.Add(new DisplayField(MyMedia.MyProgress, this));
			displayFields.Add(new DisplayField(MyMedia.MyProgressPercentage, this));
			displayFields.Add(new DisplayField(MyMedia.MyImageName, this));
			displayFields.Add(new DisplayField(MyMedia.MyReleaseDate, this));
			displayFields.Add(new DisplayField(MyMedia.MyFirstWatchDate, this));

			displayStack.Children.Clear();
			foreach (var item in displayFields)
			{
				displayStack.Children.Add(item);
			}
		}

		public void EnableInput(MediaProp mediaProp)
		{
			InputField inputField;

			if (mediaProp is MediaPropText)
			{

			}
			else if (mediaProp is MediaPropInt)
			{

			}
			else if (mediaProp is MediaPropBool)
			{

			}
			else if (mediaProp is MediaPropDate)
			{

			}
		}
	}
}
