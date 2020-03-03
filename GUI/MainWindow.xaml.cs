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
        public static MainWindow MyMainwindow { get; set; }

        public string[] typeString = { "", "Buch", "Web-Novel", "Film", "Serie", "Anime", "Anime-Film" };
        public int typeIndex = 0;

        public MediaList mediaList = new MediaList();
        private JSONSerializer json = new JSONSerializer();
        private Page activePage;

        public MainWindow()
        {
            MyMainwindow = this;
            InitializeComponent();
            Load();
            Refresh();
        }

        public void Refresh()
        {
            if (activePage != null)
            {
                (activePage as PageInterface).Refresh();
            }
        }

        private void Load()
        {
            mediaList = json.Deserialize();
            mediaList.Sort((x, y) => y.MyTitle.CompareTo(x.MyTitle));
        }

        private void Button_List_Click(object sender, RoutedEventArgs e)
        {
            activePage = new ListPage();
            PageView.Content = activePage;
        }

        private void Button_Tile_Click(object sender, RoutedEventArgs e)
        {
            activePage = new TilePage();
            PageView.Content = activePage;
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            activePage = new AddPage();
            PageView.Content = activePage;
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            json.Serialize(mediaList);
        }


        private void TypeChoice(int i)
        {
            typeIndex = i;

            if (activePage is ListPage)
            {
                
            }
            else if (activePage is AddPage)
            {
                (activePage as AddPage).MyTypeChoice = typeIndex;
            }
            else if (activePage is TilePage)
            {
                
            }
            Refresh();
        }

        private void Button_All_Click(object sender, RoutedEventArgs e)
        {
            TypeChoice(0);
        }

        private void Button_Book_Click(object sender, RoutedEventArgs e)
        {
            TypeChoice(1);
        }

        private void Button_WebNovel_Click(object sender, RoutedEventArgs e)
        {
            TypeChoice(2);
        }

        private void Button_Movies_Click(object sender, RoutedEventArgs e)
        {
            TypeChoice(3);
        }

        private void Button_Shows_Click(object sender, RoutedEventArgs e)
        {
            TypeChoice(4);
        }

        private void Button_Anime_Click(object sender, RoutedEventArgs e)
        {
            TypeChoice(5);
        }

        private void Button_Anime_Movies_Click(object sender, RoutedEventArgs e)
        {
            TypeChoice(6);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
           
        }
    }
}
