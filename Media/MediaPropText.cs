using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaClass
{
	public class MediaPropText : MediaProp
	{
		public string MyValue { get; set; }

		public MediaPropText(string myValue, string myDescription) : base(myDescription)
		{
			MyValue = myValue;
		}

		public bool ValidateValue()
		{
			return true;
		}
	}
}
