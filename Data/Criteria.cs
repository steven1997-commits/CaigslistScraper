using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Scraper.Data
{
    class Criteria
    {
        public Criteria()
        {
            Parts = new List<CriteriaPart>();
        }

        public string Data { get; set; }
        public string RegExp { get; set; }
        public RegexOptions Options { get; set; }

        public List<CriteriaPart> Parts { get; set; }

    }
}
