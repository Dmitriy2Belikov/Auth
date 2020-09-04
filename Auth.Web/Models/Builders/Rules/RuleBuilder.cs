using Auth.DataLayer.Models;
using Auth.Web.Models.ViewModels.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Models.Builders.Rules
{
    public class RuleBuilder : IRuleBuilder
    {
        public RuleViewModel BuildViewModel(Rule rule)
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
