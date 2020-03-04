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
		public bool TestTitle(string type, string title)
		{
			if (title != "")
			{
				foreach (var item in this)
				{
					if (item.MyType == type && item.MyTitle == title)
					{
						return false;
					}
				}
			}
			return true;
		}

		public bool TestAuthor(string author)
		{
			return true;
		}

		public bool TestStudio(string studio)
		{
			return true;
		}

		public bool TestRewatches()
		{
			return true;
		}

		public bool TestRating(string rating)
		{
			int newRating;

			if (int.TryParse(rating, out newRating))
			{
				return true;
			}
			return false;
		}

		public bool TestProgress(string progress)
		{
			return true;
		}

		public bool TestPercentage(string progress)
		{
			int newProgress;

			if (int.TryParse(progress, out newProgress))
			{
				return true;
			}
			return false;
		}

		public bool TestImage()
		{
			return true;
		}

		public bool TesReleaseDate()
		{
			return true;
		}

		public bool TestFirstDate(string date)
		{
			DateTime newDate;

			if (DateTime.TryParse(date, out newDate))
			{
				return true;
			}
			return false;
		}

		public bool TestWatchDate()
		{
			return true;
		}
	}
}
