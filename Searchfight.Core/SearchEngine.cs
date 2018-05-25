using System;
using System.Linq;
using System.Net;
using DuckDuckGo.Net;
using Google.Apis.Customsearch.v1;

namespace Searchfight.Core
{
    public class SearchEngine
    {
        public decimal SearchOnDuckDuckGo(string keyword)
        {
            var search = new Search
            {
                NoHtml = false,
                NoRedirects = true,
                IsSecure = true,
                SkipDisambiguation = false,
                ApiClient = new HttpWebApi()
            };
            var result = search.Query(keyword, "Searchfight");
            return result.RelatedTopics.Count;
        }

        public long SearchOnGoogle(string keyword)
        {
            const string apiKey = "AIzaSyARjMGA_pLN1yvgZ0ULMjH57jC-qwcz4uQ";
            const string searchEngineId = "005290272738969375348:t877gwtrdk0";
            var customSearchService =
                new CustomsearchService(new Google.Apis.Services.BaseClientService.Initializer {ApiKey = apiKey});
            var listRequest = customSearchService.Cse.List(keyword);
            listRequest.Cx = searchEngineId;
            var search = listRequest.Execute();
            return search.SearchInformation.TotalResults ?? 0;
        }

        public decimal SearchOnBing(string keyword)
        {
            const string accountKey = "ls2YxwQCBAdTP/NprBJj7+4c1Ys+dFuenRDODWh/Q6s=";
            const string rootUrl = "https://api.datamarket.azure.com/Bing/Search";
            var bingContainer = new Bing.BingSearchContainer(new Uri(rootUrl))
            {
                Credentials = new NetworkCredential(accountKey, accountKey)
            };

            var webQuery = bingContainer.Web(keyword, Options: null, WebSearchOptions: null, Market: null, Adult: null,
                Latitude: null, Longitude: null, WebFileType: null);

            var webResults = webQuery.Execute();

            return webResults.Count();
        }
    }
}
