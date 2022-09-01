using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class tbl_KnittingFabricProcessAssociation
    {
        [Key]
        public long AssociationId { get; set; }
        public long KnittingFabricId { get; set; }
        public long ProcessId { get; set; }

        public virtual tbl_KnittingAttribute_Setup Process { get; set; }
    }
}
