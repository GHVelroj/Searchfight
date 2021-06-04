using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searchfight
{
    class SearchEnginesFight
    {
        private readonly SearchEngineFactory _factory;
        private readonly IEnumerable<String> _terms;
        private readonly IList<FightResult> _fightResults;

        private class FightResult
        {
            public string EngineName { get; set; }
            public string Word { get; set; }
            public ulong Total { get; set; }
            public FightResult(string engine, string word, ulong total)
            {
                EngineName = engine;
                Word = word;
                Total = total;
            }
        }
        public SearchEnginesFight(string[] terms, SearchEngineFactory factory)
        {
            _terms = Utilities.FormatTerms(terms);
            _factory = factory;
            _fightResults = new List<FightResult>();
        }

        internal void StartFight()
        {
            foreach (var engine in SearchEngineFactory.GetEngines())
            {
                foreach (var term in _terms)
                {
                    string result = engine.PerformSearch(term);
                    ulong total = engine.FormatResult(result);
                    _fightResults.Add(new FightResult(engine.GetName(), term, total));
                }
            }

            PrintResults();
        }

        internal void PrintResults()
        {
            var listWords = _fightResults.Select(r => r.Word).Distinct();
            var listEngines = _fightResults.Select(r => r.EngineName).Distinct();
            Console.Clear();
            foreach (var word in listWords)
            {
                string line = word;
                foreach (var item in _fightResults.Where(r => r.Word == word))
                {
                    line += ": "+ item.EngineName + ": " + item.Total.ToString();
                }
                Console.WriteLine(line);
            }
            foreach (var engine in listEngines)
            {
                string line = engine + " winner: " + _fightResults.Where(r => r.EngineName == engine)
                                                                    .OrderByDescending(r => r.Total).First().Word;
                
                Console.WriteLine(line);
            }
            Console.WriteLine("Total winner: " + _fightResults.GroupBy(t => t.Word)
                                                               .Select(t => new
                                                               {   Lang = t.Key,
                                                                   Amount = t.Sum(ta => (decimal)ta.Total),
                                                               }).OrderByDescending(r => r.Amount).First().Lang);
        }
    }
}
