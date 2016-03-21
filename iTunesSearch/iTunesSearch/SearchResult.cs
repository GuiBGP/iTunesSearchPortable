using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTunesSearch
{
    public class SearchResult
    {
        public SearchResult()
        {
            Results = new List<ItemResult>();
        }

        public int ResultCount { set; get; }
        public List<ItemResult> Results { set; get; }
    }
}
