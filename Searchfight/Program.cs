using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Net;
using System.Linq;

namespace Searchfight
{
    class Program
    {
        static void Main(string[] args)
        {
            //quick test && debugg
            //args = new string[] { "java", ".net", "java script" };
            if (args.Length >= 2)
            {
                var ObjSEF = new SearchEnginesFight(args, new SearchEngineFactory());
                try
                {
                    ObjSEF.StartFight();
                    ObjSEF.PrintResults();
                }
                catch (Exception e)
                {

                    Console.WriteLine("ERROR::::::::"+ e.ToString());
                }
                finally
                {
                    Console.WriteLine("==============================");
                }
            }
            else
            {
                Console.WriteLine("Can't arrange the match with less than 2 terms...");
            }
        }
    }
}
