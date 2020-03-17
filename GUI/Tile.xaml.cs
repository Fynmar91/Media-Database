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
	/// Interaction logic for Tile.xaml
	/// </summary>
	public partial class Tile : Page
	{
		Media MyMedia;

		public Tile(Media media)
		{
			InitializeComponent();
			MyMedia = media;

			string path = "";
			if (media.MyImageName != null)
			{
				path = System.IO.Path.Combine(MainWindow.MyMainwindow.MySettings.MyImageFolder, media.MyImageName.MyValue);
			}

			if (File.Exists(path))
			{				
				var uri = new Uri(path);
				var bitmap = new BitmapImage(uri);
				image.Source = bitmap;
			}
			if (media.MyTitle.MyHasSeasons)
			{

				title.Text = media.MyTitle.MyValue + " " + media.MyTitle.MySeason;
			}
			else
			{
				title.Text = media.MyTitle.MyValue;
			}
		}

		private void Click_Click(object sender, RoutedEventArgs e)
		{
			MainWindow.MyMainwindow.OpenDisplayPage(MyMedia);
		}
	}
}
