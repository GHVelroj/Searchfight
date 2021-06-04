using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Searchfight.SearchEngines
{
    class Yahoo : BaseSearchEngine
    {
        public Yahoo()
        {
            this.Name = "Yahoo";
            this.Url = "https://search.yahoo.com/search?p=";
            this.Target = "div[class='compPagination']>span";
        }

        public override ulong FormatResult(string result)
        {
            if (UInt64.TryParse(result.Split(" ")[0].Replace(",",""), out ulong TotalR))
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
            var _text = driver.FindElement(By.CssSelector(this.Target)).Text;
            driver.Close();
            driver.Dispose();
            return _text;
        }
    }
}
