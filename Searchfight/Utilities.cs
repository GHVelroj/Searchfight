using System;
using System.Collections.Generic;

namespace Searchfight
{
    internal class Utilities
    {
        internal static IEnumerable<string> FormatTerms(string[] terms)
        {
            var result = new List<string>();
            var multipleW = false;
            var auxString = "";
            foreach (var item in terms)
            {
                if (item.StartsWith("\"") && multipleW == false)
                {
                    auxString += item[1..];
                    multipleW = true;
                    if (item.EndsWith("\""))
                    {
                        multipleW = false;
                        auxString = auxString[0..^1];
                    }
                }
                else if (multipleW == true && !item.EndsWith("\""))
                {
                    auxString += item;
                }
                else if (multipleW == true && item.EndsWith("\""))
                {
                    auxString += item[0..^1];
                    multipleW = false;
                }
                else if (multipleW == false)
                {
                    auxString = item;
                }

                if (auxString.Length > 0 && multipleW == false)
                {
                    result.Add(auxString);
                    auxString = "";
                }
            }

            return result.ToArray();
        }
    }
}