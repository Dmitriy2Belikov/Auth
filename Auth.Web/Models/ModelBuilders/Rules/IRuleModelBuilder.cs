using Auth.DataLayer.Models.Rules;
using Auth.Web.Models.ViewModels.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Models.ModelBuilders.Rules
{
    public interface IRuleModelBuilder
    {
        RuleViewModel BuildNew(Rule rule);
    }
}
