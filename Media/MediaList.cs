using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaClass
{
    [Serializable]
    public class MediaList : List<Media>
    {
		//public void TestedAdd()
		//{
		//	Media media = new Media();

		//	media.MyType = comboBox_MediaChoice.SelectedValue.ToString();

		//	media.MyTitle = myTitle_in.Text;

		//	media.MyIsStarted = myIsStarted_in.IsChecked.Value;
		//	media.MyIsFinished = myIsFinished_in.IsChecked.Value;

		//	media.MyAuthor = myAuthor_in.Text;

		//	media.MyStudio = myStudio_in.Text;

		//	if (rating_switch.IsChecked == true)
		//	{
		//		media.MyRating = Convert.ToInt16(myRating_in.Value);
		//	}
		//	else
		//	{
		//		media.MyRating = -1;
		//	}

		//	media.MyProgressPercentage = Convert.ToInt16(myPercentageRead_in.Value);
		//	media.MyProgress = myProgress_in.Text;

		//	media.MyIsDropped = myIsDropped_in.IsChecked.Value;

		//	MainWindow.MyMainwindow.mediaList.Add(media);
		//}

		public bool TestTitle(string type, string title)
		{
			if (title != "")
			{
				foreach (var item in this)
				{
					if (item.MyType == type && item.MyTitle == title)
					{
						return true;
					}
				}
			}
			return false;
		}

		public bool TestAuthor()
		{
			return true;
		}

		public bool TestStudio()
		{
			return true;
		}
		public bool TestRewatches()
		{
			return true;
		}
		public bool TestRating()
		{
			return true;
		}
		public bool TestProgress()
		{
			return true;
		}
		public bool TestImage()
		{
			return true;
		}
		public bool TesReleaseDate()
		{
			return true;
		}
		public bool TestFirstDate()
		{
			return true;
		}
		public bool TestWatchDate()
		{
			return true;
		}


	}
}
