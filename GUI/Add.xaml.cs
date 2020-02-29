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
using System.Windows.Shapes;
using MediaClass;

namespace GUI
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        MediaList list;
        MainWindow main;

        public Add(MediaList list, MainWindow main)
        {
            this.list = list;
            this.main = main;
            InitializeComponent();
            Grid_Title.Visibility = Visibility.Hidden;
            Grid_Author.Visibility = Visibility.Hidden;
        }

        public void Refresh()
        {
            Grid_Title.Visibility = Visibility.Hidden;
            Grid_Author.Visibility = Visibility.Hidden;
            Input_Title.Clear();
            Input_Author.Clear();
            main.Refresh();
        }

        private void Book_Click(object sender, RoutedEventArgs e)
        {
            Text_Title.Text = "Titel";
            Text_Author.Text = "Autor";
            Grid_Title.Visibility = Visibility.Visible;
            Grid_Author.Visibility = Visibility.Visible;
            result.Text = "";
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            bool contains = false;

            foreach (var item in list)
            {
                if (item.MyTitle == Input_Title.Text.ToString())
                {
                    contains = true;
                    break;
                }               
            }

            if (contains)
            {
                result.Text = "Gibt es schon";
            }
            else
            {
                result.Text = "Erfolgreich hinzugefügt";

                Book b = new Book
                {
                    MyTitle = Input_Title.Text.ToString(),
                    MyAuthor = Input_Author.Text.ToString()
                };
                list.Add(b);
            }

            Refresh();
        }
    }
}
