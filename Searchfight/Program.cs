using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Searchfight
{
    public class Program
    {
        public static void Main(string[] keywords)
        {
            var engine = new Core.SearchEngine();
            decimal googleMaxValue = 0, duckduckgoMaxValue = 0, bingMaxValue = 0;
            string googleWinner = string.Empty, duckduckgoWinner = string.Empty, bingWinner = string.Empty;
            foreach (var keyword in keywords)
            {
                var google = engine.SearchOnGoogle(keyword);//limitless
                var duckDuckGo = engine.SearchOnDuckDuckGo(keyword);//maximum response 11 by default
                var bing = engine.SearchOnBing(keyword);//according to documentation bing maximum response is 50

                if (google > googleMaxValue)
                {
                    googleMaxValue = google;
                    googleWinner = keyword;
                }

                if (duckDuckGo > duckduckgoMaxValue)
                {
                    duckduckgoMaxValue = duckDuckGo;
                    duckduckgoWinner = keyword;
                }

                if (bing > bingMaxValue)
                {
                    bingMaxValue = bing;
                    bingWinner = keyword;
                }

                var partialResult = new StringBuilder();
                partialResult.AppendLine("==============================");
                partialResult.AppendLine($"{keyword} :");
                partialResult.AppendLine($"Google: {google}");
                partialResult.AppendLine($"DuckDuckGo: {duckDuckGo}");
                partialResult.AppendLine($"Bing: {bing}");
                partialResult.AppendLine("==============================");

                Console.WriteLine(partialResult);
            }

            var maxValues = new List<KeyValuePair<string, decimal>>
            {
                new KeyValuePair<string, decimal>(googleWinner, googleMaxValue),
                new KeyValuePair<string, decimal>(duckduckgoWinner, duckduckgoMaxValue),
                new KeyValuePair<string, decimal>(bingWinner, bingMaxValue)
            };

            var finalResult = new StringBuilder();
            finalResult.AppendLine("==============================");
            finalResult.AppendLine("Final Results...");
            finalResult.AppendLine($"Google Winner: {googleWinner}");
            finalResult.AppendLine($"DuckDuckGo Winner: {duckduckgoWinner}");
            finalResult.AppendLine($"Bing Winner: {bingWinner}");
            finalResult.AppendLine($"Total Winner: {maxValues.FirstOrDefault(a => a.Value == maxValues.Max(x => x.Value)).Key}");
            finalResult.AppendLine("==============================");
            Console.WriteLine(finalResult);
        }
    }
}
