using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaClass
{
	public class MediaPropDate : MediaProp
	{
		public string MyValue { get; set; }
		public bool MyIsShort { get; set; }

		public MediaPropDate(string myValue, string myDescription, bool isShort) : base(myDescription)
		{
			MyValue = myValue;
			MyIsShort = isShort;
		}

		public bool ValidateValue(string date)
		{
			DateTime newDate;

			if (MyIsShort)
			{
				if (DateTime.TryParse(date + "-01-01", out newDate) && date.Length == 4)
				{
					return true;
				}
			}
			else
			{
				if (DateTime.TryParse(date, out newDate))
				{
					return true;
				}
			}

			if (date == "")
			{
				return true;
			}

			return false;
		}
	}
}
