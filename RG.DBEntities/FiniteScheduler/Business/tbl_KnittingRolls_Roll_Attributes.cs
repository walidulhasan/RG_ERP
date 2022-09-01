using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public class tbl_KnittingRolls_Roll_Attributes
    {
        [Key]
        public long RollAttrID { get; set; }
        [ForeignKey("tbl_KnittingRolls")]
        public long? RollID { get; set; }
        public int? RollAttrSetupID { get; set; }
        public int? RollAttrValue { get; set; }
        public string RollAttrDesc { get; set; }
        public tbl_KnittingRolls tbl_KnittingRolls { get; set; }
    }
}
