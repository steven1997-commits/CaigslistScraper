using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Scraper.Data
{
    class CriteriaPart
    {
        public string RegExp { get; set; }
        public RegexOptions Options { get; set; }
    }
}
