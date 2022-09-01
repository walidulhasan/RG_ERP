using RG.DBEntities.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class YarnKnittingContractYarnSpecification
    {
        [Key]
        public long YarnId { get; set; }
        public long KnittingContractId { get; set; }
        public long? AttributeInstanceId { get; set; }
        public long? YarnNo { get; set; }
        public long? YarnCountId { get; set; }
        public long? YarnCompositionId { get; set; }
        public long? YarnQualityId { get; set; }
        public long? YarnDesignId { get; set; }
        public long? IsYarnDyed { get; set; }
        public double? Utilization { get; set; }
        public long? YarnDyeingId { get; set; }
        public long? FabricColorId { get; set; }
        public string PantoneNo { get; set; }

        public virtual Yarn_KnittingContractMaster Yarn_KnittingContractMaster { get; set; }
    }
}
