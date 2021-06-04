using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searchfight
{
    public interface ISearchEngine
    {
        string GetName();
        string PerformSearch(string query);
        ulong FormatResult(string result);
    }
}
