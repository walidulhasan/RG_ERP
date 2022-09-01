using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblSampleItem
    {
        [Key]
        public long SampleItemId { get; set; }
        public long ItemId { get; set; }
        public long SampleId { get; set; }
        public int UnitId { get; set; }
        public long RequisitionDetailId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal Balance { get; set; }
        public string Remarks { get; set; }
        public int? CurrencyId { get; set; }
        public decimal? ConversionRate { get; set; }
        public int? DeliveryPoint { get; set; }
    }
}
