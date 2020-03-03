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
        string folder = Environment.ExpandEnvironmentVariables(@"%AppData%\Media-Database\Bilder\");

        public Tile()
        {
            InitializeComponent();
            var path = System.IO.Path.Combine(folder, "StarGateAtlantisS1.jpg");
            var uri = new Uri(path);
            var bitmap = new BitmapImage(uri);
            image.Source = bitmap;
        }
    }
}
