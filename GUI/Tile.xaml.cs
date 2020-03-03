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
    /// Interaction logic for Tile.xaml
    /// </summary>
    public partial class Tile : Page
    {
        Media media;

        string folder = Environment.ExpandEnvironmentVariables(@"%AppData%\Media-Database\Bilder\");

        public Tile(Media m)
        {
            InitializeComponent();
            media = m;

            if (m.MyImageName != null)
            {
                var path = System.IO.Path.Combine(folder, m.MyImageName);
                var uri = new Uri(path);
                var bitmap = new BitmapImage(uri);
                image.Source = bitmap;
            }
            title.Text = m.MyTitle;
        }

        private void Click_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.MyMainwindow.OpenDisplayPage(media);
        }
    }
}
