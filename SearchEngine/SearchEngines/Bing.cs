using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace Searchfight.SearchEngines
{
    public class Bing : BaseSearchEngine
    {
        public Bing()
        {
            this.Name = "Bing";
            this.Url = "https://bing.com/search?q=";
            this.Target = "span.sb_count";
        }

        public override ulong FormatResult(string result)
        {
            if (UInt64.TryParse(result.Split(" ")[0].Replace(".",""), out ulong TotalR))
            {
                return TotalR;
            }
            return TotalR;
        }


        public override string PerformSearch(string query)
        {
            var uriQuery = this.Url + Uri.EscapeDataString(query);

            ChromeOptions opts = new();
            //bing engine fails at some attempts when hiding the ui
            //opts.AddArgument("--headless");
            IWebDriver driver = new ChromeDriver(opts);
            driver.Navigate().GoToUrl(uriQuery);
            var _text = driver.FindElement(By.CssSelector(this.Target)).Text;
            driver.Close();
            driver.Dispose();
            return _text;
        }
        
    }
}
