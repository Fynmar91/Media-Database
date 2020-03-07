using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MediaClass
{
	[Serializable]
	public class MediaList : List<Media>
	{
		public bool MyTitle(string type, string title)
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

		public bool MyAuthor(string type, string author)
		{
			return true;
		}

		public bool MyStudio(string type, string studio)
		{
			return true;
		}

		public bool MyProgress(string type, string progress)
		{
			return true;
		}		

		public bool MyImageName(string type, string image)
		{
			return true;
		}

		public bool MyReleaseDate(string type, string date)
		{
			DateTime newDate;

			if (DateTime.TryParse(date + "-01-01", out newDate) && date.Length == 4)
			{
				return true;
			}
			else if (date == "")
			{
				return true;
			}
			return false;
		}

		public bool MyFirstWatchDate(string type, string date)
		{
			DateTime newDate;

			if (DateTime.TryParse(date, out newDate))
			{
				return true;
			}
			else if (date == "")
			{
				return true;
			}
			return false;
		}

		public bool MyLastWatchDate(string type, string date)
		{
			DateTime newDate;

			if (DateTime.TryParse(date, out newDate))
			{
				return true;
			}
			else if (date == "")
			{
				return true;
			}
			return false;
		}
	}
}
