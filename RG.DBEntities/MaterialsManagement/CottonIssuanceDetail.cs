using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CottonIssuanceDetail
    {
        [Key]
        public int Id { get; set; }
        public int IssuanceId { get; set; }
        public int OperationId { get; set; }
        public int? OrderId { get; set; }
        public int? CoaitemId { get; set; }

        public virtual CottonIssuanceMaster Issuance { get; set; }
    }
}
