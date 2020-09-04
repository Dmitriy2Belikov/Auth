using Auth.DataLayer.Models;
using Auth.Web.Models.Builders.WorkingEntityOperations;
using Auth.Web.Models.Builders.Rules;
using Auth.Web.Models.Forms.Permissions;
using Auth.Web.Models.ViewModels.Pemissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Models.Builders.Permissions
{
    public class PermissionBuilder : IPermissionBuilder
    {
        private IRuleBuilder _ruleBuilder;
        private IWorkingEntityOperationBuilder _operationBuilder;

        public PermissionBuilder(IRuleBuilder ruleBuilder, IWorkingEntityOperationBuilder operationBuilder)
        {
            _ruleBuilder = ruleBuilder;
            _operationBuilder = operationBuilder;
        }

        public Permission BuildNew(Role role, RegisterPermissionForm registerPermissionForm)
        {
            var permission = new Permission()
            {
                RoleId = role.Id,
                WorkingEntityOperationId = registerPermissionForm.WorkingEntityOperationId,
                RuleId = registerPermissionForm.RuleId
            };

            return permission;
        }
        public Permission BuildNew(Role role, EditPermissionForm editPermissionForm)
        {
            var permission = new Permission()
            {
                RoleId = role.Id,
                WorkingEntityOperationId = editPermissionForm.WorkingEntityOperationId,
                RuleId = editPermissionForm.RuleId
            };

            return permission;
        }

        public PermissionViewModel BuildViewModel(Permission permission)
        {
            var permissionViewModel = new PermissionViewModel()
            {
                Operation = _operationBuilder.BuildViewModel(permission.WorkingEntityOperation),
                Rule = _ruleBuilder.BuildViewModel(permission.Rule)
            };

            return permissionViewModel;
        }
    }
}
