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
    /// Interaction logic for ListView.xaml
    /// </summary>
    public partial class ListView : UserControl
    {
        public ListView(MediaList mediaList)
        {
            InitializeComponent();
            List_Media.ItemsSource = mediaList;
            Refresh();
        }
        public void Refresh()
        {
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
