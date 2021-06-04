using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Searchfight.SearchEngines
{
    class Google : BaseSearchEngine
    {
        public Google()
        {
            this.Name = "Google";
            this.Url = "https://google.com/search?q=";
            this.Target = "result-stats";
        }

        public override ulong FormatResult(string result)
        {
            if (UInt64.TryParse(result.Split(" ")[2].Replace(",",""), out ulong TotalR))
            {
                return TotalR;
            }
            return TotalR;
        }

        public override string PerformSearch(string query)
        {
            var uriQuery = this.Url + Uri.EscapeDataString(query);

            ChromeOptions opts = new();
            opts.AddArgument("--headless");
            IWebDriver driver = new ChromeDriver(opts);
            driver.Navigate().GoToUrl(uriQuery);
            var _text = driver.FindElement(By.Id(this.Target)).Text;
            driver.Close();
            driver.Dispose();
            return _text;
        }
    }
}
