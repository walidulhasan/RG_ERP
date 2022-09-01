using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Business
{
  public partial class Yarn_IssuanceToKnitterMaster:DefaultTableProperties
    {[Key]
        public long YarnKNIssID { get; set; }
        [ForeignKey("Yarn_KnittingContractMaster")]
        public long YarnKNContractID { get; set; }
        public DateTime? IssuanceDate { get; set; }
        public long? PickListID { get; set; }
        public long? SubPickListID { get; set; }
        public int Status { get; set; }
        public long? CompanyID { get; set; }
        public int? BusinessID { get; set; }
        public virtual Yarn_KnittingContractMaster Yarn_KnittingContractMaster { get; set; }
    }
}
