using Auth.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DataLayer.ConfigurationModules.Common
{
    public class Catalog
    {
        public Guid WorkingEntityId { get; private set; }
        public List<CatalogOperation> Operations { get; private set; }

        public Catalog(Guid entityId, List<CatalogOperation> operations)
        {
            WorkingEntityId = entityId;
            Operations = operations;
        }
    }
}
