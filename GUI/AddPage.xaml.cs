﻿using HelperClasses;
using MediaClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
		private List<InputField> inputFields = new List<InputField>(); 

		public AddPage()
		{
			InitializeComponent();
			comboBox_MediaChoice.ItemsSource = MainWindow.MyMainwindow.MyTypeString;
			Refresh();
		}

		public void Refresh()
		{
			comboBox_MediaChoice.SelectedIndex = MainWindow.MyMainwindow.MySelectedTypeIndex;

			ResetInput();

			switch (comboBox_MediaChoice.SelectedIndex)
			{
				case 1:
					SetInputBook();
					break;
				case 2:
					SetInputWebNovel();
					break;
				case 3:
					SetInputMovie();
					break;
				case 4:
					SetInputShow();
					break;
				case 5:
					SetInputAnime();
					break;
				case 6:
					SetInputAnimeMovie();
					break;
				default:
					break;
			}
			BuildUI();
		}

		//
		// Application Stuff
		//
		private void ComboBox_MediaChoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			MainWindow.MyMainwindow.SelectMediaType(comboBox_MediaChoice.SelectedIndex);
		}

		private void Button_Add_Click(object sender, RoutedEventArgs e)
		{
			AddMedia();
		}

		public bool CheckTitle(string title, bool hasSeasons, int season)
		{
			return MainWindow.MyMainwindow.MyMediaList.IsUnique(MainWindow.MyMainwindow.MyActiveTypeString, title, hasSeasons, season);
		}

		private void AddMedia()
		{
			// Error Stuff
			foreach (var item in inputFields)
			{
				if (!item.MyNoError)
				{
					return;
				}
			}

			// Set Propperties
			Media media = new Media();
			media.MyType.MyValue = MainWindow.MyMainwindow.MyActiveTypeString;

			foreach (var item in inputFields)
			{
				foreach (var prop in media.MyProperties)
				{
					if (item.MyMediaProp.MyDescription == prop.MyDescription)
					{
						if (prop is MediaPropTitle)
						{
							(prop as MediaPropTitle).MyValue = item.MyInput[0];
							(prop as MediaPropTitle).MySeason = int.Parse(item.MyInput[1]);
							break;
						}
						else if (prop is MediaPropText)
						{
							(prop as MediaPropText).MyValue = item.MyInput[0];
							break;
						}
						else if (prop is MediaPropInt)
						{
							(prop as MediaPropInt).MyValue = int.Parse(item.MyInput[0]);
							break;
						}
						else if (prop is MediaPropBool)
						{
							(prop as MediaPropBool).MyValue = bool.Parse(item.MyInput[0]);
							break;
						}
						else if (prop is MediaPropDate)
						{
							(prop as MediaPropDate).MyValue = item.MyInput[0];
							break;
						}
					}
				}				
			}

			// Download Image
			Downloader d = new Downloader();
			media.MyImageName.MyValue = d.GetImage(MainWindow.MyMainwindow.MySettings.MyImageFolder, media);

			MainWindow.MyMainwindow.MyMediaList.Add(media);
			Refresh();
		}		

		//
		// Media Type Selection Stuff
		//
		private void ResetInput()
		{
			inputStack.Children.Clear();
			inputFields.Clear();
		}

		private void BuildUI()
		{
			foreach (var item in inputFields)
			{
				inputStack.Children.Add(item);
			}
		}

		private void SetInputBook()
		{
			Media media = new Media();
			inputFields.Add(new InputField(media.MyTitle, this));
			inputFields.Add(new InputField(media.MyAuthor, this));
			inputFields.Add(new InputField(media.MyIsStarted, this));
			inputFields.Add(new InputField(media.MyIsFinished, this));
			inputFields.Add(new InputField(media.MyRating, this));
			inputFields.Add(new InputField(media.MyIsDropped, this));
			inputFields.Add(new InputField(media.MyProgress, this));
			inputFields.Add(new InputField(media.MyProgressPercentage, this));
			inputFields.Add(new InputField(media.MyReleaseDate, this));
			inputFields.Add(new InputField(media.MyFirstWatchDate, this));
		}

		private void SetInputWebNovel()
		{
			Media media = new Media();
			inputFields.Add(new InputField(media.MyTitle, this));
			inputFields.Add(new InputField(media.MyAuthor, this));
			inputFields.Add(new InputField(media.MyIsStarted, this));
			inputFields.Add(new InputField(media.MyIsFinished, this));
			inputFields.Add(new InputField(media.MyRating, this));
			inputFields.Add(new InputField(media.MyIsDropped, this));
			inputFields.Add(new InputField(media.MyProgress, this));
			inputFields.Add(new InputField(media.MyProgressPercentage, this));
			inputFields.Add(new InputField(media.MyReleaseDate, this));
			inputFields.Add(new InputField(media.MyFirstWatchDate, this));
		}

		private void SetInputMovie()
		{
			Media media = new Media();
			inputFields.Add(new InputField(media.MyTitle, this));
			inputFields.Add(new InputField(media.MyIsStarted, this));
			inputFields.Add(new InputField(media.MyIsFinished, this));
			inputFields.Add(new InputField(media.MyRating, this));
			inputFields.Add(new InputField(media.MyIsDropped, this));
			inputFields.Add(new InputField(media.MyProgress, this));
			inputFields.Add(new InputField(media.MyReleaseDate, this));
			inputFields.Add(new InputField(media.MyFirstWatchDate, this));
		}

		private void SetInputShow()
		{
			Media media = new Media();
			media.MyTitle.MyHasSeasons = true;
			inputFields.Add(new InputField(media.MyTitle, this));
			inputFields.Add(new InputField(media.MyIsStarted, this));
			inputFields.Add(new InputField(media.MyIsFinished, this));
			inputFields.Add(new InputField(media.MyRating, this));
			inputFields.Add(new InputField(media.MyIsDropped, this));
			inputFields.Add(new InputField(media.MyProgress, this));
			inputFields.Add(new InputField(media.MyReleaseDate, this));
			inputFields.Add(new InputField(media.MyFirstWatchDate, this));
		}

		private void SetInputAnime()
		{
			Media media = new Media();
			media.MyTitle.MyHasSeasons = true;
			inputFields.Add(new InputField(media.MyTitle, this));
			inputFields.Add(new InputField(media.MyStudio, this));
			inputFields.Add(new InputField(media.MyIsStarted, this));
			inputFields.Add(new InputField(media.MyIsFinished, this));
			inputFields.Add(new InputField(media.MyRating, this));
			inputFields.Add(new InputField(media.MyIsDropped, this));
			inputFields.Add(new InputField(media.MyProgress, this));
			inputFields.Add(new InputField(media.MyReleaseDate, this));
			inputFields.Add(new InputField(media.MyFirstWatchDate, this));
		}

		private void SetInputAnimeMovie()
		{
			Media media = new Media();
			inputFields.Add(new InputField(media.MyTitle, this));
			inputFields.Add(new InputField(media.MyStudio, this));
			inputFields.Add(new InputField(media.MyIsStarted, this));
			inputFields.Add(new InputField(media.MyIsFinished, this));
			inputFields.Add(new InputField(media.MyRating, this));
			inputFields.Add(new InputField(media.MyIsDropped, this));
			inputFields.Add(new InputField(media.MyProgress, this));
			inputFields.Add(new InputField(media.MyReleaseDate, this));
			inputFields.Add(new InputField(media.MyFirstWatchDate, this));
		}
	}
}
