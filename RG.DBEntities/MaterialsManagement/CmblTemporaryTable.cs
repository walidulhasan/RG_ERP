using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CmblTemporaryTable
    {
        [Key]
        public string ItemDescription { get; set; }
        public string ItemName { get; set; }
        public string Unit { get; set; }
        public double? OBQuantity { get; set; }
        public double? ItemId { get; set; }
        public double? OBOf3May { get; set; }
        public string Unit1 { get; set; }
        public string F8 { get; set; }
    }
}
