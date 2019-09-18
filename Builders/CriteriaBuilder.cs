using Scraper.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Scraper.Builders
{
    class CriteriaBuilder
    {
        private string data;
        private string regexp;
        private RegexOptions options;
        private List<CriteriaPart> parts;

        public CriteriaBuilder()
        {
            setDefaults();
        }

        private void setDefaults()
        {
            data = string.Empty;
            regexp = string.Empty;
            options = RegexOptions.None;
            parts = new List<CriteriaPart>();
        }

        public CriteriaBuilder WithData(string data)
        {
            this.data = data;
            return this;
        }

        public CriteriaBuilder WithRegExp(string exp)
        {
            this.regexp = exp;
            return this;
        }

        public CriteriaBuilder WithOptions(RegexOptions options)
        {
            this.options = options;
            return this;
        }

        public CriteriaBuilder WithPart(CriteriaPart part)
        {
            this.parts.Add(part);
            return this;
        }

        public Criteria Build()
        {
            Criteria criteria = new Criteria();
            criteria.Data = data;
            criteria.RegExp = regexp;
            criteria.Options = options;
            criteria.Parts = parts;
            return criteria;
        }
    }
}
