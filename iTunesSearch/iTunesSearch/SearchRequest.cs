using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace iTunesSearch
{
    public class SearchRequest
    {
        //ex.   itunes.apple.com/search?term=anime&media=podcast;
        private string _api = "https://itunes.apple.com/search";
        private Media _media = Media.All;

        public Dictionary<ParameterKey, string> Parameters { set; get; }

        public SearchRequest(Media media = Media.All)
        {
            _media = media;
            Parameters = new Dictionary<ParameterKey, string>();
        }

        public async Task<SearchResult> SearchAsync(string term)
        {
            return await SearchAsync(term, _media);
        }

        public async Task<SearchResult> SearchAsync(string term, Media media)
        {
            return await RequestAsync(_api + "?media=" + media.ToString().ToLowerInvariant() + "&term=" + term + LoadParameters());
        }

        private string LoadParameters()
        {
            StringBuilder pars = new StringBuilder();

            if (Parameters != null && Parameters.Count > 0)
            {
                foreach (var pair in Parameters)
                {
                    pars.Append("&" + pair.Key + "=" + pair.Value);
                }
            }

            return pars.ToString();
        }

        /// <summary>
        /// Responsável por realizar a requisição da Busca
        /// </summary>
        /// <param name="url"></param>
        /// <returns>Você deverá reimplementar esse método caso precise de um novo modo de Requisição HTTP</returns>
        protected virtual async Task<SearchResult> RequestAsync(string url)
        {
            using (HttpClient client = new HttpClient()) {
                // https://social.msdn.microsoft.com/Forums/en-US/fc086c69-7fd3-4ecb-80ad-66de089d8df4/httpclientgetstringasync-vs-httpclientgetasync?forum=winappswithcsharp
                var response = await client.GetAsync(url);
                string responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<SearchResult>(responseString);
            }
        }
    }

}

