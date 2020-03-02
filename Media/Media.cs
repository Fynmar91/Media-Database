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
        public string MyRating { get; set; }
        public int MyLastPage { get; set; }
        public int MyPercentageRead { get; set; }

        public DateTime MyReleaseDate { get; set; }
        public string MyReleaseDateS
        {
            get
            {
                if (MyReleaseDate != DateTime.MinValue)
                {

                    return MyReleaseDate.ToString("yyyy-MM-dd");
                }
                else
                {
                    return "";
                }
            }
        }

        public DateTime MyFirstWatchDate { get; set; }
        public string MyFirstWatchDateS
        {
            get
            {
                if (MyFirstWatchDate != DateTime.MinValue)
                {

                    return MyFirstWatchDate.ToString("yyyy-MM-dd");
                }
                else
                {
                    return "";
                }
            }
        }

        public DateTime MyLastWatchDate { get; set; }
        public string MyLastWatchDateS
        {
            get
            {
                if (MyLastWatchDate != DateTime.MinValue)
                {

                    return MyLastWatchDate.ToString("yyyy-MM-dd");
                }
                else
                {
                    return "";
                }
            }
        }
    }
}
