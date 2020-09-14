using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.Models.WorkingEntityOperations
{
    public interface IWorkingEntityOperationFactory
    {
        WorkingEntityOperation Create(Guid systemModuleId, Guid workingEntityId, string title);
    }
}
