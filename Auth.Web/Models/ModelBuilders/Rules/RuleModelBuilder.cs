using Auth.DataLayer.Models.Rules;
using Auth.Web.Models.ViewModels.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Models.ModelBuilders.Rules
{
    public class RuleModelBuilder : IRuleModelBuilder
    {
        public RuleViewModel BuildNew(Rule rule)
        {
            var ruleViewModel = new RuleViewModel()
            {
                Id = rule.Id,
                Name = rule.Name
            };

            return ruleViewModel;
        }
    }
}
