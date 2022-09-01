using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Business
{
  public partial  class Yarn_KnittingContractColor
    {
        public int ID { get; set; }
        [ForeignKey("Yarn_KnittingContractMaster")]
        public long YarnKNContractID { get; set; }
        public int? YarnNO { get; set; }
        public string Color { get; set; }
        public virtual Yarn_KnittingContractMaster Yarn_KnittingContractMaster { get; set; }
    }
}
