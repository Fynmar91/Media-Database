using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaClass
{
	public class MediaPropTitle : MediaProp
	{
		public string MyValue { get; set; }

		public MediaPropText MyType { get; set; }
		public MediaPropInt MySeason { get; set; }
		public bool MyHasSeasons { get; set; }

		public string MyName
		{
			get
			{
				if (MyHasSeasons)
				{
					return MyValue + MySeason.MyValue.ToString();
				}
				else
				{
					return MyValue;
				}
			}
		}

		public MediaPropTitle(string myValue, string myDescription, bool hasSeasons, int season) : base(myDescription)
		{
			MyValue = myValue;
			MyHasSeasons = hasSeasons;
			MyType = new MediaPropText("", "Typ:");
			MySeason = new MediaPropInt(season, "Staffel:");
		}

		public bool ValidateValue()
		{
			return true;
		}
	}
}
