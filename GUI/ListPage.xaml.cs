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
	/// Interaction logic for ListPage.xaml
	/// </summary>
	public partial class ListPage : Page, IPage
	{
		public MediaList displayList;

		public ListPage()
		{
			InitializeComponent();
			Refresh();
		}

		public void EnableInput()
		{
			throw new NotImplementedException();
		}

		public void Refresh()
		{
			displayList = new MediaList();

			string filter = MainWindow.MyMainwindow.MyTypeString[MainWindow.MyMainwindow.MySelectedTypeIndex];

			foreach (var item in MainWindow.MyMainwindow.MyMediaList)
			{
				if (filter == "" || item.MyType.MyValue == filter)
				{
					displayList.Add(item);
				}
			}

			List_Media.ItemsSource = displayList;
			List_Media.Items.Refresh();
		}

		private void List_Media_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			if (sender is ListView && (sender as ListView).SelectedItem != null)
			{
				MainWindow.MyMainwindow.OpenDisplayPage((sender as ListView).SelectedItem as Media);
			}
		}
	}
}
