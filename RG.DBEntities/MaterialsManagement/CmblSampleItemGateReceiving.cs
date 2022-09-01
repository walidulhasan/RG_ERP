using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblSampleItemGateReceiving
    {
        [Key]
        public int SampleItemRecId { get; set; }
        public int SampleRecId { get; set; }
        public long SampleItemId { get; set; }
        public decimal ReceivedQuantity { get; set; }
    }
}
