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
	public partial class DisplayPage : Page, IPage
	{
		private List<AttributeField> AttributeFields = new List<AttributeField>();
		public Media MyMedia { get; set; }
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

			AttributeFields.Clear();
			AttributeFields.Add(new AttributeField(0, MyMedia.MyTitle, this));
			AttributeFields.Add(new AttributeField(0, MyMedia.MyAuthor, this));
			AttributeFields.Add(new AttributeField(0, MyMedia.MyIsStarted, this));
			AttributeFields.Add(new AttributeField(0, MyMedia.MyIsFinished, this));
			AttributeFields.Add(new AttributeField(0, MyMedia.MyRating, this));
			AttributeFields.Add(new AttributeField(0, MyMedia.MyIsDropped, this));
			AttributeFields.Add(new AttributeField(0, MyMedia.MyProgress, this));
			AttributeFields.Add(new AttributeField(0, MyMedia.MyProgressPercentage, this));
			AttributeFields.Add(new AttributeField(0, MyMedia.MyImageName, this));
			AttributeFields.Add(new AttributeField(0, MyMedia.MyReleaseDate, this));
			AttributeFields.Add(new AttributeField(0, MyMedia.MyFirstWatchDate, this));

			displayStack.Children.Clear();
			foreach (var item in AttributeFields)
			{
				displayStack.Children.Add(item as AttributeField);
			}
		}	
	}
}
