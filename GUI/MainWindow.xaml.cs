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

		public int MyTypeIndex { get; set; }

		public string[] typeString = { "", "Buch", "Web-Novel", "Film", "Serie", "Anime", "Anime-Film" };

		private List<Button> selectButtons;
		private List<Button> pageButtons;

		public MediaList mediaList = new MediaList();
		private JSONSerializer json = new JSONSerializer();
		private Page activePage;

		private ListPage listPage;
		private TilePage tilePage;
		private AddPage addPage;

		public MainWindow()
		{
			MyMainwindow = this;
			InitializeComponent();
			Load();
			SetSelectButtonColor(0);
			SetPageButtonColor(0);
			MyTypeIndex = 0;
			listPage = new ListPage();
			tilePage = new TilePage();
			addPage = new AddPage();
			activePage = tilePage;
			PageView.Content = activePage;
			Refresh();
		}

		public void Refresh()
		{
			if (activePage is DisplayPage)
			{
				(activePage as DisplayPage).Refresh();
			}
			listPage.Refresh();
			tilePage.Refresh();
			addPage.Refresh();
		}

		//
		// Page Stuff
		//
		private void Button_Tile_Click(object sender, RoutedEventArgs e)
		{
			activePage = tilePage;
			PageView.Content = activePage;
			SetPageButtonColor(0);
			Refresh();
		}

		private void Button_List_Click(object sender, RoutedEventArgs e)
		{
			activePage = listPage;
			PageView.Content = activePage;
			SetPageButtonColor(1);
			Refresh();
		}

		private void Button_Add_Click(object sender, RoutedEventArgs e)
		{
			activePage = addPage;
			PageView.Content = activePage;
			SetPageButtonColor(2);
			Refresh();
		}

		public void OpenDisplayPage(Media m)
		{
			activePage = new DisplayPage(m);
			PageView.Content = activePage;
			SetPageButtonColor(3);
			Refresh();
		}
		public void SetPageButtonColor(int i)
		{
			if (pageButtons == null)
			{
				pageButtons = new List<Button>();
				pageButtons.Add(Button_Tile);
				pageButtons.Add(Button_List);
				pageButtons.Add(Button_Add);
			}

			foreach (var item in pageButtons)
			{
				item.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xBA, 0xBA, 0xBA));
			}
			if (i < pageButtons.Count)
			{
				pageButtons[i].Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x16, 0xDA, 0xF9));
			}
		}		
		
		//
		// Type Selection Stuff
		//
		private void Button_All_Click(object sender, RoutedEventArgs e)
		{
			SelecteMediaType(0);
			SetSelectButtonColor(0);
			Refresh();
		}

		private void Button_Book_Click(object sender, RoutedEventArgs e)
		{
			SelecteMediaType(1);
			SetSelectButtonColor(1);
			Refresh();
		}

		private void Button_WebNovel_Click(object sender, RoutedEventArgs e)
		{
			SelecteMediaType(2);
			SetSelectButtonColor(2);
			Refresh();
		}

		private void Button_Movies_Click(object sender, RoutedEventArgs e)
		{
			SelecteMediaType(3);
			SetSelectButtonColor(3);
			Refresh();
		}

		private void Button_Shows_Click(object sender, RoutedEventArgs e)
		{
			SelecteMediaType(4);
			SetSelectButtonColor(4);
			Refresh();
		}

		private void Button_Anime_Click(object sender, RoutedEventArgs e)
		{
			SelecteMediaType(5);
			SetSelectButtonColor(5);
			Refresh();
		}

		private void Button_Anime_Movies_Click(object sender, RoutedEventArgs e)
		{
			SelecteMediaType(6);
			SetSelectButtonColor(6);
			Refresh();
		}
		private void SelecteMediaType(int i)
		{
			MyTypeIndex = i;

			addPage.MyTypeChoice = MyTypeIndex;
		}

		public void SetSelectButtonColor(int i)
		{
			if (selectButtons == null)
			{
				selectButtons = new List<Button>();
				selectButtons.Add(Button_All);
				selectButtons.Add(Button_Book);
				selectButtons.Add(Button_WebNovel);
				selectButtons.Add(Button_Movies);
				selectButtons.Add(Button_Shows);
				selectButtons.Add(Button_Anime);
				selectButtons.Add(Button_Anime_Movies);
			}

			foreach (var item in selectButtons)
			{
				item.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xBA, 0xBA, 0xBA));
			}
			selectButtons[i].Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x16, 0xDA, 0xF9));
		}


		//
		// Application Stuff
		//
		private void Load()
		{
			mediaList = json.Deserialize();
			mediaList.Sort((x, y) => y.MyTitle.CompareTo(x.MyTitle));
		}

		private void Button_Save_Click(object sender, RoutedEventArgs e)
		{
			json.Serialize(mediaList);
		}


		private void Window_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ChangedButton == MouseButton.Left)
			{
				this.DragMove();
			}
		}

		private void Button_Close_Click(object sender, RoutedEventArgs e)
		{
			System.Windows.Application.Current.Shutdown();
		}

		private void Button_Full_Click(object sender, RoutedEventArgs e)
		{
			if (this.WindowState != WindowState.Maximized)
			{
				this.WindowState = WindowState.Maximized;
			}
			else
			{
				this.WindowState = WindowState.Normal;
			}
		}
	}
}
