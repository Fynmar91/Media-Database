using MediaClass;
using System;
using System.Collections.Generic;
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
		Media media;

		string folder = Environment.ExpandEnvironmentVariables(@"%AppData%\Media-Database\Bilder\");

		public DisplayPage(Media m)
		{
			InitializeComponent();
			media = m;
			Refresh();
		}

		public void Refresh()
		{
			if (media.MyImageName != null)
			{
				var path = System.IO.Path.Combine(folder, media.MyImageName);
				var uri = new Uri(path);
				var bitmap = new BitmapImage(uri);
				image.Source = bitmap;
			}

			title.Text = media.MyTitle;
			author.Text = media.MyAuthor;
			studio.Text = media.MyStudio;
			started.Text = media.MyIsStarted.ToString();
			finished.Text = media.MyIsFinished.ToString();
			rewatches.Text = media.MyTotalRewatches.ToString();
			rating.Text = media.MyRating.ToString();
			progress.Text = media.MyProgress;
			percentage.Text = media.MyProgressPercentage.ToString();
			dropped.Text = media.MyIsDropped.ToString();
			imageName.Text = media.MyImageName;
			release.Text = media.MyReleaseDate;
			firstwatch.Text = media.MyFirstWatchDate;
			lastwatch.Text = media.MyLastWatchDate;
		}
	}
}
