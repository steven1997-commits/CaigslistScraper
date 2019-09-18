using Scraper.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace Scraper.Workers
{
    class Scraper
    {
        public List<string> Scrape(Criteria criteria)
        {
            List<string> results = new List<string>();

            MatchCollection matches = Regex.Matches(criteria.Data,criteria.RegExp,criteria.Options);

            foreach (Match match in matches)
            {
                if (!criteria.Parts.Any())
                {
                    results.Add(match.Groups[0].Value);
                } else
                {
                    foreach (CriteriaPart part in criteria.Parts)
                    {
                        Match matchedPart = Regex.Match(match.Groups[0].Value,part.RegExp,part.Options);

                        if (matchedPart.Success)
                        {
                            results.Add(matchedPart.Groups[1].Value);
                        }
                    }
                }
            }

            return results;
        }
    }
}
