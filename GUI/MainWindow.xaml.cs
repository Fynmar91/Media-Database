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

		private List<Button> buttons;

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
			SetButtonColor(0);
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
			if (addPage != null)
			{
				addPage.Refresh();
			}
			listPage.Refresh();
			tilePage.Refresh();
			addPage.Refresh();
		}

		private void Load()
		{
			mediaList = json.Deserialize();
			mediaList.Sort((x, y) => y.MyTitle.CompareTo(x.MyTitle));
		}

		private void Button_List_Click(object sender, RoutedEventArgs e)
		{
			activePage = listPage;
			PageView.Content = activePage;
		}

		private void Button_Tile_Click(object sender, RoutedEventArgs e)
		{
			activePage = tilePage;
			PageView.Content = activePage;
		}

		public void OpenDisplayPage(Media m)
		{
			activePage = new DisplayPage(m);
			PageView.Content = activePage;
		}

		private void Button_Add_Click(object sender, RoutedEventArgs e)
		{
			activePage = addPage;
			PageView.Content = activePage;
		}

		private void Button_Save_Click(object sender, RoutedEventArgs e)
		{
			json.Serialize(mediaList);
		}

		private void TypeChoice(int i)
		{
			MyTypeIndex = i;

			addPage.MyTypeChoice = MyTypeIndex;

			Refresh();
		}

		private void Button_All_Click(object sender, RoutedEventArgs e)
		{
			TypeChoice(0);
			SetButtonColor(0);
		}

		private void Button_Book_Click(object sender, RoutedEventArgs e)
		{
			TypeChoice(1);
			SetButtonColor(1);
		}

		private void Button_WebNovel_Click(object sender, RoutedEventArgs e)
		{
			TypeChoice(2);
			SetButtonColor(2);
		}

		private void Button_Movies_Click(object sender, RoutedEventArgs e)
		{
			TypeChoice(3);
			SetButtonColor(3);
		}

		private void Button_Shows_Click(object sender, RoutedEventArgs e)
		{
			TypeChoice(4);
			SetButtonColor(4);
		}

		private void Button_Anime_Click(object sender, RoutedEventArgs e)
		{
			TypeChoice(5);
			SetButtonColor(5);
		}

		private void Button_Anime_Movies_Click(object sender, RoutedEventArgs e)
		{
			TypeChoice(6);
			SetButtonColor(6);
		}

		public void SetButtonColor(int i)
		{
			if (buttons == null)
			{
				buttons = new List<Button>();
				buttons.Add(Button_All);
				buttons.Add(Button_Book);
				buttons.Add(Button_WebNovel);
				buttons.Add(Button_Movies);
				buttons.Add(Button_Shows);
				buttons.Add(Button_Anime);
				buttons.Add(Button_Anime_Movies);
			}

			foreach (var item in buttons)
			{
				item.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xBA, 0xBA, 0xBA));
			}
			buttons[i].Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x16, 0xDA, 0xF9));
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
