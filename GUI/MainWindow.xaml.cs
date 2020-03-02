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

        public MediaList mediaList = new MediaList();
        public MediaList displayList;
        private JSONSerializer json = new JSONSerializer();
        private Page activePage;

        public MainWindow()
        {
            MyMainwindow = this;
            InitializeComponent();
            Load();
            displayList = mediaList;
            Refresh();
        }

        public void Refresh()
        {
            if (activePage is ListPage && ListPage.MyListPage != null)
            {
                ListPage.MyListPage.Refresh();
            }
            else if (activePage is AddPage && AddPage.MyAddPage != null)
            {
                AddPage.MyAddPage.Refresh();
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



        private void Button_All_Click(object sender, RoutedEventArgs e)
        {
            if (activePage is ListPage)
            {
                displayList = mediaList;
            }
            else if (activePage is AddPage)
            {
                (activePage as AddPage).MyMediaChoice = 0;
            }
            Refresh();
        }

        private void Button_Book_Click(object sender, RoutedEventArgs e)
        {
            if (activePage is ListPage)
            {
                displayList = new MediaList();

                foreach (var item in mediaList)
                {
                    if (item.MyType == "Buch")
                    {
                        displayList.Add(item);
                    }
                }
            }
            else if (activePage is AddPage)
            {
                (activePage as AddPage).MyMediaChoice = 1;
            }
            Refresh();
        }

        private void Button_WebNovel_Click(object sender, RoutedEventArgs e)
        {
            if (activePage is ListPage)
            {
                displayList = new MediaList();

                foreach (var item in mediaList)
                {
                    if (item.MyType == "Web-Novel")
                    {
                        displayList.Add(item);
                    }
                }
            }
            else if (activePage is AddPage)
            {
                (activePage as AddPage).MyMediaChoice = 2;
            }
            Refresh();
        }

        private void Button_Movies_Click(object sender, RoutedEventArgs e)
        {
            if (activePage is ListPage)
            {
                displayList = new MediaList();

                foreach (var item in mediaList)
                {
                    if (item.MyType == "Film")
                    {
                        displayList.Add(item);
                    }
                }
            }
            else if (activePage is AddPage)
            {
                (activePage as AddPage).MyMediaChoice = 3;
            }
            Refresh();
        }

        private void Button_Shows_Click(object sender, RoutedEventArgs e)
        {
            if (activePage is ListPage)
            {
                displayList = new MediaList();

                foreach (var item in mediaList)
                {
                    if (item.MyType == "Serie")
                    {
                        displayList.Add(item);
                    }
                }
            }
            else if (activePage is AddPage)
            {
                (activePage as AddPage).MyMediaChoice = 4;
            }
            Refresh();
        }

        private void Button_Anime_Click(object sender, RoutedEventArgs e)
        {
            if (activePage is ListPage)
            {
                displayList = new MediaList();

                foreach (var item in mediaList)
                {
                    if (item.MyType == "Anime")
                    {
                        displayList.Add(item);
                    }
                }
            }
            else if (activePage is AddPage)
            {
                (activePage as AddPage).MyMediaChoice = 5;
            }
            Refresh();
        }

        private void Button_Anime_Movies_Click(object sender, RoutedEventArgs e)
        {
            if (activePage is ListPage)
            {
                displayList = new MediaList();

                foreach (var item in mediaList)
                {
                    if (item.MyType == "Anime-Film")
                    {
                        displayList.Add(item);
                    }
                }
            }
            else if (activePage is AddPage)
            {
                (activePage as AddPage).MyMediaChoice = 6;
            }
            Refresh();
        }
    }
}
