using Auth.DataLayer.Models.Permissions;
using Auth.Web.Models.ModelBuilders.Rules;
using Auth.Web.Models.ModelBuilders.WorkingEntityOperations;
using Auth.Web.Models.ViewModels.Pemissions;

namespace Auth.Web.Models.ModelBuilders.Permissions
{
    public class PermissionModelBuilder : IPermissionModelBuilder
    {
        private IWorkingEntityOperationModelBuilder _workingEntityOperationModelBuilder;
        private IRuleModelBuilder _ruleModelBuilder;


        public PermissionModelBuilder(IWorkingEntityOperationModelBuilder workingEntityOperationModelBuilder, IRuleModelBuilder ruleModelBuilder)
        {
            _workingEntityOperationModelBuilder = workingEntityOperationModelBuilder;
            _ruleModelBuilder = ruleModelBuilder;
        }

        public PermissionViewModel BuildNew(Permission permission)
        {
            var permmissionViewModel = new PermissionViewModel()
            {
                WorkingEntityOperation = _workingEntityOperationModelBuilder.BuildNew(permission.WorkingEntityOperation),
                Rule = _ruleModelBuilder.BuildNew(permission.Rule)
            };

            return permmissionViewModel;
        }
    }
}
