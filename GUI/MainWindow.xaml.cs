using MediaClass;
using Serializing;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaList mediaList = new MediaList();
        private JSONSerializer json = new JSONSerializer();

        public MainWindow()
        {
            InitializeComponent();
            Load();
            List_Media.ItemsSource = this.mediaList;
            Refresh();
        }

        public void Refresh()
        {
            List_Media.Items.Refresh();
        }

        private void Load()
        {
            mediaList = json.Deserialize();
            mediaList.Sort((x, y) => y.MyTitle.CompareTo(x.MyTitle));
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            Add add = new Add(mediaList, this);
            add.Show();
        }

        private void List_Media_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void List_Media_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
