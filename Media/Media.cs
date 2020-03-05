using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaClass
{
	public class Media
	{
		private string _myType;
		private string _myTitle;
		private string _myAuthor;
		private string _myStudio;
		private bool _myIsStarted;
		private bool _myIsFinished;
		private int _myTotalRewatches;
		private int _myRating;
		private string _myProgress;
		private int _myProgressPercentage;
		private bool _myIsDropped;
		private string _myImageName;
		private string _myReleaseDate;
		private string _myFirstWatchDate;
		private string _myLastWatchDate;

		public string MyType { get => _myType; set => _myType = value; }
		public string MyTitle { get => _myTitle; set => _myTitle = value; }
		public string MyAuthor { get => _myAuthor; set => _myAuthor = value; }
		public string MyStudio { get => _myStudio; set => _myStudio = value; }
		public bool MyIsStarted { get => _myIsStarted; set => _myIsStarted = value; }
		public bool MyIsFinished { get => _myIsFinished; set => _myIsFinished = value; }
		public int MyTotalRewatches { get => _myTotalRewatches; set => _myTotalRewatches = value; }
		public int MyRating { get => _myRating; set => _myRating = value; }
		public string MyProgress { get => _myProgress; set => _myProgress = value; }
		public int MyProgressPercentage { get => _myProgressPercentage; set => _myProgressPercentage = value; }
		public bool MyIsDropped { get => _myIsDropped; set => _myIsDropped = value; }
		public string MyImageName { get => _myImageName; set => _myImageName = value; }
		public string MyReleaseDate { get => _myReleaseDate; set => _myReleaseDate = value ; }
		public string MyFirstWatchDate { get => _myFirstWatchDate; set => _myFirstWatchDate = value; }
		public string MyLastWatchDate { get => _myLastWatchDate; set => _myLastWatchDate = value; }
	}
}
