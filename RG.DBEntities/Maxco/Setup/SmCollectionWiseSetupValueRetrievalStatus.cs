using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class SmCollectionWiseSetupValueRetrievalStatus
    {
        public int Id { get; set; }
        public int CollectionId { get; set; }
        public int SetupTypeId { get; set; }
        public bool IsReset { get; set; }
    }
}
