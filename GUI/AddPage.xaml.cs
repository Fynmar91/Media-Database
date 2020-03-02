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
    /// Interaction logic for AddPage.xaml
    /// </summary>
    public partial class AddPage : Page, PageInterface
    {
        string[] mediaChoices = { "", "Buch", "Web Novel", "Film", "Serie", "Anime", "Anime-Film" };

        public AddPage()
        {
            InitializeComponent();
            comboBox_MediaChoice.ItemsSource = mediaChoices;
            comboBox_MediaChoice.SelectedIndex = 0;
            Refresh();
        }

        public void Refresh()
        {
            Box_myTitle.Text = "";
            Box_myAuthor.Text = "";
            Box_myRating.Text = "";
            comboBox_MediaChoice.SelectedIndex = 0;
        }

        private void AddMedia()
        {
            Media media = new Media();

            if (comboBox_MediaChoice.SelectedIndex != 0)
            {
                media.MyType = comboBox_MediaChoice.SelectedValue.ToString();
            }

            if (Box_myTitle.Text.ToString() != "")
            {
                media.MyTitle = Box_myTitle.Text.ToString();
            }

            if (Box_myAuthor.Text.ToString() != "")
            {
                media.MyAuthor = Box_myAuthor.Text.ToString();
            }

            media.MyIsWatched = checkBox_myIsWatched.IsChecked.Value;

            if (Box_myRating.Text.ToString() != "")
            {
                media.MyRating = Box_myRating.Text.ToString();
            }

            if (Date_myReleaseDate.SelectedDate != null)
            {
                media.MyReleaseDate = Date_myReleaseDate.SelectedDate.Value;
            }

            if (Date_myFirstWatchDate.SelectedDate != null)
            {
                media.MyFirstWatchDate = Date_myFirstWatchDate.SelectedDate.Value;
                media.MyLastWatchDate = Date_myFirstWatchDate.SelectedDate.Value;
            }

            MainWindow.MyMainwindow.mediaList.Add(media);
        }

        private bool CheckMedia()
        {
            bool passed = true;

            if (Box_myTitle.Text.ToString() != "" && comboBox_MediaChoice.SelectedIndex != 0)
            {
                foreach (var item in MainWindow.MyMainwindow.mediaList)
                {
                    if (item.MyType == comboBox_MediaChoice.SelectedValue.ToString() && item.MyTitle == Box_myTitle.Text.ToString())
                    {
                        passed = false;
                        break;
                    }
                }

            }
            else
            {
                passed = false;
            }

            if (passed)
            {
                Box_myTitle.Background = Brushes.Green;
                return true;
            }
            else
            {
                Box_myTitle.Background = Brushes.Red;
                return false;
            }
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            if (CheckMedia())
            {
                AddMedia();
                Refresh();
            }
        }

        private void Button_Check_Click(object sender, RoutedEventArgs e)
        {
            CheckMedia();
        }
    }
}
