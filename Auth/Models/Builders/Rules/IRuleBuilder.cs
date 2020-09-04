using Auth.DataLayer.Models;
using Auth.Web.Models.ViewModels.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Models.Builders.Rules
{
    public interface IRuleBuilder
    {
        RuleViewModel BuildViewModel(Rule rule);
    }
}
