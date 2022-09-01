using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public class MM_ModelGrossRequirement
    {
        [Key]
        public int MGRID { get; set; }
        public int ObjectID { get; set; }
        public long AttributeInstanceID { get; set; }
        public int MRPItemCode { get; set; }
        public double Gross { get; set; }
        public long ModelID { get; set; }
        public int? ColorSetID { get; set; }
        public int? SizeSetID { get; set; }
        public bool? Status { get; set; }
        public double? Usage { get; set; }
        public double? WastagePercent { get; set; }
        public double? WastageQuantity { get; set; }
        public int? GrossUnitID { get; set; }
    }
}
