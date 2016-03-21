using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTunesSearch
{
    public class InjectedSearchRequest : SearchRequest
    {
        protected virtual async Task<SearchResult> RequestAsync(string url) {
            return null;
        }
    }
}
