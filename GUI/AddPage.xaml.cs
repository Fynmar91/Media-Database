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
        string[] mediaChoices = { "", "Buch", "Web-Novel", "Film", "Serie", "Anime", "Anime-Film" };

        public int MyMediaChoice
        {
            get { return comboBox_MediaChoice.SelectedIndex; }
            set { comboBox_MediaChoice.SelectedIndex = value; }
        }


        public AddPage()
        {
            InitializeComponent();
            comboBox_MediaChoice.ItemsSource = mediaChoices;
            comboBox_MediaChoice.SelectedIndex = 0;
            Refresh();
        }

        public void Refresh()
        {
            myTitle_in.Text = "";
            myAuthor_in.Text = "";
            myRating_in.Value = 0;
            comboBox_MediaChoice.SelectedIndex = 0;
        }

        private void AddMedia()
        {
            Media media = new Media();

            if (comboBox_MediaChoice.SelectedIndex != 0)
            {
                media.MyType = comboBox_MediaChoice.SelectedValue.ToString();
            }

            if (myTitle_in.Text.ToString() != "")
            {
                media.MyTitle = myTitle_in.Text.ToString();
            }

            if (myAuthor_in.Text.ToString() != "")
            {
                media.MyAuthor = myAuthor_in.Text.ToString();
            }

            if (myRating_in.Value != 0)
            {
                media.MyRating = myRating_in.Value.ToString();
            }

            MainWindow.MyMainwindow.mediaList.Add(media);
        }

        private bool CheckMedia()
        {
            bool passed = true;

            if (myTitle_in.Text.ToString() != "" && comboBox_MediaChoice.SelectedIndex != 0)
            {
                foreach (var item in MainWindow.MyMainwindow.mediaList)
                {
                    if (item.MyType == comboBox_MediaChoice.SelectedValue.ToString() && item.MyTitle == myTitle_in.Text.ToString())
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
                myTitle_in.Background = Brushes.Green;
                return true;
            }
            else
            {
                myTitle_in.Background = Brushes.Red;
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
