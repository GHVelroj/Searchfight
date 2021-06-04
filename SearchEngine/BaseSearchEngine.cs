namespace Searchfight
{
    public abstract class BaseSearchEngine : ISearchEngine
    {
        protected string Name;
        protected string Url;
        protected string Target;

        public string GetName()
        {
            return this.Name;
        }

        //formatting the scraped result
        public abstract ulong FormatResult(string result);

        //basic scraping
        public abstract string PerformSearch(string query);
    }
}
