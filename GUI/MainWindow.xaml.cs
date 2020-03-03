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



        private void Button_All_Click(object sender, RoutedEventArgs e)
        {
            typeIndex = 0;
            if (activePage is ListPage)
            {
                displayList = mediaList;
            }
            else if (activePage is AddPage)
            {
                (activePage as AddPage).MyMediaChoice = typeIndex;
            }
            else if (activePage is TilePage)
            {
                (activePage as TilePage).Refresh();
            }
            Refresh();
        }

        private void Button_Book_Click(object sender, RoutedEventArgs e)
        {
            typeIndex = 1;
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
                (activePage as AddPage).MyMediaChoice = typeIndex;
            }
            else if (activePage is TilePage)
            {
                (activePage as TilePage).Refresh();
            }
            Refresh();
        }

        private void Button_WebNovel_Click(object sender, RoutedEventArgs e)
        {
            typeIndex = 2;
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
                (activePage as AddPage).MyMediaChoice = typeIndex;
            }
            else if (activePage is TilePage)
            {
                (activePage as TilePage).Refresh();
            }
            Refresh();
        }

        private void Button_Movies_Click(object sender, RoutedEventArgs e)
        {
            typeIndex = 3;
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
                (activePage as AddPage).MyMediaChoice = typeIndex;
            }
            else if (activePage is TilePage)
            {
                (activePage as TilePage).Refresh();
            }
            Refresh();
        }

        private void Button_Shows_Click(object sender, RoutedEventArgs e)
        {
            typeIndex = 4;
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
                (activePage as AddPage).MyMediaChoice = typeIndex;
            }
            else if (activePage is TilePage)
            {
                (activePage as TilePage).Refresh();
            }
            Refresh();
        }

        private void Button_Anime_Click(object sender, RoutedEventArgs e)
        {
            typeIndex = 5;
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
                (activePage as AddPage).MyMediaChoice = typeIndex;
            }
            else if (activePage is TilePage)
            {
                (activePage as TilePage).Refresh();
            }
            Refresh();
        }

        private void Button_Anime_Movies_Click(object sender, RoutedEventArgs e)
        {
            typeIndex = 6;
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
                (activePage as AddPage).MyMediaChoice = typeIndex;
            }
            else if (activePage is TilePage)
            {
                (activePage as TilePage).Refresh();
            }
            Refresh();
        }
    }
}
