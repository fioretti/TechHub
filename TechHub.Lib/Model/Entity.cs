using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHub.Lib.Core;

namespace TechHub.Lib.Model
{
    public class Entity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }


        public List<BrokenBusinessRule> GetBrokenRules()
        {
            List<BrokenBusinessRule> brokenRules = new List<BrokenBusinessRule>();

            if (String.IsNullOrEmpty(Type))
                brokenRules.Add(new BrokenBusinessRule("Type", "Type is required."));
            if (String.IsNullOrEmpty(Content))
                brokenRules.Add(new BrokenBusinessRule("Content", "Content is required."));

            return brokenRules;
        }

        private void AddToBrokenRulesList(List<BrokenBusinessRule> currentBrokenRules, List<BrokenBusinessRule> brokenRulesToAdd)
        {
            foreach (BrokenBusinessRule brokenRule in brokenRulesToAdd)
            {
                currentBrokenRules.Add(brokenRule);
            }
        }
    }
}
