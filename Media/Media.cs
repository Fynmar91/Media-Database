using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaClass
{
    [Serializable]
    public class Media
    {
        public string MyType { get; set; }
        public string MyTitle { get; set; }
        public string MyAuthor { get; set; }
        public string MyStudio { get; set; }
        public bool MyIsStarted { get; set; }
        public bool MyIsFinished { get; set; }
        public int MyTotalRewatches { get; set; }
        public int MyRating { get; set; }
        public string MyProgress { get; set; }
        public int MyProgressPercentage { get; set; }
        public bool MyIsDropped { get; set; }

        public string MyReleaseDate { get; set; }
        public string MyFirstWatchDate { get; set; }
        public string MyLastWatchDate { get; set; }       
    }
}
