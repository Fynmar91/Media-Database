using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaClass
{
	public class MediaPropBool : MediaProp
	{
		public bool MyValue { get; set; }

		public MediaPropBool(bool myValue, string myDescription) : base(myDescription)
		{
			MyValue = myValue;
		}

		public bool ValidateValue()
		{
			return true;
		}
	}
}
