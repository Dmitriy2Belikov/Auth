using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.Models.WorkingEntityOperations
{
    public class WorkingEntityOperationFactory : IWorkingEntityOperationFactory
    {
        public WorkingEntityOperation Create(Guid systemModuleId, Guid workingEntityId, string title)
        {
            var workingEnityOperation = new WorkingEntityOperation()
            {
                Id = Guid.NewGuid(),
                SystemModuleId = systemModuleId,
                Title = title,
                WorkingEntityId = workingEntityId
            };

            return workingEnityOperation;
        }
    }
}
