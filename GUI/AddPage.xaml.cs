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
using MediaClass;

namespace GUI
{
    /// <summary>
    /// Interaction logic for AddPage.xaml
    /// </summary>
    public partial class AddPage : Page, PageInterface
    {
        public AddPage()
        {
            InitializeComponent();
            Refresh();
        }

        private void AddMedia<T>()
        {
            if (typeof(T) == typeof(Book))
            {
                Book media = new Book(Box_myAuthor.Text.ToString(), Box_myTitle.Text.ToString(), checkBox_myIsWatched.IsChecked.Value, Date_myReleaseDate.SelectedDate.Value);
                MainWindow.MyMainwindow.mediaList.Add(media);
            }            
        }

        public void Refresh()
        {
            
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            AddMedia<Book>();
        }
    }
}
