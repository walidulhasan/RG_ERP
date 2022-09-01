using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public class tbl_KnittingSubPickListDetail//
    {
        [Key]
        public long SubPickListDetailID { get; set; }
        [ForeignKey("tbl_KnittingSubPickListMaster")]
        public long SubPickListID { get; set; }
        public long AttributeInstanceID { get; set; }
        public double Quantity { get; set; }
        public int? UnitID { get; set; }
        public string BatchDescription { get; set; }
        public double? ReceivingQuantity { get; set; }
        public virtual tbl_KnittingSubPickListMaster tbl_KnittingSubPickListMaster { get; set; }
    }
}
