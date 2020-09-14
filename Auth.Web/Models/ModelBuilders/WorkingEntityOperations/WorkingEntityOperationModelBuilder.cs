using Auth.DataLayer.Models.WorkingEntityOperations;
using Auth.Web.Models.ViewModels.WorkingEntityOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Models.ModelBuilders.WorkingEntityOperations
{
    public class WorkingEntityOperationModelBuilder : IWorkingEntityOperationModelBuilder
    {
        public WorkingEntityOperationViewModel BuildNew(WorkingEntityOperation workingEntityOperation)
        {
            var workingEnityOperationViewModel = new WorkingEntityOperationViewModel()
            {
                Id = workingEntityOperation.Id,
                Title = workingEntityOperation.Title,
                SystemModuleId = workingEntityOperation.SystemModuleId,
                WorkingEntityId = workingEntityOperation.WorkingEntityId
            };

            return workingEnityOperationViewModel;
        }
    }
}
