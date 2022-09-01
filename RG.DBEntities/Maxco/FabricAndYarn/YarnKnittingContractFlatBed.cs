using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class YarnKnittingContractFlatBed
    {
       
        public long YarnKncontractId { get; set; }
        [Key]
        public int SizeId { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public int Quantity { get; set; }
        public int QuantityInKgs { get; set; }
        public double RatePerPieces { get; set; }
        public double Amount { get; set; }
        public int? BalanceQuantity { get; set; }
    }
}
