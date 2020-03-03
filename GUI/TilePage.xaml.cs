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
using System.IO;
using MediaClass;

namespace GUI
{
    /// <summary>
    /// Interaction logic for TilePage.xaml
    /// </summary>
    public partial class TilePage : Page, PageInterface
    {
        public MediaList displayList;

        public List<Tile> tiles = new List<Tile>();

        public TilePage()
        {
            InitializeComponent();
            Refresh();
        }

        public void Refresh()
        {
            displayList = new MediaList();

            string filter = MainWindow.MyMainwindow.typeString[MainWindow.MyMainwindow.typeIndex];

            if (filter != null)
            {
                stack1.Children.Clear();
                stack2.Children.Clear();
                tiles.Clear();
            }

            foreach (var item in MainWindow.MyMainwindow.mediaList)
            {
                if (filter == "" || item.MyType == filter)
                {
                    Frame frame = new Frame { };
                    Tile tile = new Tile { };
                    frame.Content = tile;

                    tiles.Add(tile);
                    displayList.Add(item);

                    if (stack1.Children.Count <= stack2.Children.Count)
                    {                        
                        stack1.Children.Add(frame);
                    }
                    else
                    {
                        stack2.Children.Add(frame);
                    }

                    tile.title.Text = item.MyTitle;
                }
            }
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scrollViewer = (ScrollViewer)sender;
            if (e.Delta < 0)
            {
                scrollViewer.LineRight();
                scrollViewer.LineRight();
                scrollViewer.LineRight();
                scrollViewer.LineRight();
            }
            else
            {
                scrollViewer.LineLeft();
                scrollViewer.LineLeft();
                scrollViewer.LineLeft();
                scrollViewer.LineLeft();
            }
            e.Handled = true;
        }
    }
}
