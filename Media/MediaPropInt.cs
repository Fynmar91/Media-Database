using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaClass
{
	public class MediaPropInt : MediaProp
	{
		public int MyValue { get; set; }

		public MediaPropInt(int myValue, string myDescription) : base(myDescription)
		{
			MyValue = myValue;
		}

		public bool ValidateValue()
		{
			return true;
		}
	}
}
