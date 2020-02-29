using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaClass
{
    [Serializable]
    public abstract class Media
    {
        public string MyTitle { get; set; }
        public bool MyIsWatched { get; set; }
        public DateTime MyReleaseDate { get; set; }
        public DateTime MyFirstWatchDate { get; set; }
        public DateTime MyLastWatchDate { get; set; }
        public int MyTotalRewatches { get; set; }
        public int MyRating { get; set; }
    }
}
