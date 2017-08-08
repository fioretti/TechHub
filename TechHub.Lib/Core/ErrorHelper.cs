using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechHub.Lib.Core
{
    public class ErrorHelper
    {
        public static string GetBrokenRulesToStringFor(List<BrokenBusinessRule> brokenRules)
        {
            StringBuilder sbBrokenRules = new StringBuilder();

            foreach (BrokenBusinessRule br in brokenRules)
            {
                sbBrokenRules.Append(br.Rule);
            }

            return sbBrokenRules.ToString();
        }
    }
}
