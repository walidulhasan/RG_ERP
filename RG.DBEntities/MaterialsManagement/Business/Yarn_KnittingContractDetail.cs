using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Business
{
  public  class Yarn_KnittingContractDetail
    {
        [Key]
        public long YarnKNContractDetailID { get; set; }
        [ForeignKey("Yarn_KnittingContractMaster")]
        public long YarnKNContractID { get; set; }
        public int MRPItemCode { get; set; }
        public long AttributeInstanceID { get; set; }
        public int? YarnNO { get; set; }
        public double? Utilization { get; set; }

        public virtual Yarn_KnittingContractMaster Yarn_KnittingContractMaster { get; set; }
    }
}
