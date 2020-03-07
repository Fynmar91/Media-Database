using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaClass
{
	public class Media
	{
		public List<MediaProp> MyProperties { get; set; }

		public Media()
		{
			MyProperties = new List<MediaProp>();
			MyProperties.Add(MyType = new MediaPropText("", "Typ:"));
			MyProperties.Add(MyTitle = new MediaPropTitle("", "Titel:", false, 0));
			MyProperties.Add(MyAuthor = new MediaPropText("", "Autor:"));
			MyProperties.Add(MyStudio = new MediaPropText("", "Studio:"));
			MyProperties.Add(MyIsStarted = new MediaPropBool(false, "Angefangen:"));
			MyProperties.Add(MyIsFinished = new MediaPropBool(false, "Beendet:"));
			MyProperties.Add(MyTotalRewatches = new MediaPropInt(-1, "Wiederholungen:"));
			MyProperties.Add(MyRating = new MediaPropInt(-1, "Bewertung:"));
			MyProperties.Add(MyProgress = new MediaPropText("", "Fortschritt:"));
			MyProperties.Add(MyProgressPercentage = new MediaPropInt(-1, "Fortschritt%:"));
			MyProperties.Add(MyIsDropped = new MediaPropBool(false, "Dropped:"));
			MyProperties.Add(MyImageName = new MediaPropText("", "Bildername:"));
			MyProperties.Add(MyReleaseDate = new MediaPropDate("", "Erscheinungsjahr:", true));
			MyProperties.Add(MyFirstWatchDate = new MediaPropDate("", "Angefangen am:", false));
			MyProperties.Add(MyLastWatchDate = new MediaPropDate("", "Wiederholt am:", false));
		}

		public MediaPropText MyType { get; set; }
		public MediaPropTitle MyTitle { get; set; }
		public MediaPropText MyAuthor { get; set; }
		public MediaPropText MyStudio { get; set; }
		public MediaPropBool MyIsStarted { get; set; }
		public MediaPropBool MyIsFinished { get; set; }
		public MediaPropInt MyTotalRewatches { get; set; }
		public MediaPropInt MyRating { get; set; }
		public MediaPropText MyProgress { get; set; }
		public MediaPropInt MyProgressPercentage { get; set; }
		public MediaPropBool MyIsDropped { get; set; }
		public MediaPropText MyImageName { get; set; }
		public MediaPropDate MyReleaseDate { get; set; }
		public MediaPropDate MyFirstWatchDate { get; set; }
		public MediaPropDate MyLastWatchDate { get; set; }
	}
}
