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
        private Page activePage;

        public MainWindow()
        {
            InitializeComponent();
            Load();
            Refresh();
        }

        public void Refresh()
        {
        }

        private void Load()
        {
            mediaList = json.Deserialize();
            mediaList.Sort((x, y) => y.MyTitle.CompareTo(x.MyTitle));
        }

        private void Button_List_Click(object sender, RoutedEventArgs e)
        {
            activePage = new ListPage(mediaList);
            PageView.Content = activePage;
        }

        private void Button_Tile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Book_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_WebNovel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            json.Serialize(mediaList);
        }
    }
}
