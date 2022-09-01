using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public class tbl_KnittingRolls//
    {
        [Key]
        public long RollID { get; set; }
        public string RollCode { get; set; }
        public long JobID { get; set; }
        public int Status { get; set; }
        public int QualityID { get; set; }
        public long ParentID { get; set; }
        public long? GateReceivingID { get; set; }
        public int? MACHINE { get; set; }
        public string ShiftCode { get; set; }
        public DateTime RollCreationDate { get; set; }
        public string Yarnlot { get; set; }
        [NotMapped]
        public int RollNo { get; set; }
        //public long ConfirmationID { get; set; } not in db table
        public tbl_KnittingRolls_Roll_Attributes tbl_KnittingRolls_Roll_Attributes { get; set; }
        public tbl_KnittingStockTransaction tbl_KnittingStockTransaction { get; set; }
    }
}
