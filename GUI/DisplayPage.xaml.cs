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
		Media MyMedia;

		public DisplayPage(Media media)
		{
			InitializeComponent();
			MyMedia = media;
			Refresh();
		}

		public void Refresh()
		{
			string path = "";
			if (MyMedia.MyImageName != null)
			{
				path = System.IO.Path.Combine(MainWindow.MyMainwindow.MySettings.MyImageFolder, MyMedia.MyImageName);
			}

			if (File.Exists(path))
			{
				var uri = new Uri(path);
				var bitmap = new BitmapImage(uri);
				image.Source = bitmap;
			}

			title.Text = MyMedia.MyTitle;
			author.Text = MyMedia.MyAuthor;
			studio.Text = MyMedia.MyStudio;
			started.Text = MyMedia.MyIsStarted.ToString();
			finished.Text = MyMedia.MyIsFinished.ToString();
			rewatches.Text = MyMedia.MyTotalRewatches.ToString();
			rating.Text = MyMedia.MyRating.ToString();
			progress.Text = MyMedia.MyProgress;
			percentage.Text = MyMedia.MyProgressPercentage.ToString();
			dropped.Text = MyMedia.MyIsDropped.ToString();
			imageName.Text = MyMedia.MyImageName;
			release.Text = MyMedia.MyReleaseDate;
			firstwatch.Text = MyMedia.MyFirstWatchDate;
			lastwatch.Text = MyMedia.MyLastWatchDate;
		}
	}
}
