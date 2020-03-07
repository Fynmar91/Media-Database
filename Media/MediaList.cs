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
		public bool CheckForDuplicates(string type, string title)
		{
			if (title != "")
			{
				foreach (var item in this)
				{
					if (item.MyType.MyValue == type && item.MyTitle.MyValue == title)
					{
						if (true)
						{

						}
						return false;
					}
				}
			}
			else
			{
				return false;
			}

			return true;
		}		
	}
}
