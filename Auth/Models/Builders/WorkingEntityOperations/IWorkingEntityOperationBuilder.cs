using Auth.DataLayer.Models;
using Auth.Web.Models.ViewModels.WorkingEntityOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Models.Builders.WorkingEntityOperations
{
    public interface IWorkingEntityOperationBuilder
    {
        WorkingEntityOperationViewModel BuildViewModel(WorkingEntityOperation entityOperation);
    }
}
