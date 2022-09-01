using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Business
{
   public class MM_ModelRequisitionRequirement
    {
        [Key]
        public int MRRID { get; set; }
        public int ObjectID { get; set; }
        public long AttributeInstanceID { get; set; }
        public int MRPItemCode { get; set; }
        public double Gross { get; set; }
        public int ModelID { get; set; }
        public int? ColorSetID { get; set; }
        public int? SizeSetID { get; set; }
        public int? AdditionalQuantity { get; set; }
        [ForeignKey("MM_ModelRequisitionMaster")]
        public int? MRMID { get; set; }
        public int? Status { get; set; }
        public int? MGRID { get; set; }
        public double Balance { get; set; }
        public string SpecialComments { get; set; }

        public virtual MM_ModelRequisitionMaster MM_ModelRequisitionMaster { get; set; }
    }
}
