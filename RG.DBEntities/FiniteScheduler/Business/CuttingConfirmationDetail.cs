using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class CuttingConfirmationDetail
    {
        public int CuttingConfirmationDetailId { get; set; }
        public int CuttingConfirmationMasterId { get; set; }
        public int? AttributeInstanceId { get; set; }
        public int? ShellColorId { get; set; }
        public int? ColorId { get; set; }
        public int? SizeId { get; set; }
        public int? RequiredQuantity { get; set; }
        public int? ConfirmedQuantity { get; set; }
        public int? RejectedQuantity { get; set; }
        public long? RangeId { get; set; }
        public long? TrimId { get; set; }

        public virtual CuttingConfirmationMaster CuttingConfirmationMaster { get; set; }
    }
}
