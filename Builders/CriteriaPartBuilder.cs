using Scraper.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Scraper.Builders
{
    class CriteriaPartBuilder
    {
        private string regexp;
        private RegexOptions options;

        public CriteriaPartBuilder()
        {
            setDefaults();
        }

        private void setDefaults()
        {
            regexp = string.Empty;
            options = RegexOptions.None;
        }

        public CriteriaPartBuilder WithRegExp(string exp)
        {
            this.regexp = exp;
            return this;
        }

        public CriteriaPartBuilder WithOptions(RegexOptions options)
        {
            this.options = options;
            return this;
        }

        public CriteriaPart Build()
        {
            CriteriaPart part = new CriteriaPart();
            part.RegExp = regexp;
            part.Options = options;
            return part;
        }
    }
}
