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
		public bool Title(string type, string title)
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

		public bool Progress(string progress)
		{
			return true;
		}		

		public bool TestImage()
		{
			return true;
		}

		public bool ReleaseDate(string date)
		{
			DateTime newDate;

			if (DateTime.TryParse(date, out newDate))
			{
				return true;
			}
			return false;
		}

		public bool FirstWatchDate(string date)
		{
			DateTime newDate;

			if (DateTime.TryParse(date, out newDate))
			{
				return true;
			}
			return false;
		}

		public bool LastWatchDate(string date)
		{
			DateTime newDate;

			if (DateTime.TryParse(date, out newDate))
			{
				return true;
			}
			return false;
		}
	}
}
