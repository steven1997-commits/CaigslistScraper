using Scraper.Builders;
using Scraper.Data;
using System;
using System.Net;
using System.Text.RegularExpressions;
using Scraper.Workers;
using System.Collections.Generic;
using System.Linq;

namespace Scraper
{
    class Program
    {
        private const string Method = "search";

        static void Main(string[] args)
        {

            try
            {
                Console.WriteLine("Enter city:");
                string city = Console.ReadLine() ?? string.Empty;

                Console.WriteLine("Enter the CraigsList category:");
                string category = Console.ReadLine() ?? string.Empty;

                using (WebClient client = new WebClient())
                {
                    string content = client
                        .DownloadString($"http://{city.Replace(" ", string.Empty)}.craigslist.org/{Method}/{category}");
                    Criteria criteria = new CriteriaBuilder()
                        .WithData(content)
                        .WithRegExp(@"<a href=\""(.*?)\"" data-id=\""(.*?)\"" class=\""result-title hdrlnk\"">(.*?)</a>")
                        .WithOptions(RegexOptions.ExplicitCapture)
                        .WithPart(new CriteriaPartBuilder()
                            .WithRegExp(@">(.*?)</a>")
                            .WithOptions(RegexOptions.Singleline)
                            .Build())
                        .WithPart(new CriteriaPartBuilder()
                            .WithRegExp(@"href=\""(.*?)\""")
                            .WithOptions(RegexOptions.Singleline)
                            .Build())
                        .Build();

                    Scraper.Workers.Scraper scraper = new Scraper.Workers.Scraper();
                    List<string> results = scraper.Scrape(criteria);
                    if (results.Any())
                    {
                        foreach (string element in results)
                        {
                            Console.WriteLine(element);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No matches found.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
