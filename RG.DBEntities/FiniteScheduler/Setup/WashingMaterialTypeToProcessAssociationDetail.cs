using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public partial class WashingMaterialTypeToProcessAssociationDetail
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public int ProcessCodeId { get; set; }
        public int MaterialTypeId { get; set; }
    }
}
