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
		public bool MyHasSeasons { get; set; }
		public int MySeason { get; set; }

		public MediaPropTitle(string myValue, string myDescription, bool hasSeasons, int season) : base(myDescription)
		{
			MyValue = myValue;
			MyHasSeasons = hasSeasons;
			MySeason = season;
		}

		public bool ValidateValue()
		{
			return true;
		}
	}
}
