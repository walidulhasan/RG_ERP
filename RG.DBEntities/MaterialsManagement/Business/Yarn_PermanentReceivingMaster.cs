using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Business
{
  public partial  class Yarn_PermanentReceivingMaster
    {
        [Key]
        public long YarnPermRecID { get; set; }
        [ForeignKey("Yarn_TemporaryReceivingMaster")]
        public long YarnTempRecID { get; set; }
        public long? yarnQtyInspID { get; set; }
        public long? yarnWeighingID { get; set; }
        public string YarnPermRecNo { get; set; }
        public DateTime? YarnPermRecDate { get; set; }
        public long? YarnPOID { get; set; }
        public long? CompanyID { get; set; }
        public int? BusinessID { get; set; }

        public virtual Yarn_TemporaryReceivingMaster Yarn_TemporaryReceivingMaster { get; set; }
    }
}
