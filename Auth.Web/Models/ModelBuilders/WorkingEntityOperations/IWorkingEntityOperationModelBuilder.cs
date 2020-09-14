using Auth.DataLayer.Models.WorkingEntityOperations;
using Auth.Web.Models.ViewModels.WorkingEntityOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Models.ModelBuilders.WorkingEntityOperations
{
    public interface IWorkingEntityOperationModelBuilder
    {
        WorkingEntityOperationViewModel BuildNew(WorkingEntityOperation workingEntityOperation);
    }
}
