using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class FsStockTransaction
    {
        public long Id { get; set; }
        public int DocumentTypeId { get; set; }
        public int? DocumentNo { get; set; }
        public DateTime DocumentDate { get; set; }
        public int? FsReceivingLotsVariationId { get; set; }
        public int? FsRequirementSheetFabricsId { get; set; }
        public long AttributeinstanceId { get; set; }
        public double Quantity { get; set; }
        public int? NoOfRolls { get; set; }
        public double? ReceivedWidth { get; set; }
        public double? ReceivedGsm { get; set; }
        public int? TypeId { get; set; }
        public double? ProcessRate { get; set; }
    }
}
