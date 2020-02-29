using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaClass
{
    [Serializable]
    public class Book : Media
    {
        public string MyAuthor { get; set; }
        public int MyLastPage { get; set; }
        public int MyPercentageRead { get; set; }
    }
}
