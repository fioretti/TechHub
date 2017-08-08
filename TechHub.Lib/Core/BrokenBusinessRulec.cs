using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechHub.Lib.Core
{
    public class BrokenBusinessRule
    {
        private string _property;
        public string Property
        {
            get { return _property; }
            set { _property = value; }
        }
        private string _rule;
        public string Rule
        {
            get { return _rule; }
            set { _rule = value; }
        }
        public BrokenBusinessRule(string property, string rule)
        {
            this._property = property;
            this._rule = rule;
        }
    }
}
