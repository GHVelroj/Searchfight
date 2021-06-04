using Searchfight.SearchEngines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searchfight
{
    public class SearchEngineFactory
    {
        private static IEnumerable<ISearchEngine> engines;

        public SearchEngineFactory()
        {
            LoadEngines();
        }

        private static void LoadEngines()
        {
            if (engines == null || !engines.Any())
            {
                var google = new Google();
                var bing = new Bing();
                var yahoo = new Yahoo();
                engines = new List<ISearchEngine> { google, bing, yahoo };
            }
        }

        public static IEnumerable<ISearchEngine> GetEngines()
        {
            return engines;
        }
    }
}
