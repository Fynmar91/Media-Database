using MediaClass;
using HelperClasses;
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

		private int selectedTypeIndex;
		public int MySelectedTypeIndex
		{
			get { return selectedTypeIndex; }
			set
			{
				selectedTypeIndex = value;
				if (activePage != null)
				{
					(activePage as PageInterface).Refresh();
				}
			}
		}

		private string[] typeString = { "", "Buch", "Web-Novel", "Film", "Serie", "Anime", "Anime-Film" };
		public string[] MyTypeString { get => typeString; set => typeString = value; }
		public string MyActiveTypeString { get => typeString[MySelectedTypeIndex];  }


		private List<Button> selectButtons;
		private List<Button> pageButtons;

		public Settings MySettings { get; set; }
		public MediaList MyMediaList { get; set; }
		private JSONSerializer json = new JSONSerializer();
		private Page activePage;

		private ListPage listPage;
		private TilePage tilePage;
		private AddPage addPage;

		public MainWindow()
		{
			MyMainwindow = this;
			InitializeComponent();
			LoadSettings();
			Load();
			MySelectedTypeIndex = 0;
			tilePage = new TilePage();
			addPage = new AddPage();
			activePage = tilePage;
			PageView.Content = activePage;
			SetSelectButtonColor(0);
			SetPageButtonColor(0);
			Refresh();
		}

		public void Refresh()
		{
			if (activePage != null)
			{
				(activePage as PageInterface).Refresh();
			}
		}

		//
		// Page Stuff
		//
		private void Button_Tile_Click(object sender, RoutedEventArgs e)
		{
			activePage = tilePage;
			PageView.Content = activePage;
			SetPageButtonColor(0);
		}

		private void Button_List_Click(object sender, RoutedEventArgs e)
		{
			listPage = new ListPage();
			activePage = listPage;
			PageView.Content = activePage;
			SetPageButtonColor(1);
		}

		private void Button_Add_Click(object sender, RoutedEventArgs e)
		{
			activePage = addPage;
			PageView.Content = activePage;
			SetPageButtonColor(2);
		}

		public void OpenDisplayPage(Media m)
		{
			activePage = new DisplayPage(m);
			PageView.Content = activePage;
			SetPageButtonColor(3);
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
			Refresh();
		}

		//
		// Type Selection Stuff
		//
		private void Button_All_Click(object sender, RoutedEventArgs e)
		{
			SelectMediaType(0);
		}

		private void Button_Book_Click(object sender, RoutedEventArgs e)
		{
			SelectMediaType(1);
		}

		private void Button_WebNovel_Click(object sender, RoutedEventArgs e)
		{
			SelectMediaType(2);
		}

		private void Button_Movies_Click(object sender, RoutedEventArgs e)
		{
			SelectMediaType(3);
		}

		private void Button_Shows_Click(object sender, RoutedEventArgs e)
		{
			SelectMediaType(4);
		}

		private void Button_Anime_Click(object sender, RoutedEventArgs e)
		{
			SelectMediaType(5);
		}

		private void Button_Anime_Movies_Click(object sender, RoutedEventArgs e)
		{
			SelectMediaType(6);
		}
		public void SelectMediaType(int i)
		{
			MySelectedTypeIndex = i;

			switch (i)
			{
				case 1:
					SetSelectButtonColor(1);
					break;
				case 2:
					SetSelectButtonColor(2);
					break;
				case 3:
					SetSelectButtonColor(3);
					break;
				case 4:
					SetSelectButtonColor(4);
					break;
				case 5:
					SetSelectButtonColor(5);
					break;
				case 6:
					SetSelectButtonColor(6);
					break;
				default:
					SetSelectButtonColor(0);
					break;
			}
			Refresh();
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
		private void LoadSettings()
		{
			MySettings = json.DeserializeSettings();
		}

		private void Load()
		{
			MyMediaList = json.Deserialize(MySettings);
			MyMediaList.Sort((x, y) => y.MyTitle.CompareTo(x.MyTitle));
		}		

		private void Button_Save_Click(object sender, RoutedEventArgs e)
		{
			json.Serialize(MyMediaList, MySettings);
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
			json.SerializeSettings(MySettings);
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

		private void Button_Options_Click(object sender, RoutedEventArgs e)
		{
			MySettings.GetFolder();
		}

		private void Button_Load_Click(object sender, RoutedEventArgs e)
		{
			Load();
			Refresh();
		}
	}
}
