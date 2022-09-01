using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CottonItemRequisitionRequirement
    {
        [Key]
        public long Irrid { get; set; }
        public long Irid { get; set; }
        public long AttributeInstanceId { get; set; }
        public int UserSelectedUnitId { get; set; }
        public double ReqQuantity { get; set; }
        public int Status { get; set; }
        public double ReducedQuantity { get; set; }
        public DateTime ReqDate { get; set; }
    }
}
