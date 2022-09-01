using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.FiniteScheduler.Business
{
 public partial  class tbl_GateKnittingRolls//
    {
        [Key]
        public long RollID { get; set; }
        public string RollCode { get; set; }
        public long JobID { get; set; }
        public int Status { get; set; }
        public int QualityID { get; set; }
        public long ParentID { get; set; }
        [ForeignKey("tbl_knittingGate")]
        public long? KnittingGateID { get; set; }
        public virtual tbl_knittingGate tbl_knittingGate { get; set; }
    }
}
