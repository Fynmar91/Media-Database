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
		private List<FieldInterface> displayFields = new List<FieldInterface>();
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

		public void EnableInput()
		{
			throw new NotImplementedException();
		}

		public void Refresh()
		{
			var uri = new Uri(path);
			var bitmap = new BitmapImage(uri);
			image.Source = bitmap;

			int index = 0;
			displayFields.Clear();
			displayFields.Add(new DisplayField(MyMedia.MyTitle, this, ++index));
			displayFields.Add(new DisplayField(MyMedia.MyAuthor, this, ++index));
			displayFields.Add(new DisplayField(MyMedia.MyIsStarted, this, ++index));
			displayFields.Add(new DisplayField(MyMedia.MyIsFinished, this, ++index));
			displayFields.Add(new DisplayField(MyMedia.MyRating, this, ++index));
			displayFields.Add(new DisplayField(MyMedia.MyIsDropped, this, ++index));
			displayFields.Add(new DisplayField(MyMedia.MyProgress, this, ++index));
			displayFields.Add(new DisplayField(MyMedia.MyProgressPercentage, this, ++index));
			displayFields.Add(new DisplayField(MyMedia.MyImageName, this, ++index));
			displayFields.Add(new DisplayField(MyMedia.MyReleaseDate, this, ++index));
			displayFields.Add(new DisplayField(MyMedia.MyFirstWatchDate, this, ++index));

			displayStack.Children.Clear();
			foreach (var item in displayFields)
			{
				displayStack.Children.Add(item as DisplayField);
			}
		}

		public void EnableInput(MediaProp mediaProp, int index)
		{
			InputField inputField;

			if (mediaProp is MediaPropText)
			{
				inputField = new InputField(mediaProp);
				displayStack.Children.RemoveAt(index - 1);
				displayStack.Children.Insert(index - 1, inputField);
			}
			else if (mediaProp is MediaPropInt)
			{
				inputField = new InputField(mediaProp);
				displayStack.Children.RemoveAt(index - 1);
				displayStack.Children.Insert(index - 1, inputField);
			}
			else if (mediaProp is MediaPropBool)
			{
				inputField = new InputField(mediaProp);
				displayStack.Children.RemoveAt(index - 1);
				displayStack.Children.Insert(index - 1, inputField);
			}
			else if (mediaProp is MediaPropDate)
			{
				inputField = new InputField(mediaProp);
				displayStack.Children.RemoveAt(index - 1);
				displayStack.Children.Insert(index - 1, inputField);
			}
		}
	}
}
