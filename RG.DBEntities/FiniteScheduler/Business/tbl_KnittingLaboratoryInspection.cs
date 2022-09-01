using RG.DBEntities.FiniteScheduler.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.FiniteScheduler.Business
{
   public class tbl_KnittingLaboratoryInspection
    {
        public long ID { get; set; }
        [ForeignKey("tbl_KnittingRolls")]
        public long RollID { get; set; }
        [ForeignKey("tbl_KnittingAttribute_Setup")]
        public long ProcessID { get; set; }
        public double RollProcessValue { get; set; }

        public virtual tbl_KnittingAttribute_Setup tbl_KnittingAttribute_Setup { get; set; }
        public virtual tbl_KnittingRolls tbl_KnittingRolls { get; set; }
    }
}
