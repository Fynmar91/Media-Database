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
		public bool IsUnique(string type, string title, bool hasSeasons, int season)
		{
			if (title != "")
			{
				foreach (var item in this)
				{
					if (item.MyType.MyValue == type && item.MyTitle.MyValue == title)
					{
						if (hasSeasons && item.MyTitle.MySeason == season)
						{
							return false;
						}
						else
						{
							return true;
						}						
					}
				}
				return true;
			}
			else
			{
				return true;
			}
		}		
	}
}
