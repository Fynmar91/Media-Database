using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaClass
{
	public abstract class MediaProp
	{
		protected MediaProp(string myDescription)
		{
			MyDescription = myDescription;
		}

		public string MyDescription { get; set; }
	}
}
