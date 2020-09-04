using Auth.DataLayer.Models;
using Auth.Web.Models.ViewModels.WorkingEntityOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Models.Builders.WorkingEntityOperations
{
    public class WorkingEntityOperationBuilder : IWorkingEntityOperationBuilder
    {
        public WorkingEntityOperationViewModel BuildViewModel(WorkingEntityOperation entityOperation)
        {
            var operationViewModel = new WorkingEntityOperationViewModel()
            {
                Id = entityOperation.Id,
                Title = entityOperation.Title,
                SystemModuleId = entityOperation.SystemModuleId,
                WorkingEntityId = entityOperation.WorkingEntityId
            };

            return operationViewModel;
        }
    }
}
