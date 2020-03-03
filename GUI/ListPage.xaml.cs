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
    /// Interaction logic for ListPage.xaml
    /// </summary>
    public partial class ListPage : Page, PageInterface
    {
        public MediaList displayList;

        public ListPage()
        {
            InitializeComponent();            
            Refresh();
        }
        public void Refresh()
        {
            displayList = new MediaList();

            string filter = MainWindow.MyMainwindow.typeString[MainWindow.MyMainwindow.typeIndex];

            foreach (var item in MainWindow.MyMainwindow.mediaList)
            {
                if (filter == "" || item.MyType == filter)
                {
                    displayList.Add(item);
                }
            }

            List_Media.ItemsSource = displayList;
            List_Media.Items.Refresh();
        }

        private void List_Media_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void List_Media_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
