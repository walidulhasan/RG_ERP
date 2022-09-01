using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public class Yarn_KnittingContractFlatBed
    {
        [ForeignKey("Yarn_KnittingContractMaster")]
        public long YarnKNContractID { get; set; }
        [Key]
        public int SizeID { get; set; }
        public double? Length { get; set; }
        public double? Width { get; set; }
        public int? Quantity { get; set; }
        public double? QuantityInKGs { get; set; }
        public double? RatePerPieces { get; set; }
        public double? Amount { get; set; }
        public int? BalanceQuantity { get; set; }
        public double? BalanceQuantityInKGs { get; set; }
        public double? SkgLength { get; set; }
        public double? SkgWidth { get; set; }
        public long? AttributeInstanceID { get; set; }

        public virtual Yarn_KnittingContractMaster Yarn_KnittingContractMaster { get; set; }
    }
}
